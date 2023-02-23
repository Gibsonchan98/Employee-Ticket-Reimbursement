/*
    -This class inherits from IRepository. 
    - This class will not be doing: 
        - Input Validation
        - Console I/O
        - Any complex application logic
    - This class will read and write to SQL databse hosted by Azure.
*/

/*
Reading/writing to DB
1. Connect to DB
2. Assemble/Write the query
3. Execute it
4. Process the data or check that it's been successful
*/
using Models;
using System.Data.SqlClient; 

namespace DataAccess; 

public class DBRepository : IRepository{

    Secrets secrets = new Secrets();

    /*
        Returns all accounts in database
    */
     List<Account> IRepository.GetAllAccounts()
    {
        List<Account> accounts = new();
        // Connecting to Azure server
        try{
            using SqlConnection connection = new SqlConnection(secrets.getConnectionString()); 
            
            //opening connection 
            connection.Open();

            //executing query 
            using SqlCommand cmd = new SqlCommand("Select * FROM EUSERS",connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            Account acct = new();

            while(reader.Read()){
                int accountID = (int) reader["EID"];
                string pwd = (string) reader ["EPassword"];
                string stype = (string) reader ["WorkerType"];
                char type = stype[0];
                if(accounts.Count == 0 || accountID != accounts.Last().workId){
                    acct = new Account {
                    workId = accountID,
                    password = pwd,
                    workerType = type,
                    };
                    accounts.Add(acct);
                }
                
            }


        } catch (Exception e){
            Console.WriteLine("Caught SQL Exception trying to get all accounts {0}");
            throw e;
        }
        return accounts; 
    }

    /*
        This method adds account to database
    */
    public void createNewAccount(Account accountToCreate){
        try{
            //connect to database on Azure
            using SqlConnection connection = new SqlConnection(secrets.getConnectionString()); 
            connection.Open();   //open connection
            //run insert query 
            //NO SEMICOLON ON QUERY STRING!!!!!!!!
            string query =  "INSERT INTO EUSERS(EID, WorkerType, EPassword) VALUES (@id, @wType, @pwd)";
            using SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@id",accountToCreate.workId);
            cmd.Parameters.AddWithValue("@wType",accountToCreate.workerType);
            cmd.Parameters.AddWithValue("@pwd",accountToCreate.password);

            cmd.ExecuteNonQuery();
            connection.Close();

        }catch(SqlException e){
            Console.WriteLine("Caught SQL Exception trying to create new account {0}");
            throw e;
        }
    }


    /*
      - Checks if account exists. 
      - This can be used for login and registration check
      - returns Account object
      */
    public Account checkExistingAccount(int id, string pwd){
        Account existingAcct = new();
        try{
            using SqlConnection con = new SqlConnection(secrets.getConnectionString());
            con.Open();
            //Select * FROM EUSERS WHERE EID = 123 AND EPassword = '123857' 
            string query = "SELECT * FROM EUSERS WHERE EID = @id AND EPassword = @pwd";
            using SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pwd", pwd);

            using SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                int accountID = (int) reader["EID"];
                string ipwd = (string) reader ["EPassword"];
                string stype = (string) reader ["WorkerType"];
                char type = stype[0];
                existingAcct = new Account{
                    workId = accountID,
                    password = ipwd,
                    workerType = type,
                };
            }

            con.Close();

        } catch(SqlException ex){
            Console.WriteLine("Caught SQL Exception trying to find account {0}");
            throw ex;
        }
        return existingAcct;
    }




    /// <summary>
    /// Retrieves all ticket submissions
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    public List<Ticket> GetAllTicketSubmissions()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Persists a new ticket to storage (Adds ticket to database)
    /// </summary>
    public void SubmitTicket(Ticket ticketToSubmit)
    {
        throw new NotImplementedException();
    }

   
}