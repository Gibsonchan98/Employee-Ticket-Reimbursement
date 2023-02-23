using System;
namespace DataAccess; 

internal class Secrets{
    private const string connectingString = "Server=tcp:etr.database.windows.net,1433;Initial Catalog=ETReimbursement;Persist Security Info=False;User ID=etradmin;Password=123456!T;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public string getConnectionString() => Secrets.connectingString;
}