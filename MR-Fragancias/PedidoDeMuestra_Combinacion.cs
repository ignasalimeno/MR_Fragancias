using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Negocio;
using Telerik.WinControls.UI;

namespace MR_Fragancias
{
    public partial class PedidoDeMuestra_Combinacion : Telerik.WinControls.UI.RadForm
    {
        public PedidoDeMuestra_Combinacion()
        {
            InitializeComponent();
        }

        #region - Variables -

        public List<Fragancia> listFraganciasSeleccionadas;
        int primerFragancia = -99;
        string segundaFragancia = "-99";
        int idFragComb = 1;
        int idDPG = 0;
        int ultColor = 4;

        List<Color> _listColor = new List<Color>();
        int idListaColor = 0;

        //nuevas variables
        bool dosSeleccionadas = false;

        //Variables FragVendidas
        public string tipoConsulta = "nuevo";
        public int idPedidoMuestraGlobal = 0;

        #endregion

        #region - Eventos -

        private void PedidoDeMuestra_Combinacion_Load(object sender, EventArgs e)
        {
            if (tipoConsulta == "nuevo")
            {
                refrescarGrillaSeleccionados();
            }

            cargarClientes();

            this.WindowState = FormWindowState.Maximized;

            _listColor.Add(Color.Aqua);
            _listColor.Add(Color.LightBlue);
            _listColor.Add(Color.LightCyan);
            _listColor.Add(Color.LightGreen);
            _listColor.Add(Color.Salmon);

            btn_GuardarPedido.Tag = "validar";

            date_FechaEntregaCliente.Value = DateTime.Now;
            date_FechaSolicitud.Value = DateTime.Now;

            if (tipoConsulta == "actualizar")
            {
                cargarDatosPedidoMuestra(idPedidoMuestraGlobal);
                refresecarVisualGrilla();
                btn_GuardarPedido.Tag = "validar";
            }

            if (tipoConsulta == "vendida")
            {
                cargarDatosPedidoMuestra(idPedidoMuestraGlobal);
                refresecarVisualGrilla();
                btn_GuardarPedido.Tag = "vendida";

                gbox_InfoPedidoMuestra.Enabled = false;
                gbox_Acciones.Enabled = false;

                //DataGridViewCheckBoxColumn selColumn = new DataGridViewCheckBoxColumn();
                //selColumn.Name = "Seleccionar";
                //dataGridView1.Columns.Add(selColumn);
                //dataGridView1.AutoGenerateColumns = false;

                
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            if (btn_GuardarPedido.Tag == "validar")
            {
                if (e.ColumnIndex == 6)
                {
                    refresecarVisualGrilla();
                }
                else
                {
                    if (e.ColumnIndex == 12)
                    {
                        if (dataGridView1[5, e.RowIndex].Value.ToString() != "")
                        {
                            string idCombi = dataGridView1[5, e.RowIndex].Value.ToString();

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1[5, i].Value.ToString() == idCombi)
                                {
                                    dataGridView1[12, i].Value = dataGridView1[12, e.RowIndex].Value;
                                }
                            }
                        }
                        refresecarVisualGrilla();
                    }
                }
            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    if (dataGridView1[5, e.RowIndex].Value.ToString() != "")
                    {
                        string idCombi = dataGridView1[5, e.RowIndex].Value.ToString();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1[5, i].Value.ToString() == idCombi)
                            {
                                dataGridView1[0, i].Value = dataGridView1[0, e.RowIndex].Value;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Combinar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn selColumn = new DataGridViewCheckBoxColumn();
            selColumn.Name = "Seleccionar";
            dataGridView1.Columns.Add(selColumn);

            dataGridView1.AutoGenerateColumns = false;

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["idComb"].Value.ToString() != "")
                {
                    drow.Cells["Seleccionar"].ReadOnly = true;
                }
            }
            btn_Combinar.Enabled = false;
            btn_AgregarDPG.Enabled = false;
            btn_AceptarCombinacion.Visible = true;
            btn_AceptarCombinacion.Tag = "combinar";
            btn_CancelarCombinacion.Visible = true;
            btn_Descombinar.Enabled = false;
            btn_QuitarDPG.Enabled = false;
        }

        private void btn_AceptarCombinacion_Click(object sender, EventArgs e)
        {
            if (btn_AceptarCombinacion.Tag == "combinar") //Si es Combinación
            {
                primerFragancia = 0;
                segundaFragancia = "0";
                double sumaCostos = 0;
                int countSelecc = 0;
                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["Seleccionar"].Value != null)
                    {
                        if (drow.Cells["Seleccionar"].Value.ToString() == "True")
                        {
                            countSelecc++;
                            if (primerFragancia == 0)
                            {
                                primerFragancia = int.Parse(drow.Cells["idFragancia"].Value.ToString());
                                sumaCostos += double.Parse(drow.Cells["Costo"].Value.ToString()) *
                                               double.Parse(drow.Cells["Porcentaje"].Value.ToString()) / 100;
                            }
                            else
                            {
                                segundaFragancia = drow.Cells["idFragancia"].Value.ToString();
                                sumaCostos += double.Parse(drow.Cells["Costo"].Value.ToString()) *
                                               double.Parse(drow.Cells["Porcentaje"].Value.ToString()) / 100;
                            }
                        }
                    }
                }
                if (countSelecc == 2)
                {
                    combinar();
                    btn_CancelarCombinacion.PerformClick();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar dos fragancias para hacer la combinación.");
                }
            }

            if (btn_AceptarCombinacion.Tag == "descombinar") //Si es Descombinacion
            {
                int idCombSelected = 0;
                int countSelecc = 0;

                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["Seleccionar"].Value != null)
                    {
                        if (drow.Cells["Seleccionar"].Value.ToString() == "True")
                        {
                            countSelecc++;
                            idCombSelected = int.Parse(drow.Cells["idComb"].Value.ToString()); ;

                        }
                    }
                }
                if (countSelecc >= 2)
                {
                    MessageBox.Show("Debe seleccionar una fragancias de la combinación para descombinar.");
                }
                else
                {
                    descombinar(idCombSelected);
                    btn_CancelarCombinacion.PerformClick();
                }

            }

            if (btn_AceptarCombinacion.Tag == "agregarDPG") //Si agrega DPG
            {
                int idCombSelected = 0;
                int countSelecc = 0;
                string nombreComb = "";
                bool existeDPG = false;

                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["Seleccionar"].Value != null)
                    {
                        if (drow.Cells["Seleccionar"].Value.ToString() == "True")
                        {
                            if (drow.Cells["idComb"].Value.ToString() != "")
                            {
                                countSelecc++;
                                idCombSelected = int.Parse(drow.Cells["idComb"].Value.ToString());
                                nombreComb = drow.Cells["Nombre"].Value.ToString();
                                if (drow.Cells["NombreReal"].Value.ToString() == "DPG")
                                {
                                    existeDPG = true;
                                }
                            }
                            else
                            {
                                idCombSelected = int.Parse(drow.Cells["idFragancia"].Value.ToString());
                            }

                        }
                    }
                }

                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["idComb"].Value.ToString() != "")
                    {
                        if (int.Parse(drow.Cells["idComb"].Value.ToString()) == idCombSelected)
                        {
                            if (drow.Cells["NombreReal"].Value.ToString() == "DPG")
                            {
                                existeDPG = true;
                            }
                        }
                    }
                }

                if (existeDPG)
                {
                    MessageBox.Show("La fragancia seleccionada ya posee DPG.");
                }
                else
                {
                    if (countSelecc >= 2)
                    {
                        MessageBox.Show("Debe seleccionar una fragancia para agregar DPG.");
                    }
                    else
                    {
                        if (countSelecc > 0)
                        {
                            agregarDPG("si", idCombSelected.ToString(), nombreComb);
                        }
                        else
                        {
                            agregarDPG("no", idCombSelected.ToString(), nombreComb);
                        }
                        btn_CancelarCombinacion.PerformClick();
                    }
                }
            }

            if (btn_AceptarCombinacion.Tag == "quitarDPG") //Si agrega DPG
            {
                int idCombSelected = 0;
                bool existeDPG = false;

                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["Seleccionar"].Value != null)
                    {
                        if (drow.Cells["Seleccionar"].Value.ToString() == "True")
                        {
                            if (drow.Cells["idComb"].Value.ToString() != "")
                            {
                                idCombSelected = int.Parse(drow.Cells["idComb"].Value.ToString());
                            }
                        }
                    }
                }

                foreach (DataGridViewRow drow in dataGridView1.Rows)
                {
                    if (drow.Cells["idComb"].Value.ToString() != "")
                    {
                        if (int.Parse(drow.Cells["idComb"].Value.ToString()) == idCombSelected)
                        {
                            if (drow.Cells["NombreReal"].Value.ToString() == "DPG")
                            {
                                existeDPG = true;
                            }
                        }
                    }
                }

                if (existeDPG)
                {
                    quitarDPG(idCombSelected);
                    btn_CancelarCombinacion.PerformClick();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fragancia o combinación que tenga DPG.");
                }
            }

        }

        private void btn_CancelarCombinacion_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Seleccionar");
            btn_AceptarCombinacion.Visible = false;
            btn_CancelarCombinacion.Visible = false;
            btn_Combinar.Enabled = true;
            btn_AgregarDPG.Enabled = true;
            btn_Descombinar.Enabled = true;
            btn_QuitarDPG.Enabled = true;
        }

        private void btn_Descombinar_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn selColumn = new DataGridViewCheckBoxColumn();
            selColumn.Name = "Seleccionar";
            dataGridView1.Columns.Add(selColumn);

            dataGridView1.AutoGenerateColumns = false;

            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["idComb"].Value.ToString() == "")
                {
                    drow.Cells["Seleccionar"].ReadOnly = true;
                }
            }

            btn_Combinar.Enabled = false;
            btn_AgregarDPG.Enabled = false;
            btn_AceptarCombinacion.Visible = true;
            btn_AceptarCombinacion.Tag = "descombinar";
            btn_CancelarCombinacion.Visible = true;
            btn_QuitarDPG.Enabled = false;
            btn_Descombinar.Enabled = false;
        }

        private void btn_AgregarDPG_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn selColumn = new DataGridViewCheckBoxColumn();
            selColumn.Name = "Seleccionar";
            dataGridView1.Columns.Add(selColumn);

            dataGridView1.AutoGenerateColumns = false;


            btn_Combinar.Enabled = false;
            btn_AgregarDPG.Enabled = false;
            btn_AceptarCombinacion.Visible = true;
            btn_AceptarCombinacion.Tag = "agregarDPG";
            btn_CancelarCombinacion.Visible = true;
            btn_Descombinar.Enabled = false;
            btn_QuitarDPG.Enabled = false;
        }

        private void btn_QuitarDPG_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn selColumn = new DataGridViewCheckBoxColumn();
            selColumn.Name = "Seleccionar";
            dataGridView1.Columns.Add(selColumn);

            dataGridView1.AutoGenerateColumns = false;


            btn_Combinar.Enabled = false;
            btn_AgregarDPG.Enabled = false;
            btn_AceptarCombinacion.Visible = true;
            btn_AceptarCombinacion.Tag = "quitarDPG";
            btn_CancelarCombinacion.Visible = true;
            btn_Descombinar.Enabled = false;
            btn_QuitarDPG.Enabled = false;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combo_Cliente_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cargarContactos(int.Parse(combo_Cliente.SelectedValue.ToString()));
        }

        private void txt_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txt_Gramos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


        }

        private void btn_GuardarPedido_Click(object sender, EventArgs e)
        {
            if (btn_GuardarPedido.Tag == "validar")
            {
                if (validarGrilla())
                {
                    if (tipoConsulta == "nuevo")
                    {
                        btn_GuardarPedido.Tag = "guardar";
                    }
                    if (tipoConsulta == "actualizar")
                    {
                        btn_GuardarPedido.Tag = "actualizar";
                    }

                    MessageBox.Show("Para finalizar la carga del pedido, complete los nombres de las fragancias!", "Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                    }

                    dataGridView1.Columns["Nombre"].ReadOnly = false;
                    dataGridView1.Columns["Nombre"].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            else
            {
                //GUARDO EL PEDIDO
                if (btn_GuardarPedido.Tag == "guardar")
                {
                    DialogResult result = MessageBox.Show("¿Desea confirmar el pedido de muestra?", "Confirmar", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        int idPedidoMuestra = guardarPedidoDeMuestra();
                        if (idPedidoMuestra > 0)
                        {
                            DialogResult nResult = MessageBox.Show("El pedido se guardo correctamente." + Environment.NewLine +
                                                            " El número de pedido de es: " + idPedidoMuestra + Environment.NewLine +
                                                            "¿Desea guardar el archivo de resumen y la carta?", "Confirmación", MessageBoxButtons.YesNo);
                            if (nResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                folderBrowserDialog1.ShowDialog();
                                string path = folderBrowserDialog1.SelectedPath;
                                if (path != "")
                                {
                                    Reportes.Form_Reporte miReporteForm = new Reportes.Form_Reporte();
                                    miReporteForm.idPedidoMuestra = idPedidoMuestra;
                                    miReporteForm.pathSave = path;
                                    miReporteForm.ShowDialog();

                                    MessageBox.Show("Los archivos se generaron correctamente en: " + path, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al intentar guardar el pedido." + idPedidoMuestra, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }


                //ACTUALIZO EL PEDIDO
                if (btn_GuardarPedido.Tag == "actualizar")
                {
                    DialogResult result1 = MessageBox.Show("¿Desea confirmar las modificaciones sobre el pedido de muestra?", "Confirmar", MessageBoxButtons.YesNo);

                    if (result1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool idPedidoMuestra = actualizarPedidoDeMuestra(idPedidoMuestraGlobal);
                        if (idPedidoMuestra)
                        {
                            DialogResult nResult = MessageBox.Show("El pedido se actualizó correctamente." + Environment.NewLine +
                                                            "¿Desea guardar el archivo de resumen y la carta?", "Confirmación", MessageBoxButtons.YesNo);
                            if (nResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                folderBrowserDialog1.ShowDialog();
                                string path = folderBrowserDialog1.SelectedPath;
                                if (path != "")
                                {
                                    Reportes.Form_Reporte miReporteForm = new Reportes.Form_Reporte();
                                    miReporteForm.idPedidoMuestra = idPedidoMuestraGlobal;
                                    miReporteForm.pathSave = path;
                                    miReporteForm.ShowDialog();

                                    MessageBox.Show("Los archivos se generaron correctamente en: " + path, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al intentar actualizar el pedido." + idPedidoMuestra, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }


                //ACTUALIZO LAS QUE FUERON VENDIDAS
                if (btn_GuardarPedido.Tag == "vendida")
                {
                    Negocio.PedidosMuestra_Fragancias mifrag = new PedidosMuestra_Fragancias();

                    foreach (DataGridViewRow drow in dataGridView1.Rows)
                    {
                        if (drow.Cells["Vendida"].Value != null)
                        {
                            if (drow.Cells["Vendida"].Value.ToString() == "True")
                            {
                                mifrag.actualizarFraganciaAVendida(idPedidoMuestraGlobal, int.Parse(drow.Cells["idFragancia"].Value.ToString()));
                            }
                        }
                    }
                }
                    
            }
        }

        private void txt_Gramos_Leave(object sender, EventArgs e)
        {
            actualizarGramosyCosto();
        }

        private void txt_Costo_Leave(object sender, EventArgs e)
        {
            actualizarGramosyCosto();
        }

        #endregion

        #region - Procedimientos -

        void actualizarGramosyCosto()
        {
            try
            {
                DataTable dtNew = (DataTable)dataGridView1.DataSource;
                if (dtNew != null)
                {
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dtNew.Rows[i]["PrecioVta"] = txt_Costo.Text;
                        dtNew.Rows[i]["Gramos"] = txt_Gramos.Text;
                    }
                    dataGridView1.DataSource = dtNew;
                }
                refresecarVisualGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void refrescarGrillaSeleccionados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("idFragancia");
            dt.Columns.Add("NombreReal");
            dt.Columns.Add("idFragComb");
            dt.Columns.Add("CombPrincipal");
            dt.Columns.Add("idComb");
            dt.Columns.Add("Porcentaje");
            dt.Columns.Add("Costo");
            dt.Columns.Add("CostoCalculado");
            dt.Columns.Add("CostoComb");
            dt.Columns.Add("Gramos");
            dt.Columns.Add("Markup");
            dt.Columns.Add("PrecioVta");

            try
            {
                foreach (Fragancia item in listFraganciasSeleccionadas)
                {
                    DataRow drow = dt.NewRow();
                    drow["Nombre"] = item.NombreReal;
                    drow["idFragancia"] = item.idFragancia;
                    drow["NombreReal"] = item.NombreReal;
                    drow["Porcentaje"] = 100;
                    drow["Costo"] = item.Costo;
                    drow["CostoCalculado"] = item.Costo;
                    drow["CostoComb"] = item.Costo;
                    drow["Gramos"] = 0;
                    drow["Markup"] = 0;
                    drow["PrecioVta"] = 0;
                    dt.Rows.Add(drow);
                }

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["idFragancia"].Visible = false;
                dataGridView1.Columns["idFragcomb"].Visible = false;
                dataGridView1.Columns["CombPrincipal"].Visible = false;
                dataGridView1.Columns["idComb"].Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }

                dataGridView1.Columns["Porcentaje"].ReadOnly = false;
                dataGridView1.Columns["PrecioVta"].ReadOnly = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        void combinar()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["idFragancia"].ToString() == primerFragancia.ToString())
                {
                    dt.Rows[i]["Nombre"] = "Combinación: " + idFragComb;
                    dt.Rows[i]["idFragComb"] = segundaFragancia.ToString();
                    dt.Rows[i]["Porcentaje"] = 80;
                    dt.Rows[i]["idComb"] = idFragComb;
                    dt.Rows[i]["CombPrincipal"] = "true";
                }
                if (dt.Rows[i]["idFragancia"].ToString() == segundaFragancia.ToString())
                {
                    dt.Rows[i]["Nombre"] = "Combinación: " + idFragComb;
                    dt.Rows[i]["Porcentaje"] = 20;
                    dt.Rows[i]["idComb"] = idFragComb;
                }
            }
            idFragComb++;
            primerFragancia = -99;
            segundaFragancia = "-99";

            DataView dv = dt.DefaultView;
            dv.Sort = "idComb ASC, CombPrincipal DESC, idFragancia ASC";
            DataTable dtNew = dv.ToTable();

            dataGridView1.DataSource = dtNew;

            refresecarVisualGrilla();

        }

        void descombinar(int idComb)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["idComb"].ToString() == idComb.ToString())
                {
                    if (dt.Rows[i]["NombreReal"].ToString() != "DPG")
                    {
                        dt.Rows[i]["Nombre"] = dt.Rows[i]["NombreReal"].ToString();
                        dt.Rows[i]["idComb"] = "";
                        dt.Rows[i]["idFragComb"] = "";
                        dt.Rows[i]["Porcentaje"] = "100";
                        dt.Rows[i]["CombPrincipal"] = "";
                    }
                    else
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
            }

            dataGridView1.DataSource = dt;

            refresecarVisualGrilla();
        }

        void refresecarVisualGrilla()
        {
            //======================================================
            //--- Tratamiento sobre los datos de la grilla
            DataTable dtNew = (DataTable)dataGridView1.DataSource;

            for (int i = 0; i < dtNew.Rows.Count - 1; i++)
            {
                if (dtNew.Rows[i]["idFragComb"].ToString() != "")
                {
                    if (dtNew.Rows[i]["Nombre"].ToString() == dtNew.Rows[i + 1]["Nombre"].ToString())
                    {
                        dtNew.Rows[i]["CombPrincipal"] = "true";
                    }
                    else
                    {

                    }
                }
            }

            //Costo Calculado y Gramos
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                dtNew.Rows[i]["CostoCalculado"] = double.Parse(dtNew.Rows[i]["Costo"].ToString()) *
                                                  double.Parse(dtNew.Rows[i]["Porcentaje"].ToString()) / 100;

                dtNew.Rows[i]["Gramos"] = double.Parse(dtNew.Rows[i]["Porcentaje"].ToString()) *
                                            double.Parse(txt_Gramos.Text) / 100;
            }

            //Costo Combinación
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                if (dtNew.Rows[i]["idComb"].ToString() != "")
                {
                    double sumaComb = 0;
                    string idFragCombi = dtNew.Rows[i]["idComb"].ToString();

                    for (int j = 0; j < dtNew.Rows.Count; j++)
                    {
                        if (dtNew.Rows[j]["idComb"].ToString() == idFragCombi)
                        {
                            sumaComb += double.Parse(dtNew.Rows[j]["CostoCalculado"].ToString());
                        }
                    }

                    for (int j = 0; j < dtNew.Rows.Count; j++)
                    {
                        if (dtNew.Rows[j]["idComb"].ToString() == idFragCombi)
                        {
                            dtNew.Rows[j]["CostoComb"] = sumaComb;
                        }
                    }
                }
                else
                {
                    dtNew.Rows[i]["CostoComb"] = dtNew.Rows[i]["CostoCalculado"].ToString();
                }
            }


            //Markup
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                dtNew.Rows[i]["Markup"] = double.Parse(dtNew.Rows[i]["PrecioVta"].ToString()) /
                                          double.Parse(dtNew.Rows[i]["CostoComb"].ToString());
            }



            dataGridView1.DataSource = dtNew;

            DataView dv = dtNew.DefaultView;
            dv.Sort = "idComb ASC, idFragancia ASC";
            DataTable dtOrder = dv.ToTable();

            dataGridView1.DataSource = dtOrder;


            ////-- Calculos de Costos, Precio Venta, etc.
            //dtNew = (DataTable)dataGridView1.DataSource;
            //for (int i = 0; i < dtNew.Rows.Count; i++)
            //{

            //    //Precio Markup
            //    dtNew.Rows[i]["Markup"] = double.Parse(dtNew.Rows[i]["PrecioVta"].ToString()) /
            //                              double.Parse(dtNew.Rows[i]["CostoComb"].ToString());
            //}

            //dataGridView1.DataSource = dtNew;

            //dv = dtNew.DefaultView;
            //dv.Sort = "idComb ASC, idFragancia ASC";
            //dtOrder = dv.ToTable();

            //dataGridView1.DataSource = dtOrder;

            //======================================================



            //======================================================
            //--- Tratamiento sobre la grilla directamente
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["idComb"].Value.ToString() != "")
                {

                    int colorAPintar = int.Parse(row.Cells["idComb"].Value.ToString());

                    if (colorAPintar > 4)
                    {
                        do
                        {
                            colorAPintar = colorAPintar - 4;
                        }
                        while (colorAPintar > 4);
                    }

                    //Colorea la grilla
                    row.DefaultCellStyle.BackColor = _listColor[colorAPintar];

                    ////Si es una celda combinada, pero no principal, no puede editar.
                    //if (row.Cells["CombPrincipal"].Value.ToString() == "")
                    //{
                    //    row.Cells["Porcentaje"].ReadOnly = true;
                    //}
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            //======================================================



        }

        void agregarDPG(string esComb, string idComb, string nombreComb)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            DataRow nuevoDPG = dt.NewRow();

            nuevoDPG["Nombre"] = "DPG";
            nuevoDPG["idFragancia"] = "DPG" + idDPG;
            nuevoDPG["NombreReal"] = "DPG";
            nuevoDPG["Porcentaje"] = 20;
            nuevoDPG["Costo"] = new Negocio.DPG().obtenerCosto();
            nuevoDPG["Gramos"] = txt_Gramos.Text;
            nuevoDPG["PrecioVta"] = txt_Costo.Text;

            if (esComb == "si")
            {
                nuevoDPG["idComb"] = idComb;
                nuevoDPG["Nombre"] = nombreComb;
            }

            dt.Rows.Add(nuevoDPG);

            if (esComb == "no")
            {
                primerFragancia = int.Parse(idComb);
                segundaFragancia = "DPG" + idDPG;
                combinar();
            }

            idDPG++;

            DataView dv = dt.DefaultView;
            dv.Sort = "idComb ASC, CombPrincipal DESC, idFragancia ASC";
            DataTable dtNew = dv.ToTable();

            dataGridView1.DataSource = dtNew;

            refresecarVisualGrilla();
        }

        void quitarDPG(int idComb)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int countCantComb = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["idComb"].ToString() == idComb.ToString())
                {
                    countCantComb++;
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++) //Elimino el DPG
            {
                if (dt.Rows[i]["NombreReal"] == "DPG")
                {
                    if (dt.Rows[i]["idComb"].ToString() == idComb.ToString())
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
            }

            dataGridView1.DataSource = dt;

            if (countCantComb == 2)
            {
                //Fragancia con DPG
                descombinar(idComb);
            }

            refresecarVisualGrilla();
        }

        void cargarClientes()
        {
            Cliente miCliente = new Cliente();
            DataTable dtCliente = miCliente.obtenerTodos();

            combo_Cliente.ValueMember = "idCliente";
            combo_Cliente.DisplayMember = "RazonSocial";

            combo_Cliente.DataSource = dtCliente;
        }

        void cargarContactos(int idCliente)
        {
            Contactos miContacto = new Contactos();
            DataTable dtContactos = miContacto.obtenerTodos(idCliente);

            if (dtContactos.Rows.Count > 0)
            {
                combo_Contacto.ValueMember = "idContacto";
                combo_Contacto.DisplayMember = "Nombre";

                combo_Contacto.DataSource = dtContactos;
                combo_Contacto.Enabled = true;
            }
            else
            {
                combo_Contacto.DataSource = "";
                combo_Contacto.Enabled = false;
            }
        }

        bool validarGrilla()
        {
            //Validar porcentajes
            bool porcentajesOK = true;
            bool markupOk = true;
            DataTable dtNew = (DataTable)dataGridView1.DataSource;

            for (int i = 0; i < dtNew.Rows.Count - 1; i++)
            {
                if (double.Parse(dtNew.Rows[i]["Markup"].ToString()) <= 1.6)
                {
                    markupOk = false;
                }

                if (dtNew.Rows[i]["idComb"].ToString() == "")
                {
                    if (dtNew.Rows[i]["Porcentaje"].ToString() != "100")
                    {
                        porcentajesOK = false;
                    }
                }
                else
                {
                    int sumaComb = 0;
                    for (int j = 0; j < dtNew.Rows.Count; j++)
                    {
                        if (dtNew.Rows[i]["idComb"].ToString() == dtNew.Rows[j]["idComb"].ToString())
                        {
                            sumaComb += int.Parse(dtNew.Rows[j]["Porcentaje"].ToString());
                        }
                    }
                    if (sumaComb != 100)
                    {
                        porcentajesOK = false;
                    }
                }
            }

            if (porcentajesOK == false)
            {
                MessageBox.Show("Error con los porcentajes. Recuerde que las combinaciones y las fragancias deben sumar 100 de porcentaje.");
                return false;
            }
            else
            {
                if (markupOk == false)
                {
                    MessageBox.Show("Error con el markup. Ningún markup debe estar por debajo de 1,6");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        int guardarPedidoDeMuestra()
        {
            string anterioridFragComb = "";

            try
            {
                Negocio.PedidosMuestra mipedido = new PedidosMuestra();

                mipedido.idPedidoMuestra = 0;
                mipedido.idCliente = combo_Cliente.SelectedValue.ToString() == "" ? 0 : int.Parse(combo_Cliente.SelectedValue.ToString());
                if (combo_Contacto.SelectedValue == null)
                {
                    mipedido.idContacto = 0;
                }
                else
                {
                    mipedido.idContacto = combo_Contacto.SelectedValue.ToString() == "" ? 0 : int.Parse(combo_Contacto.SelectedValue.ToString());
                }
                    mipedido.Vendedor = txt_Vendedor.Text;
                mipedido.FechaEntregaCliente = date_FechaEntregaCliente.Value;
                mipedido.ProductoFinal = txt_ProductoFinal.Text;
                mipedido.FechaSolicitud = date_FechaSolicitud.Value;
                mipedido.Aplicacion = rb_Aplicacion_Si.IsChecked;
                mipedido.BaseCliente = rb_BaseCliente_Si.IsChecked;
                mipedido.Costo = double.Parse(txt_Costo.Text);
                mipedido.Gramos = double.Parse(txt_Gramos.Text);

                int idPedidoMuestra = mipedido.guardarPedidoMuestra(mipedido);

                if (idPedidoMuestra > 0)
                {
                    DataTable dt = (DataTable)dataGridView1.DataSource;

                    foreach (DataRow item in dt.Rows)
                    {
                        PedidosMuestra_Fragancias miFragancia = new PedidosMuestra_Fragancias();

                        miFragancia.idPedidoMuestra = idPedidoMuestra;
                        if (item["idFragancia"].ToString().StartsWith("DPG"))
                        {
                            miFragancia.idFragancia = "-99";
                        }
                        else
                        {
                            miFragancia.idFragancia = item["idFragancia"].ToString();
                        }
                        miFragancia.NombreVenta = item["Nombre"].ToString();
                        miFragancia.NombreReal = item["NombreReal"].ToString();
                        if (item["idFragComb"].ToString() == "")
                        {
                            miFragancia.idFragComb = "0";
                        }
                        else
                        {
                            if (item["idFragComb"].ToString().StartsWith("DPG"))
                            {
                                miFragancia.idFragComb = anterioridFragComb;
                            }
                            else
                            {
                                miFragancia.idFragComb = item["idFragComb"].ToString();
                            }
                        }
                        //miFragancia.idFragComb = item["idFragComb"].ToString() == "" ? "0" : item["idFragComb"].ToString();
                        anterioridFragComb = miFragancia.idFragComb;
                        miFragancia.CombPrincipal = item["CombPrincipal"].ToString();
                        miFragancia.idComb = item["idComb"].ToString() == "" ? 0 : int.Parse(item["idComb"].ToString()); ;
                        miFragancia.Porcentaje = item["Porcentaje"].ToString() == "" ? 0 : double.Parse(item["Porcentaje"].ToString());
                        miFragancia.Costo = item["Costo"].ToString() == "" ? 0 : double.Parse(item["Costo"].ToString());
                        miFragancia.CostoCalculado = item["CostoCalculado"].ToString() == "" ? 0 : double.Parse(item["CostoCalculado"].ToString());
                        miFragancia.CostoComb = item["CostoComb"].ToString() == "" ? 0 : double.Parse(item["CostoComb"].ToString());
                        miFragancia.Gramos = item["Gramos"].ToString() == "" ? 0 : double.Parse(item["Gramos"].ToString());
                        miFragancia.Markup = item["Markup"].ToString() == "" ? 0 : double.Parse(item["Markup"].ToString());
                        miFragancia.PrecioVta = item["PrecioVta"].ToString() == "" ? 0 : double.Parse(item["PrecioVta"].ToString());
                        miFragancia.Presentada = true;
                        miFragancia.Vendida = false;

                        if (miFragancia.guardarPedidosMuestraFragancias(miFragancia) == false)
                        {
                            throw new Exception();
                        }
                    }

                    return idPedidoMuestra;
                }
                else
                {
                    mipedido.borrarPedidoMuestra(mipedido.idPedidoMuestra);
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        bool actualizarPedidoDeMuestra(int idpedido)
        {
            try
            {
                Negocio.PedidosMuestra mipedido = new PedidosMuestra();

                mipedido.idPedidoMuestra = idpedido;
                mipedido.idCliente = combo_Cliente.SelectedValue.ToString() == "" ? 0 : int.Parse(combo_Cliente.SelectedValue.ToString());
                mipedido.idContacto = combo_Contacto.SelectedValue.ToString() == "" ? 0 : int.Parse(combo_Contacto.SelectedValue.ToString());
                mipedido.Vendedor = txt_Vendedor.Text;
                mipedido.FechaEntregaCliente = date_FechaEntregaCliente.Value;
                mipedido.ProductoFinal = txt_ProductoFinal.Text;
                mipedido.FechaSolicitud = date_FechaSolicitud.Value;
                mipedido.Aplicacion = rb_Aplicacion_Si.IsChecked;
                mipedido.BaseCliente = rb_BaseCliente_Si.IsChecked;
                mipedido.Costo = double.Parse(txt_Costo.Text);
                mipedido.Gramos = double.Parse(txt_Gramos.Text);

                bool idPedidoMuestra = mipedido.actualizarPedidoMuestra(mipedido);

                if (idPedidoMuestra)
                {
                    if (mipedido.borrarPedidoMuestraFragancias(idPedidoMuestraGlobal)) 
                    {
                        DataTable dt = (DataTable)dataGridView1.DataSource;

                        foreach (DataRow item in dt.Rows)
                        {
                            PedidosMuestra_Fragancias miFragancia = new PedidosMuestra_Fragancias();

                            miFragancia.idPedidoMuestra = idpedido;
                            miFragancia.idFragancia = item["idFragancia"].ToString();
                            miFragancia.NombreVenta = item["Nombre"].ToString();
                            miFragancia.NombreReal = item["NombreReal"].ToString();
                            miFragancia.idFragComb = item["idFragComb"].ToString() == "" ? "0" : item["idFragComb"].ToString();
                            miFragancia.CombPrincipal = item["CombPrincipal"].ToString();
                            miFragancia.idComb = item["idComb"].ToString() == "" ? 0 : int.Parse(item["idComb"].ToString()); ;
                            miFragancia.Porcentaje = item["Porcentaje"].ToString() == "" ? 0 : double.Parse(item["Porcentaje"].ToString());
                            miFragancia.Costo = item["Costo"].ToString() == "" ? 0 : double.Parse(item["Costo"].ToString());
                            miFragancia.CostoCalculado = item["CostoCalculado"].ToString() == "" ? 0 : double.Parse(item["CostoCalculado"].ToString());
                            miFragancia.CostoComb = item["CostoComb"].ToString() == "" ? 0 : double.Parse(item["CostoComb"].ToString());
                            miFragancia.Gramos = item["Gramos"].ToString() == "" ? 0 : double.Parse(item["Gramos"].ToString());
                            miFragancia.Markup = item["Markup"].ToString() == "" ? 0 : double.Parse(item["Markup"].ToString());
                            miFragancia.PrecioVta = item["PrecioVta"].ToString() == "" ? 0 : double.Parse(item["PrecioVta"].ToString());
                            miFragancia.Presentada = true;
                            miFragancia.Vendida = bool.Parse(item["Vendida"].ToString());

                            if (miFragancia.guardarPedidosMuestraFragancias(miFragancia) == false)
                            {
                                throw new Exception();
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;  
                    }
                    
                }
                else
                {
                    //mipedido.borrarPedidoMuestra(mipedido.idPedidoMuestra);
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        void cargarDatosPedidoMuestra(int idPedidoMuestra)
        {
            Negocio.PedidosMuestra _miPedidoMuestra = new PedidosMuestra();
            _miPedidoMuestra = _miPedidoMuestra.get1PedidoMuestra(idPedidoMuestra);

            //Cargo datos en el form
            this.Text = _miPedidoMuestra.idPedidoMuestra.ToString();
            txt_Vendedor.Text = _miPedidoMuestra.Vendedor.ToString();
            combo_Cliente.SelectedValue = _miPedidoMuestra.idCliente;
            combo_Contacto.SelectedValue = _miPedidoMuestra.idContacto;
            date_FechaEntregaCliente.Value = _miPedidoMuestra.FechaEntregaCliente;
            txt_ProductoFinal.Text = _miPedidoMuestra.ProductoFinal;
            date_FechaSolicitud.Value = _miPedidoMuestra.FechaSolicitud;
            rb_Aplicacion_Si.IsChecked = _miPedidoMuestra.Aplicacion;
            rb_BaseCliente_Si.IsChecked = _miPedidoMuestra.BaseCliente;
            txt_Costo.Text = _miPedidoMuestra.Costo.ToString();
            txt_Gramos.Text = _miPedidoMuestra.Gramos.ToString();

            //Cargo las fragancias
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("idFragancia");
            dt.Columns.Add("NombreReal");
            dt.Columns.Add("idFragComb");
            dt.Columns.Add("CombPrincipal");
            dt.Columns.Add("idComb");
            dt.Columns.Add("Porcentaje");
            dt.Columns.Add("Costo");
            dt.Columns.Add("CostoCalculado");
            dt.Columns.Add("CostoComb");
            dt.Columns.Add("Gramos");
            dt.Columns.Add("Markup");
            dt.Columns.Add("PrecioVta");
            dt.Columns.Add(new DataColumn("Vendida", typeof(bool)));

            try
            {
                foreach (PedidosMuestra_Fragancias item in _miPedidoMuestra.fragancias)
                {
                    DataRow drow = dt.NewRow();
                    drow["Nombre"] = item.NombreVenta;
                    drow["idFragancia"] = item.idFragancia;
                    drow["NombreReal"] = item.NombreReal;
                    drow["idFragComb"] = item.idFragComb;
                    drow["CombPrincipal"] = item.CombPrincipal;
                    drow["idComb"] = item.idComb;
                    drow["Porcentaje"] = item.Porcentaje;
                    drow["Costo"] = item.Costo;
                    drow["CostoCalculado"] = item.Costo;
                    drow["CostoComb"] = item.Costo;
                    drow["Gramos"] = item.Gramos;
                    drow["Markup"] = item.Markup;
                    drow["PrecioVta"] = item.PrecioVta;
                    drow["Vendida"] = item.Vendida;
                    dt.Rows.Add(drow);
                }

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["idFragancia"].Visible = false;
                dataGridView1.Columns["idFragcomb"].Visible = false;
                dataGridView1.Columns["CombPrincipal"].Visible = false;
                dataGridView1.Columns["idComb"].Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }

                dataGridView1.Columns["Porcentaje"].ReadOnly = false;
                dataGridView1.Columns["PrecioVta"].ReadOnly = false;
                dataGridView1.Columns["Vendida"].ReadOnly = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        

    }
}
