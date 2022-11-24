using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace XBCAD_WebApp.Models
{
    public class EmployeeModel
    {
        // Declaration of property ()

        [Key]
        public int emp_id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string emp_Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string emp_Password { get; set; }


        /*        public string Employee_Password { get; set; }
                public string Employee_Email { get; set; }*/

        // Creation of constructor ()

        public EmployeeModel()
        {
            
        }

        public EmployeeModel(string employee_Password, string employee_Email)
        {
            employee_Password = employee_Password;
            employee_Email = employee_Email;
        }

    }
}
