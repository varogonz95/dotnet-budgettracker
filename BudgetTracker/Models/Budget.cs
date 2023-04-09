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
        public string? Name { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CustomPeriodicity { get; set; }

        [Required]
        public PeriodicityType Periodicity { get; set; }

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
        CustomFixed,
        CustomRepeatable
    }

    public static class PeriodicityTypeDisplay
    {
        public static readonly string Daily = "Daily";
        public static readonly string Weekly = "Weekly";
        public static readonly string Monthly = "Monthly";
        public static readonly string Yearly = "Yearly";
        public static readonly string CustomFixed = "CustomFixed";
        public static readonly string CustomRepeatable = "CustomRepeatable";

        public static string FromEnum(PeriodicityType periodicityType) => periodicityType switch
        {
            PeriodicityType.Daily => "Daily",
            PeriodicityType.Weekly => "Weekly",
            PeriodicityType.Monthly => "Monthly",
            PeriodicityType.Yearly => "Yearly",
            PeriodicityType.CustomFixed => "Custom Fixed",
            PeriodicityType.CustomRepeatable => "Custom Repeatable",
            _ => "NA",
        };
    };
}
