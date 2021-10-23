using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestApi
{
    
    public partial class SolicitudAprobacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button5_Click(object sender, EventArgs e)
        {
            //buscar documento info previa

            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000106/DOM_Casa_Blanca/InformacionPrevia";

            string parametros = String.Format("ROL={0}&RecuperarDocumento={1}", TextBoxRolInfoPrevia.Text, true);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var info = JsonConvert.DeserializeObject<InformacionPrevia>(responseString);

                    Response.ContentType = "application/force-download";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=certificado.pdf");
                    Response.BinaryWrite(info.documento);

                    Response.End();
                }
                else
                {
                    AgregarMensaje("buscar info previa");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar info previa");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }




            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //buscar info previa
            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000106/DOM_Casa_Blanca/InformacionPrevia";

            string parametros = String.Format("ROL={0}&RecuperarDocumento={1}", TextBoxRolInfoPrevia.Text, false);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;

            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    AgregarMensaje(responseString);
                    var info = JsonConvert.DeserializeObject<InformacionPrevia>(responseString);

                    TextBoxNumeroPrevio.Text = info.numero;
                    FechaPrevia.Value = info.Fecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    AgregarMensaje("buscar info previa");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch(WebException ex)
            {
                AgregarMensaje("buscar info previa");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }

        }

        void AgregarMensaje( string texto)
        {
            TextBoxMensajes.Text += texto + Environment.NewLine;
        }

        protected void BuscarPropiedad_Click(object sender, EventArgs e)
        {
           
            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000108/CBR/Datos_Propiedad";

            string parametros = String.Format("ROL={0}", TextBoxRolPropiedad.Text);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    /*
                    {
                      "ID": 1,
                      "ROL": "523",
                      "NombreVia": "El Palto",
                      "Numero": 3100,
                      "NumeroLocal": "Depto 33",
                      "Manzana": "M1",
                      "Lote": "L1",
                      "Poblacion": "Miraflores",
                      "Localidad": "Viña del Mar",
                      "NumeroPlano": "321"
                    }
                    */

                    AgregarMensaje(responseString);
                    var propiedad = JObject.Parse(responseString);

                    TextBoxDireccionVia.Text = propiedad["NombreVia"].ToString();
                    TextBoxDireccionNumero.Text = propiedad["Numero"].ToString();
                    TextBoxDireccionNumeroLocal.Text = propiedad["NumeroLocal"].ToString();
                    TextBoxManzana.Text = propiedad["Manzana"].ToString();
                    TextBoxLote.Text = propiedad["Lote"].ToString();
                    TextBoxPoblacion.Text = propiedad["Poblacion"].ToString();
                    TextBoxLocalidad.Text = propiedad["Localidad"].ToString();
                    TextBoxPlanoLoteo.Text = propiedad["NumeroPlano"].ToString();




                }
                else
                {
                    AgregarMensaje("buscar info previa");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar info previa");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }


        }

        
        protected void ButtonEmpresa_Click(object sender, EventArgs e)
        {
            //nada
        }


        protected void ButtonBuscarProfesional_Click(object sender, EventArgs e)
        {
            

            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000106/DOM_V_MAR/Patente_Profesional";

            string parametros = String.Format("RUT={0}", TextBoxRutArquitecto.Text);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    /*
            
                    {
                      "ID": 1,
                      "Nombre": "Juan Pérez",
                      "RUT": "12345678",
                      "Direccion": "mi casa",
                      "Fono": "542984309574",
                      "Email": "jperez@empresa.com",
                      "Profesion": "Ingeniero Civil",
                      "Vigencia": "2024-01-01T00:00:00"
                    }
                    */
                    AgregarMensaje(responseString);
                    var patente = JObject.Parse(responseString);

                    TextBoxNombreArquitecto.Text = patente["Nombre"].ToString();
                    TextBoxPatente.Text = patente["Profesion"].ToString();

                    DateTime Fecha = DateTime.Parse(patente["Vigencia"].ToString());
                    TextBoxFechaPatente.Text = Fecha.Date.ToString("dd/MM/yyyy");
                    
                    CheckBoxVigente.Checked = Fecha >= DateTime.Now.Date;

                }
                else
                {
                    AgregarMensaje("buscar datos patente");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar datos patente");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }
        }

        protected void ButtonBuscarRUT1_Click(object sender, EventArgs e)
        {

            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000108/REGISTRO_CIVIL/Datos_de_Persona";

            string parametros = String.Format("RUT={0}", TextBoxRutPropietario.Text);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    /*
                    {
                      "ID": 3,
                      "RUT": "3344556677",
                      "Nombre": "Roberto Navarro"
                    }
                    
                    */
                    AgregarMensaje(responseString);
                    var persona = JObject.Parse(responseString);

                    TextBoxNombrePropietario.Text = persona["Nombre"].ToString();

                }
                else
                {
                    AgregarMensaje("buscar datos persona");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar datos persona");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }
        }

        protected void ButtonBuscarRutRepresentante_Click(object sender, EventArgs e)
        {
            //se repite lo mismo del metodo anterior, para mejorar: armar metodo que invoque al servicio

            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000108/REGISTRO_CIVIL/Datos_de_Persona";

            string parametros = String.Format("RUT={0}", TextBoxRutRepresentante.Text);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    /*
                    {
                      "ID": 3,
                      "RUT": "3344556677",
                      "Nombre": "Roberto Navarro"
                    }
                    
                    */

                    AgregarMensaje(responseString);
                    var persona = JObject.Parse(responseString);

                    TextBoxRepresentante.Text = persona["Nombre"].ToString();

                }
                else
                {
                    AgregarMensaje("buscar datos persona");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar datos persona");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }
        }

        protected void ButtonBuscarFactibilidad_Click(object sender, EventArgs e)
        {
            string servidor_local = "http://200.120.192.26";
            string protocolo = "r1";
            string servicio = "thinknet/GOV/10000108/ESVAL/Factibilidad_Agua_y_Alcantarillado";

            string parametros = String.Format("ROL={0}", TextBoxRolFactibilidad.Text);

            string urlCompleta = servidor_local + "/" + protocolo + "/" + servicio + "?" + parametros;
            AgregarMensaje(urlCompleta);

            string cliente = "thinknet/GOV/10000106/DOM_Casa_Blanca";

            var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
            request.Headers.Add("X-Road-Client", cliente);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                string responseString = "";
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    /*
                     {
                        "ID": 1,
                        "ROL": "523",
                        "factible": true
                      }
                    
                    */
                    AgregarMensaje(responseString);
                    var persona = JObject.Parse(responseString);

                    CheckBoxFactibilidad.Checked = persona["factible"].ToString().ToUpper() == "TRUE";

                }
                else
                {
                    AgregarMensaje("buscar datos factibilidad");
                    AgregarMensaje("status code=" + response.StatusCode);
                    AgregarMensaje(responseString);
                }
            }
            catch (WebException ex)
            {
                AgregarMensaje("buscar datos factibilidad");
                AgregarMensaje(ex.Message);

                AgregarMensaje(ex.Response.Headers["X-Road-Error"]);

            }
        }
    }
}