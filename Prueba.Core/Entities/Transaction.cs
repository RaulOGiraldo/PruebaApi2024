namespace PostgresSql.Data;

public partial class Transaction
{
    public int TraId { get; set; }
    public int TraProId { get; set; }
    public DateOnly TraDate { get; set; }
    public decimal TraUnits { get; set; }
    public bool TraIsDeleted { get; set; } = false;
    public int TraUseId { get; set; }

    public virtual Product TraProductos { get; set; } = null!;
    public virtual User User { get; set; } = null!;

}
