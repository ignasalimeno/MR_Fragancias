namespace MR_Fragancias
{
    partial class InputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
            this.btn_Aceptar = new Telerik.WinControls.UI.RadButton();
            this.txt_Valor = new Telerik.WinControls.UI.RadTextBox();
            this.lbl_Texto = new Telerik.WinControls.UI.RadLabel();
            this.btn_Cancelar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Aceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Valor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Texto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Aceptar.Location = new System.Drawing.Point(218, 72);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(74, 24);
            this.btn_Aceptar.TabIndex = 1;
            this.btn_Aceptar.Text = "Aceptar";
            // 
            // txt_Valor
            // 
            this.txt_Valor.Location = new System.Drawing.Point(12, 36);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(360, 20);
            this.txt_Valor.TabIndex = 0;
            this.txt_Valor.TabStop = false;
            this.txt_Valor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Valor_KeyDown);
            // 
            // lbl_Texto
            // 
            this.lbl_Texto.Location = new System.Drawing.Point(12, 12);
            this.lbl_Texto.Name = "lbl_Texto";
            this.lbl_Texto.Size = new System.Drawing.Size(33, 18);
            this.lbl_Texto.TabIndex = 5;
            this.lbl_Texto.Text = "Label";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(298, 72);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(74, 24);
            this.btn_Cancelar.TabIndex = 2;
            this.btn_Cancelar.Text = "Cancelar";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 110);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lbl_Texto);
            this.Controls.Add(this.txt_Valor);
            this.Controls.Add(this.btn_Aceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputBox";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MR Fragancias";
            this.Load += new System.EventHandler(this.InputBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Aceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Valor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Texto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_Aceptar;
        private Telerik.WinControls.UI.RadTextBox txt_Valor;
        private Telerik.WinControls.UI.RadLabel lbl_Texto;
        private Telerik.WinControls.UI.RadButton btn_Cancelar;
    }
}
