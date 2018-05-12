using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MR_Fragancias
{
    public partial class CambiarPassword : Telerik.WinControls.UI.RadForm
    {
        public CambiarPassword()
        {
            InitializeComponent();
        }

        private void txt_Pass2_TextChanged(object sender, EventArgs e)
        {
            if (txt_Pass2.Text != txt_Pass1.Text)
            {
                lbl_PassNoIguales.Visible = true;
                radButton1.Enabled = false;
            }
            else
            {
                lbl_PassNoIguales.Visible = false;
                radButton1.Enabled = true;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (txt_Pass1.Text.Trim() != "")
            {
                DialogResult dgRes = MessageBox.Show(this, "¿Está seguro que desea cambiar el password del administrador?", "MR Fragancias", MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Usuarios _usuario = new Negocio.Usuarios();
                    if (_usuario.cambiarPassword("Administrador", txt_Pass1.Text))
                    {
                        MessageBox.Show(this, "El password se cambio correctamente!", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Hubo un error al querer cambiar el password!", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                } 
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ((Principal)this.ParentForm).expandirBarra();
            ((Principal)this.ParentForm).passAdmin = txt_Pass1.Text;
        }
    }
}
