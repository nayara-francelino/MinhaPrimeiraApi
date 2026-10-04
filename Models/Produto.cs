using System.ComponentModel.DataAnnotations;

namespace MinhaPrimeiraApi.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Range(0.01, 10000)]
        public decimal Preco { get; set; }
    }
}