namespace MR_Fragancias
{
    partial class Costos_Historial
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
            this.dgw = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgw.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgw.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgw.ForeColor = System.Drawing.Color.Black;
            this.dgw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgw.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.dgw.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dgw.MasterTemplate.AllowAddNewRow = false;
            this.dgw.MasterTemplate.AllowDeleteRow = false;
            this.dgw.MasterTemplate.AllowEditRow = false;
            this.dgw.Name = "dgw";
            this.dgw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.dgw.RootElement.ForeColor = System.Drawing.Color.Black;
            this.dgw.Size = new System.Drawing.Size(316, 305);
            this.dgw.TabIndex = 4;
            this.dgw.Text = "dgw";
            // 
            // Costos_Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 329);
            this.Controls.Add(this.dgw);
            this.Name = "Costos_Historial";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Costos";
            this.Load += new System.EventHandler(this.Costos_Historial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgw;
    }
}
