﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDiary.Data.Entities
{
    public class User : IdentityUser
    {
        
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public ICollection<WeightCondition>? WeightConditions { get; set; } 

        public ICollection<Target>? Targets { get; set; } 

        public ICollection<Meal>? Meals { get; set; } 

        public UserMenu UserMenu { get; set; }
        
        [ForeignKey(nameof(UserMenu))]
        public int UserMenuId { get; set; }
    }
}
