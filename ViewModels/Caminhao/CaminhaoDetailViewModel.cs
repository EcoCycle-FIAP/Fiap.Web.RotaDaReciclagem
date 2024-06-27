using Fiap.Web.RotaDaReciclagem.Models;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.RotaDaReciclagem.ViewModels.Caminhao
{
    public class CaminhaoDetailViewModel
    {
        [Display(Name = "Id do Caminhao")]
        public int CaminhaoId { get; set; }

        [Display(Name = "Nome do Motorista")]
        public string? Motorista { get; set; }

        [Display(Name = "Modelo do Caminhao")]
        public string? Modelo { get; set; }

        [Display(Name = "Placa do Caminhao")]
        public string? Placa { get; set; }

        [Display(Name = "Capacidade (L)")]
        public int CapacidadeLitros { get; set; }
        public List<AgendamentoModel>? Agendamentos { get; set; }
        public List<RotaModel>? Rotas { get; set; }
    }
}
