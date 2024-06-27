namespace Fiap.Web.RotaDaReciclagem.Models
{
    public class MoradorModel
    {
        public int MoradorId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int EnderecoNumero { get; set; }
        public string? EnderecoComplemento { get; set; }
        public string? EnderecoBairro { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Senha { get; set; }
        public List<AgendamentoModel>? Agendamentos { get; set; }
    }
}
