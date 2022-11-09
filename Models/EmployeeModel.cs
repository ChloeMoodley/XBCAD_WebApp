namespace XBCAD_WebApp.Models
{
    public class EmployeeModel
    {
        // Declaration of property ()
        public string Employee_Username { get; set; }
        public string Employee_Password { get; set; }
        public string Employee_Email { get; set; }

        // Creation of constructor ()
        public EmployeeModel(string employee_Username, string employee_Password, string employee_Email)
        {
            Employee_Username = employee_Username;
            Employee_Password = employee_Password;
            Employee_Email = employee_Email;
        }

    }
}
