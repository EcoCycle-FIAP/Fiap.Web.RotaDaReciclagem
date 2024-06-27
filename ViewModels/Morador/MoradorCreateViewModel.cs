using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Morador
{
    public class MoradorCreateViewModel
    {
        public int MoradorId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome do morador.")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "O nome do morador não pode exceder 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o endereço do morador.")]
        [Display(Name = "Endereço")]
        [StringLength(60, ErrorMessage = "O endereco não pode exceder 60 caracteres.")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o número do endereço.")]
        [Display(Name = "Nº do Endereço")]
        [Range(1, int.MaxValue, ErrorMessage = "O Nº do endereço deve ser um número inteiro positivo.")]
        public int EnderecoNumero { get; set; }

        [Display(Name = "Complemento do Endereço")]
        [StringLength(60, ErrorMessage = "O complemento do endereco não pode exceder 60 caracteres.")]
        public string? EnderecoComplemento { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o bairro do endereço.")]
        [Display(Name = "Bairro do Endereço")]
        [StringLength(30, ErrorMessage = "O bairro do endereco não pode exceder 30 caracteres.")]
        public string? EnderecoBairro { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o email do morador.")]
        [Display(Name = "Email")]
        [StringLength(320, ErrorMessage = "O email do endereco não pode exceder 320 caracteres.")]
        [EmailAddress(ErrorMessage = "O formato do email informado é inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o telefone do morador.")]
        [Display(Name = "Telefone")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "O Nº do telefone deve ter exatamente 15 caracteres.")]
        public string? Telefone { get; set; }

        public string? Senha { get; set; }
    }
}
