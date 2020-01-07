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
    public class DeleteModel : PageModel
    {
        private readonly IAsyncRepository<Student> _repository;

        public DeleteModel(IAsyncRepository<Student> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _repository.GetByIdAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _repository.GetByIdAsync(id);

            if (Student != null)
            {
                await _repository.DeleteAsync(Student);
                
            }

            return RedirectToPage("./Index");
        }
    }
}
