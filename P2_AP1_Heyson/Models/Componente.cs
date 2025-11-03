using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P2_AP1_Heyson.Models;

public class Componente
{
    [Key]
        public int ComponenteId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
}