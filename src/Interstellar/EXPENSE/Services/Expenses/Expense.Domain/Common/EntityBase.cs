using System.ComponentModel.DataAnnotations;

namespace Expense.Domain.Common;

public abstract class EntityBase
{
    [Key]
    public int ExpenseId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
