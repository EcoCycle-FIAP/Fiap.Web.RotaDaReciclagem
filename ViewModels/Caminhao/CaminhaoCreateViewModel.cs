using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Caminhao
{
    public class CaminhaoCreateViewModel
    {
        public int CaminhaoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome do motorista.")]
        [Display(Name = "Motorista")]
        [StringLength(100, ErrorMessage = "O nome do motorista não pode exceder 100 caracteres.")]
        public string? Motorista { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o modelo do caminhão.")]
        [Display(Name = "Modelo")]
        [StringLength(30, ErrorMessage = "O modelo do caminhão não pode exceder 30 caracteres.")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a placa do caminhão.")]
        [Display(Name = "Placa")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa do caminhão deve ter exatamente 7 caracteres.")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a capacidade em litros.")]
        [Display(Name = "Capacidade (L)")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser um número inteiro positivo.")]
        public int CapacidadeLitros { get; set; }
    }
}
