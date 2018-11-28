namespace TCPClient
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_ReceiveDate = new System.Windows.Forms.TextBox();
            this.txt_SendData = new System.Windows.Forms.TextBox();
            this.btn_TCPClientStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_ReceiveDate
            // 
            this.txt_ReceiveDate.Location = new System.Drawing.Point(-1, 406);
            this.txt_ReceiveDate.Multiline = true;
            this.txt_ReceiveDate.Name = "txt_ReceiveDate";
            this.txt_ReceiveDate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ReceiveDate.Size = new System.Drawing.Size(529, 237);
            this.txt_ReceiveDate.TabIndex = 0;
            // 
            // txt_SendData
            // 
            this.txt_SendData.Location = new System.Drawing.Point(-1, 163);
            this.txt_SendData.Multiline = true;
            this.txt_SendData.Name = "txt_SendData";
            this.txt_SendData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SendData.Size = new System.Drawing.Size(529, 237);
            this.txt_SendData.TabIndex = 1;
            // 
            // btn_TCPClientStart
            // 
            this.btn_TCPClientStart.Location = new System.Drawing.Point(12, 101);
            this.btn_TCPClientStart.Name = "btn_TCPClientStart";
            this.btn_TCPClientStart.Size = new System.Drawing.Size(190, 48);
            this.btn_TCPClientStart.TabIndex = 2;
            this.btn_TCPClientStart.Text = "TCPClientStart";
            this.btn_TCPClientStart.UseVisualStyleBackColor = true;
            this.btn_TCPClientStart.Click += new System.EventHandler(this.btn_TCPClientStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 640);
            this.Controls.Add(this.btn_TCPClientStart);
            this.Controls.Add(this.txt_SendData);
            this.Controls.Add(this.txt_ReceiveDate);
            this.Name = "MainForm";
            this.Text = "TCPClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ReceiveDate;
        private System.Windows.Forms.TextBox txt_SendData;
        private System.Windows.Forms.Button btn_TCPClientStart;
    }
}

