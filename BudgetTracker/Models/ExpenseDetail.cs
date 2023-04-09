using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Models
{
    public class ExpenseDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [Precision(10, 2)]
        [DataType(DataType.Currency)]
        public decimal? ExpectedAmount { get; set; }

        [Precision(10, 2)]
        [DataType(DataType.Currency)]
        public decimal? ActualAmount { get; set; } = null;

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedTime { get; set; }

        // Relationships
        public int BudgetId { get; set; }
        public Budget? Budget { get; set; }
    }
}
