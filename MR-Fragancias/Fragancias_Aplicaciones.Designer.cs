namespace MR_Fragancias
{
    partial class Fragancias_Aplicaciones
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Cancelar = new Telerik.WinControls.UI.RadButton();
            this.btn_Aceptar = new Telerik.WinControls.UI.RadButton();
            this.combo_idAplicacion = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btn_Eliminar = new Telerik.WinControls.UI.RadButton();
            this.txt_AplDetallada = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btn_Agregar = new Telerik.WinControls.UI.RadButton();
            this.dgw = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Aceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_idAplicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AplDetallada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Agregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btn_Cancelar);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Aceptar);
            this.splitContainer1.Panel1.Controls.Add(this.combo_idAplicacion);
            this.splitContainer1.Panel1.Controls.Add(this.radLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Eliminar);
            this.splitContainer1.Panel1.Controls.Add(this.txt_AplDetallada);
            this.splitContainer1.Panel1.Controls.Add(this.radLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Agregar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgw);
            this.splitContainer1.Size = new System.Drawing.Size(434, 474);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(241, 64);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(76, 24);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.Visible = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(159, 64);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(76, 24);
            this.btn_Aceptar.TabIndex = 6;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.Visible = false;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // combo_idAplicacion
            // 
            this.combo_idAplicacion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.combo_idAplicacion.Enabled = false;
            this.combo_idAplicacion.Location = new System.Drawing.Point(112, 12);
            this.combo_idAplicacion.Name = "combo_idAplicacion";
            // 
            // 
            // 
            this.combo_idAplicacion.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.combo_idAplicacion.Size = new System.Drawing.Size(181, 20);
            this.combo_idAplicacion.TabIndex = 10;
            this.combo_idAplicacion.TabStop = false;
            this.combo_idAplicacion.Text = "radDropDownList1";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(8, 16);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(61, 16);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Aplicación:";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(346, 68);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(76, 24);
            this.btn_Eliminar.TabIndex = 5;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // txt_AplDetallada
            // 
            this.txt_AplDetallada.Enabled = false;
            this.txt_AplDetallada.Location = new System.Drawing.Point(112, 38);
            this.txt_AplDetallada.Name = "txt_AplDetallada";
            this.txt_AplDetallada.Size = new System.Drawing.Size(205, 20);
            this.txt_AplDetallada.TabIndex = 7;
            this.txt_AplDetallada.TabStop = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(8, 43);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(83, 16);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Apl. Detallada: ";
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(346, 38);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(76, 24);
            this.btn_Agregar.TabIndex = 5;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // dgw
            // 
            this.dgw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgw.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgw.ForeColor = System.Drawing.Color.Black;
            this.dgw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgw.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dgw.MasterTemplate.AllowAddNewRow = false;
            this.dgw.MasterTemplate.AllowDeleteRow = false;
            this.dgw.MasterTemplate.AllowEditRow = false;
            this.dgw.Name = "dgw";
            this.dgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.dgw.RootElement.ForeColor = System.Drawing.Color.Black;
            this.dgw.Size = new System.Drawing.Size(434, 364);
            this.dgw.TabIndex = 1;
            this.dgw.Text = "dgw";
            this.dgw.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgw_CellClick);
            // 
            // Fragancias_Aplicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 474);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Fragancias_Aplicaciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fragancias_Aplicaciones";
            this.Load += new System.EventHandler(this.Fragancias_Aplicaciones_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Aceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_idAplicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AplDetallada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Agregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadButton btn_Eliminar;
        private Telerik.WinControls.UI.RadButton btn_Agregar;
        private Telerik.WinControls.UI.RadDropDownList combo_idAplicacion;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txt_AplDetallada;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btn_Cancelar;
        private Telerik.WinControls.UI.RadButton btn_Aceptar;
        private Telerik.WinControls.UI.RadGridView dgw;
    }
}
