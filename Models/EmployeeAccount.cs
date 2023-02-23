using System;

namespace Models;

/*
    - As an employee, I should be able to submit a ticket 
    - As an employee, I should be able to create Account
    - As an employee, I should be able to view past submitted tickets
*/
public class EmployeeAcct: Account{

    //constructor
    public EmployeeAcct(){
        ticketList = new List<Ticket>();
        this.workerType = 'E';
    }

    //to worker info
    public override string ToString(){
        return "HI";
    }

    

    //validate employee name input 

    /*  This method creates ticket and adds to list 
        it returns a ticket value so that it is added to manager list
    */
    public Ticket submitTicket(){
        Ticket ticket = new Ticket();
        ticketList.Add(ticket);
        return ticket; 
    }

}
