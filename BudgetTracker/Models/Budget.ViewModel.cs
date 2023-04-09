using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetTracker.Models
{
    public class BudgetViewModel : Budget
    {
        public IEnumerable<SelectListItem> Periodicities { get; set; }
    }
}
