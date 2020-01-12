using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Interfaces
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<Student> GetByIdWithEnrollmentsAndClassesAsync(string id);
    }
}
