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
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public DetailsModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _repository.GetByIdWithEnrollmentsAndClassesAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
