using System;
using System.ComponentModel;

namespace DNSFoxStrings
{
    public struct DB
    {
        public static readonly string Table_Settings = "appSettings";
        public static readonly string Table_SystemServers = "systemServers";
        public static readonly string Table_UserServers = "userServers";
        public static readonly string Table_ClientBlacklist = "clientBlacklist";
        public static readonly string Table_IncomingLog = "questionLog";
        public static readonly string Table_QuestionCount = "questionCount";
        public static readonly string Table_ConsoleLog = "consoleLog";
        public static readonly string Table_ResponseLog = "responseLog";
    }

    public struct Setting
    {
        public static readonly string Form_Console_Max_Lines = "formConsoleMaxLines";
        public static readonly string Form_Visibility = "formVisibility";
    }
}