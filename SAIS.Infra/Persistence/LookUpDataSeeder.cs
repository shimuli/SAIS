using SAIS.Core.Domain.Entities;
using SAIS.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Infra.Persistence;

public class LookUpDataSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Genders
        if (!context.Genders.Any())
        {
            context.Genders.AddRange(
                new Gender { Value = "Male" },
                new Gender { Value = "Female" },
                new Gender { Value = "Other" }
            );
        }

        // Marital Statuses
        if (!context.MaritalStatuses.Any())
        {
            context.MaritalStatuses.AddRange(
                new MaritalStatus { Value = "Single" },
                new MaritalStatus { Value = "Married" },
                new MaritalStatus { Value = "Divorced" },
                new MaritalStatus { Value = "Widowed" }
            );
        }

        // Programmes
        if (!context.Programmes.Any())
        {
            context.Programmes.AddRange(
                new Programme {  Name = "Cash Transfer for Orphans and Vulnerable Children" },
                new Programme { Name = "Older Persons Cash Transfer" },
                new Programme {  Name = "Persons with Severe Disabilities Cash Transfer" },
                new Programme {  Name = "Inua Jamii Senior Citizens Programme" }
            );
        }

        await context.SaveChangesAsync();
    }
}