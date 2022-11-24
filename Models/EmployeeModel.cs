namespace XBCAD_WebApp.Models
{
    public class EmployeeModel
    {
        // Declaration of property ()
        public string email { get; set; }
        public string password { get; set; }

        // Creation of constructor ()
        public EmployeeModel(string employee_Password, string employee_Email)
        {
            email = employee_Password;
            password = employee_Email;
        }

        public EmployeeModel()
        {

        }

    }
}
