using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThreePage.Services;

namespace ThreePage.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        public readonly IDepartmentService _departmentService;
        [BindProperty]
        public ThreePage.Models.Department department { get; set; }

        public AddDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _departmentService.Add(department);
            return RedirectToPage("/Index");
        }
    }
}
