using System.Threading.Tasks;
using authorRESTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace authorRESTAPI.Data
{
    public class AuthorDAL : IAuthor
    {
        private ApplicationDbContext _db;

        public AuthorDAL(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(string id)
        {
            try
            {
                 var author = await GetById(id);
                 if (author == null) throw new Exception($"Data auther dengan id:{id}, tidak ditemukan");
                 _db.Authors.Remove(author);
                 await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var results = await (from a in _db.Authors orderby a.FirstName ascending select a).AsNoTracking().ToListAsync();
            return results; 
        }

        public async Task<Author> GetById(string id)
        {
            var result = await (from a in _db.Authors where a.ID == Convert.ToInt32(id) select a).SingleOrDefaultAsync();
            return result;
        }

        public async Task<Author> GetByName(string name)
        {
            var result = await (from a in _db.Authors where a.FirstName.Contains(name) || a.LastName.Contains(name) select a).SingleOrDefaultAsync();
            return result;
        }

        public async Task<Author> Insert(Author obj)
        {
            try
            {
                _db.Authors.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public async Task<Author> Update(string id, Author obj)
        {
            try
            {
                 var author = await GetById(id);
                 if (author == null) throw new Exception($"Authod dengan id:{id}, tidak ditemukan");
                 author.FirstName = obj.FirstName;
                 author.LastName = obj.LastName;
                 author.DateOfBirth = obj.DateOfBirth;
                 author.MainCategory = obj.MainCategory;
                 await _db.SaveChangesAsync();
                 return author;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }
    }
}