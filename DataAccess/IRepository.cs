/*
    - Interface: used for only containing actions. Naming convention: name starts with I
    - This interface works as a repo interface
    Created by: Melanie Palomino
    Date: Febuary 15,2023
*/
using Models; 

namespace DataAccess; 
public interface IRepository{
    
    /// <summary>
    /// Retrieves all ticket submissions
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    List<Ticket> GetAllTicketSubmissions();

    /// <summary>
    /// Retrieves all ticket submissions
    /// </summary>
    /// <returns>a list of ticket submissions</returns>
    List<Account> GetAllAccounts();

    /// <summary>
    /// Persists a new ticket to storage
    /// </summary>
    void SubmitTicket(Ticket ticketToSubmit);

    void createNewAccount(Account accountToCreate);

    Account checkExistingAccount(int id, string pwd);
}