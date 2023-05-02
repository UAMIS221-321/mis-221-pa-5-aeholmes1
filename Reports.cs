namespace mis_221_pa_5_aeholmes1
{
    public class Reports
    {
        
        Trainer[] trainers;
        Listing[] listings;
        Transaction[] transactions;

        private TransactionUtility transactionUtility;

        public Reports(Trainer[] trainers) {
            this.trainers = trainers;
        }

        public Reports(Listing[] listings) {
            this.listings = listings;
        }

        public Reports(Transaction[] transactions) {
            this.transactions = transactions;
        }

        public void PrintAllTrainers() {
            for(int i = 0; i < Trainer.GetTrainerCount(); i++) {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        public void PrintAllListings() {
            for(int i = 0; i < Listing.GetListingCount(); i++) {
                System.Console.WriteLine(listings[i].ToString());
            }
        }

        public void PrintAllTrainingSessions() {
            for(int i = 0; i < Transaction.GetBookingCount(); i++) {
                System.Console.WriteLine(transactions[i].ToString());
            }
        }


            // binary search is an extra.. not sure where to put it or what function it serves, maybe to sort by date or ID?



// following report functions should have the option to save to a file (probably create files ahead of time that each thing will save to & writeline telling the user the file name)

        // report individual customer sessions/session history (enter an email and see associated session history)
            // search method for email, or control break report?

        

        public void IndividualCustomerHistory() {
            System.Console.WriteLine("Please enter the email of the customer whose session history you'd like to see.");
            string searchVal = Console.ReadLine();
            Transaction transaction = transactionUtility.Get(searchVal);
            if (transaction.GetCustomerEmail() != "") {
                // for loop to sort thru list
                for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                    if (transactions[i].GetCustomerEmail() == searchVal) {
                        System.Console.WriteLine(transactions[i].ToString());
                    }
                }
                if (GetSavingStatusFromUser() == "yes") {
                    StreamWriter outFile = new StreamWriter("customerhistory.txt");

                    for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                        if (transactions[i].GetCustomerEmail() == searchVal) {
                            outFile.WriteLine(transactions[i].ToFile());
                        }
                    }
                    outFile.Close();
                }
            }
        }

        static string GetSavingStatusFromUser() {
            System.Console.WriteLine("Would you like to save this information to a file? Please enter 'yes' or 'no'.");
                string userInput = Console.ReadLine();
                while (!ValidSavingChoice(userInput)) {
                    System.Console.WriteLine("Invalid input. Please enter a valid input.");
                    System.Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                
                    System.Console.WriteLine("Would you like to save this information to a file? Please enter 'yes' or 'no'.");
                    userInput = Console.ReadLine();
                }
                return userInput.ToLower(); 
        }

        static bool ValidSavingChoice(string userInput) {
            var userChoice = userInput;
            bool savingTruth = userInput.ToUpper() == "YES" || userInput.ToUpper() == "NO";
            return savingTruth;
        }

        static void AllCustomerHistory() {
            
        }

        // list of all sessions from all customers, sorted by customer name and then by date
            // add total number of sessions for each customer

        // revenue report: list of revenue by month and by year
            // add cost of each session/transaction, sorted by month and then by year (june, july, august... total for 2021, 2022, 2023...)
            // this should be similar functionality to listing of sessions per customer





    }
}