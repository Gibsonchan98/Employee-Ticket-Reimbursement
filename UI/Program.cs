/*This will be used for logging*/
using UI; 
using Services; 
using DataAccess; 

/*
    - Look at Repo to see how to log
Download appropriate packages for serilog
dotnet add package serilog
dotnet add package serilog.sinks.console (for logging to console)
dotnet add package serilog.sinks.file (for logging to file)
*/  
    //create repo object 
    IRepository repo = new DBRepository();
    //create service object with deep injection of repo object
    TicketServices service = new TicketServices(repo);
    //AcctService service = new AcctService(repo);

    // How to inject dependencies upon instantiation
    // new MainMenu(new WorkoutService(new FileStorage())).Start();

    MainMenu menu = new MainMenu(service);
    menu.Start();