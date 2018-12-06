using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
namespace MouseMovePrm
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll",CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(long dwFlags,long dx,long dy,long cButtons,long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private Thread _moveThread = null;
        private bool _isThreadStop = true;

        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartThread();
        }

        private void StartThread()
        {
            if (_moveThread == null)
            {
                _isThreadStop = true;
                _moveThread = new Thread(MouseMovePosition);
                _moveThread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DisposeThread();
        }

        private void DisposeThread()
        {

            if (_moveThread != null)
            {
                _isThreadStop = false;
                _moveThread.Join(2000);
                _moveThread = null;
            }

            Point position = new Point(this.Location.X - 30 , 0);
            Click(position);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MouseMovePosition()
        {
            Random randomNum = new Random();
            Point position = this.Location;

            while (_isThreadStop)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Clip = new Rectangle(this.Location, this.Size);

                this.Cursor = Cursors.Default;
                int number = 0;

                if (Cursor.Position.X <= (this.Location.X + this.Width))
                {
                    number = randomNum.Next(1, this.Width - 10);
                    position = new Point(this.Location.X + number, this.Location.Y + (this.Height/2));
                    Click(position);
                }
                else 
                {
                    position = new Point(Location.X + 1, this.Location.Y + (this.Height / 2));
                    Click(position);
                }

                number = randomNum.Next(1, 3000);

                lblMousePosition.Text =
                    " Mouse Click Position " + Environment.NewLine
                    + " SleepTime : " + number.ToString() + Environment.NewLine
                    + " Mouse PositionX : " + position.X.ToString() + Environment.NewLine
                    + " Mouse PositionY : " + position.Y.ToString();

                Thread.Sleep(number);
            }
        }

        public void Click(Point pt)
        {
            Cursor.Position = pt;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, pt.X, pt.Y, 0, 0);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                StartThread();
                this.Activate();
            }
            else if (e.KeyCode == Keys.F6)
            {
                DisposeThread();
                this.Activate();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeThread();
        }
    }
}
