using PostgresSql.Data;

namespace Prueba.Core.Entities
{
    public class UsersInRoles
    {
        public int UsurolUsuId { get; set; }
        public int UsurolRolId { get; set; }

        public virtual Role Rol { get; set; } = null!;
        public virtual User User { get; set; } = null!;

    }
}
