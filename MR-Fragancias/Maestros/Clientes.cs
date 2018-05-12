
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MR_Fragancias.Maestros
{
    public partial class Clientes : Telerik.WinControls.UI.RadForm
    {
        #region - Variables

        #region -- Cliente

        Negocio.Cliente _objeto = new Negocio.Cliente();
        int idObjetoActual;
        public string Accion;

        #endregion

        #region -- Domicilios

        Negocio.Domicilio _dom = new Negocio.Domicilio();
        int idDomicilioActual;
        string accionDomicilio = "Listar";
        #endregion

        #region -- Telefonos

        Negocio.Telefono _tel = new Negocio.Telefono();
        int idTelActual;
        string accionTelefono = "Listar";
        #endregion

        #region -- Nombres

        Negocio.Nombres _nombre = new Negocio.Nombres();
        int idNombreActual;
        string accionNombre = "Listar";

        #endregion

        #region -- Contactos

        Negocio.Contactos _contacto = new Negocio.Contactos();
        int idContactoActual;
        string accionContacto = "Listar";

        #endregion

        #region -- Notas

        Negocio.Nota _nota = new Negocio.Nota();
        int idNotaActual;
        string accionNota = "Listar";

        #endregion

        #endregion
      
        public Clientes()
        {
            InitializeComponent();
        }

        #region - Eventos

        #region -- Clientes

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarGrillaTotal();

            habilitarControlesCliente(false);

            switch (Accion)
            {
                case "Listar":
                    btn_Accion.Visible = false;
                    habilitarBotones(false);
                    break;
                case "Agregar":
                    btn_Accion.Visible = true;
                    resetTxtBox();
                    habilitarBotones(false);
                    habilitarControlesCliente(true);
                    break;
                case "Modificar":
                    btn_Accion.Visible = true;
                    habilitarControlesCliente(true);
                    break;
                case "Eliminar":
                    btn_Accion.Visible = true;
                    habilitarBotones(false);
                    break;

                default:
                    break;
            }
            combo_CamposBusqueda.SelectedIndex = 0;
            btn_Accion.Text = Accion;
            habilitarControlesDomicilio(false);
            habilitarControlesTelefono(false);
            habilitarControlesNombres(false);
            habilitarControlesContactos(false);
            habilitarControlesNotas(false);

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

                    foreach (Control item in this.tab_Datos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                    cargarGrillaDomicilios();
                    cargarGrillaTelefonos();
                    cargarGrillaNombres();
                    cargarGrillaContactos();
                    cargarGrillaNotas();
                }
            }
        }

        #region --- Busqueda

        private void rb_Desc_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rb_Desc.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
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
            filtrarGrilla("RazonSocial", txt_BusquedaNombre.Text);
        }

        #endregion

        #endregion

        #region -- Domicilios

        private void btn_Domicilios_Agregar_Click(object sender, EventArgs e)
        {
            foreach (Control item in tab_Domicilios.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
            btn_Domicilios_Aceptar.Visible = true;
            btn_Domicilios_Cancelar.Visible = true;
            btn_Domicilios_Agregar.Enabled = false;
            btn_Domicilios_Modificar.Enabled = false;
            btn_Domicilios_Eliminar.Enabled = false;
            accionNota = "Agregar";
            habilitarControlesDomicilio(true);
        }

        private void btn_Domicilios_Modificar_Click(object sender, EventArgs e)
        {
            btn_Domicilios_Aceptar.Visible = true;
            btn_Domicilios_Cancelar.Visible = true;
            btn_Domicilios_Agregar.Enabled = false;
            btn_Domicilios_Modificar.Enabled = false;
            btn_Domicilios_Eliminar.Enabled = false;
            accionNota = "Modificar";
            habilitarControlesDomicilio(true);
        }

        private void btn_Domicilios_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarDomicilio();
        }

        private void btn_Domicilios_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionNota == "Agregar")
                {
                    agregarDomicilio();
                }
                else if (accionNota == "Modificar")
                {
                    modificarDomicilio();
                }
            }
            catch (Exception)
            {

                throw;
            }
            btn_Domicilios_Aceptar.Visible = false;
            btn_Domicilios_Cancelar.Visible = false;
            btn_Domicilios_Agregar.Enabled = true;
            btn_Domicilios_Modificar.Enabled = true;
            btn_Domicilios_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaDomicilios();
            habilitarControlesDomicilio(false);
        }

        private void btn_Domicilios_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Domicilios_Aceptar.Visible = false;
            btn_Domicilios_Cancelar.Visible = false;
            btn_Domicilios_Agregar.Enabled = true;
            btn_Domicilios_Modificar.Enabled = true;
            btn_Domicilios_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaDomicilios();
            habilitarControlesDomicilio(false);
        }

        private void dgw_Domicilios_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (accionDomicilio != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idDomicilioActual = int.Parse(dgw_Domicilios.Rows[e.RowIndex].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Domicilios.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Domicilios.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Domicilios.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region -- Telefonos

        private void btn_Telefonos_Agregar_Click(object sender, EventArgs e)
        {
            foreach (Control item in tab_Telefonos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
            btn_Telefonos_Aceptar.Visible = true;
            btn_Telefonos_Cancelar.Visible = true;
            btn_Telefonos_Agregar.Enabled = false;
            btn_Telefonos_Modificar.Enabled = false;
            btn_Telefonos_Eliminar.Enabled = false;
            accionNota = "Agregar";
            habilitarControlesTelefono(true);
        }

        private void btn_Telefonos_Modificar_Click(object sender, EventArgs e)
        {
            btn_Telefonos_Aceptar.Visible = true;
            btn_Telefonos_Cancelar.Visible = true;
            btn_Telefonos_Agregar.Enabled = false;
            btn_Telefonos_Modificar.Enabled = false;
            btn_Telefonos_Eliminar.Enabled = false;
            accionNota = "Modificar";
            habilitarControlesTelefono(true);
        }

        private void btn_Telefonos_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarTelefono();
        }

        private void btn_Telefonos_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionNota == "Agregar")
                {
                    agregarTelefono();
                }
                else if (accionNota == "Modificar")
                {
                    modificarTelefono();
                }
            }
            catch (Exception)
            {

                throw;
            }
            btn_Telefonos_Aceptar.Visible = false;
            btn_Telefonos_Cancelar.Visible = false;
            btn_Telefonos_Agregar.Enabled = true;
            btn_Telefonos_Modificar.Enabled = true;
            btn_Telefonos_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaTelefonos();
            habilitarControlesTelefono(false);
        }

        private void btn_Telefonos_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Telefonos_Aceptar.Visible = false;
            btn_Telefonos_Cancelar.Visible = false;
            btn_Telefonos_Agregar.Enabled = true;
            btn_Telefonos_Modificar.Enabled = true;
            btn_Telefonos_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaTelefonos();
            habilitarControlesTelefono(false);
        }

        private void dgw_Telefonos_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (accionNota != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idTelActual = int.Parse(dgw_Telefonos.Rows[e.RowIndex].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Telefonos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Telefonos.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Telefonos.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region -- Nombre

        private void btn_Nombres_Agregar_Click(object sender, EventArgs e)
        {
            foreach (Control item in tab_Nombres.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
            btn_Nombres_Aceptar.Visible = true;
            btn_Nombres_Cancelar.Visible = true;
            btn_Nombres_Agregar.Enabled = false;
            btn_Nombres_Modificar.Enabled = false;
            btn_Nombres_Eliminar.Enabled = false;
            accionNota = "Agregar";
            habilitarControlesNombres(true);
        }

        private void btn_Nombres_Modificar_Click(object sender, EventArgs e)
        {
            btn_Nombres_Aceptar.Visible = true;
            btn_Nombres_Cancelar.Visible = true;
            btn_Nombres_Agregar.Enabled = false;
            btn_Nombres_Modificar.Enabled = false;
            btn_Nombres_Eliminar.Enabled = false;
            accionNota = "Modificar";
            habilitarControlesNombres(true);
        }

        private void btn_Nombres_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarNombre();
        }

        private void btn_Nombres_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionNota == "Agregar")
                {
                    agregarNombre();
                }
                else if (accionNota == "Modificar")
                {
                    modificarNombre();
                }
            }
            catch (Exception)
            {

                throw;
            }
            btn_Nombres_Aceptar.Visible = false;
            btn_Nombres_Cancelar.Visible = false;
            btn_Nombres_Agregar.Enabled = true;
            btn_Nombres_Modificar.Enabled = true;
            btn_Nombres_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaNombres();
            habilitarControlesNombres(false);
        }

        private void btn_Nombres_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Nombres_Aceptar.Visible = false;
            btn_Nombres_Cancelar.Visible = false;
            btn_Nombres_Agregar.Enabled = true;
            btn_Nombres_Modificar.Enabled = true;
            btn_Nombres_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaNombres();
            habilitarControlesNombres(false);
        }

        private void dgw_Nombres_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (accionNota != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idNombreActual = int.Parse(dgw_Nombres.Rows[e.RowIndex].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Nombres.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Nombres.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Nombres.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region -- Contactos

        private void btn_Contactos_Agregar_Click(object sender, EventArgs e)
        {
            foreach (Control item in tab_Contactos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
            btn_Contactos_Aceptar.Visible = true;
            btn_Contactos_Cancelar.Visible = true;
            btn_Contactos_Agregar.Enabled = false;
            btn_Contactos_Modificar.Enabled = false;
            btn_Contactos_Eliminar.Enabled = false;
            accionContacto = "Agregar";
            habilitarControlesContactos(true);
        }

        private void btn_Contactos_Modificar_Click(object sender, EventArgs e)
        {
            btn_Contactos_Aceptar.Visible = true;
            btn_Contactos_Cancelar.Visible = true;
            btn_Contactos_Agregar.Enabled = false;
            btn_Contactos_Modificar.Enabled = false;
            btn_Contactos_Eliminar.Enabled = false;
            accionContacto = "Modificar";
            habilitarControlesContactos(true);
        }

        private void btn_Contactos_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarContacto();
        }

        private void btn_Contactos_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionContacto == "Agregar")
                {
                    agregarContacto();
                }
                else if (accionContacto == "Modificar")
                {
                    modificarContacto();
                }
            }
            catch (Exception)
            {

                throw;
            }
            btn_Contactos_Aceptar.Visible = false;
            btn_Contactos_Cancelar.Visible = false;
            btn_Contactos_Agregar.Enabled = true;
            btn_Contactos_Modificar.Enabled = true;
            btn_Contactos_Eliminar.Enabled = true;
            accionContacto = "Listar";
            refrescarGrillaContactos();
            habilitarControlesContactos(false);
        }

        private void btn_Contactos_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Contactos_Aceptar.Visible = false;
            btn_Contactos_Cancelar.Visible = false;
            btn_Contactos_Agregar.Enabled = true;
            btn_Contactos_Modificar.Enabled = true;
            btn_Contactos_Eliminar.Enabled = true;
            accionContacto = "Listar";
            refrescarGrillaContactos();
            habilitarControlesContactos(false);
        }

        private void dgw_Contactos_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (accionContacto != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idContactoActual = int.Parse(dgw_Contactos.Rows[e.RowIndex].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Contactos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Contactos.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Contactos.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region -- Notas

        private void btn_Notas_Agregar_Click(object sender, EventArgs e)
        {
            foreach (Control item in tab_Notas.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
            btn_Notas_Aceptar.Visible = true;
            btn_Notas_Cancelar.Visible = true;
            btn_Notas_Agregar.Enabled = false;
            btn_Notas_Modificar.Enabled = false;
            btn_Notas_Eliminar.Enabled = false;
            accionNota = "Agregar";
            habilitarControlesNotas(true);
        }

        private void btn_Notas_Modificar_Click(object sender, EventArgs e)
        {
            btn_Notas_Aceptar.Visible = true;
            btn_Notas_Cancelar.Visible = true;
            btn_Notas_Agregar.Enabled = false;
            btn_Notas_Modificar.Enabled = false;
            btn_Notas_Eliminar.Enabled = false;
            accionNota = "Modificar";
            habilitarControlesNotas(true);
        }

        private void btn_Notas_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarNota();
        }

        private void btn_Notas_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accionNota == "Agregar")
                {
                    agregarNota();
                }
                else if (accionNota == "Modificar")
                {
                    modificarNota();
                }
            }
            catch (Exception)
            {

                throw;
            }
            btn_Notas_Aceptar.Visible = false;
            btn_Notas_Cancelar.Visible = false;
            btn_Notas_Agregar.Enabled = true;
            btn_Notas_Modificar.Enabled = true;
            btn_Notas_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaNotas();
            habilitarControlesNotas(false);
        }

        private void btn_Notas_Cancelar_Click(object sender, EventArgs e)
        {
            btn_Notas_Aceptar.Visible = false;
            btn_Notas_Cancelar.Visible = false;
            btn_Notas_Agregar.Enabled = true;
            btn_Notas_Modificar.Enabled = true;
            btn_Notas_Eliminar.Enabled = true;
            accionNota = "Listar";
            refrescarGrillaNotas();
            habilitarControlesNotas(false);
        }

        private void dgw_Notas_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (accionNota != "Agregar")
            {
                if (e.RowIndex >= 0)
                {
                    idNotaActual = int.Parse(dgw_Notas.Rows[e.RowIndex].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Notas.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Notas.Rows[e.RowIndex].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Notas.Rows[e.RowIndex].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
            }
        }

        #endregion

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region - Procedimientos

        #region -- Cliente

        private void refrescarGrilla()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw.Columns[0].IsVisible = false;
                dgw.Columns["Activo"].IsVisible = false;


                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ Renombre de columnas --------
                dgw.Columns["RazonSocial"].HeaderText = "RazonSocial";
                dgw.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                dgw.Columns["Actividad"].HeaderText = "Actividad";
                dgw.Columns["CUIT"].HeaderText = "CUIT";
                dgw.Columns["Email"].HeaderText = "Email";
                dgw.Columns["EntregaValores"].HeaderText = "EntregaValores";
                dgw.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                dgw.Columns["Observaciones"].HeaderText = "Observaciones";
                dgw.Columns["Vendedor"].HeaderText = "Vendedor";
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
                    idObjetoActual = int.Parse(dgw.Rows[0].Cells[0].Value.ToString());

                    foreach (Control item in this.tab_Datos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idObjetoActual = -99;

                    foreach (Control item in this.tab_Domicilios.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            _item.Text = "";
                        }
                    }
                }

                cargarGrillaDomicilios();
                cargarGrillaTelefonos();
                cargarGrillaNombres();
                cargarGrillaContactos();
                cargarGrillaNotas();
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
                    combo_CamposBusqueda.Items.Add(new RadListDataItem(dgw.Columns[i].HeaderText, dgw.Columns[i].FieldName));
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
            foreach (Control item in tab_Datos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Text = "";
                }
            }
        }

        public Negocio.Cliente crearObjeto()
        {
            try
            {
                Negocio.Cliente _newObject = new Negocio.Cliente();
                _newObject.idCliente = idObjetoActual;
                _newObject.RazonSocial = txt_RazonSocial.Text;
                _newObject.Fecha_Alta = date_Fecha_Alta.Value;
                _newObject.Actividad = txt_Actividad.Text;
                _newObject.CUIT = txt_CUIT.Text;
                _newObject.Email = txt_Email.Text;
                _newObject.EntregaValores = txt_EntregaValores.Text;
                _newObject.CondicionesVenta = txt_CondicionesVenta.Text;
                _newObject.Observaciones = txt_Observaciones.Text;
                _newObject.Vendedor = txt_Vendedor.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarObjeto()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Cliente _newObj = crearObjeto();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaTotal();
                    resetTxtBox();
                }
            }
        }

        private void modificarObjeto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Cliente _newObjeto = crearObjeto();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTotal();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarObjeto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Cliente _newObjeto = crearObjeto();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTotal();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void habilitarBotones(bool estado)
        {
            btn_Domicilios_Agregar.Visible = estado;
            btn_Domicilios_Modificar.Visible = estado;
            btn_Domicilios_Eliminar.Visible = estado;
            btn_Telefonos_Agregar.Visible = estado;
            btn_Telefonos_Modificar.Visible = estado;
            btn_Telefonos_Eliminar.Visible = estado;
            btn_Nombres_Agregar.Visible = estado;
            btn_Nombres_Modificar.Visible = estado;
            btn_Nombres_Eliminar.Visible = estado;
            btn_Contactos_Agregar.Visible = estado;
            btn_Contactos_Modificar.Visible = estado;
            btn_Contactos_Eliminar.Visible = estado;
        }

        private void habilitarControlesCliente(bool estado)
        {
            foreach (Control item in tab_Datos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #region -- Domicilios

        public Negocio.Domicilio crearDomicilio()
        {
            try
            {
                Negocio.Domicilio _newObject = new Negocio.Domicilio();
                _newObject.idDomicilio = idDomicilioActual;
                _newObject.idCliente = idObjetoActual;
                _newObject.Tipo = txt_Domicilios_Tipo.Text;
                _newObject.Calle = txt_Domicilios_Calle.Text;
                _newObject.Numero = txt_Domicilios_Numero.Text;
                _newObject.Piso = txt_Domicilios_Piso.Text;
                _newObject.Dpto = txt_Domicilios_Dpto.Text;
                _newObject.CodPostal = txt_Domicilios_CodPostal.Text;
                _newObject.Localidad = txt_Domicilios_Localidad.Text;
                _newObject.Provincia = txt_Domicilios_Provincia.Text;
                _newObject.Observaciones = txt_Observaciones.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarDomicilio()
        {
            try
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Domicilio _newObj = crearDomicilio();

                    if (_newObj.agregarObjeto(_newObj))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cargarGrillaDomicilios();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al querer agregar el domicilio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarDomicilio()
        {
            try
            {
                if (idDomicilioActual != -99 || dgw_Domicilios.SelectedRows.Count > 0)
                {
                    DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                    if (dgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        Negocio.Domicilio _newDomicilio = crearDomicilio();

                        if (_newDomicilio.modificarObjeto(_newDomicilio))
                        {
                            MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        cargarGrillaDomicilios();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Debe seleccionar un domicilio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al querer modificar el domicilio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarDomicilio()
        {
            try
            {
                if (idDomicilioActual != -99 || dgw_Domicilios.SelectedRows.Count > 0)
                {
                    DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el domicilio?", this.Name, MessageBoxButtons.YesNo);
                    if (dgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        Negocio.Domicilio _newDomicilio = crearDomicilio();

                        if (_newDomicilio.eliminarObjeto(_newDomicilio))
                        {
                            MessageBox.Show(this, "Domicilio eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarGrillaDomicilios();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al querer eliminar el domicilio!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarGrillaDomicilios()
        {
            dgw_Domicilios.DataSource = _dom.obtenerTodos(idObjetoActual);
            refrescarGrillaDomicilios();
        }

        private void refrescarGrillaDomicilios()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw_Domicilios.Columns[0].IsVisible = false;
                dgw_Domicilios.Columns[1].IsVisible = false;
                dgw_Domicilios.Columns["Activo"].IsVisible = false;


                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ Renombre de columnas --------
                //dgw_Domicilios.Columns["RazonSocial"].HeaderText = "RazonSocial";
                //dgw_Domicilios.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                //dgw_Domicilios.Columns["Actividad"].HeaderText = "Actividad";
                //dgw_Domicilios.Columns["CUIT"].HeaderText = "CUIT";
                //dgw_Domicilios.Columns["Email"].HeaderText = "Email";
                //dgw_Domicilios.Columns["EntregaValores"].HeaderText = "EntregaValores";
                //dgw_Domicilios.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                //dgw_Domicilios.Columns["Observaciones"].HeaderText = "Observaciones";
                //dgw_Domicilios.Columns["Vendedor"].HeaderText = "Vendedor";
                //===================================================================
                //===================================================================


                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw_Domicilios.Columns.Count - 1; i++)
                {
                    dgw_Domicilios.Columns[i].BestFit();
                }

                //-- Carga de valores de la grilla
                if (dgw_Domicilios.Rows.Count > 0)
                {

                    foreach (Control item in this.tab_Domicilios.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Domicilios.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Domicilios.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idDomicilioActual = -99;

                    foreach (Control item in this.tab_Domicilios.Controls)
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

        private void habilitarControlesDomicilio(bool estado)
        {
        foreach (Control item in tab_Domicilios.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #region -- Telefonos

        public Negocio.Telefono crearTelefono()
        {
            try
            {
                Negocio.Telefono _newObject = new Negocio.Telefono();
                _newObject.idTelefono = idTelActual;
                _newObject.idCliente = idObjetoActual;
                _newObject.Tipo = txt_Telefonos_Tipo.Text;
                _newObject.Numero = txt_Telefonos_Numero.Text;
                _newObject.Interno = txt_Telefonos_Interno.Text;
                _newObject.Observaciones = txt_Telefonos_Observaciones.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarTelefono()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Telefono _newObj = crearTelefono();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaTelefonos();
                }
            }
        }

        private void modificarTelefono()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Telefono _newObjeto = crearTelefono();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTelefonos();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarTelefono()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Telefono _newObjeto = crearTelefono();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaTelefonos();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarGrillaTelefonos()
        {
            dgw_Telefonos.DataSource = _tel.obtenerTodos(idObjetoActual);
            refrescarGrillaTelefonos();
        }

        private void refrescarGrillaTelefonos()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw_Telefonos.Columns[0].IsVisible = false;
                dgw_Telefonos.Columns[1].IsVisible = false;
                dgw_Telefonos.Columns["Activo"].IsVisible = false;

                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ Renombre de columnas --------
                //dgw_Telefonos.Columns["RazonSocial"].HeaderText = "RazonSocial";
                //dgw_Telefonos.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                //dgw_Telefonos.Columns["Actividad"].HeaderText = "Actividad";
                //dgw_Telefonos.Columns["CUIT"].HeaderText = "CUIT";
                //dgw_Telefonos.Columns["Email"].HeaderText = "Email";
                //dgw_Telefonos.Columns["EntregaValores"].HeaderText = "EntregaValores";
                //dgw_Telefonos.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                //dgw_Telefonos.Columns["Observaciones"].HeaderText = "Observaciones";
                //dgw_Telefonos.Columns["Vendedor"].HeaderText = "Vendedor";
                //===================================================================
                //===================================================================

                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw_Telefonos.Columns.Count - 1; i++)
                {
                    dgw_Telefonos.Columns[i].BestFit();
                }

                //-- Carga de valores de la grilla
                if (dgw_Telefonos.Rows.Count > 0)
                {
                    foreach (Control item in this.tab_Telefonos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }
                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Telefonos.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Telefonos.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idTelActual = -99;

                    foreach (Control item in this.tab_Telefonos.Controls)
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

        private void habilitarControlesTelefono(bool estado)
        {
            foreach (Control item in tab_Telefonos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #region -- Nombres

        public Negocio.Nombres crearNombre()
        {
            try
            {
                Negocio.Nombres _newObject = new Negocio.Nombres();
                _newObject.idNombre = idNombreActual;
                _newObject.idCliente = idObjetoActual;
                _newObject.Tipo = txt_Nombres_Tipo.Text;
                _newObject.Nom = txt_Nombres_Nombre.Text;
                _newObject.Observaciones = txt_Nombres_Observaciones.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarNombre()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Nombres _newObj = crearNombre();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaNombres();
                }
            }
        }

        private void modificarNombre()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Nombres _newObjeto = crearNombre();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaNombres();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarNombre()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Nombres _newObjeto = crearNombre();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaNombres();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarGrillaNombres()
        {
            dgw_Nombres.DataSource = _nombre.obtenerTodos(idObjetoActual);
            refrescarGrillaNombres();
        }

        private void refrescarGrillaNombres()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw_Nombres.Columns[0].IsVisible = false;
                dgw_Nombres.Columns[1].IsVisible = false;
                dgw_Nombres.Columns["Activo"].IsVisible = false;

                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ Renombre de columnas --------
                //dgw_Nombres.Columns["RazonSocial"].HeaderText = "RazonSocial";
                //dgw_Nombres.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                //dgw_Nombres.Columns["Actividad"].HeaderText = "Actividad";
                //dgw_Nombres.Columns["CUIT"].HeaderText = "CUIT";
                //dgw_Nombres.Columns["Email"].HeaderText = "Email";
                //dgw_Nombres.Columns["EntregaValores"].HeaderText = "EntregaValores";
                //dgw_Nombres.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                //dgw_Nombres.Columns["Observaciones"].HeaderText = "Observaciones";
                //dgw_Nombres.Columns["Vendedor"].HeaderText = "Vendedor";
                //===================================================================
                //===================================================================

                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw_Nombres.Columns.Count - 1; i++)
                {
                    dgw_Nombres.Columns[i].BestFit();
                }

                //-- Carga de valores de la grilla
                if (dgw_Nombres.Rows.Count > 0)
                {
                    foreach (Control item in this.tab_Nombres.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }
                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Nombres.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Nombres.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idTelActual = -99;

                    foreach (Control item in this.tab_Nombres.Controls)
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

        private void habilitarControlesNombres(bool estado)
        {
             foreach (Control item in tab_Nombres.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #region -- Contactos

        public Negocio.Contactos crearContacto()
        {
            try
            {
                Negocio.Contactos _newObject = new Negocio.Contactos();
                _newObject.idContacto = idContactoActual;
                _newObject.idCliente = idObjetoActual;
                _newObject.Nombre = txt_Contactos_Nombre.Text;
                _newObject.Cargo = txt_Contactos_Cargo.Text;
                _newObject.Telefono = txt_Contactos_Telefono.Text;
                _newObject.Email = txt_Contactos_Email.Text;
               _newObject.Observaciones = txt_Contactos_Observaciones.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarContacto()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Contactos _newObj = crearContacto();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaContactos();
                }
            }
        }

        private void modificarContacto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Contactos _newObjeto = crearContacto();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaContactos();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarContacto()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Contactos _newObjeto = crearContacto();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaContactos();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarGrillaContactos()
        {
            dgw_Contactos.DataSource = _contacto.obtenerTodos(idObjetoActual);
            refrescarGrillaContactos();
        }

        private void refrescarGrillaContactos()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw_Contactos.Columns[0].IsVisible = false;
                dgw_Contactos.Columns[1].IsVisible = false;
                dgw_Contactos.Columns["Activo"].IsVisible = false;

                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ ReContacto de columnas --------
                //dgw_Contactos.Columns["RazonSocial"].HeaderText = "RazonSocial";
                //dgw_Contactos.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                //dgw_Contactos.Columns["Actividad"].HeaderText = "Actividad";
                //dgw_Contactos.Columns["CUIT"].HeaderText = "CUIT";
                //dgw_Contactos.Columns["Email"].HeaderText = "Email";
                //dgw_Contactos.Columns["EntregaValores"].HeaderText = "EntregaValores";
                //dgw_Contactos.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                //dgw_Contactos.Columns["Observaciones"].HeaderText = "Observaciones";
                //dgw_Contactos.Columns["Vendedor"].HeaderText = "Vendedor";
                //===================================================================
                //===================================================================

                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw_Contactos.Columns.Count - 1; i++)
                {
                    dgw_Contactos.Columns[i].BestFit();
                }

                //-- Carga de valores de la grilla
                if (dgw_Contactos.Rows.Count > 0)
                {
                    foreach (Control item in this.tab_Contactos.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }
                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Contactos.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Contactos.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idTelActual = -99;

                    foreach (Control item in this.tab_Contactos.Controls)
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

        private void habilitarControlesContactos(bool estado)
        {
            foreach (Control item in tab_Contactos.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #region -- Notas

        public Negocio.Nota crearNota()
        {
            try
            {
                Negocio.Nota _newObject = new Negocio.Nota();
                _newObject.idNota = idNotaActual;
                _newObject.idCliente = idObjetoActual;
                _newObject.FechaNota = date_Notas_FechaNota.Value;
                _newObject.Texto = txt_Notas_Texto.Text;
                return _newObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void agregarNota()
        {
            DialogResult dgRes = MessageBox.Show("¿Está seguro que desea agregar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
            if (dgRes == System.Windows.Forms.DialogResult.Yes)
            {
                Negocio.Nota _newObj = crearNota();

                if (_newObj.agregarObjeto(_newObj))
                {
                    MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " agregado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarGrillaNotas();
                }
            }
        }

        private void modificarNota()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea modificar los datos del " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Nota _newObjeto = crearNota();

                    if (_newObjeto.modificarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " modificado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaNotas();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarNota()
        {
            if (idObjetoActual != -99)
            {
                DialogResult dgRes = MessageBox.Show("¿Está seguro que desea eliminar el " + this.Name.Substring(0, this.Name.Length - 1) + "?", this.Name, MessageBoxButtons.YesNo);
                if (dgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Negocio.Nota _newObjeto = crearNota();

                    if (_newObjeto.eliminarObjeto(_newObjeto))
                    {
                        MessageBox.Show(this, this.Name.Substring(0, this.Name.Length - 1) + " eliminado correctamente!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarGrillaNotas();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Debe seleccionar un " + this.Name.Substring(0, this.Name.Length - 1) + "!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cargarGrillaNotas()
        {
            dgw_Notas.DataSource = _nota.obtenerTodos(idObjetoActual);
            refrescarGrillaNotas();
        }

        private void refrescarGrillaNotas()
        {
            try
            {
                //-- Carga de grilla y seteo de campos comunes
                dgw_Notas.Columns[0].IsVisible = false;
                dgw_Notas.Columns[1].IsVisible = false;
                dgw_Notas.Columns["Activo"].IsVisible = false;

                //===================================================================
                //========================= EDITAR CÓDIGO ===========================
                //===================================================================
                //------ ReNota de columnas --------
                //dgw_Notas.Columns["RazonSocial"].HeaderText = "RazonSocial";
                //dgw_Notas.Columns["Fecha_Alta"].HeaderText = "Fecha_Alta";
                //dgw_Notas.Columns["Actividad"].HeaderText = "Actividad";
                //dgw_Notas.Columns["CUIT"].HeaderText = "CUIT";
                //dgw_Notas.Columns["Email"].HeaderText = "Email";
                //dgw_Notas.Columns["EntregaValores"].HeaderText = "EntregaValores";
                //dgw_Notas.Columns["CondicionesVenta"].HeaderText = "CondicionesVenta";
                //dgw_Notas.Columns["Observaciones"].HeaderText = "Observaciones";
                //dgw_Notas.Columns["Vendedor"].HeaderText = "Vendedor";
                //===================================================================
                //===================================================================

                //-- Autoajuste de tamaño de columnas
                for (int i = 0; i < dgw_Notas.Columns.Count - 1; i++)
                {
                    dgw_Notas.Columns[i].BestFit();
                }

                //-- Carga de valores de la grilla
                if (dgw_Notas.Rows.Count > 0)
                {
                    foreach (Control item in this.tab_Notas.Controls)
                    {
                        if (item is Telerik.WinControls.UI.RadTextBox)
                        {
                            Telerik.WinControls.UI.RadTextBox _item = (Telerik.WinControls.UI.RadTextBox)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 3)
                                {
                                    for (int i = 2; i < _names.Length; i++)
                                    {
                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + _names[i] + "_";
                                        }
                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Text = dgw_Notas.Rows[0].Cells[_name].Value.ToString();
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }

                        if (item is Telerik.WinControls.UI.RadDateTimePicker)
                        {
                            Telerik.WinControls.UI.RadDateTimePicker _item = (Telerik.WinControls.UI.RadDateTimePicker)item;
                            try
                            {
                                string[] _names = _item.Name.Split('_');
                                string _name = "";
                                if (_names.Length > 2)
                                {
                                    for (int i = 1; i < _names.Length; i++)
                                    {
                                        _name = _name + _names[i];

                                        if (i != _names.Length - 1)
                                        {
                                            _name = _name + "_";
                                        }

                                    }
                                }
                                else
                                {
                                    _name = _names[_names.Length - 1];
                                }

                                _item.Value = DateTime.ParseExact(dgw_Notas.Rows[0].Cells[_name].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                _item.Text = "Error al cargar";
                            }
                        }
                    }
                }
                else
                {
                    idTelActual = -99;

                    foreach (Control item in this.tab_Notas.Controls)
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

        private void habilitarControlesNotas(bool estado)
        {
            foreach (Control item in tab_Notas.Controls)
            {
                if (item.GetType() == typeof(Telerik.WinControls.UI.RadTextBox))
                {
                    item.Enabled = estado;
                }
            }
        }

        #endregion

        #endregion



    }
}