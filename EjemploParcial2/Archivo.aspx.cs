using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class Archivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //subir archivo
        protected void Button1_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            try
            {
                string path = $"{Server.MapPath(".")}/files";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
                {
                    bool validacion = true;
                    if (archivo.FileName == "")
                    {
                        result += $"No selecciono ningun archivo";
                        validacion = false;
                    }
                    if (archivo.ContentLength > 2097152)
                    {
                        result += $"El archivo {archivo.FileName} supera los 2 Mb. - ";
                        validacion = false;
                    }

                    //archivo.ContentType = "text/plain"; "image/jpeg"; "application/pdf"; "application/zip";
                    if (File.Exists($"{path}/{archivo.FileName}"))
                    {
                        result += $"El archivo {archivo.FileName} ya existe - ";
                        validacion = false;
                    }

                    if (archivo.ContentType != "image/jpeg" && archivo.ContentType != "image/jpg" && archivo.FileName != "")
                    {
                        result += $"El archivo {archivo.FileName} no es imagen";
                        validacion = false;
                    }
                    if (!validacion)
                    {
                        throw new Exception(result);
                    }
                    else
                    {
                        FileUpload1.SaveAs($"{path}/{archivo.FileName}");

                        string script = $@"
                            Swal.fire({{
                                title: 'Éxito',
                                text: '{"Archivo guardado exitosamente"}',
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }});
                        ";
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                    }
                }
            }
            catch (Exception)
            {
                string script = $@"
                Swal.fire({{
                    title: 'Error',
                    text: '{result}',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                }});
            ";
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
            }
            finally
            {
                //cargarGrilla();
            }
        }
    }
}