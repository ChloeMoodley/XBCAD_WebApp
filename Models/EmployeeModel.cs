using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace XBCAD_WebApp.Models
{
    //assisted with adding models Rick-Anderson (2022)
    public class EmployeeModel
    {
        // Declaration of property ()
        //code modified by Downing (2019) for datatype
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

        //this code was modified by Troelsen & Japikse (2017)
        public EmployeeModel()
        {
            
        }

        //this code was modified by Troelsen & Japikse (2017)
        public EmployeeModel(string employee_Password, string employee_Email)
        {
            employee_Password = employee_Password;
            employee_Email = employee_Email;
        }

    }
}
