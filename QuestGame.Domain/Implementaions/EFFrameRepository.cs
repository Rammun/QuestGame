using QuestGame.Domain.Entities;
using QuestGame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Implementaions
{
    public class EFFrameRepository : IFrameRepository
    {
        ApplicationDbContext dbContext;

        public EFFrameRepository(ApplicationDbContext dbContext)
        {
            dbContext = this.dbContext;
        }

        public IEnumerable<Frame> GetAll()
        {
            return dbContext.Frames;
        }

        public Frame GetById(int id)
        {
            return dbContext.Frames.Find(id);
        }

        public void Add(Frame frame)
        {
            dbContext.Frames.Add(frame);
        }

        public void Update(Frame frame)
        {
            dbContext.Entry(frame).State = EntityState.Modified;
        }

        public void Delete(Frame frame)
        {
            Delete(frame.Id);
        }

        public void Delete(object id)
        {
            Frame frame = GetById((int)id);
            if (frame != null)
                dbContext.Frames.Remove(frame);
        }
    }
}
