namespace Prueba.Core.DTOs
{
    public class ProductCreacionDTO
    {
        public int ProId { get; set; }
        public string ProName { get; set; } = null!;
        public decimal ProStock { get; set; }
        public bool ProIsdeleted { get; set; }

    }
}
