using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace BudgetTracker.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BudgetTrackerUser class
public class AppUser : IdentityUser
{
    #region Relationships
    public IQueryable<Budget>? Budgets { get; internal set; }
    #endregion
}

