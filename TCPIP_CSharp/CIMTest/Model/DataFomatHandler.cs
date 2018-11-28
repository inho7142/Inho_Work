using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIMTest.Model
{
    public class DataFomatHandler : DataFomat
    {
        public void SendBarcodeReadReport()
        {
            this.BarcodeReadReport();
        }

        public void SendGroupStartReport()
        {
            this.GroupStartReport();
        }

        public void SendVCRReadCellReport()
        {
            this.VCRReadCellReport();
        }

        public void SendPannelContactReport()
        {
            this.PannelContactReport();
        }

        public void SendTestResultReport()
        {
            this.TestResultReport();
        }

        public void SendInputTrayReportReport()
        {
            this.InputTrayReportReport();
        }

        public void SendGroupEndReport()
        {
            this.GroupEndReport();
        }
    }
}
