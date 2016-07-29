using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain;
using QuestGame.Domain.DBInitializers;
using System.Diagnostics;

namespace QuestGame.Domain
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private Random rnd = new Random();

        protected override void Seed(ApplicationDbContext dbContext)
        {
            // Здесь инициализируем БД

            DBInitialization initialization = new DBInitialization(dbContext);

            // Здесь добавляем созданные нами объекты, наследованные от InitializationDB, для инициализации БД            // Пример DBInitilizers.InitUserAdmin
            initialization.Add(new InitUserAdmin());
            initialization.Add(new InitQuests());
            try
            {
                initialization.Initialization();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }
    }
}
