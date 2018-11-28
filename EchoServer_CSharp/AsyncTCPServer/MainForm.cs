using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Net;

namespace AsyncTCPServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void AsyncTCPServerTest()
        {


        }
        async Task AysncEchoServer()
        {           
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();            
            while (true)
            {
                // 비동기 Accept                
                TcpClient tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);                
                 
                // 새 쓰레드에서 처리
                Task.Factory.StartNew(AsyncTcpProcess, tc);                
            }
        }
 
        async void AsyncTcpProcess(object o)
        {
            TcpClient tc = (TcpClient)o;
 
            int MAX_SIZE = 1024;  // 가정
            NetworkStream stream = tc.GetStream();
 
            // 비동기 수신            
            var buff = new byte[MAX_SIZE];
            var nbytes = await stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);
            if (nbytes > 0)
            {                
                string msg = Encoding.ASCII.GetString(buff, 0, nbytes);
                Console.WriteLine("{msg} at {DateTime.Now}");                
                                 
                // 비동기 송신
                await stream.WriteAsync(buff, 0, nbytes).ConfigureAwait(false);
            }
 
            stream.Close();
            tc.Close();
        }
    }
}
