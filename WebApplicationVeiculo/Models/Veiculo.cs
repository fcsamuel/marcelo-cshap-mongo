using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationVeiculo.Models
{
    public class Veiculo
    {
        public ObjectId Id { get; set; }
        [Display(Name = "Código")]
        public int veiculoId { get; set; }
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [Display(Name = "Cor")]
        public string cor { get; set; }
        [Display(Name = "Ano de fabricação")]
        public int anoFabricacao { get; set; }
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
        [Display(Name = "Data de aquisição")]
        public string dataAquisicao { get; set; }

    }
}