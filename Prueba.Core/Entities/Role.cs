using Prueba.Core.Entities;

namespace PostgresSql.Data;

public partial class Role
{
    public int RolId { get; set; }
    public string RolName { get; set; } = null!;

    //public virtual ICollection<User> UsurolUsus { get; set; } = new List<User>();

    public virtual List<UsersInRoles> UsersInRoles { get; set; } = null!;

}
