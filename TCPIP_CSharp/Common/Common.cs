using Communication.TCP;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Common
{
    [Guid("8D66976A-346C-43AF-9F81-67CC99D9EC83")]
    public class Common : iCommon
    {
        private TCPServer _tcpServer = null;
        private TCPClient _tcpClient = null;

        /// <summary>
        /// Server Create 서버 생성
        /// </summary>
        /// <param name="port"></param>
        /// <param name="otherPrm"></param>
        public void ServerCreate(int port, bool otherPrm)
        {
            try
            {
                if (_tcpServer == null)
                {
                    _tcpServer = new TCPServer();
                }
                _tcpServer.TCPServerStart(port, otherPrm);
                _tcpServer.AysncEchoServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                using (Destruction.Disposable disposable = new Destruction.Disposable())
                {
                    disposable.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] ReceiveDataSaving()
        {
            string[] resultArray = null;

            if (_tcpServer != null)
            {

                var receiveData = _tcpServer.ReceiveDataSaving();
                int listCount = receiveData.Count;

                if (receiveData.Count > 0)
                {
                    resultArray = new string[listCount];
                }

                for (int i = 0; i < listCount; i++)
                {
                    resultArray[i] = receiveData[i];
                }
            }
            return resultArray;
        }

        /// <summary>
        /// Client Create 클라이언트 생성 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string[] ClientCreate(string ipAddress, int port, int index, string[] data)
        {
            List<string> resultList = null;

            try
            {
                if (_tcpClient == null)
                {
                    _tcpClient = new TCPClient();
                    resultList = _tcpClient.TCPClientStart(ipAddress, port, index, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                using (Destruction.Disposable disposable = new Destruction.Disposable())
                {
                    disposable.Dispose();
                }
            }

            // Client 받은 데이터 확인 
            string[] resultArray = null;

            if (resultList.Count > 0)
            {
                resultArray = new string[resultList.Count];
            }

            for (int i = 0; i < resultList.Count; i++)
            {
                resultArray[i] = resultList[i];
            }

            return resultArray;
        }
    }
}
