using Communication.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIMTest.Model
{
    public class DataFomat
    {
        protected TCPClient _tcpClient = new TCPClient();

        protected void BarcodeReadReport()
        {
            string[] data = new string[5];

            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";

            _tcpClient.TCPClientStart("127.0.0.1", 2001, 0401, data);
        }

        protected void GroupStartReport()
        {
            string[] data = new string[5];
            // 20 20 5 5 20
            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";

            _tcpClient.TCPClientStart("192.168.101.170", 7000, 0411, data);
        }

        protected void VCRReadCellReport()
        {
            string[] data = new string[5];
            // 20 20 5 5 20
            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";

            _tcpClient.TCPClientStart("192.168.100.56", 7000, 0403, data);
        }

        protected void PannelContactReport()
        {
            string[] data = new string[3];
            // 20 20 2
            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "22";

            _tcpClient.TCPClientStart("192.168.100.56", 7000, 0419, data);
        }

        protected void TestResultReport()
        {
            string[] data = new string[5];

            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";

            _tcpClient.TCPClientStart("192.168.100.56", 7000, 0607, data);
        }

        protected void InputTrayReportReport()
        {
            string[] data = new string[6];
            // 20 20 20 20 2 2
            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "EEEEEFFFFFGGGGGHHHHH";
            data[3] = "EEEEEFFFFFGGGGGHHHHH";
            data[4] = "55";
            data[5] = "11";

            _tcpClient.TCPClientStart("192.168.100.56", 7000, 0415, data);
        }

        protected void GroupEndReport()
        {
            string[] data = new string[15];
            // 20 20 5 5 20 3 [20 2 3[20 2 2 2 2 10]]
            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";
            data[5] = "333";
            data[6] = "IIIIIJJJJJKKKKKLLLLL";
            data[7] = "22";
            data[8] = "333";
            data[9] = "IIIIIJJJJJKKKKKLLLLL";
            data[10] = "22";
            data[11] = "22";
            data[12] = "22";
            data[13] = "22";
            data[14] = "IIIIIJJJJJ";

            _tcpClient.TCPClientStart("192.168.100.56", 7000, 0413, data);
        }
        
    }
}
