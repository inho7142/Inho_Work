namespace AsyncTCPServer
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
            this.tbx_ReceiveData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx_ReceiveData
            // 
            this.tbx_ReceiveData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbx_ReceiveData.Location = new System.Drawing.Point(0, 188);
            this.tbx_ReceiveData.Multiline = true;
            this.tbx_ReceiveData.Name = "tbx_ReceiveData";
            this.tbx_ReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_ReceiveData.Size = new System.Drawing.Size(284, 74);
            this.tbx_ReceiveData.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbx_ReceiveData);
            this.Name = "MainForm";
            this.Text = "AsyncTCPServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_ReceiveData;
    }
}

