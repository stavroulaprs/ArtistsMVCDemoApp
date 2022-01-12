using ArtistsMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistsMVCDemo.Repositories
{
    interface IMessageData :IDisposable
    {
        IEnumerable<Message> GetAll();
        Message GetById(int? id);
        void Create(Message message);
        void Update(Message message);
        void Delete(int? id);
    }
}
