using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Entity;
using  System.ComponentModel.DataAnnotations;

namespace turismoDotnet.Models {

    public class SitioInputModel {
        [Required (ErrorMessage  =  "El nombre  es requerido")]
        public string Nombre { get; set; }

        [Required (ErrorMessage  =  "La descripcion  es requerida")]
        public string Descripcion { get; set; }

        [Required (ErrorMessage  =  "La informacion  es requerida")]
        public string Informacion { get; set; }

        [Required (ErrorMessage  =  "La imagen  es requerida")]
        public string ImagenesPath { get; set; }
    }
    public class SitioViewModel : SitioInputModel {
        public SitioViewModel () {

        }
        public SitioViewModel (Sitio sitio) {
            Nombre = sitio.Nombre;
            Descripcion = sitio.Descripcion;
            Informacion = sitio.Informacion;
            ImagenesPath = sitio.ImagenesPath;
        }
    }
}