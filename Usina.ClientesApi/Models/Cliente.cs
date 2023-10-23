using System.ComponentModel.DataAnnotations.Schema;
using Usina.ClientesApi.Models.Base;

namespace Usina.ClientesApi.Models
{
    [Table("cliente")]
    public class Cliente : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("Cidade")]
        public string Cidade { get; set; }
        [Column("UF")]
        public string UF { get; set; }
        [Column("DataInsercao")]
        public DateTime DataInsercao { get; set; }
    }
}
