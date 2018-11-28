using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using GloryCimProtocol;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication.TCP
{

    public class TCPClient
    {
        #region Private Variable
        private NormalCaseScenario _normalCaseScenario = new NormalCaseScenario();
        private List<string> _receiveList = new List<string>();
        private BinaryFormatter _bin = new BinaryFormatter();
        private TcpClient _tc = null;
        private NetworkStream _stream = null;
        private int timeOutsec = 5000;
        #endregion

        public List<string> TCPClientStart(string ipAddress, int port, int indexNumber, string[] data)
        {

            _receiveList.Clear();

            try
            {
                // (1) IP 주소와 포트를 지정하고 TCP 연결 
                _tc = new TcpClient(ipAddress, port);

                List<string> msg = _normalCaseScenario.SetSendMessage(indexNumber, data);

                byte[] buff = msg.SelectMany(s => System.Text.Encoding.ASCII.GetBytes(s)).ToArray();

                // (2) NetworkStream을 얻어옴 
                _stream = _tc.GetStream();
                _bin.Serialize(_stream, msg);

                foreach (var o in msg)
                {
                    Console.WriteLine("Output: " + o + " Size : " + o.Length);
                }

                // (3) 스트림에 바이트 데이타 전송
                _stream.Write(buff, 0, buff.Length);
                _stream.ReadTimeout = timeOutsec;

                // (4) 스트림으로부터 바이트 데이타 읽기
                _receiveList = (List<string>)_bin.Deserialize(_stream);

                var outbuf = _receiveList.SelectMany(s => System.Text.Encoding.ASCII.GetBytes(s)).ToArray();
                int nbytes = _stream.Read(outbuf, 0, outbuf.Length);
                string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);


                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("{nbytes} bytes: " + nbytes.ToString());

                foreach (var o in _receiveList)
                {
                    Console.WriteLine("Output: " + o + " Size : " + o.Length);
                }
                Console.WriteLine("-----------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // (5) 스트림과 TcpClient 객체 닫기
                if (_stream != null)
                {
                    _stream.Close();
                    _stream.Dispose();
                }
                if (_tc != null)
                {
                    _tc.Close();
                }
            }
            return _receiveList;
        }
    }
}



