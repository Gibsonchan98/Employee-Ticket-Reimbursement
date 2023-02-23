using System; 
using Models; 
using DataAccess;

namespace Services{

public class AcctService{
    private readonly IRepository _repo;      //private of repo interface

    //Implementationof dependecy injection. Needs Irepo to initialize class
    public AcctService(IRepository repo){
        _repo = repo; 
    }

    public List<Ticket> GetAllAccounts(){
        return _repo.GetAllTicketSubmissions();
    }
    /*This method checks if account exists in order to login user
        This could potentially be replaced with query later on
    */
    public char loginUser(string id, string pwd){
        //get all accounts
        List<Account> accounts = _repo.GetAllAccounts();
        Account succes = new();
        bool goodInput = int.TryParse(id, out int LID);
        foreach(Account a in accounts){
            if(a.workId == LID && a.password == pwd){
                return a.workerType;
            }
        }
        return 'N';
    }
}

}
