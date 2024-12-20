using Prueba.Core.Entities;

namespace PostgresSql.Data;

public partial class User
{
    public int UseId { get; set; }
    public string? UseName { get; set; }
    public string UseDocument { get; set; } = null!;

    //public virtual ICollection<Role> UsurolRols { get; set; } = new List<Role>();
    public virtual List<UsersInRoles> UsersInRoles { get; set; } = null!;
    public virtual List<Transaction> Transactions { get; set; } = null!;

}
