using Fiap.Web.RotaDaReciclagem.Models;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Morador
{
    public class MoradorDetailViewModel
    {
        [Display(Name = "Id do Morador")]
        public int MoradorId { get; set; }

        [Display(Name = "Nome do Morador")]
        public string? Nome { get; set; }

        [Display(Name = "Endereco do Morador")]
        public string? Endereco { get; set; }

        [Display(Name = "Nº do Endereço")]
        public int EnderecoNumero { get; set; }

        [Display(Name = "Complemento")]
        public string? EnderecoComplemento { get; set; }

        [Display(Name = "Bairro")]
        public string? EnderecoBairro { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }
        public List<AgendamentoModel>? Agendamentos { get; set; }
    }
}
