using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryCimProtocol
{

    public class MessageScenario : ReportMessage
    {
        private List<string> sendlist = new List<string>();

        public override List<string> ReportData(string eqpType, string command, string type, string[] data)
        {
            sendlist.Clear();
            //byte stx = this.Stx;
            this.EqpType = eqpType;
            this.Command = command;
            this.Type = type;

            this.Data = (string[])data.Clone();

            sendlist.Add(this.Stx.ToString());
            sendlist.Add(this.EqpType);
            sendlist.Add(this.Command);
            sendlist.Add(this.Type);

            for (int count = 0; count < this.Data.Length; count++)
            {
                sendlist.Add(this.Data[count]);
            }
            sendlist.Add(this.Etx.ToString());

            return sendlist;
        }

     
        ///// <summary>
        /////  EmptyTray Use Event Report 0423
        ///// </summary>
        ///// <returns></returns>
        //public string EmptyTrayUseEventReport(string[] data)
        //{
        //    return ReportData("E", "04", "23", data);
        //}

        ///// <summary>
        /////  Port Change Event Report 0421
        ///// </summary>
        ///// <returns></returns>
        //public string PortChangeEventReport(string[] data)
        //{
        //    return ReportData("E", "04", "21", data);
        //}

        ///// <summary>
        /////  EQP State Report 1001
        ///// </summary>
        ///// <returns></returns>
        //public string EQPStateReport(string[] data)
        //{
        //    return ReportData("E", "10", "01", data);
        //}

        ///// <summary>
        /////  EQP Alarm Report 0501
        ///// </summary>
        ///// <returns></returns>
        ///// 
        //public string EQPAlarmReport(string[] data)
        //{
        //    return ReportData("E", "05", "01", data);
        //}

        ///// <summary>
        /////  OpCallSend 0609
        ///// </summary>
        ///// <returns></returns>
        ///// 
        //public string OpCallSend(string[] data)
        //{
        //    return ReportData("E", "06", "09", data);
        //}

        ///// <summary>
        /////  Panel Scrap Report 0417
        ///// </summary>
        ///// <returns></returns>
        ///// 
        //public string PanelScrapReport(string[] data)
        //{
        //    return ReportData("E", "04", "17", data);
        //}
    }
}
