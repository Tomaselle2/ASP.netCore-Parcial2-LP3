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
                string filePath = registro.Cells[4].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
            if (e.CommandName == "Eliminar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string fileName = registro.Cells[2].Text;
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
    
    }
}