namespace Prueba.Core.DTOs
{
    public class TransactionCreacionDTO
    {
        public int TraId { get; set; }
        public int TraProId { get; set; }
        public DateOnly TraDate { get; set; }
        public decimal TraUnits { get; set; }
        public bool TraIsDeleted { get; set; } = false;
        public int TraUseId { get; set; }

    }
}
