using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartUpIdeas.DAL;
using Microsoft.Practices.Unity;

namespace StartUpIdeas.Repositories
{
    public class StartUpIdeasRepository : IRepository<StartUpIdeas.DAL.StartUpIdea, int>
    {
        [Dependency]
        public StartUpIdeasEntities context { get; set; }

        public void Add(StartUpIdea entity)
        {
            context.StartUpIdeas.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<StartUpIdea> Get()
        {
            return context.StartUpIdeas.ToList();
        }

        public StartUpIdea Get(int id)
        {
            return context.StartUpIdeas.Find(id);
        }

        public void Remove(StartUpIdea entity)
        {
            var obj = context.StartUpIdeas.Find(entity.Id);
            context.StartUpIdeas.Remove(obj);
            context.SaveChanges();
        }
    }
}