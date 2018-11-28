using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using GloryCimProtocol;

namespace Communication.TCP
{
    public class TCPServer
    {
        
        #region Private Variable
        private TcpClient _tc = null;
        private NetworkStream _stream = null;
        private BinaryFormatter _bin = new BinaryFormatter();
        private List<string> _resultList = new List<string>();
        private List<string> _oldResultList = new List<string>();
        private TcpListener _listener = null;
        private NormalCaseScenario _normalCaseScenario = new NormalCaseScenario();
        private bool _isOtherPrm = false;
        #endregion

        public void TCPServerStart(int port, bool isOtherPrm)
        { 
            _listener = new TcpListener(IPAddress.Any, port);
            _isOtherPrm = isOtherPrm;
        }
        public async 
            Task AysncEchoServer()
        {
            try
            {
                _listener.Start();
                while (true)
                {
                    // 비동기 Accept                
                    TcpClient tc = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    // 새 쓰레드에서 처리
                    Task.Factory.StartNew(AsyncTcpProcess, tc);
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void AsyncTcpProcess(object o)
        {
            if (o == null)
                return;

            _resultList.Clear();
            List<string> list = null;
            
            try
            {
                _tc = (TcpClient)o;
                _stream = _tc.GetStream();
                
                // 비동기 수신       
                list = (List<string>)_bin.Deserialize(_stream);
                byte[] buff = list.SelectMany(s => System.Text.Encoding.ASCII.GetBytes(s)).ToArray();
                var nbytes = await _stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);

                if (nbytes > 0)
                {
                    foreach (var obj in list)
                    {
                        Console.WriteLine("ReceiveData : " + obj + "SIZE :" + obj.Length);
                    }

                    _resultList = _normalCaseScenario.SendMessage(list, _isOtherPrm);
                    
                   
                    ReceiveDataSaving();
                   
                    // 비동기 송신
                    byte[] outbuff = _resultList.SelectMany(s => System.Text.Encoding.ASCII.GetBytes(s)).ToArray();
                    _bin.Serialize(_stream, _resultList);
                    await _stream.WriteAsync(outbuff, 0, outbuff.Length).ConfigureAwait(false);

                    foreach (var obj in _resultList)
                    {
                        Console.WriteLine("ReceiveData : " + obj + "SIZE :" + obj.Length);
                    }

                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_stream != null)
                {
                    _stream.Close();
                }
                if (_tc != null)
                {
                    _tc.Close();
                }
            }
        }

        public List<string> ReceiveDataSaving()
        {
            List<string> sendList = null;

            

            foreach (var obj in _resultList)
            {
                
            }

            //_oldResultList
            //_resultList

            return sendList;
        }
    }
}
