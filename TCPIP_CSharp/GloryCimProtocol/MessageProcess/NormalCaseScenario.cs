using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryCimProtocol
{
    //EX
    //public class Normal
    //{
    //    public Normal()
    //    { Console.WriteLine("r"); }

    //    public static void test()
    //    {
    //        Console.WriteLine("r");
    //    }
    //}
    //EX
    //public struct equipmentInfo
    //{
    //    //EX
    //    //private string a;
    //    //public string A
    //    //{
    //    //    get { return a; }
    //    //    set { a =value;}
    //    //}

    //    //private string b= "심ㄴ===";

    //    //public string B { get;}
    //    //EX



    //};

    public class NormalCaseScenario : ReportMessage
    {
        private List<string> _sendlist = new List<string>();
        private List<string> _resultList = new List<string>();
        //  equipmentInfo _pt = new equipmentInfo();

        public static string cellId = "";
        public static string panerId ="";
        // private List<string> _infotList = new List<string>();

        public override List<string> ReportData(string eqpType, string command, string type, string[] data)
        {
            _sendlist.Clear();
            //byte stx = this.Stx;
            this.EqpType = eqpType;
            this.Command = command;
            this.Type = type;
            this.Data = (string[])data.Clone();

            _sendlist.Add(this.Stx.ToString());
            _sendlist.Add(this.EqpType);
            _sendlist.Add(this.Command);
            _sendlist.Add(this.Type);

            for (int count = 0; count < this.Data.Length; count++)
            {
                _sendlist.Add(this.Data[count]);
            }
            _sendlist.Add(this.Etx.ToString());

            return _sendlist;
        }

        /// <summary>
        ///  Barcode Read Report (Tray ID) 0401 ()
        /// </summary>
        /// <returns></returns>
        public List<string> BarcodeReadReport(string[] data)
        {
            return ReportData("E", "04", "01", data);
        }

        /// <summary>
        ///  Group Start Report 0411
        /// </summary>
        /// <returns></returns>
        public List<string> GroupStartReport(string[] data)
        {
            return ReportData("E", "04", "11", data);
        }

        /// <summary>
        ///  VCR Read Cell Report 0403
        /// </summary>
        /// <returns></returns>
        public List<string> VCRReadCellReport(string[] data)
        {
            return ReportData("E", "04", "03", data); ;
        }

        /// <summary>
        ///  Pannel Contact Report 0419
        /// </summary>
        /// <returns></returns>
        public List<string> PannelContactReport(string[] data)
        {
            return ReportData("E", "04", "19", data);
        }

        /// <summary>
        ///  Test Result Report 0607
        /// </summary>
        /// <returns></returns>
        public List<string> TestResultReport(string[] data)
        {
            return ReportData("P", "06", "07", data);
        }

        /// <summary>
        ///  Test Result Report 0607
        /// </summary>
        /// <returns></returns>
        public List<string> TestResultSend(string[] data)
        {
            return ReportData("E", "04", "07", data);
        }

        /// <summary>
        ///  Input Tray Report Report 0415
        /// </summary>
        /// <returns></returns>
        public List<string> InputTrayReportReport(string[] data)
        {
            return ReportData("E", "04", "15", data);
        }

        /// <summary>
        ///  Group End Report 0413
        /// </summary>
        /// <returns></returns>
        public List<string> GroupEndReport(string[] data)
        {
            return ReportData("E", "04", "13", data);
        }
        /// <summary>
        /// Client
        /// </summary>
        /// <param name="indexNumber"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<string> SetSendMessage(int indexNumber, string[] data)
        {
            List<string> resultData = null;

            switch (indexNumber)
            {
                case 0401:
                    resultData = BarcodeReadReport(data);
                    break;
                case 0411:
                    resultData = GroupStartReport(data);
                    break;
                case 0403:
                    resultData = VCRReadCellReport(data);
                    break;
                case 0407:
                    resultData = TestResultSend(data);
                    break;
                case 0419:
                    resultData = PannelContactReport(data);
                    break;
                case 0607:
                    resultData = TestResultReport(data);
                    break;
                case 0415:
                    resultData = InputTrayReportReport(data);
                    break;
                case 0413:
                    resultData = GroupEndReport(data);
                    break;
            }
            return resultData;
        }

        /// <summary>
        /// Server
        /// </summary>
        /// <param name="list"></param>
        /// <param name="otherPrm"></param>
        /// <returns></returns>
        public List<string> SendMessage(List<string> list, bool otherPrm)
        {
            _resultList.Clear();

            equipmentInfoCheck(list);
            string stx = list[0];
            string eqpType = list[1];
            string command = list[2];
            string type = list[3];
            string Acknowledge = "0";
            int lastIndex = list.Count - 1;
            string etx = list[lastIndex];

            // 판정에서 데이터 넘길때 
            string PanerID = cellId;

            if (otherPrm)
            {
                _resultList.Add(stx);
                _resultList.Add(eqpType);
                _resultList.Add(command);
                int returnType = int.Parse(type.ToString()) + 1;
                _resultList.Add(returnType.ToString());
                _resultList.Add(Acknowledge);

                if (type == "19")
                {
                    _resultList.Add(PanerID);

                }
                _resultList.Add(etx);
            }
            else
            {
                _resultList.Add(stx);
                _resultList.Add(eqpType);
                _resultList.Add(command);
                _resultList.Add(type);
                _resultList.Add(Acknowledge);
                _resultList.Add(etx);
            }
            return _resultList;
        }

        public void equipmentInfoCheck(List<string> list)
        {

            //string stx = list[0];
            //string eqpType = list[1];
            string command = list[2];
            string type = list[3];
            string Data_First = list[4];
            string Data_Second = list[5];
            string Data_Trifle = list[6];


            string sort = command + type;

            switch (int.Parse(sort))
            {
                case 403:

                    cellId = Data_Second;
                    break;

                case 419:
                    panerId = Data_First;
                    break;

            }

        }
        //    public void printdd()
        //    {
        //        Console.WriteLine("ttt");
        //    }
        //}
    }
}
