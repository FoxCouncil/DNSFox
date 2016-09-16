using DNSFox.Enums;
using DNSFox.Lang;
using DNSFoxStrings;
using PresentationControls;
using System;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;

namespace DNSFox
{
    public partial class DNSFoxMainForm : Form
    {
        private static Object threadLockObject = new Object();
        private bool interfaceSetupRoutine = false;

        public DNSFoxMainForm()
        {
            // Do the wingoes stuff.
            InitializeComponent();

            // Setup The Gui Elements
            SetupGui();
            
            // Object Events
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            DNSFoxApp.ServerStateChange += DNSFoxApp_ServerStateChange;
            DNSFoxApp.QuestionReceived += DNSFoxApp_QuestionReceived;
            DNSFoxApp.ConsoleLogActivity += DNSFoxApp_ConsoleLogActivity;

            // Forum Control Events
            comboBoxIPListenerSelection.CheckBoxCheckedChanged += comboBoxIPListenerSelection_CheckBoxCheckedChanged;

            // Do sexy fox stuff...
            PopulateSystemIPComboBox();
        }

        #region UI Setup Methods
        private void SetupGui()
        {
            SetupConsoleGui();
        }

        private void SetupConsoleGui()
        {
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_red);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_yellow);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_blue);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_orange);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_green);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_purple);
            imageListConsoleLogType.Images.Add(Properties.Resources.flag_pink);

            string[] logTypes = Enum.GetNames(typeof(ConsoleLogType));

            int idx = 0;

            foreach (string logType in logTypes)
            {
                string logTypeButtonSettingKey = StringUtils.UppercaseFirst(logType) + "ConsoleLogTypeChecked";
                object buttonSetting = DNSFoxApp.GetSetting(logTypeButtonSettingKey);

                toolStripConsole.Items.Insert(idx, new ToolStripButton
                {
                    Name = "consoleLogToolStripButton" + logType,
                    Text = StringUtils.UppercaseFirst(logType),
                    Image = imageListConsoleLogType.Images[idx],
                    CheckOnClick = true,
                    Checked = buttonSetting != null ? Convert.ToBoolean(buttonSetting) : true,
                    Tag = (ConsoleLogType)Enum.Parse(typeof(ConsoleLogType), logType),
                    Margin = new Padding((idx == 0) ? 0 : 3, 1, 0, 1),
                });

                toolStripConsole.Items[idx].Click += DNSFoxMainForm_ConsoleLogTypeButtonClick;

                idx++;
            }
        }
        #endregion

        #region Console Tab

        #region - Form Event Handlers
        void DNSFoxMainForm_ConsoleLogTypeButtonClick(object sender, EventArgs e)
        {
            ToolStripButton consoleLogTypeButton = (ToolStripButton)sender;
            string logTypeButtonSettingKey = consoleLogTypeButton.Text + "ConsoleLogTypeChecked";
            DNSFoxApp.SetSetting(logTypeButtonSettingKey, consoleLogTypeButton.Checked);
            RefreshConsoleLog();
        }
        #endregion

        #region - DNSFoxApp Event Handlers
        void DNSFoxApp_ConsoleLogActivity(object sender, ConsoleActivityEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { DNSFoxApp_ConsoleLogActivity(sender, e); });
                return;
            }

            lock (threadLockObject)
            {
                listBoxConsole.Items.Add(new ConsoleLogItem
                {
                    Timestamp = e.Timestamp,
                    Type = e.Type,
                    Message = e.Message
                });

                int visibleItems = listBoxConsole.ClientSize.Height / listBoxConsole.ItemHeight;
                listBoxConsole.TopIndex = Math.Max(listBoxConsole.Items.Count - visibleItems + 1, 0);
            }
        }
        #endregion

        #endregion

        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            comboBoxIPListenerSelection.BeginInvoke(new MethodInvoker(PopulateSystemIPComboBox));
        }

        private void PopulateSystemIPComboBox()
        {
            comboBoxIPListenerSelection.Items.Clear();

            comboBoxIPListenerSelection.Items.Add(Strings.AllNetworkInterfaces);

            // Get Default IP(s) to listen on.
            comboBoxIPListenerSelection.CheckBoxItems[Strings.AllNetworkInterfaces].CheckState = CheckState.Checked;

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipProps = netInterface.GetIPProperties();

                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                {
                    comboBoxIPListenerSelection.Items.Add(addr.Address.ToString());
                }
            }
        }

        private void DNSFoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_QueryCount.Text = DNSFoxApp.GetTotalQuestions().ToString("N0");

            if (DNSFoxApp.ServerRunning)
            {
                toolStripStatusLabel_ServerTime.Text = TimeUtils.StringfyDateTimeDifference(DNSFoxApp.ServerStartedTime);
            }
            else
            {
                toolStripStatusLabel_ServerTime.Text = DateTime.Now.ToString();
            }

            //Dictionary<string, int> popQuestions = DNSFoxApp.GetPopularDNSNames();

            //popNameListbox.Items.Clear();

            //foreach (KeyValuePair<string, int> entry in popQuestions)
            //{
            //    popNameListbox.Items.Add(entry.Key + ": " + entry.Value.ToString());
            //}
        }

        private void DNSFoxMainForm_VisibleChanged(object sender, EventArgs e)
        {
            DNSFoxApp.SetSetting(Setting.Form_Visibility, this.Visible);

            if (this.Visible)
            {
                if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
                {
                    typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewIncoming, new object[] { true });
                }

                updateTimer.Start();
            }
            else
            {
                updateTimer.Stop();
                DNSFoxApp.ServerStateChange -= DNSFoxApp_ServerStateChange;
            }
        }

        void DNSFoxApp_QuestionReceived(object sender, QuestionReceivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { DNSFoxApp_QuestionReceived(sender, e); });
                return;
            }

            InsertIcomingRow(e.SourceAddress, e.Class, e.Type, (e.Name.ToUpper() + "."), e.Timestamp);
        }

        private void InsertIcomingRow(IPAddress sourceAddress, RecordClass recordClass, RecordType recordType, string name, DateTime timestamp)
        {
            dataGridViewIncoming.Rows.Insert(0, sourceAddress.ToString(), recordClass.ToString().ToUpper(), recordType.ToString().ToUpper(), name, timestamp);

            if (dataGridViewIncoming.Rows.Count >= 101)
            {
                dataGridViewIncoming.Rows.RemoveAt(dataGridViewIncoming.Rows[dataGridViewIncoming.Rows.GetLastRow(0)].Index);
            }
        }

        void comboBoxIPListenerSelection_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (!interfaceSetupRoutine)
            {
                int totalSelected = comboBoxIPListenerSelection.CheckBoxItems.Count(item => item.Checked);
                
                CheckBoxComboBox listBox = comboBoxIPListenerSelection;

                if (totalSelected > 1 && listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Checked)
                {
                    interfaceSetupRoutine = true;

                    listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Enabled =
                        listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Checked = false;

                }
                else if (totalSelected == 0 || listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Checked)
                {
                    interfaceSetupRoutine = true;

                    listBox.CheckBoxItems.ForEach(delegate(CheckBoxComboBoxItem item) { item.Checked = false; });
                    listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Enabled =
                        listBox.CheckBoxItems[Strings.AllNetworkInterfaces].Checked = true;
                }

                DNSFoxApp.SetSetting("interfaceSelection", listBox.Text);

                interfaceSetupRoutine = false;
            }
        }

        void DNSFoxApp_ServerStateChange(object sender, ServerStateChangeEventArgs e)
        {
            this.Text = string.Format("{0} - {1}", Strings.ProgramName, e.State ? Strings.StatusOnlineMessage : Strings.StatusOfflineMessage);

            comboBoxIPListenerSelection.Enabled = !e.State;

            labelServerStatus.Text = e.State ? Strings.StatusOnlineMessage : Strings.StatusOfflineMessage;
            labelServerStatus.ForeColor = e.State ? Color.DarkGreen : Color.DarkRed;

            statusStrip.BackColor = e.State ? Color.MediumSpringGreen : Color.LightCoral;

            buttonStartServer.Enabled = !e.State;
            buttonStopServer.Enabled = e.State;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            DNSFoxApp.ServerStart();
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            DNSFoxApp.ServerStop();
        }

        private void toolStripButtonConsoleRefresh_Click(object sender, EventArgs e)
        {
            RefreshConsoleLog();
        }

        private void RefreshConsoleLog()
        {
            lock (threadLockObject)
            {
                using (SQLiteDataReader data = DNSFoxApp.QueryDatabase(DB.Table_ConsoleLog, 100))
                {
                    listBoxConsole.Items.Clear();

                    while (data.Read())
                    {
                        string buttonName = "consoleLogToolStripButton" + Enum.GetName(typeof(ConsoleLogType), data.GetInt32(1));
                        if (((ToolStripButton)toolStripConsole.Items[buttonName]).Checked)
                        {
                            listBoxConsole.Items.Add(new ConsoleLogItem
                            {
                                Timestamp = TimeUtils.FromUnixTimestamp(data.GetDouble(0)).ToLocalTime(),
                                Type = (ConsoleLogType)data.GetInt32(1),
                                Message = data.GetString(2)
                            });
                        }
                    }
                }

                int visibleItems = listBoxConsole.ClientSize.Height / listBoxConsole.ItemHeight;
                listBoxConsole.TopIndex = Math.Max(listBoxConsole.Items.Count - visibleItems + 1, 0);
            }
        }

        private void RefreshIncomingLog()
        {
            lock (threadLockObject)
            {
                dataGridViewIncoming.Rows.Clear();

                using (SQLiteDataReader data = DNSFoxApp.QueryDatabase(DB.Table_IncomingLog, 100))
                {

                }
            }
        }

        private void tab_Console_Enter(object sender, EventArgs e)
        {
            RefreshConsoleLog();
        }

        private void tab_Incoming_Enter(object sender, EventArgs e)
        {
            RefreshIncomingLog();
        }
    }
}
