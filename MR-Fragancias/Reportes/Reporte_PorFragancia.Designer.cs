namespace MR_Fragancias.Reportes
{
    partial class Reporte_PorFragancia
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.combo_Fragancias = new Telerik.WinControls.UI.RadDropDownList();
            this.label4 = new System.Windows.Forms.Label();
            this.date_FechaSolicitud_Desde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.date_FechaSolicitud_Hasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ck_Vendidas = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ck_Presentadas = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_CargarReporte = new System.Windows.Forms.Button();
            this.mRFraganciasDataSet3 = new MR_Fragancias.MRFraganciasDataSet3();
            this.mRFraganciasDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporte_PorFraganciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.combo_Fragancias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_PorFraganciaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Reporte_PorFraganciaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MR_Fragancias.Reportes.Reporte_Fragancia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(922, 362);
            this.reportViewer1.TabIndex = 0;
            // 
            // combo_Fragancias
            // 
            this.combo_Fragancias.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.combo_Fragancias.Location = new System.Drawing.Point(71, 12);
            this.combo_Fragancias.Name = "combo_Fragancias";
            this.combo_Fragancias.Size = new System.Drawing.Size(250, 20);
            this.combo_Fragancias.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo:";
            // 
            // date_FechaSolicitud_Desde
            // 
            this.date_FechaSolicitud_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FechaSolicitud_Desde.Location = new System.Drawing.Point(71, 38);
            this.date_FechaSolicitud_Desde.Name = "date_FechaSolicitud_Desde";
            this.date_FechaSolicitud_Desde.Size = new System.Drawing.Size(88, 20);
            this.date_FechaSolicitud_Desde.TabIndex = 10;
            this.date_FechaSolicitud_Desde.TabStop = false;
            this.date_FechaSolicitud_Desde.Text = "29/07/2017";
            this.date_FechaSolicitud_Desde.Value = new System.DateTime(2017, 7, 29, 16, 13, 22, 187);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Hasta:";
            // 
            // date_FechaSolicitud_Hasta
            // 
            this.date_FechaSolicitud_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FechaSolicitud_Hasta.Location = new System.Drawing.Point(71, 64);
            this.date_FechaSolicitud_Hasta.Name = "date_FechaSolicitud_Hasta";
            this.date_FechaSolicitud_Hasta.Size = new System.Drawing.Size(88, 20);
            this.date_FechaSolicitud_Hasta.TabIndex = 11;
            this.date_FechaSolicitud_Hasta.TabStop = false;
            this.date_FechaSolicitud_Hasta.Text = "29/07/2017";
            this.date_FechaSolicitud_Hasta.Value = new System.DateTime(2017, 7, 29, 16, 13, 22, 187);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Desde:";
            // 
            // ck_Vendidas
            // 
            this.ck_Vendidas.AutoSize = true;
            this.ck_Vendidas.Checked = true;
            this.ck_Vendidas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Vendidas.Location = new System.Drawing.Point(165, 94);
            this.ck_Vendidas.Name = "ck_Vendidas";
            this.ck_Vendidas.Size = new System.Drawing.Size(70, 17);
            this.ck_Vendidas.TabIndex = 2;
            this.ck_Vendidas.Text = "Vendidas";
            this.ck_Vendidas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fragancia:";
            // 
            // ck_Presentadas
            // 
            this.ck_Presentadas.AutoSize = true;
            this.ck_Presentadas.Checked = true;
            this.ck_Presentadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Presentadas.Location = new System.Drawing.Point(71, 94);
            this.ck_Presentadas.Name = "ck_Presentadas";
            this.ck_Presentadas.Size = new System.Drawing.Size(85, 17);
            this.ck_Presentadas.TabIndex = 1;
            this.ck_Presentadas.Text = "Presentadas";
            this.ck_Presentadas.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_CargarReporte);
            this.splitContainer1.Panel1.Controls.Add(this.combo_Fragancias);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.date_FechaSolicitud_Desde);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.date_FechaSolicitud_Hasta);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.ck_Vendidas);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ck_Presentadas);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(922, 510);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_CargarReporte
            // 
            this.btn_CargarReporte.Location = new System.Drawing.Point(284, 73);
            this.btn_CargarReporte.Name = "btn_CargarReporte";
            this.btn_CargarReporte.Size = new System.Drawing.Size(90, 38);
            this.btn_CargarReporte.TabIndex = 16;
            this.btn_CargarReporte.Text = "Cargar Reporte";
            this.btn_CargarReporte.UseVisualStyleBackColor = true;
            this.btn_CargarReporte.Click += new System.EventHandler(this.btn_CargarReporte_Click);
            // 
            // mRFraganciasDataSet3
            // 
            this.mRFraganciasDataSet3.DataSetName = "MRFraganciasDataSet3";
            this.mRFraganciasDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mRFraganciasDataSet3BindingSource
            // 
            this.mRFraganciasDataSet3BindingSource.DataSource = this.mRFraganciasDataSet3;
            this.mRFraganciasDataSet3BindingSource.Position = 0;
            // 
            // Reporte_PorFraganciaBindingSource
            // 
            this.Reporte_PorFraganciaBindingSource.DataMember = "Reporte_PorFragancia";
            this.Reporte_PorFraganciaBindingSource.DataSource = this.mRFraganciasDataSet3;
            // 
            // Reporte_PorFragancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(922, 510);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Reporte_PorFragancia";
            this.Text = "Reporte_PorFragancia";
            this.Load += new System.EventHandler(this.Reporte_PorFragancia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_Fragancias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_PorFraganciaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Telerik.WinControls.UI.RadDropDownList combo_Fragancias;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Desde;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_Vendidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_Presentadas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_CargarReporte;
        private MRFraganciasDataSet3 mRFraganciasDataSet3;
        private System.Windows.Forms.BindingSource mRFraganciasDataSet3BindingSource;
        private System.Windows.Forms.BindingSource Reporte_PorFraganciaBindingSource;
    }
}