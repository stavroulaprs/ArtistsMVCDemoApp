using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.Repositories
{
    public class MessageRepository : IMessageData
    {
        private ApplicationDbContext _context;

        public MessageRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public Message GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Message message = _context.Messages
                .SingleOrDefault(a => a.ID == id);

            if (!message.IsRead)
            {
                message.IsRead = true;
                Save();
            }

            return message;
        }
        public void Create(Message message)
        {
            message.Date = DateTime.Now;

            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Update(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            Message message = GetById(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}