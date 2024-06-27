using Fiap.Web.RotaDaReciclagem.Models;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Agendamento
{
    public class AgendamentoDetailViewModel
    {
        [Display(Name = "Id do Agendamento")]
        public int AgendamentoId { get; set; }

        [Display(Name = "Data do Agendamento")]
        public DateTime Data { get; set; }

        [Display(Name = "Tipo de Resíduo")]
        public string TipoResiduo { get; set; }

        [Display(Name = "Quantidade (L)")]
        public int QuantidadeLitros { get; set; }

        [Display(Name ="Id do Caminhão")]
        public int CaminhaoId { get; set; }

        public CaminhaoModel Caminhao { get; set; }

        public MoradorModel Morador { get; set; }
    }
}
