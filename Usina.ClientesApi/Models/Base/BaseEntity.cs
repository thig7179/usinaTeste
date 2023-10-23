using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usina.ClientesApi.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Codigo")]
        public long Codigo { get; set; }
    }
}
