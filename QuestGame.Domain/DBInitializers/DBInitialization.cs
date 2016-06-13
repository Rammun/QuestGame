using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain;
using QuestGame.Domain.Interfaces;

namespace QuestGame.Domain.DBInitializers
{
    public class DBInitialization
    {
        List<IInitialization> methods;
        ApplicationDbContext context;

        public DBInitialization(ApplicationDbContext context)
        {
            this.context = context;
            this.methods = new List<IInitialization>();
        }

        public void Add(IInitialization initObject)
        {
            methods.Add(initObject);
        }

        public void Initialization()
        {
            foreach (var method in methods)
                method.Initialization(context);
        }
    }
}
