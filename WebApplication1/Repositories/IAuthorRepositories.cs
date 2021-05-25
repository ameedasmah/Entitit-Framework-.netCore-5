using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
   public interface IAuthorRepositories
    {
         Task<IEnumerable<Author>> GetAuthors();
         Task<Author> GetAuthor(int Id);
         Task<Author> CreateAuthor(Author author);
         Task Update(Author author);


    }
}
