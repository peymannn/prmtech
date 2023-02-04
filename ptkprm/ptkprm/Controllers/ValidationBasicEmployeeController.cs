using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ptkprm.Controllers
{
    public class BasicEmployee
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10,ErrorMessage ="Invalid Name Lenght")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone is not valid.")]
        public string Phone { get; set; }

        [Range(minimum: 30, maximum: 400, ErrorMessage = "Hourly salary does not fall within allowed range.")]
        public decimal HourlySalary { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValidationBasicEmployeeController : ControllerBase
    {
        public ValidationBasicEmployeeController()
        {

        }

        [HttpPost]
        public BasicEmployee Post([FromBody] BasicEmployee employee)
        {
            return employee;
        }



    }
}
