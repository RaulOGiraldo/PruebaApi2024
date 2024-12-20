namespace PostgresSql.Data;

public partial class Product
{
    public int ProId { get; set; }
    public string ProName { get; set; } = null!;
    public decimal ProStock { get; set; }
    public bool ProIsdeleted { get; set; } = false;

    public virtual List<Transaction> Transactions { get; set; } = null!;
}
