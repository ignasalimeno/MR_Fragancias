
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MR_Fragancias.Maestros
{
    public partial class Fragancias : Telerik.WinControls.UI.RadForm
    {
        #region "Variables"

        Negocio.Fragancia _objeto = new Negocio.Fragancia();
        int idObjetoActual;
        public string Accion;

        #endregion

        public Fragancias()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void Fragancias_Load(object sender, EventArgs e)
        {
            cargarFamiliasOlfativas();
            cargarEstados();

            cargarGrillaTotal();

            habilitarControlesCliente(false);

            switch (Accion)
            {
                case "Listar":
                    btn_Accion.Visible = false;
                    break;
                case "Agregar":
                    btn_Accion.Visible = true;
                    resetTxtBox();
                    habilitarControlesCliente(true);
                    break;
                case "Modificar":
                    btn_Accion.Visible = true;
                    habilitarControlesCliente(true);
                    break;
                case "Eliminar":
                    btn_Accion.Visible = true;
                    break;

                default:
                    break;
            }

            combo_CamposBusqueda.SelectedIndex = 0;
            btn_Accion.Text = Accion;

            
            btn_Costos_Historial.Enabled = true;

            this.WindowState = FormWindowState.Maximized;
            btn_Cerrar.Location = new Point(this.Size.Width - 85, gb_Objeto.Location.Y + 12);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ((Principal)this.ParentForm).expandirBarra();
        }

        private void btn_ListarTodos_Click(object sender, EventArgs e)
        {
            cargarGrillaTotal();
        }

        private void btn_Accion_Click(object sender, EventArgs e)
        {
            switch (Accion)
            {
                case "Agregar":
                    agregarObjeto();
                    break;
                case "Modificar":
                    modificarObjeto();
                    break;
                case "Eliminar":
                    eliminarObjeto();
                    break;
                default:
                    break;
            }
        }

        private void dgw_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (Accion != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idObjetoActual = int.Parse(dgw.Rows[e.RowIndex].Cells[0].Value.ToString());

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

                    //Codigo especial por fecha pedido stock
                    if (dgw.Rows[e.RowIndex].Cells["FechaPedidoStock"].Value.ToString() == "" || dgw.Rows[e.RowIndex].Cells["FechaPedidoStock"].Value.ToString() == "01/01/1900 0:00:00")
                    {
                        rb_HayStock.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    }
                    else
                    {
                        rb_FechaPedido.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                        date_FechaPedidoStock.Text = dgw.Rows[e.RowIndex].Cells["FechaPedidoStock"].Value.ToString();
                    }

                    //Codigo especial para costo
                    if (dgw.Rows[e.RowIndex].Cells["Costo"].Value.ToString() != "")
                    {
                        txt_Costo.Text = dgw.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
                        lbl_FechaActCosto.Text = dgw.Rows[e.RowIndex].Cells["FechaActCosto"].Value.ToString().Substring(0,10);

                    }
                    else
                    {
                        txt_Costo.Text = "";
                        lbl_FechaActCosto.Text = "";
                    }
                }
            }
        }

        private void rb_FechaPedido_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rb_FechaPedido.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                date_FechaPedidoStock.Enabled = true;
            }
            else
            {
                date_FechaPedidoStock.Enabled = false;
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Costos_Historial_Click(object sender, EventArgs e)
        {
            Costos_Historial _costoForm = new Costos_Historial(idObjetoActual);
            _costoForm.ShowDialog();
        }
    
        #region "Busqueda"

        private void rb_Desc_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rb_Desc.IsChecked == true)
            {
                combo_CamposBusqueda.Enabled = false;
                txt_BusquedaOtros.Text = "";
                txt_BusquedaOtros.Enabled = false;
                txt_BusquedaNombre.Text = "";
                txt_BusquedaNombre.Enabled = true;
            }
            else
            {
                combo_CamposBusqueda.Enabled = true;
                txt_BusquedaOtros.Text = "";
                txt_BusquedaOtros.Enabled = true;
                txt_BusquedaNombre.Text = "";
                txt_BusquedaNombre.Enabled = false;
            }
        }

        private void txt_BusquedaOtros_TextChanged(object sender, EventArgs e)
        {
            filtrarGrilla(combo_CamposBusqueda.SelectedValue.ToString(), txt_BusquedaOtros.Text);
        }

        private void txt_BusquedaNombre_TextChanged(object sender, EventArgs e)
        {
            filtrarGrilla("NombreReal", txt_BusquedaNombre.Text);
        }
        
        #endregion

  
        #endregion

        #region "Procedimientos"

        private void refrescarGrilla()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw.Columns[0].IsVisible = false;
                dgw.Columns["Activo"].IsVisible = false;
                dgw.Columns["FechaActCosto"].IsVisible = false;


                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ Renombre de columnas --------
                dgw.Columns["NombreReal"].HeaderText = "Nombre Real";
                dgw.Columns["NombreVenta"].HeaderText = "Nombre Venta";
                dgw.Columns["idFamiliaOlfativa"].HeaderText = "idFamiliaOlfativa";
                dgw.Columns["idFamiliaOlfativa"].IsVisible = false;
                dgw.Columns["DescOlfativa_NotaSalida"].HeaderText = "Nota de Salida";
                dgw.Columns["DescOlfativa_NotaMedia"].HeaderText = "Nota Media";
                dgw.Columns["DescOlfativa_NotaFondo"].HeaderText = "Nota Fondo";
                dgw.Columns["FechaPedidoStock"].HeaderText = "Fecha Pedido de Stock";
                dgw.Columns["idEstado"].HeaderText = "idEstado";
                dgw.Columns["idEstado"].IsVisible = false;
                dgw.Columns["FechaIngreso"].HeaderText = "Fecha de Ingreso";
                dgw.Columns["ContratipoNombre"].HeaderText = "Nombre Contratipo";
                dgw.Columns["ContratipoMarca"].HeaderText = "Marca Contratipo";
                dgw.Columns["ContratipoAño"].HeaderText = "Año Contratipo";
                dgw.Columns["Equivalencia"].HeaderText = "Equivalencia";
                dgw.Columns["Identificador"].HeaderText = "Identificador";
                dgw.Columns["Identificador"].IsVisible = false;
                dgw.Columns["Costo"].IsVisible = false;
                dgw.Columns["FamiliaOlfativa"].HeaderText = "Familia Olfativa";

                //===================================================================
                //===================================================================


                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw.Columns.Count - 1; i++)
                {
                    dgw.Columns[i].BestFit();
                }
                
                //-- Carga de valores de la grilla
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
            }
            catch (Exception)
            {
                MessageBox.Show("Error al refrescar grilla");
            }
        }

        private void cargarGrillaTotal()
        {
            dgw.DataSource = _objeto.obtenerTodos();
            refrescarGrilla();

            for (int i = 0; i < dgw.Columns.Count - 1; i++)
            {
                if (dgw.Columns[i].IsVisible)
                {
                    if (dgw.Columns[i].FieldName.ToString() == "Estado" || dgw.Columns[i].FieldName.ToString() == "FamiliaOlfativa")
                    {
                    }
                    else
                    {
                        combo_CamposBusqueda.Items.Add(new RadListDataItem(dgw.Columns[i].HeaderText, dgw.Columns[i].FieldName));

                    }
                }
            }
            if (combo_CamposBusqueda.Items.Count > 0)
            {
                combo_CamposBusqueda.Items[0].Selected = true;
            }
            
        }

        private void filtrarGrilla(string columna, string text)
        {
            dgw.DataSource = _objeto.obtenerTodos(columna, text);
            refrescarGrilla();
        }

        private void resetTxtBox()
        {
            foreach (Control item in gb_Objeto.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadDropDownList))
                {
                    Telerik.WinControls.UI.RadDropDownList _item = (Telerik.WinControls.UI.RadDropDownList)item;
                    _item.SelectedIndex = 0;
                }
                if (item.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                {
                    System.Windows.Forms.DateTimePicker _item = (System.Windows.Forms.DateTimePicker)item;
                    _item.Value = DateTime.Now.Date;
                }

                txt_Costo.Text = "";
                lbl_FechaActCosto.Text = "";
            }
        }

        public Negocio.Fragancia crearObjeto()
        {
            try
            {
                Negocio.Fragancia _newObject = new Negocio.Fragancia();
                _newObject.idFragancia = idObjetoActual;
                _newObject.NombreReal = txt_NombreReal.Text;
                _newObject.NombreVenta = txt_NombreVenta.Text;
                _newObject.idFamiliaOlfativa = int.Parse(combo_idFamiliaOlfativa.SelectedValue.ToString());
                _newObject.DescOlfativa_NotaSalida = txt_DescOlfativa_NotaSalida.Text;
                _newObject.DescOlfativa_NotaMedia = txt_DescOlfativa_NotaMedia.Text;
                _newObject.DescOlfativa_NotaFondo = txt_DescOlfativa_NotaFondo.Text;

                //--- Código especial para stock ------------------------
                if (rb_HayStock.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    _newObject.FechaPedidoStock = null;
                }
                else
                {
                    _newObject.FechaPedidoStock = date_FechaPedidoStock.Value;
                }
                //=======================================================

                _newObject.idEstado = int.Parse(combo_idEstado.SelectedValue.ToString());
                _newObject.FechaIngreso = date_FechaIngreso.Value;
                _newObject.ContratipoNombre = txt_ContratipoNombre.Text;
                _newObject.ContratipoMarca = txt_ContratipoMarca.Text;
                _newObject.ContratipoAño = txt_ContratipoAño.Text;
                _newObject.Equivalencia = txt_Equivalencia.Text;
                //_newObject.Identificador = long.Parse(txt_Identificador.Text);
             
                //--- Código especial para el costo --------------------
                _newObject.Costo = float.Parse(txt_Costo.Text);
                //=======================================================
                
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarObjeto()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?",  this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Fragancia _newObj = crearObjeto();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!",  this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaTotal();
                    resetTxtBox();
                }
            }
        }

        private void modificarObjeto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?",  this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Fragancia _newObjeto = crearObjeto();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0,this.Name.Length - 1) +" modificado correctamente!",  this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTotal();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!",  this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarObjeto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?",  this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Fragancia _newObjeto = crearObjeto();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!",  this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTotal();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!",  this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarFamiliasOlfativas()
        {
            Negocio.FamiliasOlfativas _familia = new Negocio.FamiliasOlfativas();
            combo_idFamiliaOlfativa.DataSource = _familia.obtenerTodos();
            combo_idFamiliaOlfativa.ValueMember = "idFamiliaOlfativa";
            combo_idFamiliaOlfativa.DisplayMember = "Nombre";
        }

        private void cargarEstados()
        {
            Negocio.Estados _estado = new Negocio.Estados();
            combo_idEstado.DataSource = _estado.obtenerTodos();
            combo_idEstado.ValueMember = "idEstado";
            combo_idEstado.DisplayMember = "Estado";
        }

              private void habilitarControlesCliente(bool estado)
        {
            foreach (Control item in gb_Objeto.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox)
                    || item.GetType() == typeof(Telerik.WinControls.UI.RadDateTimePicker)
                    || item.GetType() == typeof(Telerik.WinControls.UI.RadDropDownList)
                    || item.GetType() == typeof(System.Windows.Forms.Panel)
                    || item.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                {
                    item.Enabled = estado;
                }
            }

            txt_Costo.Enabled = estado;
        }

        #endregion

        private void btn_VerAplicaciones_Click(object sender, EventArgs e)
        {
            Fragancias_Aplicaciones _apliForm = new Fragancias_Aplicaciones();
            _apliForm.idFragancia = idObjetoActual;
            _apliForm.ShowDialog();
        }

     }
}