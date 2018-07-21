using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidosMuestra_Fragancias
    {
        public int idPedidoMuestra;
        public string idFragancia;
        public string NombreVenta;
        public string NombreReal;
        public string idFragComb;
        public string CombPrincipal;
        public int idComb;
        public double Porcentaje;
        public double Costo;
        public double CostoCalculado;
        public double CostoComb;
        public double Gramos;
        public double Markup;
        public double PrecioVta;
        public bool Presentada;
        public bool Vendida;

        public bool guardarPedidosMuestraFragancias(PedidosMuestra_Fragancias miFragancia)
        {
            try
            {
                string str = "INSERT INTO [MRFragancias].[dbo].[PedidosMuestra_Fragancias] VALUES (";
                str = str + miFragancia.idPedidoMuestra + ", ";
                str = str + "'" + miFragancia.idFragancia + "', ";
                str = str + "'" + miFragancia.NombreVenta + "', ";
                str = str + "'" + miFragancia.NombreReal + "', ";
                str = str + "'" + miFragancia.idFragComb.ToString().Replace(',', '.') + "', ";
                str = str + "'" + miFragancia.CombPrincipal + "', ";
                str = str + miFragancia.idComb.ToString().Replace(',','.') + ", ";
                str = str + miFragancia.Porcentaje.ToString().Replace(',', '.') + ", ";
                str = str + miFragancia.Costo.ToString().Replace(',', '.') + ", ";
                str = str + miFragancia.CostoCalculado.ToString().Replace(',', '.') + ", ";
                str = str + miFragancia.CostoComb.ToString().Replace(',', '.') + ", ";
                str = str + miFragancia.Gramos.ToString().Replace(',', '.').ToString().Replace(',','.') + ", ";
                if (miFragancia.Markup.ToString() == "Infinito" || miFragancia.Markup.ToString() == "∞")
                {
                    miFragancia.Markup = 0;
                
                }
                
                str = str + miFragancia.Markup.ToString().Replace(',', '.') + ", ";
                str = str + miFragancia.PrecioVta.ToString().Replace(',', '.') + ", ";
                str = str + "1,";
                if (miFragancia.Vendida == true)
                {
                    str = str + "1)";
                }
                else
                {
                    str = str + "0)";
                }

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool actualizarPedidoMuestraFragancias(PedidosMuestra_Fragancias miFragancia)
        {
            try
            {
                string str = "UPDATE [MRFragancias].[dbo].[PedidosMuestra_Fragancias] SET ";
                str = str + "[NombreVenta] = " + "'" + miFragancia.NombreVenta + "', ";
                str = str + "[NombreReal] = " + "'" + miFragancia.NombreReal + "', ";
                str = str + "[idFragComb] = " + miFragancia.idFragComb.ToString().Replace(',', '.') + ", ";
                str = str + "[CombPrincipal] = " + "'" + miFragancia.CombPrincipal + "', ";
                str = str + "[idComb] = " + miFragancia.idComb.ToString().Replace(',', '.') + ", ";
                str = str + "[Porcentaje] = " + miFragancia.Porcentaje.ToString().Replace(',', '.') + ", ";
                str = str + "[Costo] = " + miFragancia.Costo.ToString().Replace(',', '.') + ", ";
                str = str + "[CostoCalculado] = " + miFragancia.CostoCalculado.ToString().Replace(',', '.') + ", ";
                str = str + "[CostoComb] = " + miFragancia.CostoComb.ToString().Replace(',', '.') + ", ";
                str = str + "[Gramos] = " + miFragancia.Gramos.ToString().Replace(',', '.').ToString().Replace(',', '.') + ", ";
                str = str + "[Markup] = " + miFragancia.Markup.ToString().Replace(',', '.') + ", ";
                str = str + "[PrecioVta] = " + miFragancia.PrecioVta.ToString().Replace(',', '.') + ", ";
                str = str + "[Presentada] = " + (miFragancia.Presentada == true ? "1" : "0");
                str = str + "[Vendida] = " + (miFragancia.Vendida == true ? "1" : "0");
                str = str + "WHERE idPedidoMuestra = " + miFragancia.idPedidoMuestra.ToString();
                str = str + " AND idFragancia = " + miFragancia.idFragancia.ToString(); 

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public DataTable getPedidosMuestraFragancia(int idPedidoMuestra)
        {
            try
            {
                DataTable dt = AccesoADatos.connectToDB.fillTableSQL("EXEC [dbo].[Reporte_PedidosMuestra_Fragancias] @idPedidoMuestra = " + idPedidoMuestra.ToString());
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<PedidosMuestra_Fragancias> getFraganciasFromPedidoMuestra(int idPedidoMuestra)
        {
            try
            {
                List<PedidosMuestra_Fragancias> _listFragancias = new List<PedidosMuestra_Fragancias>();

                DataTable dtFragancias = AccesoADatos.connectToDB.fillTableSQL("SELECT * FROM [MRFragancias].[dbo].[PedidosMuestra_Fragancias] where idPedidoMuestra = " + idPedidoMuestra.ToString());

                if (dtFragancias.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFragancias.Rows.Count; i++)
                    {
                        PedidosMuestra_Fragancias _miFragancia = new PedidosMuestra_Fragancias();

                        _miFragancia.idPedidoMuestra = int.Parse(dtFragancias.Rows[i]["idPedidoMuestra"].ToString());
                        _miFragancia.idFragancia = dtFragancias.Rows[i]["idFragancia"].ToString();
                        _miFragancia.NombreVenta = dtFragancias.Rows[i]["NombreVenta"].ToString();
                        _miFragancia.NombreReal = dtFragancias.Rows[i]["NombreReal"].ToString();
                        _miFragancia.idFragComb = dtFragancias.Rows[i]["idFragComb"].ToString();
                        _miFragancia.CombPrincipal = dtFragancias.Rows[i]["CombPrincipal"].ToString();
                        _miFragancia.idComb = int.Parse(dtFragancias.Rows[i]["idComb"].ToString());
                        _miFragancia.Porcentaje = double.Parse(dtFragancias.Rows[i]["Porcentaje"].ToString());
                        _miFragancia.Costo = double.Parse(dtFragancias.Rows[i]["Costo"].ToString());
                        _miFragancia.CostoCalculado = double.Parse(dtFragancias.Rows[i]["CostoCalculado"].ToString());
                        _miFragancia.CostoComb = double.Parse(dtFragancias.Rows[i]["CostoComb"].ToString());
                        _miFragancia.Gramos =double.Parse( dtFragancias.Rows[i]["Gramos"].ToString());
                        _miFragancia.Markup = double.Parse(dtFragancias.Rows[i]["Markup"].ToString());
                        _miFragancia.PrecioVta = double.Parse(dtFragancias.Rows[i]["PrecioVta"].ToString());
                        _miFragancia.Presentada = dtFragancias.Rows[i]["Presentada"].ToString() == "True" ? true : false;
                        _miFragancia.Vendida = dtFragancias.Rows[i]["Vendida"].ToString() == "True" ? true : false;

                        _listFragancias.Add(_miFragancia);
                    }
                }
                else
                {
                    throw new Exception();
                }

                return _listFragancias;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool actualizarFraganciaAVendida(int idPedidoMuestra, int idFragancia)
        {
            try
            {
                string str = "";
                str = "UPDATE MRFragancias..PedidosMuestra_Fragancias ";
                str = str + "SET Vendida = 1 ";
                str = str + "WHERE idPedidoMuestra = "+ idPedidoMuestra +" AND idFragancia = " + idFragancia + " ";

                AccesoADatos.connectToDB.launchCommand(str);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
    }
}
