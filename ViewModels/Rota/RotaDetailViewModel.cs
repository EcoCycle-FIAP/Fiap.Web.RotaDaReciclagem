using Fiap.Web.RotaDaReciclagem.Models;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Rota
{
    public class RotaDetailViewModel
    {
        [Display(Name = "Id da Rota")]
        public int RotaId { get; set; }

        [Display(Name = "Pontos de Coleta")]
        public string PontosDeColeta { get; set; }

        [Display(Name = "Horário de Início da Rota")]
        public DateTime HorarioInicial { get; set; }

        [Display(Name = "Horário do Fim da Rota")]
        public DateTime HorarioFinal { get; set; }

        [Display(Name = "Id do Caminhão")]
        public int CaminhaoId { get; set; }

        public CaminhaoModel Caminhao { get; set; }
    }
}
