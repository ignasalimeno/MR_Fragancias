using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MR_Fragancias.Reportes
{
    public partial class Form_Reporte : Form
    {
       public int idPedidoMuestra;
        public string pathSave = "";
        public string tipoDeForm = "";
         
        public Form_Reporte()
        {
            InitializeComponent();
        }

        private void Form_Reporte_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_PedidoMuestra", getPedidoMuestra(idPedidoMuestra)));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_PedidoMuestraFragancias", getPedidoMuestraFragancias(idPedidoMuestra)));
                this.reportViewer1.RefreshReport();
                this.WindowState = FormWindowState.Maximized;
                this.reportViewer1.LocalReport.DisplayName = "PM_" + idPedidoMuestra.ToString() + "_Resumen";

                if (tipoDeForm == "imprimir")
                {
                    guardarPDF();
                    createDocument();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            }
            finally
            {
                if (tipoDeForm == "imprimir")
                {
                    this.Close();
                }
            }
        }

        DataTable getPedidoMuestra(int idPedidoMuestra)
        {
            Negocio.PedidosMuestra _miPedido = new Negocio.PedidosMuestra();

            return _miPedido.getPedidoMuestraReporte(idPedidoMuestra);
        }

        DataTable getPedidoMuestraFragancias(int idPedidoMuestra)
        {
            Negocio.PedidosMuestra_Fragancias _miPedido = new Negocio.PedidosMuestra_Fragancias();

            return _miPedido.getPedidosMuestraFragancia(idPedidoMuestra);
        }

        void guardarPDF()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(pathSave + "\\PM_" + idPedidoMuestra.ToString() + "_Resumen.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        #region - Carta -

        void createDocument()
        {
            object missing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document aDoc = null;

            if (File.Exists((string)"C:\\Users\\Ignacio\\Desktop\\CartaMR_Test.docx"))
            {
                DateTime today = DateTime.Now;

                object readOnly = false;
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open("C:\\Users\\Ignacio\\Desktop\\CartaMR_Test.docx", ref missing, 
                        ref readOnly, ref missing, ref missing, ref missing, 
                        ref missing, ref missing, ref missing, ref missing, 
                        ref missing, ref isVisible, ref missing, ref missing, 
                        ref missing, ref missing);

                aDoc.Activate();

                //REPLACE TEXT

                //aDoc.ActiveWindow.Selection.WholeStory();
                //aDoc.ActiveWindow.Selection.Copy();

                //IDataObject data = Clipboard.GetDataObject();
                //richTextBox1.Text = data.GetData(DataFormats.Text).ToString();
                ////aDoc.Close(ref missing, ref missing, ref missing);
            }
            aDoc.SaveAs2(pathSave + "\\PM_" + idPedidoMuestra.ToString() + "_Carta.docx", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            aDoc.Close(ref missing, ref missing, ref missing);


        }

        void findAndReplace(Microsoft.Office.Interop.Word.Application WordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object nmatchAllWordForms = false;
            object foward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactricits = false;   
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike,
                ref nmatchAllWordForms, ref foward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactricits, ref matchAlefHamza,
                ref matchControl);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //createDocument("C:\\Users\\Ignacio\\Desktop\\CartaMR_Test.docx","");

        }

    }
}
