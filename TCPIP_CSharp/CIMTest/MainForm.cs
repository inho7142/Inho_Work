using System;
using System.Windows.Forms;
using System.Threading;

using Communication.TCP;
using Communication.IPC;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using Common;

namespace CIMTest
{
    public partial class MainForm : Form
    {
        #region C++ DLL 사용
        //[DllImport("ProcDataDLL")]
        //public static extern CProcData1`;
        #endregion 

        #region Private Variable
        private Model.DataFomatHandler dataFomatHandler = new Model.DataFomatHandler();
        private TCPServer _tcpServer = new TCPServer();
        private Thread _Serverthread = null;
        private const int _threadJoinTimeOut = 2000;
        //-------------------------------------------------
        // 공유메모리 관련 변수 
        //private ReadShardMemory _readShardMemory = null;
        //private WriteShardMemory _writeShardMemory = null;
        //private string _mmfServiceName = "MaruServ";
        //-------------------------------------------------
        #endregion

        #region Constructor / Destructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //  - TCP Thread 
            Initialize();
            //  - Interface Class Library 사용 
            //iCommon icommon = new Common.Common();
            //icommon.ServerCreate(2001, false);
        }

        /// <summary>
        /// Variable Initalize 
        /// </summary>
        private void Initialize()
        {
            if (_Serverthread == null)
            {
                _Serverthread = new Thread(ServerThraedStart);
                _Serverthread.Start();
            }
            #region 공유메모리 관련
            //if (_writeShardMemory == null)
            //{
            //    _writeShardMemory = new WriteShardMemory();
            //    long testt = GetSize();
            //    Byte[] test = _writeShardMemory.ReadMMFAllBytes(_mmfServiceName);
            //    DataSet ds = _writeShardMemory.ReadFromMemoryMaptt(_mmfServiceName);
            //    var obj = ByteArrayToObject(test);
            //}

            //if (_readShardMemory == null)
            //{
            //    _readShardMemory = new ReadShardMemory();
            //}
            #endregion
        }
        #region Shared Memory (MMF)
        //public object ByteArrayToObject(byte[] buffer)
        //{
        //    object obj = null;
        //    try
        //    {
        //        BinaryFormatter binaryFormatter = new BinaryFormatter(); // Create new BinaryFormatter
        //        MemoryStream memoryStream = new MemoryStream(buffer);    // Convert buffer to memorystream
        //       //obj = binaryFormatter.Deserialize(memoryStream);        // Deserialize stream to an object
        //       var tesy = binaryFormatter.Deserialize(memoryStream);     // Deserialize stream to an object
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {

        //    }

        //    return obj;
        //}
        #endregion

        #endregion

        #region TCP Server Thread : Constructor / Destructor
        /// <summary>
        /// Server Thread Start
        /// </summary>
        private void ServerThraedStart()
        {
            _tcpServer.TCPServerStart(17000, false);
            _tcpServer.AysncEchoServer();

            //GetServerData();
        }
     
        private void GetServerData()
        {
            while (true)
            {
                //if (_tcpServer._isReceiveCompleted)
                {
                    var resultData = _tcpServer.ReceiveDataSaving();

                    for (int i = 0; i < resultData.Count; i++)
                    {
                        Console.WriteLine(resultData[i].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Thread Object 소멸
        /// </summary>
        private void ThreadDestruction()
        {
            if (_Serverthread != null)
            {
                _Serverthread.Join(_threadJoinTimeOut);
                _Serverthread = null;
            }
        }
        #endregion

        #region Button Click Event
        private void SendBarcodeReadReport_Click(object sender, EventArgs e)
        {
            string[] data = new string[5];

            data[0] = "AAAAABBBBBCCCCCDDDDD";
            data[1] = "EEEEEFFFFFGGGGGHHHHH";
            data[2] = "55555";
            data[3] = "11111";
            data[4] = "IIIIIJJJJJKKKKKLLLLL";

            iCommon icommon = new Common.Common();
            var arraySize = icommon.ClientCreate("127.0.0.1", 17000, 0419, data);
            string[] arrayData = new string[arraySize.Length];

            //dataFomatHandler.SendBarcodeReadReport();
        }

        private void SendGroupStartReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendGroupStartReport();
        }

        private void SendVCRReadCellReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendVCRReadCellReport();
        }

        private void SendPannelContactReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendPannelContactReport();
        }

        private void SendTestResultReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendTestResultReport();
        }

        private void SendInputTrayReportReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendInputTrayReportReport();
        }

        private void SendGroupEndReport_Click(object sender, EventArgs e)
        {
            dataFomatHandler.SendGroupEndReport();
        }
        #endregion

        #region UI Windows Event
        /// <summary>
        /// 프로그램 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadDestruction();
        }
        #endregion
    }
}
