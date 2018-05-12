namespace MR_Fragancias
{
    partial class BuscarPedidoMuestra
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
            this.txt_idPedidoMuestra = new Telerik.WinControls.UI.RadTextBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.combo_Cliente = new Telerik.WinControls.UI.RadDropDownList();
            this.txt_Vendedor = new Telerik.WinControls.UI.RadTextBox();
            this.date_FechaSolicitud_Desde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rb_IdPedidoMuestra = new Telerik.WinControls.UI.RadRadioButton();
            this.rb_Cliente = new Telerik.WinControls.UI.RadRadioButton();
            this.rb_Vendedor = new Telerik.WinControls.UI.RadRadioButton();
            this.rb_FechaSolicitud = new Telerik.WinControls.UI.RadRadioButton();
            this.btn_Cancelar = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.date_FechaSolicitud_Hasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btn_VerTodos = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_idPedidoMuestra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Vendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_IdPedidoMuestra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_Vendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_FechaSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_VerTodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_idPedidoMuestra
            // 
            this.txt_idPedidoMuestra.Location = new System.Drawing.Point(158, 12);
            this.txt_idPedidoMuestra.Name = "txt_idPedidoMuestra";
            this.txt_idPedidoMuestra.Size = new System.Drawing.Size(73, 20);
            this.txt_idPedidoMuestra.TabIndex = 0;
            this.txt_idPedidoMuestra.TabStop = false;
            this.txt_idPedidoMuestra.TextChanged += new System.EventHandler(this.txt_idPedidoMuestra_TextChanged);
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(12, 144);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowColumnResize = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnableSorting = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(543, 267);
            this.radGridView1.TabIndex = 1;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            // 
            // combo_Cliente
            // 
            this.combo_Cliente.Location = new System.Drawing.Point(85, 36);
            this.combo_Cliente.Name = "combo_Cliente";
            this.combo_Cliente.Size = new System.Drawing.Size(220, 20);
            this.combo_Cliente.TabIndex = 2;
            this.combo_Cliente.Text = "radDropDownList1";
            this.combo_Cliente.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_Cliente_SelectedIndexChanged);
            // 
            // txt_Vendedor
            // 
            this.txt_Vendedor.Location = new System.Drawing.Point(100, 60);
            this.txt_Vendedor.Name = "txt_Vendedor";
            this.txt_Vendedor.Size = new System.Drawing.Size(205, 20);
            this.txt_Vendedor.TabIndex = 3;
            this.txt_Vendedor.TabStop = false;
            this.txt_Vendedor.TextChanged += new System.EventHandler(this.txt_Vendedor_TextChanged);
            // 
            // date_FechaSolicitud_Desde
            // 
            this.date_FechaSolicitud_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FechaSolicitud_Desde.Location = new System.Drawing.Point(198, 84);
            this.date_FechaSolicitud_Desde.Name = "date_FechaSolicitud_Desde";
            this.date_FechaSolicitud_Desde.Size = new System.Drawing.Size(90, 20);
            this.date_FechaSolicitud_Desde.TabIndex = 4;
            this.date_FechaSolicitud_Desde.TabStop = false;
            this.date_FechaSolicitud_Desde.Text = "13/08/2017";
            this.date_FechaSolicitud_Desde.Value = new System.DateTime(2017, 8, 13, 18, 52, 32, 588);
            this.date_FechaSolicitud_Desde.ValueChanged += new System.EventHandler(this.date_FechaSolicitud_Desde_ValueChanged);
            // 
            // rb_IdPedidoMuestra
            // 
            this.rb_IdPedidoMuestra.Location = new System.Drawing.Point(22, 14);
            this.rb_IdPedidoMuestra.Name = "rb_IdPedidoMuestra";
            this.rb_IdPedidoMuestra.Size = new System.Drawing.Size(130, 18);
            this.rb_IdPedidoMuestra.TabIndex = 5;
            this.rb_IdPedidoMuestra.TabStop = true;
            this.rb_IdPedidoMuestra.Text = "Id Pedido de Muestra:";
            this.rb_IdPedidoMuestra.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rb_Cliente
            // 
            this.rb_Cliente.Location = new System.Drawing.Point(22, 38);
            this.rb_Cliente.Name = "rb_Cliente";
            this.rb_Cliente.Size = new System.Drawing.Size(57, 18);
            this.rb_Cliente.TabIndex = 0;
            this.rb_Cliente.Text = "Cliente:";
            // 
            // rb_Vendedor
            // 
            this.rb_Vendedor.Location = new System.Drawing.Point(22, 62);
            this.rb_Vendedor.Name = "rb_Vendedor";
            this.rb_Vendedor.Size = new System.Drawing.Size(72, 18);
            this.rb_Vendedor.TabIndex = 0;
            this.rb_Vendedor.Text = "Vendedor:";
            // 
            // rb_FechaSolicitud
            // 
            this.rb_FechaSolicitud.Location = new System.Drawing.Point(22, 86);
            this.rb_FechaSolicitud.Name = "rb_FechaSolicitud";
            this.rb_FechaSolicitud.Size = new System.Drawing.Size(113, 18);
            this.rb_FechaSolicitud.TabIndex = 0;
            this.rb_FechaSolicitud.Text = "Fecha de Solicitud:";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(445, 417);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(110, 24);
            this.btn_Cancelar.TabIndex = 0;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(156, 86);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "desde";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(294, 86);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "hasta";
            // 
            // date_FechaSolicitud_Hasta
            // 
            this.date_FechaSolicitud_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_FechaSolicitud_Hasta.Location = new System.Drawing.Point(333, 84);
            this.date_FechaSolicitud_Hasta.Name = "date_FechaSolicitud_Hasta";
            this.date_FechaSolicitud_Hasta.Size = new System.Drawing.Size(90, 20);
            this.date_FechaSolicitud_Hasta.TabIndex = 8;
            this.date_FechaSolicitud_Hasta.TabStop = false;
            this.date_FechaSolicitud_Hasta.Text = "13/08/2017";
            this.date_FechaSolicitud_Hasta.Value = new System.DateTime(2017, 8, 13, 18, 52, 32, 588);
            this.date_FechaSolicitud_Hasta.ValueChanged += new System.EventHandler(this.date_FechaSolicitud_Hasta_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 120);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(322, 18);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Haga doble click sobre el pedido de muestra para seleccionarlo";
            // 
            // btn_VerTodos
            // 
            this.btn_VerTodos.Location = new System.Drawing.Point(445, 114);
            this.btn_VerTodos.Name = "btn_VerTodos";
            this.btn_VerTodos.Size = new System.Drawing.Size(110, 24);
            this.btn_VerTodos.TabIndex = 11;
            this.btn_VerTodos.Text = "Ver Todos";
            this.btn_VerTodos.Click += new System.EventHandler(this.btn_VerTodos_Click);
            // 
            // BuscarPedidoMuestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 446);
            this.ControlBox = false;
            this.Controls.Add(this.btn_VerTodos);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.date_FechaSolicitud_Hasta);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.rb_Cliente);
            this.Controls.Add(this.rb_Vendedor);
            this.Controls.Add(this.rb_FechaSolicitud);
            this.Controls.Add(this.rb_IdPedidoMuestra);
            this.Controls.Add(this.date_FechaSolicitud_Desde);
            this.Controls.Add(this.txt_Vendedor);
            this.Controls.Add(this.combo_Cliente);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.txt_idPedidoMuestra);
            this.Name = "BuscarPedidoMuestra";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.BuscarPedidoMuestra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_idPedidoMuestra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Vendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_IdPedidoMuestra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_Vendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rb_FechaSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_FechaSolicitud_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_VerTodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txt_idPedidoMuestra;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadDropDownList combo_Cliente;
        private Telerik.WinControls.UI.RadTextBox txt_Vendedor;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Desde;
        private Telerik.WinControls.UI.RadRadioButton rb_IdPedidoMuestra;
        private Telerik.WinControls.UI.RadRadioButton rb_Cliente;
        private Telerik.WinControls.UI.RadRadioButton rb_Vendedor;
        private Telerik.WinControls.UI.RadRadioButton rb_FechaSolicitud;
        private Telerik.WinControls.UI.RadButton btn_Cancelar;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker date_FechaSolicitud_Hasta;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btn_VerTodos;
    }
}
