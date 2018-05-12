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
    public partial class Fragancias_Aplicaciones : Telerik.WinControls.UI.RadForm
    {
        Negocio.Aplicaciones _aplicaciones = new Negocio.Aplicaciones();
        Negocio.Fragancia _fragancia = new Negocio.Fragancia();
        public int idFragancia = 0;
        string Accion = "Listar";

        public Fragancias_Aplicaciones()
        {
            InitializeComponent();
        }

        private void Fragancias_Aplicaciones_Load(object sender, EventArgs e)
        {
            Negocio.Aplicaciones _aplicaciones = new Negocio.Aplicaciones();
            combo_idAplicacion.DataSource = _aplicaciones.obtenerTodos();
            combo_idAplicacion.ValueMember = "idAplicacion";
            combo_idAplicacion.DisplayMember = "Nombre";

            cargarGrilla();

            combo_idAplicacion.Items[0].Selected = true;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            txt_AplDetallada.Text = "";
            habilitarBotones(true);
            Accion = "Agregar";
        }

        void habilitarBotones(bool estado)
        {
            combo_idAplicacion.Enabled = estado;
            txt_AplDetallada.Enabled = estado;
            btn_Aceptar.Visible = estado;
            btn_Cancelar.Visible = estado;
            btn_Agregar.Enabled = !estado;
            btn_Eliminar.Enabled = !estado;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar la aplicación seleccionada?",  this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                if (_fragancia.eliminarAplicacion(idFragancia, int.Parse(combo_idAplicacion.SelectedValue.ToString()), txt_AplDetallada.Text))
                {
                    MessageBox.Show(this, "Aplicación eliminada correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "No se pudo eliminar la aplicación!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cargarGrilla();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            DataTable _dt = (DataTable)dgw.DataSource;
            List<int> _list = new List<int>();
            for (int i = 0; i < _dt.Rows.Count ; i++)
            {
                _list.Add(int.Parse(_dt.Rows[i]["idAplicacion"].ToString()));
            }

            if (_list.Contains(int.Parse(combo_idAplicacion.SelectedValue.ToString())))
            {
                MessageBox.Show(this, "La aplicación seleccionada, ya está ingresada!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                bool ok = false;

                if (Accion == "Agregar")
                {
                    ok = _fragancia.agregarAplicacion(idFragancia, int.Parse(combo_idAplicacion.SelectedValue.ToString()), txt_AplDetallada.Text);
                }

                if (ok)
                {
                    MessageBox.Show(this, "Aplicación agregada correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "No se pudo eliminar la aplicación!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cargarGrilla();
                habilitarBotones(false);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            cargarGrilla();
        }

        private void dgw_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                combo_idAplicacion.SelectedValue = int.Parse(dgw.Rows[e.RowIndex].Cells["idAplicacion"].Value.ToString());
                txt_AplDetallada.Text = dgw.Rows[e.RowIndex].Cells["AplDetallada"].Value.ToString();
            }
        }

        void cargarGrilla()
        {
            dgw.DataSource = _fragancia.obtenerAplicaciones(idFragancia);
            if (dgw.Rows.Count > 0)
            {
                //ARREGLAR dgw_CellClick(dgw, new Telerik.WinControls.UI.GridViewCellEventArgs(dgw.Rows[0], dgw.Columns[0])); 
            }

            dgw.Columns[0].IsVisible = false;
            dgw.Columns[1].IsVisible = false;

            for (int i = 0; i < dgw.Columns.Count - 1; i++)
            {
                dgw.Columns[i].BestFit();
            }
        }

        
    }
}
