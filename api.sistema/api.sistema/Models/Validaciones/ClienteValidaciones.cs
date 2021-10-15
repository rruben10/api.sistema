using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.sistema.Models
{
    //Se crean validaciones para los cambios de la tabla clientes
    [MetadataType(typeof(clientes.MetaData))]
    public partial class clientes
    {
        //Se sella clase para que no se pueda heredar
        sealed class MetaData
        {
            [Required]
            public string nombre;
            [Required]
            public string apellidoPaterno;
            [Required]
            public string apellidoMaterno;
            [Required]
            public string RFC;
        }
    }
}