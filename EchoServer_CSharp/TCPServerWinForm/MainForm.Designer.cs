namespace TCPServerWinForm
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
            this.tbx_ReciveData = new System.Windows.Forms.TextBox();
            this.txt_SendData = new System.Windows.Forms.TextBox();
            this.btn_TCPServerStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_ReciveData
            // 
            this.tbx_ReciveData.Location = new System.Drawing.Point(3, 353);
            this.tbx_ReciveData.Multiline = true;
            this.tbx_ReciveData.Name = "tbx_ReciveData";
            this.tbx_ReciveData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_ReciveData.Size = new System.Drawing.Size(566, 254);
            this.tbx_ReciveData.TabIndex = 0;
            // 
            // txt_SendData
            // 
            this.txt_SendData.Location = new System.Drawing.Point(3, 93);
            this.txt_SendData.Multiline = true;
            this.txt_SendData.Name = "txt_SendData";
            this.txt_SendData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SendData.Size = new System.Drawing.Size(566, 254);
            this.txt_SendData.TabIndex = 1;
            // 
            // btn_TCPServerStart
            // 
            this.btn_TCPServerStart.Location = new System.Drawing.Point(19, 37);
            this.btn_TCPServerStart.Name = "btn_TCPServerStart";
            this.btn_TCPServerStart.Size = new System.Drawing.Size(177, 37);
            this.btn_TCPServerStart.TabIndex = 2;
            this.btn_TCPServerStart.Text = "btnStart";
            this.btn_TCPServerStart.UseVisualStyleBackColor = true;
            this.btn_TCPServerStart.Click += new System.EventHandler(this.btn_TCPServerStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 603);
            this.Controls.Add(this.btn_TCPServerStart);
            this.Controls.Add(this.txt_SendData);
            this.Controls.Add(this.tbx_ReciveData);
            this.Name = "MainForm";
            this.Text = "TCPServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_ReciveData;
        private System.Windows.Forms.TextBox txt_SendData;
        private System.Windows.Forms.Button btn_TCPServerStart;
    }
}

