using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace XBCAD_WebApp.Models
{
    public class EmployeeModel
    {
        // Declaration of property ()
        public string email { get; set; }
        public string password { get; set; }

        // Creation of constructor ()

        public EmployeeModel()
        {
            
        }

        public EmployeeModel(string employee_Password, string employee_Email)
        {
            password = employee_Password;
            email = employee_Email;
        }

    }
}
