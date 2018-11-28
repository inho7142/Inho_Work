using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;

namespace TCPServerWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        public void TCPServer()
        {
            // (1) 로컬 포트 7000 을 Listen
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();

            byte[] buff = new byte[1024];

            while (true)
            {
                // (2) TcpClient Connection 요청을 받아들여
                //     서버에서 새 TcpClient 객체를 생성하여 리턴
                TcpClient tc = listener.AcceptTcpClient();

                // (3) TcpClient 객체에서 NetworkStream을 얻어옴 
                NetworkStream stream = tc.GetStream();

                // (4) 클라이언트가 연결을 끊을 때까지 데이타 수신
                int nbytes;
                while ((nbytes = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    // (5) 데이타 그대로 송신
                    stream.Write(buff, 0, nbytes);

                    //tbx_ReciveData.Text = str
                }

                // (6) 스트림과 TcpClient 객체 
                stream.Close();
                tc.Close();

                // (7) 계속 반복
            }
        }

        private void btn_TCPServerStart_Click(object sender, EventArgs e)
        {
            TCPServer();
        }

    }
}


