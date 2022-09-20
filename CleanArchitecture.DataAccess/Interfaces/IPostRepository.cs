using CleanArchitecture.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Interfaces
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetAll();
        Post GetById(int? id);
        void Create(Post post);
        void Update(Post post);
        void Delete(int? id);
    }
}
