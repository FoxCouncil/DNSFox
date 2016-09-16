using DNSFox.Enums;
using System;
using System.Net;

namespace DNSFox
{
    /// <summary>
    /// Server State Change Event Subclass
    /// </summary>
    public class ServerStateChangeEventArgs : EventArgs
    {
        /// <summary>
        /// The current server state.
        /// </summary>
        public bool State { get; set; }
    }

    /// <summary>
    /// Console Activity Event Subclass
    /// </summary>
    public class ConsoleActivityEventArgs : EventArgs
    {
        /// <summary>
        /// The DateTime the console activity was recorded
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The type of console message
        /// </summary>
        public ConsoleLogType Type { get; set; }

        /// <summary>
        /// The Console message
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Settings Changed Event Subclass
    /// </summary>
    public class SettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The name (key) of the setting that has changed
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the key (name) changed
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Is this the first time the setting has been saved?
        /// </summary>
        public bool IsNew { get; set; }
    }

    /// <summary>
    /// Question Received Event Subclass
    /// </summary>
    public class QuestionReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// The DNS question name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The IP Address initiating the question
        /// </summary>
        public IPAddress SourceAddress { get; set; }

        /// <summary>
        /// The DNS record type requested
        /// </summary>
        public RecordType Type { get; set; }

        /// <summary>
        /// The DNS record class requested
        /// </summary>
        public RecordClass Class { get; set; }

        /// <summary>
        /// The timestamp of the requested question
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}