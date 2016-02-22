using System;
using System.Text;
using System.Diagnostics;

namespace Tizen
{
    /// <summary>
    /// Directs tracing or debugging output to Tizen logging system.
    /// </summary>
    public class LogTraceListener : TraceListener
    {
        private string tagName = null;
        private StringBuilder buf = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the LogTraceListener class, using the specfied tag name of the logging system.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        public LogTraceListener(string tag) : base("DLOG")
        {
            this.tagName = tag;
        }

        /// <summary>
        /// The tag name of the log message.
        /// </summary>
        public string Tag
        {
            get { return tagName; }
            set { tagName = value; }
        }

        private void WriteImpl(string message)
        {
            if (NeedIndent)
            {
                WriteIndent();
            }
            buf.Append(message);
        }

        /// <summary>
        /// Writes an error message to the logging system.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        public override void Fail(string message)
        {
            Fail(message, null);
        }

        /// <summary>
        /// Writes an error message and a detailed error message to the logging system.
        /// </summary>
        /// <param name="message">The error message to print.</param>
        /// <param name="detailMessage">The detailed error message to print.</param>
        public override void Fail(string message, string detailMessage)
        {
            StringBuilder failBuf = new StringBuilder();
            failBuf.Append("Fail: ");
            failBuf.Append(message);
            if (!String.IsNullOrEmpty(detailMessage))
            {
                failBuf.Append(" ");
                failBuf.Append(detailMessage);
            }
            Log.Error(tagName, failBuf.ToString(), null);
        }

        /// <summary>
        /// Writes a log message to the logging system.
        /// </summary>
        /// <param name="message">The log message to print.</param>
        public override void Write(string message)
        {
            WriteImpl(message);
        }

        /// <summary>
        /// Writes a log message followed by the current line terminator to the logging system.
        /// </summary>
        /// <param name="message">The log message to print.</param>
        public override void WriteLine(string message)
        {
            WriteImpl(message + Environment.NewLine);
            NeedIndent = true;
            Flush();
        }

        /// <summary>
        /// Causes buffered data to be written to the logging system.
        /// </summary>
        public override void Flush()
        {
            Log.Debug(tagName, buf.ToString(), null);
            buf.Clear();
        }
    }
}
