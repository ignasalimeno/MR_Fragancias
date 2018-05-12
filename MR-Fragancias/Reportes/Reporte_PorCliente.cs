using Microsoft.Reporting.WinForms;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MR_Fragancias.Reportes
{
    public partial class Reporte_PorCliente : Telerik.WinControls.UI.RadForm
    {
        public Reporte_PorCliente()
        {
            InitializeComponent();
        }

        private void Reporte_PorCliente_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cargarClientes();
            date_FechaSolicitud_Desde.Value = DateTime.Parse("1-1-" + (DateTime.Now.Year - 1).ToString());
            date_FechaSolicitud_Hasta.Value = DateTime.Now;
          
        }

        private void btn_CargarReporte_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", getReporte()));
            this.reportViewer1.RefreshReport();
        }

        DataTable getReporte()
        {
            Negocio.PedidosMuestra _miPedido = new Negocio.PedidosMuestra();

            return _miPedido.getPedidoMuestraReporte_PorCliente(int.Parse(combo_Cliente.SelectedValue.ToString()), date_FechaSolicitud_Desde.Value.ToShortDateString(), date_FechaSolicitud_Hasta.Value.ToShortDateString(), ck_Presentadas.Checked, ck_Vendidas.Checked);
        }

        void cargarClientes()
        {
            Cliente miCliente = new Cliente();
            DataTable dtCliente = miCliente.obtenerTodos();

            combo_Cliente.ValueMember = "idCliente";
            combo_Cliente.DisplayMember = "RazonSocial";

            combo_Cliente.DataSource = dtCliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
