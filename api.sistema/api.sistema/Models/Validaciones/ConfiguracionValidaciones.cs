using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.sistema.Models
{
    [MetadataType(typeof(configuracion.MetaData))]
    public partial class configuracion
    {
        sealed class MetaData
        {
            [Required]
            public long id;
            [Required]
            public float tasa;
            [Required]
            public float enganche;
            [Required]
            public short plazo;
        }
    }
}