using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MR_Fragancias
{
    public partial class Principal : Telerik.WinControls.UI.RadRibbonForm
    {
        public string passAdmin = "";

        public Principal()
        {
            InitializeComponent();
        }

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "¿Está seguro que desea cerrar el sistema?", "MR Fragancias", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            passAdmin = new Negocio.Usuarios().obtenerPassword("Administrador");
        }

        private void btn_Clientes_Agregar_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Clientes _clienteForm = new Maestros.Clientes();
                    _clienteForm.Accion = "Agregar";

                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }

                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void radButtonElement1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                Maestros.Clientes _clienteForm = new Maestros.Clientes();
                _clienteForm.Accion = "Listar";
                _clienteForm.MdiParent = this;
                _clienteForm.Location = new Point(0, 0);
                _clienteForm.Show();
                this.barra_Principal.Expanded = false;
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void expandirBarra()
        {
            this.barra_Principal.Expanded = true;
            this.barra_Principal.Enabled = true;
        }

        private void openAction(Form _form)
        {

        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {

            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Clientes _clienteForm = new Maestros.Clientes();
                    _clienteForm.Accion = "Modificar";
                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement4_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Clientes _clienteForm = new Maestros.Clientes();
                    _clienteForm.Accion = "Eliminar";
                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void radButtonElement2_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    CambiarPassword _cambiarPassword = new CambiarPassword();
                    _cambiarPassword.MdiParent = this;
                    _cambiarPassword.Location = new Point(0, 0);
                    _cambiarPassword.Show();
                    _cambiarPassword.Focus();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement21_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                Maestros.Fragancias _fraganciasForm = new Maestros.Fragancias();
                _fraganciasForm.Accion = "Listar";
                _fraganciasForm.MdiParent = this;
                _fraganciasForm.Location = new Point(0, 0);
                _fraganciasForm.Show();
                this.barra_Principal.Expanded = false;
                this.barra_Principal.Enabled = false;
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement18_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Fragancias _clienteForm = new Maestros.Fragancias();
                    _clienteForm.Accion = "Agregar";
                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement19_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Fragancias _clienteForm = new Maestros.Fragancias();
                    _clienteForm.Accion = "Modificar";
                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement20_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                if (InputBox.ShowDialog("Ingrese el password de administrador.", true) == passAdmin)
                {
                    Maestros.Fragancias _clienteForm = new Maestros.Fragancias();
                    _clienteForm.Accion = "Eliminar";
                    _clienteForm.MdiParent = this;
                    _clienteForm.Location = new Point(0, 0);
                    _clienteForm.Show();
                    this.barra_Principal.Expanded = false;
                    this.barra_Principal.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "El password es incorrecto", "MR Fragancias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement22_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                PedidoDeMuestra _pedidoMuestraForm = new PedidoDeMuestra();
                _pedidoMuestraForm.MdiParent = this;
                _pedidoMuestraForm.Location = new Point(0, 0);
                _pedidoMuestraForm.Show();
                this.barra_Principal.Expanded = false;
                this.barra_Principal.Enabled = false;
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement23_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                try
                {
                    BuscarPedidoMuestra _buscar = new BuscarPedidoMuestra();
                    _buscar.ShowDialog();
                    if (_buscar.idPedidoSeleccionado.ToString() != "0")
                    {
                        folderBrowserDialog1.ShowDialog();
                        string path = folderBrowserDialog1.SelectedPath;
                        if (path != "")
                        {
                            Reportes.Form_Reporte miReporteForm = new Reportes.Form_Reporte();
                            miReporteForm.tipoDeForm = "imprimir";
                            miReporteForm.idPedidoMuestra = _buscar.idPedidoSeleccionado;
                            miReporteForm.pathSave = path;
                            miReporteForm.ShowDialog();

                            MessageBox.Show("Los archivos se generaron correctamente en: " + path, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error al generar los archivos. Verifique que la ruta sea válida", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement24_Click(object sender, EventArgs e)
        {
            BuscarPedidoMuestra _buscar = new BuscarPedidoMuestra();
            _buscar.ShowDialog();
            MessageBox.Show(_buscar.idPedidoSeleccionado.ToString());
        }

        private void radButtonElement25_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                BuscarPedidoMuestra _buscar = new BuscarPedidoMuestra();
                _buscar.ShowDialog();
                if (_buscar.idPedidoSeleccionado.ToString() != "0")
                {
                    PedidoDeMuestra_Combinacion _PMComb = new PedidoDeMuestra_Combinacion();
                    _PMComb.tipoConsulta = "actualizar";
                    _PMComb.idPedidoMuestraGlobal = int.Parse(_buscar.idPedidoSeleccionado.ToString());
                    //_PMComb.MdiParent = this;
                    //_PMComb.Location = new Point(0, 0);
                    _PMComb.Show();
                }
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement24_Click_1(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                Reportes.Reporte_PorCliente _miReporte = new Reportes.Reporte_PorCliente();
                _miReporte.MdiParent = this;
                _miReporte.Location = new Point(0, 0);
                _miReporte.Show();
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement30_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                try
                {
                    BuscarPedidoMuestra _buscar = new BuscarPedidoMuestra();
                    _buscar.ShowDialog();
                    if (_buscar.idPedidoSeleccionado.ToString() != "0")
                    {
                        Reportes.Form_Reporte miReporteForm = new Reportes.Form_Reporte();
                        miReporteForm.idPedidoMuestra = _buscar.idPedidoSeleccionado;
                        miReporteForm.tipoDeForm = "visualizador";
                        miReporteForm.MdiParent = this;
                        miReporteForm.Location = new Point(0, 0);
                        miReporteForm.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error al abrir el reporte. Intente nuevamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement29_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                Reportes.Reporte_PorFragancia _miReporte = new Reportes.Reporte_PorFragancia();
                _miReporte.MdiParent = this;
                _miReporte.Location = new Point(0, 0);
                _miReporte.Show();
            }
            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButtonElement31_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                try
                {
                    BuscarPedidoMuestra _buscar = new BuscarPedidoMuestra();
                    _buscar.ShowDialog();
                    if (_buscar.idPedidoSeleccionado.ToString() != "0")
                    {
                        PedidoDeMuestra_Combinacion _PMComb = new PedidoDeMuestra_Combinacion();
                        _PMComb.tipoConsulta = "vendida";
                        _PMComb.idPedidoMuestraGlobal = int.Parse(_buscar.idPedidoSeleccionado.ToString());
                        //_PMComb.MdiParent = this;
                        //_PMComb.Location = new Point(0, 0);
                        _PMComb.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error al abrir el reporte. Intente nuevamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            else
            {
                MessageBox.Show("No puede abrir más de un formulario a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

