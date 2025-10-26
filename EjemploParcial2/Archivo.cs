using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploParcial2
{
    public class Archivos
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string VPath { get; set; }
        public long Tamanio { get; set; }

        public Archivos(string name, string path, string vpath, long tamanio)
        {
            Name = name;
            Path = path;
            VPath = vpath;
            Tamanio = tamanio;
        }
    }
}