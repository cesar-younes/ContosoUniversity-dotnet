using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Interfaces;

namespace ContosoUniversity
{
    public class EditModel : PageModel
    {
        private readonly IAsyncRepository<Student> _repository;

        public EditModel(IAsyncRepository<Student> repository)
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

            var allStudents = await _repository.ListAllAsync();
            Student = allStudents.FirstOrDefault(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repository.UpdateAsync(Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(string id)
        {
            return _repository.GetByIdAsync(id)!=null?true:false;
        }
    }
}
