using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Models
{
    public class Budget
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Created At")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        [DisplayName("Last Updated")]
        public DateTime? UpdatedDate { get; set; }

        // Relationships
        public Guid UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
