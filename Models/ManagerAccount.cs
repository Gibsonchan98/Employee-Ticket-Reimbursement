using System;

namespace Models;

/*
    - As a manager, I should be be able to approve tickets
    - As a manager, I should have a list of tickets I need to approve
*/
public class ManagerAcct : Account{

    public ManagerAcct(){
        this.workerType = 'M';
        ticketList = new List<Ticket>();
    }

    /*This method approves tickets 
        the string input sends in ticket information
        its return should be used to update the employee's ticket status
        TO DO:
        - validate input better
    */
    public bool approveTicket(string input){
        Console.WriteLine("Would you like to approve this ticket?");
        string? response = Console.ReadLine();
        if(response?.ToLower()[0] == 'y'){
            return true;
        } 
        return false;
    }

    /*This method adds tickets that need to accepted and rejected*/
    public void addToList(Ticket submission){
        ticketList.Add(submission);
    }

    /*This method should only return tickets that still need to be approved */
    public List<Ticket> showPendingTickets(){
        return this.ticketList;
    }
}