using System;

namespace Models; 

public class Ticket{
    public string? type {get; set; } //change back to non-nullable later
    public string? description {get; set; } //change back to non-nullable later
    public decimal amount {get; set; }
    public DateTime date {get; set; }
    public int idTicket {get; private set; }

    public bool approval {get; set;}      //approved by manager or not

    //display ticket info
    public override string ToString()
    {
        return $"Date: {this.date} \n Description: {this.description} \n Amount: {this.amount}";
    }
}