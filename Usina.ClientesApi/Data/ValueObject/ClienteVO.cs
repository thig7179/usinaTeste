using System.ComponentModel.DataAnnotations.Schema;

namespace Usina.ClientesApi.Data.ValueObject
{
    public class ClienteVO
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataInsercao { get; set; }
    }
}
