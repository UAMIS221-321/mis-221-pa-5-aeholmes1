using mis_221_pa_5_aeholmes1;

// start main

string menuInput = GetMenuChoice();
while (menuInput != "5") {
    Route(menuInput);
    menuInput = GetMenuChoice();
}

// end main

// change route method to route to actual functions and not just console writeline

// extra (?): add nice user interface with logo or art or something

// extra: add log in with username and password
    // username and password are stored in a file and read in/searched when logging in
    // create new account function that requires a code for verification (to prevent customers from making scam accounts or smth)
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

static void Route(string menuInput) {
    var userChoice = int.Parse(menuInput);
    if (userChoice == 1) {
        System.Console.WriteLine("Picked 1");
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
    else if (userChoice == 4) {
        System.Console.WriteLine("Picked 4");
        Console.ReadKey();
    }
    else {
        return;
    }
}

