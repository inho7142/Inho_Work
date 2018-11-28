using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryCimProtocol
{
    public abstract class ReportMessage
    {
        private byte stx = 0x02;
        protected byte Stx
        {
            get { return stx; }
            set { stx = value; }
        }

        private string eqpType;
        protected string EqpType
        {
            get { return eqpType; }
            set { eqpType = value; }
        }

        private string command;
        protected string Command
        {
            get { return command; }
            set { command = value; }
        }

        private string type;
        protected string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string[] data;
        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        private byte etx = 0x03;
        protected byte Etx
        {
            get { return etx; }
            set { etx = value; }
        }

        public abstract List<string> ReportData(string eqpType, string command, string type, string[] data);
    }

    public class  AcknowledgeMessage
    {
        protected byte stx { get; set; }
        protected byte eqpType { get; set; }
        protected byte[] Command { get; set; }
        protected byte type { get; set; }
        protected byte Acknowledge { get; set; }
        protected byte etx { get; set; }
    }
}
