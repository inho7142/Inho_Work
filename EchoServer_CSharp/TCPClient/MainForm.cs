﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TCPClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        public void TCPClientStart()
        {
          // (1) IP 주소와 포트를 지정하고 TCP 연결 
            TcpClient tc = new TcpClient("127.0.0.1", 7000);
            //TcpClient tc = new TcpClient("localhost", 7000);
 
            string msg = "Hello World";
            byte[] buff = Encoding.ASCII.GetBytes(msg);
 
            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();
 
            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);
 
            // (4) 스트림으로부터 바이트 데이타 읽기
            byte[] outbuf = new byte[1024];
            int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);
 
            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();
 
            Console.WriteLine("{nbytes} bytes: " +  nbytes.ToString());
            Console.WriteLine("Output: " + output.ToString());

        }

        private void btn_TCPClientStart_Click(object sender, EventArgs e)
        {
            TCPClientStart();
        }
    }
}
