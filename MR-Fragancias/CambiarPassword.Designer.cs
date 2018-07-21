namespace MR_Fragancias
{
    partial class CambiarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPassword));
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txt_Pass1 = new Telerik.WinControls.UI.RadTextBox();
            this.txt_Pass2 = new Telerik.WinControls.UI.RadTextBox();
            this.lbl_PassNoIguales = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_PassNoIguales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Enabled = false;
            this.radButton1.Location = new System.Drawing.Point(245, 110);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "Aceptar";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(144, 16);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Ingrese el nuevo password:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(18, 49);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(139, 16);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Repita el nueva password:";
            // 
            // txt_Pass1
            // 
            this.txt_Pass1.Location = new System.Drawing.Point(160, 12);
            this.txt_Pass1.Name = "txt_Pass1";
            this.txt_Pass1.PasswordChar = '*';
            this.txt_Pass1.Size = new System.Drawing.Size(195, 20);
            this.txt_Pass1.TabIndex = 1;
            this.txt_Pass1.TabStop = false;
            // 
            // txt_Pass2
            // 
            this.txt_Pass2.Location = new System.Drawing.Point(160, 49);
            this.txt_Pass2.Name = "txt_Pass2";
            this.txt_Pass2.PasswordChar = '*';
            this.txt_Pass2.Size = new System.Drawing.Size(195, 20);
            this.txt_Pass2.TabIndex = 2;
            this.txt_Pass2.TabStop = false;
            this.txt_Pass2.TextChanged += new System.EventHandler(this.txt_Pass2_TextChanged);
            // 
            // lbl_PassNoIguales
            // 
            this.lbl_PassNoIguales.ForeColor = System.Drawing.Color.Red;
            this.lbl_PassNoIguales.Location = new System.Drawing.Point(201, 75);
            this.lbl_PassNoIguales.Name = "lbl_PassNoIguales";
            // 
            // 
            // 
            this.lbl_PassNoIguales.RootElement.ForeColor = System.Drawing.Color.Red;
            this.lbl_PassNoIguales.Size = new System.Drawing.Size(161, 16);
            this.lbl_PassNoIguales.TabIndex = 2;
            this.lbl_PassNoIguales.Text = "Los passwords no son iguales!";
            this.lbl_PassNoIguales.Visible = false;
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 140);
            this.Controls.Add(this.lbl_PassNoIguales);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txt_Pass1);
            this.Controls.Add(this.txt_Pass2);
            this.Controls.Add(this.radButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CambiarPassword";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CambiarPassword";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Pass2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_PassNoIguales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txt_Pass1;
        private Telerik.WinControls.UI.RadTextBox txt_Pass2;
        private Telerik.WinControls.UI.RadLabel lbl_PassNoIguales;
    }
}
