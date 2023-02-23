using System; 

namespace UI;
/*
    This class is just to show employee menu
*/ 
public class EMenu{

    public void Start(){
         while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] Submit Ticket");   //add bold to font
            Console.WriteLine("[2] View Submitted Tickets");
            Console.WriteLine("[3] Edit Tickets");
            Console.WriteLine("[4] Log out");
            Console.WriteLine("[x] Exit");   

            string? input = Console.ReadLine();   //nullable reference
            switch(input){
                case "1":
                break;
                case "2":
                break;
                case "3":
                break;
                case "4":  //change to char
                    Console.WriteLine("Going back to start of program");
                break;
                case "x":
                    System.Environment.Exit(0);
                break;
            }
            break;
        }
    }
}