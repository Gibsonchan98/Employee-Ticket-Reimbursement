using System; 
using Models;
using DataAccess; 
using Services;

namespace UI;

/*Input authontication is done in UI*/
public class MainMenu{

    private readonly TicketServices _service; 
    //private readonly AcctService _aservice; 
    public MainMenu(TicketServices service){
        this._service = service;
    }

    public void Start(){
        //Display Menu 
        Console.WriteLine("Welcome to Reimbursment System");

        while(true){
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("[1] Login");   //add bold to font
            Console.WriteLine("[2] Create account"); 
            Console.WriteLine("[3] Exit"); 

            string? input = Console.ReadLine();   //nullable reference
            char logintype = 'N';

            switch(input){
                case "1":         //Login user 
                    logintype = loginUser();
                break;
                case "2":         //create new account
                    logintype= createAccount();
                break;
                case "3":         //create new account
                    System.Environment.Exit(0);
                break;
                default:       
                    Console.WriteLine("Please enter valid input");
                break;
            } 

            switch(logintype){
                case 'M':
                    managerMenu();
                break; 
                case 'E':
                    employeeMenu();
                break;
            }
        }
        
    }

    /*
        This method creates new account. It validates input and creates new Account object
        to be added to db.
    */
    private char createAccount(){
        Console.WriteLine("Creating Account");
        Account newAccount = new Account(); 

        while(true){
            Console.WriteLine("Are you a Manager? [Y/N]?");
            string? type = Console.ReadLine();
            if(type.ToLower()[0] == 'n')
            {
                newAccount.workerType = 'E';
            } else if(type.ToLower()[0] == 'y') {
                newAccount.workerType = 'M';
            }

            Console.WriteLine("Please enter your employee ID:");

            if(Int32.TryParse(Console.ReadLine(), out int WID)){
                newAccount.workId = WID;
            }

            
                Console.WriteLine("Please enter valid password");
                string? pwd = Console.ReadLine();
                try{
                    newAccount.password = pwd;  //need to add password parameters in Account later
                    break;
                } catch (ArgumentException ex){  //add exception file later
                    Console.WriteLine(ex.Message);
                }
        

            //create account
            try{
                Console.WriteLine("here2");
                if( _service.newAccount(newAccount)){
                    Console.WriteLine("Succesfully created account.");
                    return newAccount.workerType;
                }
                else {
                    Console.WriteLine("Employee ID is already is use");
                }
                Console.WriteLine("here3");

            }catch(Exception){
                Console.WriteLine("Something went wrong with SQL");
            }
        }
        
        
        return 'N';
    }

    /*This function does the login. Needs to verify account exists. If succesful, then pulls menus depending on employee type.*/
    private char loginUser(){
        Console.WriteLine("Please enter login information.");
        Console.WriteLine("WorkerID:");
        string? id = Console.ReadLine();
        Console.WriteLine("Password:");
        string? pwd = Console.ReadLine();
        //call account service
        return _service.loginUser(id,pwd);
    }


    /*This method calls MMenu */
    private void managerMenu(){
        MMenu mm = new MMenu();
        mm.Start();
    }


    /*This method calls employee Menu*/
    private void employeeMenu(){
        EMenu em = new EMenu();
        em.Start();
    }
}