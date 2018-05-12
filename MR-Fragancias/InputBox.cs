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
    public partial class InputBox : Telerik.WinControls.UI.RadForm
    {
        public InputBox(string txt, bool pass)
        {
            InitializeComponent();
            txt_Valor.Focus();
            lbl_Texto.Text = txt;
            if (pass)
            {
                txt_Valor.PasswordChar = '*';
            }
        }

        public static string ShowDialog(string text, bool pass)
        {
            InputBox promt = new InputBox(text, pass);
            return promt.ShowDialog() == DialogResult.OK ? promt.txt_Valor.Text : "";
        }

        private void txt_Valor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Aceptar.PerformClick();
            }
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_Valor;
        }
    }
}
