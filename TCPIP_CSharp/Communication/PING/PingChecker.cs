using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GloryCimProtocol;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;

namespace Communication.PING
{
    public class PingChecker
    {
        #region
        private int timeOut = 2000; 
        #endregion
        #region Constructor, destructor
        public PingChecker()
        {

        }

        ~ PingChecker()
        {

        }
        #endregion
        Ping pingSender = new Ping();
        PingReply reply;

        public void PingCheckStart(string ipAddress)
        {
         
            try
            {
                reply = pingSender.Send(ipAddress, timeOut);

                if (reply.Status == IPStatus.Success) //핑이 제대로 들어가고 있을 경우
                {
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
                else //핑이 제대로 들어가지 않고 있을 경우 
                {
                    Console.WriteLine(reply.Status);
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
       
        }
        /// <summary>
        /// ping 응답유무 확인하는 메서드
        /// </summary>
        /// <returns></returns>
        public bool PingCheckStart(string ipAddress, bool isSuccessed = false)
        {

            reply = pingSender.Send(ipAddress, timeOut);

            if (reply.Status == IPStatus.Success)
            {
                isSuccessed = true;
            }
            else
            {
                isSuccessed = false;
            }

            return isSuccessed;
        }
    }
}



