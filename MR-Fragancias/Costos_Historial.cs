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
    public partial class Costos_Historial : Telerik.WinControls.UI.RadForm
    {
        public int idFragancia;
        private Negocio.Fragancia _frag = new Negocio.Fragancia();

        public Costos_Historial()
        {
            InitializeComponent();
        }

        public Costos_Historial(int _idFragancia)
        {
            InitializeComponent();
            idFragancia = _idFragancia;
        }

        private void Costos_Historial_Load(object sender, EventArgs e)
        {
            dgw.DataSource = _frag.obtenerCostos(idFragancia);
            dgw.Columns["idFragancia"].IsVisible = false;
            dgw.Columns["idCosto"].IsVisible = false;
            
            for (int i = 0; i < dgw.Columns.Count - 1; i++)
            {
                dgw.Columns[i].BestFit();
            }
        }
    }
}
