using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Fiap.Web.RotaDaReciclagem.ViewModels.Agendamento
{
    public class AgendamentoCreateViewModel
    {
        public int AgendamentoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a data.")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o tipo de resíduo.")]
        [Display(Name = "Tipo de Resíduo")]
        [StringLength(60, ErrorMessage = "O tipo de resíduo não pode exceder 60 caracteres.")]
        public string TipoResiduo { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a quantidade em litros.")]
        [Display(Name = "Quantidade (L)")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser um número inteiro positivo.")]
        public int QuantidadeLitros { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar um caminhão.")]
        [Display(Name = "Caminhão")]
        [Range(1, int.MaxValue, ErrorMessage = "O caminhão selecionado é inválido.")]
        public int CaminhaoId { get; set; }

        [Display(Name = "Caminhões")]
        public SelectList Caminhoes { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar um morador.")]
        [Display(Name = "Morador")]
        [Range(1, int.MaxValue, ErrorMessage = "O morador selecionado é inválido.")]
        public int MoradorId { get; set; }

        [Display(Name = "Moradores")]
        public SelectList Moradores { get; set; }

        public AgendamentoCreateViewModel()
        {
            Caminhoes = new SelectList(Enumerable.Empty<SelectListItem>());
            Moradores = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
