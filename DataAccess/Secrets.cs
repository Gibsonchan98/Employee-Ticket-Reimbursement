/*
    -This class inherits from IRepository. 
    - This class will not be doing: 
        - Input Validation
        - Console I/O
        - Any complex application logic
    - This class will read and write to SQL databse hosted by Azure.
*/

namespace DataAccess
{
    internal class Secrets
    {
        private static string connectingString = "Server=tcp:etr.database.windows.net,1433;Initial Catalog=ETReimbursement;Persist Security Info=False;User ID=etradmin;Password=123456!T;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public string getConnectionString() => connectingString;
    }
}