﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Interfaces;

namespace QuestGame.Domain.DBInitializers
{
    public class InitUserAdmin : IInitialization
    {
        public void Initialization(ApplicationDbContext dbContext)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            
            IdentityRole role = new IdentityRole("Admin");

            userManager.Create(user, "password");
            roleManager.Create(role);
            userManager.AddToRole(user.Id, role.Name);
        }
    }
}
