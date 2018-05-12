using Microsoft.Reporting.WinForms;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MR_Fragancias.Reportes
{
    public partial class Reporte_PorFragancia : Form
    {
        public Reporte_PorFragancia()
        {
            InitializeComponent();
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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

            return _miPedido.getPedidoMuestraReporte_PorFragancia(int.Parse(combo_Fragancias.SelectedValue.ToString()), date_FechaSolicitud_Desde.Value.ToShortDateString(), date_FechaSolicitud_Hasta.Value.ToShortDateString(), ck_Presentadas.Checked, ck_Vendidas.Checked);
        }

        void cargarFragancias()
        {
            Fragancia miFragancia = new Fragancia();
            DataTable dtFragancia = miFragancia.obtenerTodos();

            combo_Fragancias.ValueMember = "idFragancia";
            combo_Fragancias.DisplayMember = "NombreReal";

            combo_Fragancias.DataSource = dtFragancia;
        }

        private void Reporte_PorFragancia_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cargarFragancias();
            date_FechaSolicitud_Desde.Value = DateTime.Parse("1-1-" + (DateTime.Now.Year - 1).ToString());
            date_FechaSolicitud_Hasta.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
