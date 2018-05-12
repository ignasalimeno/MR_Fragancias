namespace MR_Fragancias.Reportes
{
    partial class Reporte_PorCliente
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
            this.combo_Cliente = new Telerik.WinControls.UI.RadDropDownList();
            this.date_FechaSolicitud_Desde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.date_FechaSolicitud_Hasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.ck_Presentadas = new System.Windows.Forms.CheckBox();
            this.ck_Vendidas = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_CargarReporte = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mRFraganciasDataSet3 = new MR_Fragancias.MRFraganciasDataSet3();
            this.mRFraganciasDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.combo_Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_Cliente
            // 
            this.combo_Cliente.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.combo_Cliente.Location = new System.Drawing.Point(71, 12);
            this.combo_Cliente.Name = "combo_Cliente";
            this.combo_Cliente.Size = new System.Drawing.Size(250, 20);
            this.combo_Cliente.TabIndex = 2;
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
            // ck_Presentadas
            // 
            this.ck_Presentadas.AutoSize = true;
            this.ck_Presentadas.Checked = true;
            this.ck_Presentadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Presentadas.Location = new System.Drawing.Point(71, 94);
            this.ck_Presentadas.Name = "ck_Presentadas";
            this.ck_Presentadas.Size = new System.Drawing.Size(88, 17);
            this.ck_Presentadas.TabIndex = 1;
            this.ck_Presentadas.Text = "Presentadas";
            this.ck_Presentadas.UseVisualStyleBackColor = true;
            // 
            // ck_Vendidas
            // 
            this.ck_Vendidas.AutoSize = true;
            this.ck_Vendidas.Checked = true;
            this.ck_Vendidas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Vendidas.Location = new System.Drawing.Point(165, 94);
            this.ck_Vendidas.Name = "ck_Vendidas";
            this.ck_Vendidas.Size = new System.Drawing.Size(74, 17);
            this.ck_Vendidas.TabIndex = 2;
            this.ck_Vendidas.Text = "Vendidas";
            this.ck_Vendidas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo:";
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_CargarReporte);
            this.splitContainer1.Panel1.Controls.Add(this.combo_Cliente);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.date_FechaSolicitud_Desde);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.date_FechaSolicitud_Hasta);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.ck_Vendidas);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ck_Presentadas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(941, 383);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 16;
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MR_Fragancias.Reportes.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(941, 250);
            this.reportViewer1.TabIndex = 0;
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
            // Reporte_PorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 383);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Reporte_PorCliente";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte_PorCliente";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.Reporte_PorCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRFraganciasDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList combo_Cliente;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Desde;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Hasta;
        private System.Windows.Forms.CheckBox ck_Presentadas;
        private System.Windows.Forms.CheckBox ck_Vendidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_CargarReporte;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mRFraganciasDataSet3BindingSource;
        private MRFraganciasDataSet3 mRFraganciasDataSet3;
        private System.Windows.Forms.Button button1;
    }
}
