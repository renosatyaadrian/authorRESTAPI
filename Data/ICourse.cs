using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Models;

namespace authorRESTAPI.Data
{
    public interface ICourse:ICrud<Course>
    {
        Task<IEnumerable<Course>> GetAllCourseByAuthor(int id);
    }
}