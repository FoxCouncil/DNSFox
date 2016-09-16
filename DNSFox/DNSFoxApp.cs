using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Deployment.Application;
using System.Reflection;
using DNSFox.Lang;
using DNSFox.Enums;
using DNSFoxStrings;

namespace DNSFox
{
    public class DNSFoxApp : ApplicationContext
    {
        #region Private Member Variables
        private static NotifyIcon trayIcon;
        private static SQLiteConnection SQL;
        private static DnsServer Server;
        //private static DnsClient UserClient;
        private static DnsClient OfficialClient;
        private static Thread FetchSystemServicesThread;
        private static Object threadLockObject = new Object();
        #endregion

        #region Public Member Variables
        public static new DNSFoxMainForm MainForm;
        public static DateTime? ServerStartedTime;
        public static bool ServerRunning = false;
        #endregion

        #region Events
        public static event ServerStateChangeDelegate ServerStateChange;
        public delegate void ServerStateChangeDelegate(object sender, ServerStateChangeEventArgs e);

        public static event SettingChangeDelegate SettingChangeEvent;
        public delegate void SettingChangeDelegate(object sender, SettingChangedEventArgs e);

        public static event QuestionReceivedDelegate QuestionReceived;
        public delegate void QuestionReceivedDelegate(object sender, QuestionReceivedEventArgs e);

        public static event ConsoleLogActivityDelegate ConsoleLogActivity;
        public delegate void ConsoleLogActivityDelegate(object sender, ConsoleActivityEventArgs e);
        #endregion

        #region Constructor
        private DNSFoxApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;

            InitTrayIcon();

            SQL = new SQLiteConnection("Data Source=" + Strings.DBFileName);
            SQL.Open();

            if (CheckDBIntegrity())
            {
                InitializeThreads();

                // Create Form
                MainForm = new DNSFoxMainForm();
            }
            else
            {
                MessageBox.Show("There was a somewhat serious error.\n\nThe database integrity was so bad, we just can't recover.\n\nYou've lost your settings and history.\n\nWe recommend you delete the FOXDns.db file and restart this app.\n\n\n\nGhost In The Machine Error: 420.", "Eh, Error.", MessageBoxButtons.OK);
                Application.Exit();
                return;
            }

            OfficialClient = new DnsClient(new List<IPAddress> { IPAddress.Parse("8.8.8.8"), IPAddress.Parse("8.8.4.4") }, 10);

            ServerStateChange += DNSFoxApp_ServerStateChange;

            if (Convert.ToBoolean(GetSetting(Setting.Form_Visibility)))
            {
                MainForm.Show();
            }
        }
        #endregion

        #region this Event Handlers
        private void DNSFoxApp_ServerStateChange(object sender, ServerStateChangeEventArgs e)
        {
            UpdateContextMenu();
        }
        #endregion

        #region TrayIcon Handlers
        private void rightClickExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rightClickStart(object sender, EventArgs e)
        {
            ServerStart();
        }

        private void rightClickStop(object sender, EventArgs e)
        {
            ServerStop();
        }

        void doubleClick(object sender, EventArgs e)
        {
            if (MainForm.Visible)
            {
                MainForm.Hide();
            }
            else
            {
                MainForm.Show();
            }
        }

        private void UpdateContextMenu()
        {
            trayIcon.ContextMenuStrip.Items[2].Text = "Server: " + (ServerRunning ? "Running" : "Stopped");

            trayIcon.ContextMenuStrip.Items[4].Enabled = !ServerRunning;
            trayIcon.ContextMenuStrip.Items[5].Enabled = ServerRunning;
        }
        #endregion

        #region Log Methods
        public static void ConsoleLog(ConsoleLogType type, string message)
        {
            DateTime timestamp = DateTime.Now;

            if (ConsoleLogActivity != null)
            {
                ConsoleLogActivity(null, new ConsoleActivityEventArgs
                {
                    Type = type,
                    Message = message,
                    Timestamp = timestamp
                });
            }

            using (SQLiteCommand consoleLogQuery = SQL.CreateCommand())
            {
                consoleLogQuery.CommandText = "INSERT INTO " + DB.Table_ConsoleLog + " VALUES(@timestamp, @type, @msg)";

                consoleLogQuery.Parameters.AddWithValue("@timestamp", TimeUtils.UnixTimestamp(timestamp));
                consoleLogQuery.Parameters.AddWithValue("@type", type);
                consoleLogQuery.Parameters.AddWithValue("@msg", message);
                consoleLogQuery.ExecuteNonQueryAsync();
            }
        }

        private static void LogQuestion(string name, IPAddress sourceAddress, RecordType recordType, RecordClass recordClass)
        {
            DateTime timestamp = DateTime.Now;

            if (QuestionReceived != null)
            {
                QuestionReceived(null, new QuestionReceivedEventArgs
                {
                    Name = name,
                    SourceAddress = sourceAddress,
                    Type = recordType,
                    Class = recordClass,
                    Timestamp = timestamp
                });
            }

            using (SQLiteCommand logQuestionQuery = SQL.CreateCommand())
            {
                logQuestionQuery.CommandText = "INSERT INTO " + DB.Table_IncomingLog + " VALUES(@ipaddress, @timestamp, @name, @type, @class)";

                logQuestionQuery.Parameters.AddWithValue("@timestamp", TimeUtils.UnixTimestamp(timestamp));
                logQuestionQuery.Parameters.AddWithValue("@ipaddress", sourceAddress.ToString());
                logQuestionQuery.Parameters.AddWithValue("@name", name);
                logQuestionQuery.Parameters.AddWithValue("@type", Enum.GetName(typeof(RecordType), recordType).ToString().ToUpper());
                logQuestionQuery.Parameters.AddWithValue("@class", Enum.GetName(typeof(RecordClass), recordClass));

                logQuestionQuery.ExecuteNonQueryAsync();
            }
        }
        #endregion

        #region DNS Server Handlers
        public static void ServerStart()
        {
            if (!ServerRunning)
            {
                // TODO: User settings storage of IP to listen too.
                // Locate Setting
                // Not Set;
                {
                    Server = new DnsServer(IPAddress.Any, 10, 10, ProcessQuery);
                }
                // if Set
                {
                    // Server = new DnsServer([User Selected IP Adress], 10, 10, ProcessQuery);
                }

                Server.Start();
                ServerRunning = true;
                ServerStartedTime = DateTime.Now;

                if (ServerStateChange != null)
                {
                    ServerStateChange(null, new ServerStateChangeEventArgs
                    {
                        State = ServerRunning
                    });
                }

                ConsoleLog(ConsoleLogType.INFO, Strings.ServerStartedMessage);
            }
        }

        public static void ServerStop()
        {
            if (ServerRunning)
            {
                Server.Stop();
                ServerRunning = false;
                ServerStartedTime = null;
                Server = null;

                if (ServerStateChange != null)
                {
                    ServerStateChange(null, new ServerStateChangeEventArgs
                    {
                        State = ServerRunning
                    });
                }

                ConsoleLog(ConsoleLogType.INFO, Strings.ServerStoppedMessage);
            }
        }
        #endregion

        #region Process Incoming Query
        private static DnsMessageBase ProcessQuery(DnsMessageBase message, IPAddress clientAddress, ProtocolType protocol)
        {
            // Todo: Check Realtime Blacklist

            message.IsQuery = false;

            DnsMessage query = message as DnsMessage;

            if ((query != null) && (query.Questions.Count == 1))
            {
                // send query to upstream server
                DnsQuestion question = query.Questions[0];

                IncrementUniqueRow(DB.Table_QuestionCount, question.Name);

                LogQuestion(question.Name, clientAddress, question.RecordType, question.RecordClass);

                ConsoleLog(ConsoleLogType.QUESTION, string.Format("{0}: {1}", clientAddress.ToString(), question.Name));

                DnsMessage answer = OfficialClient.Resolve(question.Name, question.RecordType, question.RecordClass);

                // if got an answer, copy it to the message sent to the client
                if (answer != null)
                {
                    foreach (DnsRecordBase record in (answer.AnswerRecords))
                    {
                        query.AnswerRecords.Add(record);
                    }
                    foreach (DnsRecordBase record in (answer.AdditionalRecords))
                    {
                        query.AnswerRecords.Add(record);
                    }

                    query.ReturnCode = ReturnCode.NoError;

                    return query;
                }
                else
                {
                    //MessageBox.Show();
                }
            }

            // Not a valid query or upstream server did not answer correct
            message.ReturnCode = ReturnCode.ServerFailure;

            return message;
        }
        #endregion

        #region Application Event Handlers
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            // TODO: Cleanup!
            trayIcon.Dispose();

            StopThreads();

            if (ServerRunning)
            {
                Server.Stop();
                Server = null;
            }

            SQL.Close();
        }
        #endregion

        #region Thread Methods
        private static void FetchSystemServers()
        {
            while (true)
            {
                List<IPAddress> systemServers = DnsClient.GetDnsServers();

                TruncateTable(DB.Table_SystemServers);

                foreach (IPAddress serverAddress in systemServers)
                {
                    using (SQLiteCommand insertQuery = SQL.CreateCommand())
                    {
                        insertQuery.CommandText = "INSERT INTO " + DB.Table_SystemServers + " VALUES (@ipAddress)";
                        insertQuery.Parameters.AddWithValue("@ipAddress", serverAddress.ToString());
                        insertQuery.ExecuteNonQueryAsync();
                    }
                }

                Thread.Sleep(10000);
            }
        }

        private static void StopThreads()
        {
            if (FetchSystemServicesThread.IsAlive)
            {
                FetchSystemServicesThread.Abort();
            }
        }
        #endregion

        #region Startup Methods
        private void InitTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Icon = DNSFox.Properties.Resources.DNSFoxIcon;
            trayIcon.Text = Application.ProductName;
            trayIcon.DoubleClick += doubleClick;
            
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("DNSFox Version " + CurrentVersion));
            trayIcon.ContextMenuStrip.Items[0].Enabled = false;

            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("Server: " + (ServerRunning ? "Running" : "Stopped")));
            trayIcon.ContextMenuStrip.Items[2].Enabled = false;

            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            trayIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("St&art", DNSFox.Properties.Resources.control_play, rightClickStart));

            trayIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Stop", DNSFox.Properties.Resources.control_stop, rightClickStop));
            trayIcon.ContextMenuStrip.Items[5].Enabled = false;

            trayIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            trayIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Exit", DNSFox.Properties.Resources.door_out, rightClickExit));

            trayIcon.Visible = true;
        }

        private void InitializeThreads()
        {
            if (FetchSystemServicesThread == null)
            {
                FetchSystemServicesThread = new Thread(new ThreadStart(FetchSystemServers));
                FetchSystemServicesThread.Name = "Get System DNS Thread";
                FetchSystemServicesThread.Start();
            }
        }

        private bool CheckDBIntegrity()
        {
            // TODO: Make this more robust
            if (!CheckTableExistance(DB.Table_ConsoleLog))
            {
                CreateTable(DB.Table_ConsoleLog, "timestamp integer, type, msg");
            }

            if (!CheckTableExistance(DB.Table_Settings))
            {
                CreateTable(DB.Table_Settings, "name unique, value");
            }

            if (!CheckTableExistance(DB.Table_SystemServers))
            {
                CreateTable(DB.Table_SystemServers, "address text");
            }

            if (!CheckTableExistance(DB.Table_IncomingLog))
            {
                CreateTable(DB.Table_IncomingLog, "timestamp integer, ip text, name text, type text, class text");
            }

            if (!CheckTableExistance(DB.Table_QuestionCount))
            {
                CreateTable(DB.Table_QuestionCount, "name unique, value integer");
            }
                       
            return true;
        }
        #endregion

        #region User Settings Methods
        /// <summary>
        /// Get a setting stored in the database.
        /// </summary>
        /// <param name="name">The Settings Key</param>
        /// <returns>The Setting Value</returns>
        public static object GetSetting(string name)
        {
            using (SQLiteCommand appSettingRetrieval = SQL.CreateCommand())
            {
                appSettingRetrieval.CommandText = "SELECT value FROM " + DB.Table_Settings + " WHERE name = @name";
                appSettingRetrieval.Parameters.AddWithValue("@name", name);

                SQLiteDataReader response = appSettingRetrieval.ExecuteReader();

                if (!response.HasRows)
                {
                    return null;
                }

                response.Read();

                return response.GetValue(0);
            }
        }

        /// <summary>
        /// Set a setting into the database.
        /// </summary>
        /// <param name="name">The Settings Key</param>
        /// <param name="value">The Settings Value to Store</param>
        /// <returns>True for a new setting being store, false for an update</returns>
        public static bool SetSetting(string name, object value)
        {
            bool isNewSetting = false;

            lock (threadLockObject)
            {
                using (SQLiteCommand appSettingStorageUpdate = SQL.CreateCommand())
                {
                    appSettingStorageUpdate.CommandText = "UPDATE " + DB.Table_Settings + " SET value = @value WHERE name = @name";
                    appSettingStorageUpdate.Parameters.AddWithValue("@value", value);
                    appSettingStorageUpdate.Parameters.AddWithValue("@name", name);
                    int changed = appSettingStorageUpdate.ExecuteNonQuery();

                    if (changed == 0)
                    {
                        using (SQLiteCommand appSettingStorageInsert = SQL.CreateCommand())
                        {
                            appSettingStorageInsert.CommandText = "INSERT INTO " + DB.Table_Settings + " VALUES(@name, @value)";
                            appSettingStorageInsert.Parameters.AddWithValue("@name", name);
                            appSettingStorageInsert.Parameters.AddWithValue("@value", value);
                            appSettingStorageInsert.ExecuteNonQueryAsync();
                        }

                        isNewSetting = true;
                    }
                }
            }

            if (SettingChangeEvent != null)
            {
                SettingChangeEvent(null, new SettingChangedEventArgs
                {
                    Name = name,
                    Value = value,
                    IsNew = isNewSetting
                });
            }

            return isNewSetting;
        }
        #endregion

        #region DB Methods
        /// <summary>
        /// This has got to get better!
        /// TODO: Make this better!
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="keyName"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private static void IncrementUniqueRow(string tableName, string keyName)
        {
            lock (threadLockObject)
            {
                int totalAffected = 0;

                using (SQLiteCommand updateRecord = SQL.CreateCommand())
                {
                    updateRecord.CommandText = "UPDATE " + tableName + " SET value = value + 1 WHERE name = @keyName";
                    updateRecord.Parameters.AddWithValue("@keyName", keyName);
                    totalAffected = updateRecord.ExecuteNonQuery();
                }

                if (totalAffected == 0)
                {
                    using (SQLiteCommand insertNewRecord = SQL.CreateCommand())
                    {
                        insertNewRecord.CommandText = "INSERT INTO " + tableName + " VALUES(@keyName, 1)";
                        insertNewRecord.Parameters.AddWithValue("@keyName", keyName);
                        insertNewRecord.ExecuteNonQuery();
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private static void CreateTable(string tableName, string columnData)
        {
            using (SQLiteCommand createTableCommand = SQL.CreateCommand())
            {
                createTableCommand.CommandText = "CREATE TABLE " + tableName + " (" + columnData + ")";
                createTableCommand.ExecuteNonQuery();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private static void TruncateTable(string tableName)
        {
            using (SQLiteCommand createTableCommand = SQL.CreateCommand())
            {
                createTableCommand.CommandText = "DELETE FROM " + tableName;
                createTableCommand.ExecuteNonQuery();
            }
        }

        internal static SQLiteDataReader QueryDatabase(string tableName, int total)
        {
            SQLiteDataReader result;

            lock (threadLockObject)
            {
                int idx = 0, totalRecords = 0;

                using (SQLiteDataReader data = DNSFoxApp.QueryDatabase("SELECT COUNT(*) FROM " + tableName))
                {
                    if (data.Read())
                    {
                        totalRecords = data.GetInt32(0);
                    }
                }

                if (totalRecords > total)
                {
                    idx = totalRecords - total;
                }

                SQLiteParameter[] parameters = new SQLiteParameter[] 
                { 
                    new SQLiteParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@idx",
                        Value = idx
                    },
                    new SQLiteParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@total",
                        Value = total
                    }
                };

                result = QueryDatabase("SELECT * FROM " + tableName + " LIMIT @idx, @total", parameters); 
            }

            return result;
        }

        internal static SQLiteDataReader QueryDatabase(string query)
        {
           return QueryDatabase(query, null);
        }

        internal static SQLiteDataReader QueryDatabase(string query, SQLiteParameter[] parameters)
        {
            SQLiteDataReader dataReaderCopy;

            using (SQLiteCommand simpleQuery = SQL.CreateCommand())
            {
                simpleQuery.CommandText = query;

                if (parameters != null)
                {
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        simpleQuery.Parameters.Add(parameter);
                    }
                }

                dataReaderCopy = simpleQuery.ExecuteReader();
            }

            return dataReaderCopy;
        }

        private static bool CheckTableExistance(string tableName)
        {
            using (SQLiteCommand checkForTable = SQL.CreateCommand())
            {
                checkForTable.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName;";
                checkForTable.Parameters.AddWithValue("@tableName", tableName);

                using (SQLiteDataReader checkTableResults = checkForTable.ExecuteReader())
                {
                    return checkTableResults.HasRows;
                }
            }
        }
        #endregion

        #region Utility Properties
        public string CurrentVersion
        {
            get
            {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        #endregion

        #region Main()
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new DNSFoxApp());
        }
        #endregion

        #region Temporary Shit That I need to refine to call myself a decent coder
        internal static UInt64 GetTotalQuestions()
        {
            using (SQLiteCommand getTotalQuestions = SQL.CreateCommand())
            {
                getTotalQuestions.CommandText = "SELECT SUM(value) FROM " + DB.Table_QuestionCount;

                SQLiteDataReader totalQuestionResult = getTotalQuestions.ExecuteReader();

                if (totalQuestionResult.Read() && !totalQuestionResult.IsDBNull(0))
                {
                    return Convert.ToUInt64(totalQuestionResult.GetInt64(0));
                }

                // I got nothing!
                return 0;
            }
        }

        internal static Dictionary<string, int> GetPopularDNSNames()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            using (SQLiteCommand getPopNames = SQL.CreateCommand())
            {
                getPopNames.CommandText = "SELECT * FROM " + DB.Table_QuestionCount + " ORDER BY value DESC LIMIT 10";
                SQLiteDataReader popNameResult = getPopNames.ExecuteReader();

                while (popNameResult.Read())
                {
                    output.Add(popNameResult.GetString(0), popNameResult.GetInt32(1));
                }
            }

            return output;
        }
        #endregion
    }
}
