using BudgetTracker.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Models
{
    public class Budget
    {
        #region Entity fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public PeriodicityType Periodicity { get; set; }

        [Required]
        [Display(Name = "Starting from")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [Display(Name ="Ends at")]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }

        public bool Repeats { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Created At")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        [DisplayName("Last Updated")]
        public DateTime? UpdatedDate { get; set; }
        #endregion

        #region Relationships
        public AppUser? AppUser { get; set; }
        public IQueryable<ExpenseDetail>? ExpenseDetail { get; set; }
        #endregion
    }

    public enum PeriodicityType
    {
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Custom,
    }

    public static class PeriodicityTypeDisplay
    {
        public static readonly string Daily = "Daily";
        public static readonly string Weekly = "Weekly";
        public static readonly string Monthly = "Monthly";
        public static readonly string Yearly = "Yearly";
        public static readonly string Custom = "Custom";

        public static string FromEnum(PeriodicityType periodicityType) => periodicityType switch
        {
            PeriodicityType.Daily => "Daily",
            PeriodicityType.Weekly => "Weekly",
            PeriodicityType.Monthly => "Monthly",
            PeriodicityType.Yearly => "Yearly",
            PeriodicityType.Custom => "Custom",
            _ => "Unknown",
        };
    };
}
