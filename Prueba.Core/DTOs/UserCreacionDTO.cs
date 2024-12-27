namespace Prueba.Core.DTOs
{
    public class UserCreacionDTO
    {
        public int UseId { get; set; }
        public string? UseName { get; set; }
        public string UseDocument { get; set; } = null!;

        public List<RolDTO> Roles { get; set; }
    }
}
