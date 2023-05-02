using mis_221_pa_5_aeholmes1;

Trainer[] trainers = new Trainer[500];
TrainerUtility trainUtility = new TrainerUtility(trainers);
Reports trainReport = new Reports(trainers);

Listing[] listings = new Listing[500];
ListingUtility listUtility = new ListingUtility(listings, trainUtility);
Reports listReport = new Reports(listings);

Transaction[] transactions = new Transaction[500];
TransactionUtility tranUtility = new TransactionUtility(transactions, listUtility);
Reports tranReport = new Reports(transactions);

// start main

string menuInput = GetMenuChoice();
while (menuInput != "5") {
    RouteMainMenu(menuInput);
    menuInput = GetMenuChoice();
}

// end main

// make sure to route report functions

// extra (?): add nice user interface with logo or art or something

// extra: add log in with username and password
    // username and password are stored in a file and read in/searched when logging in
    // create new account function for trainers or customers
        // bool to check if customer/trainer status is true, customer/trainer portal only lets you log in if the bool returns true
    // methods: AddAccount, Save, Find, UpdateAccount (if there's time, as a "forgot my password" kind of thing; will also require verification code)

static string GetMenuChoice() {
    DisplayMenu();
    string menuInput = Console.ReadLine();

    while (!ValidMenuChoice(menuInput)) {
        System.Console.WriteLine("Invalid menu choice. Please enter a valid menu choice.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayMenu();
        menuInput = Console.ReadLine();
    }
    return menuInput;
}

static void DisplayMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter a number to choose a menu item.");
    System.Console.WriteLine("1:     Manage Trainer Data");
    System.Console.WriteLine("2:     Manage Listing Data");
    System.Console.WriteLine("3:     Manage Customer Booking Data");
    System.Console.WriteLine("4:     Run Reports");
    System.Console.WriteLine("5:     Exit Program");
}

static bool ValidMenuChoice(string menuInput) {
    var userChoice = int.Parse(menuInput);
    bool menuTruth = userChoice <= 5 && userChoice >= 1;
    return menuTruth;
}

void RouteMainMenu(string menuInput) {
    var userChoice = int.Parse(menuInput);
    if (userChoice == 1) {
        TrainerData();
    }
    else if (userChoice == 2) {
        ListingData();
    }
    else if (userChoice == 3) {
        CustomerBookingData();
    }
    else if (userChoice == 4) {
        RunReports();
    }
    else {
        return;
    }
}

void TrainerData() {
    string trainerMenuInput = GetTrainerMenuChoice();
    while (trainerMenuInput != "5") {
        RouteTrainerMenu(trainerMenuInput);
        trainerMenuInput = GetTrainerMenuChoice();
    }
}

static string GetTrainerMenuChoice() {
    DisplayTrainerMenu();
    string trainerMenuInput = Console.ReadLine();

    while (!ValidTrainerMenuChoice(trainerMenuInput)) {
        System.Console.WriteLine("Invalid menu choice. Please enter a valid menu choice.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayTrainerMenu();
        trainerMenuInput = Console.ReadLine();
    }
    return trainerMenuInput;
}

static void DisplayTrainerMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter a number to choose a menu item.");
    System.Console.WriteLine("1:     Add a trainer");
    System.Console.WriteLine("2:     Edit trainer information");
    System.Console.WriteLine("3:     Delete a trainer");
    System.Console.WriteLine("4:     Check trainer information");
    System.Console.WriteLine("5:     Return to main menu");
}

static bool ValidTrainerMenuChoice(string trainerMenuInput) {
    var userChoice = int.Parse(trainerMenuInput);
    bool menuTruth = userChoice <= 5 && userChoice >= 1;
    return menuTruth;
}

void RouteTrainerMenu(string trainerMenuInput) {
    
    var userChoice = int.Parse(trainerMenuInput);
    if (userChoice == 1) {
        trainUtility.AddTrainer();
        System.Console.WriteLine("Trainer has been added. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 2) {
        trainUtility.UpdateTrainer();
        System.Console.WriteLine("Trainer information has been updated. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 3) {
        trainUtility.DeleteTrainer();
        System.Console.WriteLine("Trainer has been deleted. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 4) {
        trainReport.PrintAllTrainers();
        System.Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
    else {
        return;
    }
}

void ListingData() {
    string listingMenuInput = GetListingMenuChoice();
    while (listingMenuInput != "5") {
        RouteListingMenu(listingMenuInput);
        listingMenuInput = GetListingMenuChoice();
    }
}

static string GetListingMenuChoice() {
    DisplayListingMenu();
    string listingMenuInput = Console.ReadLine();

    while (!ValidListingMenuChoice(listingMenuInput)) {
        System.Console.WriteLine("Invalid menu choice. Please enter a valid menu choice.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayListingMenu();
        listingMenuInput = Console.ReadLine();
    }
    return listingMenuInput;
}

static void DisplayListingMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter a number to choose a menu item.");
    System.Console.WriteLine("1:     Add a listing");
    System.Console.WriteLine("2:     Edit listing information");
    System.Console.WriteLine("3:     Delete a listing");
    System.Console.WriteLine("4:     Check listing information");
    System.Console.WriteLine("5:     Return to main menu");
}

static bool ValidListingMenuChoice(string listingMenuInput) {
    var userChoice = int.Parse(listingMenuInput);
    bool menuTruth = userChoice <= 5 && userChoice >= 1;
    return menuTruth;
}

void RouteListingMenu(string listingMenuInput) {

    var userChoice = int.Parse(listingMenuInput);
    if (userChoice == 1) {
        listUtility.AddListing();
        System.Console.WriteLine("Listing has been added. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 2) {
        listUtility.UpdateListing();
        System.Console.WriteLine("Listing information has been updated. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 3) {
        listUtility.DeleteListing();
        System.Console.WriteLine("Listing has been deleted. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 4) {
        listReport.PrintAllListings();
        System.Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
    else {
        return;
    }
}

void CustomerBookingData() {
    string bookingMenuInput = GetBookingMenuChoice();
    while (bookingMenuInput != "4") {
        RouteBookingMenu(bookingMenuInput);
        bookingMenuInput = GetBookingMenuChoice();
    }
}

static string GetBookingMenuChoice() {
    DisplayBookingMenu();
    string bookingMenuInput = Console.ReadLine();

    while (!ValidBookingMenuChoice(bookingMenuInput)) {
        System.Console.WriteLine("Invalid menu choice. Please enter a valid menu choice.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayBookingMenu();
        bookingMenuInput = Console.ReadLine();
    }
    return bookingMenuInput;
}

static void DisplayBookingMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter a number to choose a menu item.");
    System.Console.WriteLine("1:     View available sessions");
    System.Console.WriteLine("2:     Book a session");
    System.Console.WriteLine("3:     Update booking status");
    System.Console.WriteLine("4:     Return to main menu");
}

static bool ValidBookingMenuChoice(string bookingMenuInput) {
    var userChoice = int.Parse(bookingMenuInput);
    bool menuTruth = userChoice <= 4 && userChoice >= 1;
    return menuTruth;
}

void RouteBookingMenu(string bookingMenuInput) {

    var userChoice = int.Parse(bookingMenuInput);
    if (userChoice == 1) {
        listReport.PrintAllListings();
        System.Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 2) {
        tranUtility.BookASession();
        System.Console.WriteLine("Session has been booked. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else if (userChoice == 3) {
        tranUtility.UpdateStatus();
        System.Console.WriteLine("Session status has been updated. Press any key to return to the menu.");
        Console.ReadKey();
    }
    else {
        return;
    }
}

void RunReports() {
    string reportMenuInput = GetReportMenuChoice();
    while (reportMenuInput != "4") {
        RouteReportMenu(reportMenuInput);
        reportMenuInput = GetReportMenuChoice();
    }
}

static string GetReportMenuChoice() {
    DisplayReportMenu();
    string reportMenuInput = Console.ReadLine();

    while (!ValidReportMenuChoice(reportMenuInput)) {
        System.Console.WriteLine("Invalid menu choice. Please enter a valid menu choice.");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayReportMenu();
        reportMenuInput = Console.ReadLine();
    }
    return reportMenuInput;
}

static void DisplayReportMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter a number to choose a menu item.");
    System.Console.WriteLine("1:     View individual customer sessions");
    System.Console.WriteLine("2:     View historical customer sessions");
    System.Console.WriteLine("3:     View historical revenue report");
    System.Console.WriteLine("4:     Return to main menu");
}

static bool ValidReportMenuChoice(string reportMenuInput) {
    var userChoice = int.Parse(reportMenuInput);
    bool menuTruth = userChoice <= 4 && userChoice >= 1;
    return menuTruth;
}

// make sure to route report functions

void RouteReportMenu(string reportMenuInput) {
    // Trainer[] trainers = new Trainer[500];
    // TrainerUtility trainUtility = new TrainerUtility(trainers);
    // Reports trainReport = new Reports(trainers);

    // Listing[] listings = new Listing[500];
    // ListingUtility listUtility = new ListingUtility(listings, trainUtility);
    // Reports listReport = new Reports(listings);

    // Transaction[] transactions = new Transaction[500];
    // TransactionUtility tranUtility = new TransactionUtility(transactions, listUtility);
    // Reports tranReport = new Reports(transactions);

    var userChoice = int.Parse(reportMenuInput);
    if (userChoice == 1) {
        System.Console.WriteLine("Pickedd 1");
        Console.ReadKey();
    }
    else if (userChoice == 2) {
        System.Console.WriteLine("Picked 2");
        Console.ReadKey();
    }
    else if (userChoice == 3) {
        System.Console.WriteLine("Picked 3");
        Console.ReadKey();
    }
    else {
        return;
    }
}

