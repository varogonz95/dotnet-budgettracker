using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Models
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordConfirmed { get; set; } = string.Empty;

        public virtual IQueryable<Budget> Budgets { get; set; }

        public UserAccount() { }
    }
}
