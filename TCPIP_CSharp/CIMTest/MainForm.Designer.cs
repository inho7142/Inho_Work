namespace CIMTest
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
            this.btnBarcodeReadReport = new System.Windows.Forms.Button();
            this.btnGroupStartReport = new System.Windows.Forms.Button();
            this.btnVCRReadCellReport = new System.Windows.Forms.Button();
            this.btnPannelContactReport = new System.Windows.Forms.Button();
            this.btnTestResultReport = new System.Windows.Forms.Button();
            this.btnInputTrayReportReport = new System.Windows.Forms.Button();
            this.btnGroupEndReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBarcodeReadReport
            // 
            this.btnBarcodeReadReport.Location = new System.Drawing.Point(25, 27);
            this.btnBarcodeReadReport.Name = "btnBarcodeReadReport";
            this.btnBarcodeReadReport.Size = new System.Drawing.Size(202, 41);
            this.btnBarcodeReadReport.TabIndex = 0;
            this.btnBarcodeReadReport.Text = "BarcodeReadReport";
            this.btnBarcodeReadReport.UseVisualStyleBackColor = true;
            this.btnBarcodeReadReport.Click += new System.EventHandler(this.SendBarcodeReadReport_Click);
            // 
            // btnGroupStartReport
            // 
            this.btnGroupStartReport.Location = new System.Drawing.Point(25, 79);
            this.btnGroupStartReport.Name = "btnGroupStartReport";
            this.btnGroupStartReport.Size = new System.Drawing.Size(202, 41);
            this.btnGroupStartReport.TabIndex = 2;
            this.btnGroupStartReport.Text = "GroupStartReport";
            this.btnGroupStartReport.UseVisualStyleBackColor = true;
            this.btnGroupStartReport.Click += new System.EventHandler(this.SendGroupStartReport_Click);
            // 
            // btnVCRReadCellReport
            // 
            this.btnVCRReadCellReport.Location = new System.Drawing.Point(25, 131);
            this.btnVCRReadCellReport.Name = "btnVCRReadCellReport";
            this.btnVCRReadCellReport.Size = new System.Drawing.Size(202, 41);
            this.btnVCRReadCellReport.TabIndex = 3;
            this.btnVCRReadCellReport.Text = "VCRReadCellReport";
            this.btnVCRReadCellReport.UseVisualStyleBackColor = true;
            this.btnVCRReadCellReport.Click += new System.EventHandler(this.SendVCRReadCellReport_Click);
            // 
            // btnPannelContactReport
            // 
            this.btnPannelContactReport.Location = new System.Drawing.Point(25, 183);
            this.btnPannelContactReport.Name = "btnPannelContactReport";
            this.btnPannelContactReport.Size = new System.Drawing.Size(202, 41);
            this.btnPannelContactReport.TabIndex = 4;
            this.btnPannelContactReport.Text = "PannelContactReport";
            this.btnPannelContactReport.UseVisualStyleBackColor = true;
            this.btnPannelContactReport.Click += new System.EventHandler(this.SendPannelContactReport_Click);
            // 
            // btnTestResultReport
            // 
            this.btnTestResultReport.Location = new System.Drawing.Point(25, 235);
            this.btnTestResultReport.Name = "btnTestResultReport";
            this.btnTestResultReport.Size = new System.Drawing.Size(202, 41);
            this.btnTestResultReport.TabIndex = 5;
            this.btnTestResultReport.Text = "TestResultReport";
            this.btnTestResultReport.UseVisualStyleBackColor = true;
            this.btnTestResultReport.Click += new System.EventHandler(this.SendTestResultReport_Click);
            // 
            // btnInputTrayReportReport
            // 
            this.btnInputTrayReportReport.Location = new System.Drawing.Point(25, 287);
            this.btnInputTrayReportReport.Name = "btnInputTrayReportReport";
            this.btnInputTrayReportReport.Size = new System.Drawing.Size(202, 41);
            this.btnInputTrayReportReport.TabIndex = 6;
            this.btnInputTrayReportReport.Text = "InputTrayReportReport";
            this.btnInputTrayReportReport.UseVisualStyleBackColor = true;
            this.btnInputTrayReportReport.Click += new System.EventHandler(this.SendInputTrayReportReport_Click);
            // 
            // btnGroupEndReport
            // 
            this.btnGroupEndReport.Location = new System.Drawing.Point(25, 339);
            this.btnGroupEndReport.Name = "btnGroupEndReport";
            this.btnGroupEndReport.Size = new System.Drawing.Size(202, 41);
            this.btnGroupEndReport.TabIndex = 7;
            this.btnGroupEndReport.Text = "GroupEndReport";
            this.btnGroupEndReport.UseVisualStyleBackColor = true;
            this.btnGroupEndReport.Click += new System.EventHandler(this.SendGroupEndReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 409);
            this.Controls.Add(this.btnGroupEndReport);
            this.Controls.Add(this.btnInputTrayReportReport);
            this.Controls.Add(this.btnTestResultReport);
            this.Controls.Add(this.btnPannelContactReport);
            this.Controls.Add(this.btnVCRReadCellReport);
            this.Controls.Add(this.btnGroupStartReport);
            this.Controls.Add(this.btnBarcodeReadReport);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBarcodeReadReport;
        private System.Windows.Forms.Button btnGroupStartReport;
        private System.Windows.Forms.Button btnVCRReadCellReport;
        private System.Windows.Forms.Button btnPannelContactReport;
        private System.Windows.Forms.Button btnTestResultReport;
        private System.Windows.Forms.Button btnInputTrayReportReport;
        private System.Windows.Forms.Button btnGroupEndReport;
    }
}

