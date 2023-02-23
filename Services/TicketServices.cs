using Models; 
using DataAccess;

namespace Services;

/*Dependency Injection: is a design pattern where the dependency of a class is injected 
through the constructor instead of the class itself having a specific knowledge 
of its dependency, or instantiating itself (instead of inheritng)*/

/*This method checks if ticket submission was approved*/
/*This method checks if account exists in database*/

public class TicketServices {
    private readonly IRepository _repo;      //private of repo interface

    //Implementationof dependecy injection. Needs Irepo to initialize class
    public TicketServices(IRepository repo){
        _repo = repo; 
    }

    //Method gets tickets by calling repo class. Practing abstraction
    public List<Ticket> GetAllTickets(){
        return _repo.GetAllTicketSubmissions();
    }

    //Business logic that is not UI or DataAcess, so a method that provides a service that 
    //does not belong to a specifi UI or DA, just a system service
    public List<Ticket> searchTicketByStatus(string status){
        List<Ticket> filtered = new List<Ticket>();
        //logic for filtering list to return list of desire status
        return filtered; 
    }

    public void submitTicket(Ticket ticketToCreate){
        _repo.SubmitTicket(ticketToCreate);
    }

    public List<Ticket> GetAllAccounts(){
        return _repo.GetAllTicketSubmissions();
    }

    /*This method checks if account exists in order to login user
        This could potentially be replaced with query later on
    */
    public char loginUser(string sid, string pwd){
        //check if account is in db
        Account acct = new();
        if(Int32.TryParse(sid, out int id)){
            acct = _repo.checkExistingAccount(id,pwd);
        }

        if(acct != null){
            return acct.workerType;
        }
        
        return 'N';
    }

    public bool newAccount(Account newAccount){

        if(_repo.checkExistingAccount(newAccount.workId,newAccount.password) == null){
            _repo.createNewAccount(newAccount);
            return true;
        }
       return false;
    }
}