namespace Fiap.Web.RotaDaReciclagem.ViewModels.Rota
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    public class RotaEditViewModel
    {
        public int RotaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar os pontos de coleta.")]
        [Display(Name = "Pontos de Coleta - separados por ponto e vírgula (;)")]
        [ContainsSemicolon(ErrorMessage = "É necessário informar ao menos 2 pontos de coleta, estando separados por ponto e vírgula.")]
        public string PontosDeColeta { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o horário inicial.")]
        [Display(Name = "Horário Inicial")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioInicial { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o horário final.")]
        [Display(Name = "Horário Final")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioFinal { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar um caminhão.")]
        [Display(Name = "Caminhão")]
        [Range(1, int.MaxValue, ErrorMessage = "O caminhão selecionado é inválido.")]
        public int CaminhaoId { get; set; }

        [Display(Name = "Caminhões")]
        public SelectList Caminhoes { get; set; }

        public RotaEditViewModel()
        {
            Caminhoes = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
