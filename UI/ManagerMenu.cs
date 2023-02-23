using System; 
namespace UI; 
/*
    This class is just to show manager menu
*/
public class MMenu{

    public void Start(){
        while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] View tickets that need approval");   //add bold to font
            Console.WriteLine("[2] Promote Employee"); 
            Console.WriteLine("[3] Log out");       //or exit system
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();   //nullable reference

            switch(input){
                case "1":
                break;
                case "2":
                break;
                case "3":
                break;
                case "x":
                    System.Environment.Exit(0);
                break;
            }
            break;
        }
    }

}