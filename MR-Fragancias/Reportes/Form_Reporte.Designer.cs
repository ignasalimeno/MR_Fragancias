namespace MR_Fragancias.Reportes
{
    partial class Form_Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page_Resumen = new System.Windows.Forms.TabPage();
            this.page_Carta = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.page_Resumen.SuspendLayout();
            this.page_Carta.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MR_Fragancias.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(884, 427);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.page_Resumen);
            this.tabControl1.Controls.Add(this.page_Carta);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 459);
            this.tabControl1.TabIndex = 1;
            // 
            // page_Resumen
            // 
            this.page_Resumen.Controls.Add(this.reportViewer1);
            this.page_Resumen.Location = new System.Drawing.Point(4, 22);
            this.page_Resumen.Name = "page_Resumen";
            this.page_Resumen.Padding = new System.Windows.Forms.Padding(3);
            this.page_Resumen.Size = new System.Drawing.Size(890, 433);
            this.page_Resumen.TabIndex = 0;
            this.page_Resumen.Text = "Resumen";
            this.page_Resumen.UseVisualStyleBackColor = true;
            // 
            // page_Carta
            // 
            this.page_Carta.Controls.Add(this.richTextBox1);
            this.page_Carta.Location = new System.Drawing.Point(4, 22);
            this.page_Carta.Name = "page_Carta";
            this.page_Carta.Padding = new System.Windows.Forms.Padding(3);
            this.page_Carta.Size = new System.Drawing.Size(890, 433);
            this.page_Carta.TabIndex = 1;
            this.page_Carta.Text = "Carta Presentación";
            this.page_Carta.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(884, 427);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 459);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Reporte";
            this.Load += new System.EventHandler(this.Form_Reporte_Load);
            this.tabControl1.ResumeLayout(false);
            this.page_Resumen.ResumeLayout(false);
            this.page_Carta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage page_Resumen;
        private System.Windows.Forms.TabPage page_Carta;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}