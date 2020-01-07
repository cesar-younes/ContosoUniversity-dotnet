using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Interfaces;

namespace ContosoUniversity
{
    public class IndexModel : PageModel
    {
        private readonly IAsyncRepository<Student> _repository;

        public IndexModel(IAsyncRepository<Student> repository)
        {
            _repository = repository;
        }

        public IList<Student> Students { get;set; }

        public async Task OnGetAsync()
        {
            Students = await _repository.ListAllAsync();
        }
    }
}
