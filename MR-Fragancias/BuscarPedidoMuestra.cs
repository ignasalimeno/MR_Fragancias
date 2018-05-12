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
    public partial class BuscarPedidoMuestra : Telerik.WinControls.UI.RadForm
    {
        Negocio.PedidosMuestra miPedido = new Negocio.PedidosMuestra();
        public int idPedidoSeleccionado = 0;

        public BuscarPedidoMuestra()
        {
            InitializeComponent();
        }

        private void BuscarPedidoMuestra_Load(object sender, EventArgs e)
        {
            date_FechaSolicitud_Desde.Value = DateTime.Now;

            Negocio.Cliente miCliente = new Negocio.Cliente();
            cargarClientes();

            radGridView1.DataSource = miPedido.obtenerPedidosTODOS();
            for (int i = 0; i < radGridView1.Columns.Count; i++)
            {
                radGridView1.Columns[i].BestFit();
            }

            rb_IdPedidoMuestra.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
        }

        void cargarClientes()
        {
            Negocio.Cliente miCliente = new Negocio.Cliente();
            DataTable dtCliente = miCliente.obtenerTodos();

            combo_Cliente.ValueMember = "idCliente";
            combo_Cliente.DisplayMember = "RazonSocial";

            combo_Cliente.DataSource = dtCliente;
        }

        void filtrarGrilla()
        {
            if (rb_IdPedidoMuestra.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                radGridView1.DataSource = miPedido.obtenerPedidosPorId(txt_idPedidoMuestra.Text);
            }
            if (rb_Cliente.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                radGridView1.DataSource = miPedido.obtenerPedidosPorCliente(int.Parse(combo_Cliente.SelectedValue.ToString()));
            }
            if (rb_Vendedor.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                radGridView1.DataSource = miPedido.obtenerPedidosPorVendedor(txt_Vendedor.Text);
            }
            if (rb_FechaSolicitud.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                radGridView1.DataSource = miPedido.obtenerPedidosPorFecha(date_FechaSolicitud_Desde.Value, date_FechaSolicitud_Hasta.Value);
            }

            for (int i = 0; i < radGridView1.Columns.Count; i++)
            {
                radGridView1.Columns[i].BestFit();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            idPedidoSeleccionado = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            btn_Cancelar.PerformClick();
        }

        private void txt_idPedidoMuestra_TextChanged(object sender, EventArgs e)
        {
            if (txt_idPedidoMuestra.Text == "")
            {
                radGridView1.DataSource = miPedido.obtenerPedidosTODOS();
            }
            else
            {
                rb_IdPedidoMuestra.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                filtrarGrilla();
            }
        }

        private void combo_Cliente_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            rb_Cliente.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            filtrarGrilla();
        }

        private void txt_Vendedor_TextChanged(object sender, EventArgs e)
        {
            if (txt_Vendedor.Text == "")
            {
                radGridView1.DataSource = miPedido.obtenerPedidosTODOS();
            }
            else
            {
                rb_Vendedor.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                filtrarGrilla();
            }
        }

        private void date_FechaSolicitud_Desde_ValueChanged(object sender, EventArgs e)
        {
            rb_FechaSolicitud.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            filtrarGrilla();
        }

        private void date_FechaSolicitud_Hasta_ValueChanged(object sender, EventArgs e)
        {
            rb_FechaSolicitud.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            filtrarGrilla();
        }

        private void btn_VerTodos_Click(object sender, EventArgs e)
        {
            radGridView1.DataSource = miPedido.obtenerPedidosTODOS();
            for (int i = 0; i < radGridView1.Columns.Count; i++)
            {
                radGridView1.Columns[i].BestFit();
            }
        }
    }
}
