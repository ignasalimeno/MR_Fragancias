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
    public partial class PedidoDeMuestra : Telerik.WinControls.UI.RadForm
    {
        public PedidoDeMuestra()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn1 = new GridViewCommandColumn();
            commandColumn1.UseDefaultText = true;
            commandColumn1.DefaultText = "Seleccionar";
            commandColumn1.FieldName = "Seleccionar";
            commandColumn1.HeaderText = "Seleccionar";
            dgw.Columns.Add(commandColumn1);
            dgw.CommandCellClick += new CommandCellClickEventHandler(dgw_CommandCellClick);
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.UseDefaultText = true;
            commandColumn2.DefaultText = "Seleccionar";
            commandColumn2.FieldName = "Seleccionar";
            commandColumn2.HeaderText = "Seleccionar";
            dgw_Seleccionados.Columns.Add(commandColumn2);
            dgw_Seleccionados.CommandCellClick += new CommandCellClickEventHandler(dgw_Seleccionados_CommandCellClick);
        }

        #region - Variables -
        public bool pedidoNuevo;
        Fragancia _mifragancia = new Fragancia();
        int idObjetoActual = 0;
        public List<Fragancia> _listFraganciasSeleccionadas = new List<Fragancia>();

        #endregion

        #region - Eventos -

        private void btn_Expand_Nombre_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Nombre.Tag == "Menos")
            {
                btn_Expand_Nombre.Tag = "Mas";
                btn_Expand_Nombre.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Nombre.Tag = "Menos";
                btn_Expand_Nombre.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Costo_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Costo.Tag == "Menos")
            {
                btn_Expand_Costo.Tag = "Mas";
                btn_Expand_Costo.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Costo.Tag = "Menos";
                btn_Expand_Costo.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Estado_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Estado.Tag == "Menos")
            {
                btn_Expand_Estado.Tag = "Mas";
                btn_Expand_Estado.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Estado.Tag = "Menos";
                btn_Expand_Estado.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Aplicaciones_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Aplicaciones.Tag == "Menos")
            {
                btn_Expand_Aplicaciones.Tag = "Mas";
                btn_Expand_Aplicaciones.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Aplicaciones.Tag = "Menos";
                btn_Expand_Aplicaciones.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Familias_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Familias.Tag == "Menos")
            {
                btn_Expand_Familias.Tag = "Mas";
                btn_Expand_Familias.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Familias.Tag = "Menos";
                btn_Expand_Familias.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Notas_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Notas.Tag == "Menos")
            {
                btn_Expand_Notas.Tag = "Mas";
                btn_Expand_Notas.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Notas.Tag = "Menos";
                btn_Expand_Notas.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        private void btn_Expand_Contratipo_Click(object sender, EventArgs e)
        {
            if (btn_Expand_Contratipo.Tag == "Menos")
            {
                btn_Expand_Contratipo.Tag = "Mas";
                btn_Expand_Contratipo.Image = MR_Fragancias.Properties.Resources.add_15x15;
            }
            else
            {
                btn_Expand_Contratipo.Tag = "Menos";
                btn_Expand_Contratipo.Image = MR_Fragancias.Properties.Resources.minus_15x15;
            }
            orderForm();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //((Principal)this.ParentForm).expandirBarra();
        }

        private void PedidoDeMuestra_Load(object sender, EventArgs e)
        {
            dgw.DataSource = _mifragancia.obtenerTodos();
            cargarFamiliasOlfativas();
            cargarEstados();
            cargarAplicaciones();
            btn_Expand_Aplicaciones.PerformClick();
            btn_Expand_Aplicaciones.PerformClick();

            if (dgw.Rows.Count > 0)
            {
                //ARREGLAR dgw_CellClick(dgw, new Telerik.WinControls.UI.GridViewCellEventArgs(dgw.Rows[0], dgw.Columns[0]));
            }
            else
            {
                idObjetoActual = -99;

                foreach (Control item in this.gb_Objeto.Controls)
                {
                    if (item is Telerik.WinControls.UI.RadTextBox)
                    {
                        Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                        _item.Text = "";
                    }
                }
            }

            this.WindowState = FormWindowState.Maximized;
            btn_Cerrar.Location = new Point(gb_Objeto.Width + 85, gb_Objeto.Location.Y + 12);

            for (int i = 1; i < dgw.Columns.Count; i++)
            {
                dgw.Columns[i].ReadOnly = true;
                dgw.Columns[i].BestFit();
            }

            dgw.Columns["idFragancia"].IsVisible = false;
            dgw.Columns["NombreVenta"].IsVisible = false;
            dgw.Columns["idFamiliaOlfativa"].IsVisible = false;
            dgw.Columns["DescOlfativa_NotaSalida"].IsVisible = false;
            dgw.Columns["DescOlfativa_NotaMedia"].IsVisible = false;
            dgw.Columns["DescOlfativa_NotaFondo"].IsVisible = false;
            dgw.Columns["FechaPedidoStock"].IsVisible = false;
            dgw.Columns["idEstado"].IsVisible = false;
            dgw.Columns["ContratipoNombre"].IsVisible = false;
            dgw.Columns["ContratipoMarca"].IsVisible = false;
            dgw.Columns["ContratipoAño"].IsVisible = false;
            dgw.Columns["Equivalencia"].IsVisible = false;
            dgw.Columns["Identificador"].IsVisible = false;
            dgw.Columns["Activo"].IsVisible = false;
            dgw.Columns["Costo"].IsVisible = false;
            dgw.Columns["FechaActCosto"].IsVisible = false;

            refrescarGrillaSeleccionados();

            pedidoNuevo = true;
        }

        private void dgw_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idObjetoActual = int.Parse(dgw.Rows[e.RowIndex].Cells[1].Value.ToString());

                foreach (Control item in this.gb_Objeto.Controls)
                {
                    if (item is Telerik.WinControls.UI.RadTextBox)
                    {
                        Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                        try
                        {
                            _item.Text = dgw.Rows[e.RowIndex].Cells[_item.Name.Substring(4)].Value.ToString(); ;
                        }
                        catch (Exception)
                        {
                            _item.Text = "Error al cargar";
                        }
                    }
                    if (item is Telerik.WinControls.UI.RadDropDownList)
                    {
                        Telerik.WinControls.UI.RadDropDownList _item = (Telerik.WinControls.UI.RadDropDownList)item;
                        try
                        {
                            _item.SelectedValue = int.Parse(dgw.Rows[e.RowIndex].Cells[_item.Name.Substring(6)].Value.ToString());
                        }
                        catch (Exception)
                        {
                            _item.Text = "Error al cargar";
                        }
                    }
                    if (item is System.Windows.Forms.DateTimePicker)
                    {
                        System.Windows.Forms.DateTimePicker _item = (System.Windows.Forms.DateTimePicker)item;
                        try
                        {
                            _item.Text = dgw.Rows[e.RowIndex].Cells[_item.Name.Substring(5)].Value.ToString();
                        }
                        catch (Exception)
                        {
                            _item.Text = "Error al cargar";
                        }
                    }
                }

                //Codigo especial para costo
                if (dgw.Rows[e.RowIndex].Cells["Costo"].Value.ToString() != "")
                {
                    txt_Costo.Text = dgw.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
                    lbl_FechaActCosto.Text = dgw.Rows[e.RowIndex].Cells["FechaActCosto"].Value.ToString().Substring(0, 10);

                }
                else
                {
                    txt_Costo.Text = "";
                    lbl_FechaActCosto.Text = "";
                }

                //Agregar cuando se selecciona una fragancia
                if (e.ColumnIndex == 0)
                {
                    if (this.dgw.Rows[e.RowIndex].Cells["Seleccionar"].Value != DBNull.Value)
                    {
                        if (Convert.ToBoolean(this.dgw.Rows[e.RowIndex].Cells["Seleccionar"].Value))
                        {
                            Fragancia _newFrag = new Fragancia();
                            _newFrag.idEstado = int.Parse(dgw.Rows[e.RowIndex].Cells["idFragancia"].Value.ToString());
                            _newFrag.NombreReal = dgw.Rows[e.RowIndex].Cells["NombreReal"].Value.ToString();

                            _listFraganciasSeleccionadas.Add(_newFrag);
                        }
                        dgw_Seleccionados.DataSource = _listFraganciasSeleccionadas;
                    }
                }
            }
        }

        private void btn_Costos_Historial_Click(object sender, EventArgs e)
        {
            Costos_Historial _costoForm = new Costos_Historial(idObjetoActual);
            _costoForm.ShowDialog();
        }

        private void btn_VerTodos_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = false;
            bool columnChecked = false;

            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                if (dgw.Rows[i].Cells["Seleccionar"].Value != DBNull.Value)
                {
                    if (Convert.ToBoolean(this.dgw.Rows[i].Cells["Seleccionar"].Value))
                    {
                        columnChecked = true;
                    }
                }
            }
            if (columnChecked)
            {
                DialogResult dgRes = MessageBox.Show("Se borrarán las fragancias seleccionadas. ¿Desa continuar?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    dgw.DataSource = _mifragancia.obtenerTodos();
                }
            }
            else
            {
                dgw.DataSource = _mifragancia.obtenerTodos();
            }

        }

        private void btn_Estado_Sel_Click(object sender, EventArgs e)
        {
            if (listbox_EstadosDes.SelectedItems.Count > 0)
            {
                listbox_EstadosSel.Items.Add(listbox_EstadosDes.SelectedItem);
                listbox_EstadosDes.Items.Remove(listbox_EstadosDes.SelectedItem);
            }
        }

        private void btn_Estados_Des_Click(object sender, EventArgs e)
        {
            if (listbox_EstadosSel.SelectedItems.Count > 0)
            {
                listbox_EstadosDes.Items.Add(listbox_EstadosSel.SelectedItem);
                listbox_EstadosSel.Items.Remove(listbox_EstadosSel.SelectedItem);
            }
        }

        private void btn_Estado_SelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listbox_EstadosDes.Items.Count; i++)
            {
                listbox_EstadosSel.Items.Add(listbox_EstadosDes.Items[i]);
            }
            listbox_EstadosDes.Items.Clear();
        }

        private void btn_Estados_DesAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listbox_EstadosSel.Items.Count; i++)
            {
                listbox_EstadosDes.Items.Add(listbox_EstadosSel.Items[i]);
            }
            listbox_EstadosSel.Items.Clear();
        }

        private void btn_Aplicaciones_DesAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_AplicacionesSel.Items.Count; i++)
            {
                listBox_AplicacionesDes.Items.Add(listBox_AplicacionesSel.Items[i]);
            }
            listBox_AplicacionesSel.Items.Clear();
        }

        private void btn_Aplicaciones_Des_Click(object sender, EventArgs e)
        {
            if (listBox_AplicacionesSel.SelectedItems.Count > 0)
            {
                listBox_AplicacionesDes.Items.Add(listBox_AplicacionesSel.SelectedItem);
                listBox_AplicacionesSel.Items.Remove(listBox_AplicacionesSel.SelectedItem);
            }
        }

        private void btn_Aplicaciones_Sel_Click(object sender, EventArgs e)
        {
            if (listBox_AplicacionesDes.SelectedItems.Count > 0)
            {
                listBox_AplicacionesSel.Items.Add(listBox_AplicacionesDes.SelectedItem);
                listBox_AplicacionesDes.Items.Remove(listBox_AplicacionesDes.SelectedItem);
            }
        }

        private void btn_Aplicaciones_SelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_AplicacionesDes.Items.Count; i++)
            {
                listBox_AplicacionesSel.Items.Add(listBox_AplicacionesDes.Items[i]);
            }
            listBox_AplicacionesDes.Items.Clear();
        }

        private void btn_FamiliasOlfativas_DesAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_FamiliaOlfativaSel.Items.Count; i++)
            {
                listBox_FamiliaOlfativaDes.Items.Add(listBox_FamiliaOlfativaSel.Items[i]);
            }
            listBox_FamiliaOlfativaSel.Items.Clear();
        }

        private void btn_FamiliasOlfativas_Des_Click(object sender, EventArgs e)
        {
            if (listBox_FamiliaOlfativaSel.SelectedItems.Count > 0)
            {
                listBox_FamiliaOlfativaDes.Items.Add(listBox_FamiliaOlfativaSel.SelectedItem);
                listBox_FamiliaOlfativaSel.Items.Remove(listBox_FamiliaOlfativaSel.SelectedItem);
            }
        }

        private void btn_FamiliasOlfativas_Sel_Click(object sender, EventArgs e)
        {
            if (listBox_FamiliaOlfativaDes.SelectedItems.Count > 0)
            {
                listBox_FamiliaOlfativaSel.Items.Add(listBox_FamiliaOlfativaDes.SelectedItem);
                listBox_FamiliaOlfativaDes.Items.Remove(listBox_FamiliaOlfativaDes.SelectedItem);
            }
        }

        private void btn_FamiliasOlfativas_SelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_FamiliaOlfativaDes.Items.Count; i++)
            {
                listBox_FamiliaOlfativaSel.Items.Add(listBox_FamiliaOlfativaDes.Items[i]);
            }
            listBox_FamiliaOlfativaDes.Items.Clear();
        }

        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            bool columnChecked = false;

            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                if (dgw.Rows[i].Cells["Seleccionar"].Value != DBNull.Value)
                {
                    if (Convert.ToBoolean(this.dgw.Rows[i].Cells["Seleccionar"].Value))
                    {
                        columnChecked = true;
                    }
                }
            }
            if (columnChecked)
            {
                DialogResult dgRes = MessageBox.Show("Se borrarán las fragancias seleccionadas. ¿Desa continuar?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    filtrar();
                }
            }
            else
            {
                filtrar();
            }
        }
        
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_VerAplicaciones_Click(object sender, EventArgs e)
        {
            Fragancias_Aplicaciones _apliForm = new Fragancias_Aplicaciones();
            _apliForm.idFragancia = idObjetoActual;
            _apliForm.ShowDialog();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                splitContainer1.SplitterDistance = 420;
            }
            base.OnSizeChanged(e);
        }

        private void dgw_ValueChanged(object sender, EventArgs e)
        {
            //RadCheckBoxEditor check_editor = sender as RadCheckBoxEditor;

            //if (check_editor == null)
            //    return;

            //if ((bool)check_editor.Value == true)
            //{
            //    // You can make all other check boxes disabled here

            //    Fragancia _newFrag = new Fragancia();
            //    //_newFrag.idEstado = int.Parse(dgw.Rows[check_editor.ce].Cells["idFragancia"].Value.ToString());
            //    //_newFrag.NombreReal = dgw.Rows[e.RowIndex].Cells["NombreReal"].Value.ToString();

            //    _listFraganciasSeleccionadas.Add(_newFrag);

            //    dgw_Seleccionados.DataSource = _listFraganciasSeleccionadas;
            //}
        }

        private void dgw_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            RadCheckBoxEditor check_editor = sender as RadCheckBoxEditor;

            if (check_editor == null)
                return;

            if ((bool)check_editor.Value == true)
            {
                // You can make all other check boxes disabled here

                Fragancia _newFrag = new Fragancia();
                _newFrag.idEstado = int.Parse(dgw.Rows[e.RowIndex].Cells["idFragancia"].Value.ToString());
                _newFrag.NombreReal = dgw.Rows[e.RowIndex].Cells["NombreReal"].Value.ToString();

                _listFraganciasSeleccionadas.Add(_newFrag);

                dgw_Seleccionados.DataSource = _listFraganciasSeleccionadas;
            }
        }

        private void dgw_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int a = 0;

        }

        void dgw_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement check_editor = sender as GridCommandCellElement;

            //ARREGLAR dgw_CellClick(dgw, new Telerik.WinControls.UI.GridViewCellEventArgs(dgw.Rows[check_editor.RowIndex], dgw.Columns[check_editor.ColumnIndex]));

            foreach (Fragancia item in _listFraganciasSeleccionadas)
            {
                if (item.idFragancia == int.Parse(dgw.Rows[check_editor.RowIndex].Cells["idFragancia"].Value.ToString()))
                {
                    MessageBox.Show("La fragancia ya está seleccionada.");
                    refrescarGrillaSeleccionados();
                    return;
                }
            }

            Fragancia _newFrag = new Fragancia();
            _newFrag.idFragancia = int.Parse(dgw.Rows[check_editor.RowIndex].Cells["idFragancia"].Value.ToString());
            _newFrag.NombreReal = dgw.Rows[check_editor.RowIndex].Cells["NombreReal"].Value.ToString();
            _newFrag.Costo = (txt_Costo.Text != "") ? float.Parse(txt_Costo.Text) : 0;

            _listFraganciasSeleccionadas.Add(_newFrag);

            refrescarGrillaSeleccionados();
        }

        void dgw_Seleccionados_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement check_editor = sender as GridCommandCellElement;
            _listFraganciasSeleccionadas.RemoveAt(check_editor.RowIndex);
            refrescarGrillaSeleccionados();
        }

        private void btn_Continuar_Click(object sender, EventArgs e)
        {
            if (pedidoNuevo)
            {
                //PedidoDeMuestra_Combinacion _formNew = new PedidoDeMuestra_Combinacion();
                //_formNew.listFraganciasSeleccionadas = _listFraganciasSeleccionadas;
                //var result = _formNew.ShowDialog();
                //if (result == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.Close();
                //}
                this.Close();
            }
            else
            {

            }

        }

        private void dgw_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            lbl_Total.Text = "Cantidad de fragancias filtradas: " + dgw.RowCount.ToString();
        }

        #endregion

        #region - Prodecimientos -

        void orderForm()
        {
            //Nombre
            if (btn_Expand_Nombre.Tag == "Menos")
            {
                group_Nombre.Visible = true;
                group_Nombre.Location = new Point(3, check_Nombre.Location.Y + 24);
                linea_Nombre.Y1 = check_Nombre.Location.Y + group_Nombre.Size.Height + 30;
            }
            else
            {
                group_Nombre.Visible = false;
                linea_Nombre.Y1 = check_Nombre.Location.Y + 25;
            }
            btn_Expand_Costo.Location = new Point(3, linea_Nombre.Y1 + 10);
            check_Costo.Location = new Point(25, linea_Nombre.Y1 + 10);
            group_Costos.Location = new Point(3, check_Costo.Location.Y + 24);
            linea_Nombre.X1 = 0;
            linea_Nombre.X2 = splitContainer1.Panel1.Width;
            linea_Nombre.Y2 = linea_Nombre.Y1;

            //Costos
            if (btn_Expand_Costo.Tag == "Menos")
            {
                group_Costos.Visible = true;
                group_Costos.Location = new Point(3, check_Costo.Location.Y + 24);
                linea_Costo.Y1 = check_Costo.Location.Y + group_Costos.Size.Height + 30;
            }
            else
            {
                group_Costos.Visible = false;
                linea_Costo.Y1 = check_Costo.Location.Y + 25;
            }
            btn_Expand_Estado.Location = new Point(3, linea_Costo.Y1 + 10);
            check_Estado.Location = new Point(25, linea_Costo.Y1 + 10);
            group_Estados.Location = new Point(3, check_Estado.Location.Y + 24);
            linea_Costo.X1 = 0;
            linea_Costo.X2 = splitContainer1.Panel1.Width;
            linea_Costo.Y2 = linea_Costo.Y1;

            //Estados
            if (btn_Expand_Estado.Tag == "Menos")
            {
                group_Estados.Visible = true;
                group_Estados.Location = new Point(3, check_Estado.Location.Y + 24);
                linea_Estado.Y1 = check_Estado.Location.Y + group_Estados.Size.Height + 30;
            }
            else
            {
                group_Estados.Visible = false;
                linea_Estado.Y1 = check_Estado.Location.Y + 25;
            }
            btn_Expand_Aplicaciones.Location = new Point(3, linea_Estado.Y1 + 10);
            check_Aplicaciones.Location = new Point(25, linea_Estado.Y1 + 10);
            group_Aplicaciones.Location = new Point(3, check_Aplicaciones.Location.Y + 24);
            linea_Estado.X1 = 0;
            linea_Estado.X2 = splitContainer1.Panel1.Width;
            linea_Estado.Y2 = linea_Estado.Y1;

            //Aplicaciones
            if (btn_Expand_Aplicaciones.Tag == "Menos")
            {
                group_Aplicaciones.Visible = true;
                group_Aplicaciones.Location = new Point(3, check_Aplicaciones.Location.Y + 24);
                linea_Aplicaciones.Y1 = check_Aplicaciones.Location.Y + group_Aplicaciones.Size.Height + 30;
            }
            else
            {
                group_Aplicaciones.Visible = false;
                linea_Aplicaciones.Y1 = check_Aplicaciones.Location.Y + 25;
            }
            btn_Expand_Familias.Location = new Point(3, linea_Aplicaciones.Y1 + 10);
            check_Familias.Location = new Point(25, linea_Aplicaciones.Y1 + 10);
            group_Familias.Location = new Point(3, check_Familias.Location.Y + 24);
            linea_Aplicaciones.X1 = 0;
            linea_Aplicaciones.X2 = splitContainer1.Panel1.Width;
            linea_Aplicaciones.Y2 = linea_Aplicaciones.Y1;

            //Familias
            if (btn_Expand_Familias.Tag == "Menos")
            {
                group_Familias.Visible = true;
                group_Familias.Location = new Point(3, check_Familias.Location.Y + 24);
                linea_Familias.Y1 = check_Familias.Location.Y + group_Familias.Size.Height + 30;
            }
            else
            {
                group_Familias.Visible = false;
                linea_Familias.Y1 = check_Familias.Location.Y + 25;
            }
            btn_Expand_Notas.Location = new Point(3, linea_Familias.Y1 + 10);
            check_Notas.Location = new Point(25, linea_Familias.Y1 + 10);
            group_Notas.Location = new Point(3, check_Notas.Location.Y + 24);
            linea_Familias.X1 = 0;
            linea_Familias.X2 = splitContainer1.Panel1.Width;
            linea_Familias.Y2 = linea_Familias.Y1;

            //Notas
            if (btn_Expand_Notas.Tag == "Menos")
            {
                group_Notas.Visible = true;
                group_Notas.Location = new Point(3, check_Notas.Location.Y + 24);
                linea_Notas.Y1 = check_Notas.Location.Y + group_Notas.Size.Height + 30;
            }
            else
            {
                group_Notas.Visible = false;
                linea_Notas.Y1 = check_Notas.Location.Y + 25;
            }
            btn_Expand_Contratipo.Location = new Point(3, linea_Notas.Y1 + 10);
            check_Contratipo.Location = new Point(25, linea_Notas.Y1 + 10);
            group_Contratipo.Location = new Point(3, check_Contratipo.Location.Y + 24);
            linea_Notas.X1 = 0;
            linea_Notas.X2 = splitContainer1.Panel1.Width;
            linea_Notas.Y2 = linea_Notas.Y1;

            //Contratipo
            if (btn_Expand_Contratipo.Tag == "Menos")
            {
                group_Contratipo.Visible = true;
                group_Contratipo.Location = new Point(3, check_Contratipo.Location.Y + 24);
                linea_Contratipo.Y1 = check_Contratipo.Location.Y + group_Contratipo.Size.Height + 30;
            }
            else
            {
                group_Contratipo.Visible = false;
                linea_Contratipo.Y1 = check_Contratipo.Location.Y + 25;
            }
            //btn_Expand_Contratipo.Location = new Point(3, linea_Contratipo.Y1 + 10);
            //check_Contratipo.Location = new Point(25, linea_Contratipo.Y1 + 10);
            //group_Contratipo.Location = new Point(3, check_Contratipo.Location.Y + 24);
            linea_Contratipo.X1 = 0;
            linea_Contratipo.X2 = splitContainer1.Panel1.Width;
            linea_Contratipo.Y2 = linea_Contratipo.Y1;
        }

        private void cargarFamiliasOlfativas()
        {
            Negocio.FamiliasOlfativas _familia = new Negocio.FamiliasOlfativas();
            combo_idFamiliaOlfativa.DataSource = _familia.obtenerTodos();
            combo_idFamiliaOlfativa.ValueMember = "idFamiliaOlfativa";
            combo_idFamiliaOlfativa.DisplayMember = "Nombre";

            DataTable familias = _familia.obtenerTodos();

            if (familias.Rows.Count > 0)
            {
                for (int i = 0; i < familias.Rows.Count; i++)
                {
                    listBox_FamiliaOlfativaDes.Items.Add(familias.Rows[i]["Nombre"].ToString());
                }
            }
        }

        private void cargarEstados()
        {
            Negocio.Estados _estado = new Negocio.Estados();
            combo_idEstado.DataSource = _estado.obtenerTodos();
            combo_idEstado.ValueMember = "idEstado";
            combo_idEstado.DisplayMember = "Estado";

            DataTable estados = _estado.obtenerTodos();

            if (estados.Rows.Count > 0)
            {
                for (int i = 0; i < estados.Rows.Count; i++)
                {
                    listbox_EstadosDes.Items.Add(estados.Rows[i]["Estado"].ToString());
                }
            }
        }

        private void cargarAplicaciones()
        {
            Negocio.Aplicaciones _aplicaciones = new Negocio.Aplicaciones();
            DataTable aplicaciones = _aplicaciones.obtenerTodos();

            if (aplicaciones.Rows.Count > 0)
            {
                for (int i = 0; i < aplicaciones.Rows.Count; i++)
                {
                    listBox_AplicacionesDes.Items.Add(aplicaciones.Rows[i]["Nombre"].ToString());
                }
            }
        }

        void filtrar()
        {
            List<string> _listAplicacion = new List<string>();
            List<string> _listIDAplicacion = new List<string>();
            for (int i = 0; i < listBox_AplicacionesSel.Items.Count; i++)
            {
                _listAplicacion.Add(listBox_AplicacionesSel.Items[i].ToString());
            }
            Aplicaciones _apli = new Aplicaciones();
            _listIDAplicacion = _apli.obtenerIdsPorNombre(_listAplicacion);

            List<string> _listEstados = new List<string>();
            List<string> _listIDEstados = new List<string>();
            for (int i = 0; i < listbox_EstadosSel.Items.Count; i++)
            {
                _listEstados.Add(listbox_EstadosSel.Items[i].ToString());
            }
            Estados _estado = new Estados();
            _listIDEstados = _estado.obtenerIdsPorNombre(_listEstados);

            List<string> _listFamilias = new List<string>();
            List<string> _listIDFamilias = new List<string>();
            for (int i = 0; i < listBox_FamiliaOlfativaSel.Items.Count; i++)
            {
                _listFamilias.Add(listBox_FamiliaOlfativaSel.Items[i].ToString());
            }
            FamiliasOlfativas _familias = new FamiliasOlfativas();
            _listIDFamilias = _familias.obtenerIdsPorNombre(_listFamilias);

            DataTable dtResult = new DataTable();

            dtResult = _mifragancia.filtrarFragancias(check_Nombre.Checked, check_Costo.Checked, check_Estado.Checked,
                                            check_Aplicaciones.Checked, check_Familias.Checked, check_Notas.Checked, check_Contratipo.Checked,
                                            txt_Nombre.Text,
                                            txt_Costo_Desde.Text == "" ? 0 : float.Parse(txt_Costo_Desde.Text),
                                            txt_Costo_Hasta.Text == "" ? 0 : float.Parse(txt_Costo_Hasta.Text),
                                            date_Costo_FechaAct.Value, _listIDEstados, _listIDAplicacion,
                                            _listIDFamilias, txt_Notas.Text, txt_Contratipo.Text);

            dgw.DataSource = dtResult;
        }

        void refrescarGrillaSeleccionados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idFragancia");
            dt.Columns.Add("NombreReal");

            try
            {
                foreach (Fragancia item in _listFraganciasSeleccionadas)
                {
                    DataRow drow = dt.NewRow();
                    drow["idFragancia"] = item.idFragancia;
                    drow["NombreReal"] = item.NombreReal;
                    dt.Rows.Add(drow);
                }

                dgw_Seleccionados.DataSource = dt;

                dgw_Seleccionados.Columns["idFragancia"].IsVisible = false;

                for (int i = 0; i < dgw_Seleccionados.Columns.Count; i++)
                {
                    dgw_Seleccionados.Columns[i].BestFit();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        #endregion
  
 }
}
