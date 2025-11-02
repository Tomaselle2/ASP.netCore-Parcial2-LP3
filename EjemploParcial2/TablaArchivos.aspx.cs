using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploParcial2
{
    public partial class TablaArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        public void cargarGrilla()
        {
            string path = $"{Server.MapPath(".")}/files";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                List<Archivos> fileList = new List<Archivos>();

                foreach (string file in files)
                {
                    string nombre = Path.GetFileName(file);
                    long tamanio = new FileInfo(file).Length / 1024;
                    string vpath = $"~/files/{nombre}";
                    var fileNew = new Archivos(nombre, file, vpath, tamanio);
                    fileList.Add(fileNew);
                }

                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[5].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
            if (e.CommandName == "Eliminar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string fileName = registro.Cells[3].Text;
                string fullPath = Path.Combine(Server.MapPath("~/files"), fileName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    string script = $@"
                            Swal.fire({{
                                title: 'Éxito',
                                text: '{"Archivo eliminado exitosamente"}',
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }});
                        ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                }
                else
                {
                    string script = $@"
                        Swal.fire({{
                            title: 'Error',
                            text: '{$"El archivo '{fileName}' no existe o ya fue eliminado."}',
                            icon: 'error',
                            confirmButtonText: 'Aceptar'
                        }});
                    ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                }
                cargarGrilla();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string nombreArchivo = row.Cells[3].Text;
            Image1.ImageUrl = "~/images/" + nombreArchivo;
        }

        //boton de agregar productos
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["descripcion"].DefaultValue = TextBox1.Text;
            SqlDataSource1.InsertParameters["precio"].DefaultValue = TextBox2.Text;
            SqlDataSource1.InsertParameters["url"].DefaultValue = FileUpload1.FileName;
            

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;

            string result = string.Empty;
            try
            {
                string path = $"{Server.MapPath(".")}/images";

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
                        SqlDataSource1.Insert();
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
        }
    }
}