using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationVeiculo.Models
{
    public class Categoria
    {
        public ObjectId Id { get; set; }
        [Display(Name = "Código")]
        public int categoriaId { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
