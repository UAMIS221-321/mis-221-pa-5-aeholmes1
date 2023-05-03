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

        public Reports(Transaction[] transactions) {
            this.transactions = transactions;
            this.transactionUtility = new TransactionUtility(transactions, null);
        }

        public Reports(Listing[] listings) {
            this.listings = listings;
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
        


        public void IndividualCustomerHistory() {
            System.Console.WriteLine("Please enter the email of the customer whose session history you'd like to see.");
            string searchVal = Console.ReadLine(); 
            Transaction transaction = transactionUtility.Get(searchVal);
            if (transaction.GetCustomerEmail() != "") {
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
                    System.Console.WriteLine("Data saved to file 'customerhistory.txt'.");
                    outFile.Close();
                }
            }
        }

        static string GetSavingStatusFromUser() {
            System.Console.WriteLine("Would you like to save this data to a file? Please enter 'yes' or 'no'.");
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

        public void AllCustomerHistory() {
            Sort();
            for(int i = 0; i < Transaction.GetBookingCount(); i++) {
                System.Console.WriteLine(transactions[i].ToString());
            }
            if (GetSavingStatusFromUser() == "yes") {
                StreamWriter outFile = new StreamWriter("allcustomerhistory.txt");

                for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                    outFile.WriteLine(transactions[i].ToFile());
                }
                outFile.Close();
            }
        }


        public void RevenueReport() {
            int currentDate = listings[0].GetSessionDate();
            double revenue = listings[0].GetSessionCost();
            for (int i = 1; i < Listing.GetListingCount(); i++) {
                if (listings[i].GetSessionCost() == currentDate) {
                    revenue += listings[i].GetSessionCost();
                }
                else {
                    ProcessBreak(ref currentDate, ref revenue, listings[i]);
                }
            }
            ProcessBreak(currentDate, revenue);
            if (GetSavingStatusFromUser() == "yes") {
                StreamWriter outFile = new StreamWriter("revenuereport.txt");

                for (int i = 0; i < Listing.GetListingCount(); i++) {
                    outFile.WriteLine(listings[i].ToFile());
                }
                outFile.Close();
            }            
        }

        public void ProcessBreak(ref int currentDate, ref double revenue, Listing newListing) {
            System.Console.WriteLine($"Date: {currentDate}    Revenue: ${revenue}");
            currentDate = newListing.GetSessionDate();
            revenue = newListing.GetSessionCost();
        }

        public void ProcessBreak(int currentDate, double revenue) {
            System.Console.WriteLine($"Date: {currentDate}    Revenue: ${revenue}");
        }

        public void Sort() {
            for (int i = 0; i < Transaction.GetBookingCount() - 1; i++) {
                int min = 1;
                for (int j = i + 1; j < Transaction.GetBookingCount(); j++) {
                    if (transactions[i].GetCustomerName().CompareTo(transactions[min].GetCustomerName()) < 0 ||
                    (transactions[j].GetCustomerName() == transactions[min].GetCustomerName() && transactions[j].GetTrainingDate() < transactions[min].GetTrainingDate())) {
                        min = j;
                    }
                }
                if (min != 1){
                    Swap(min, i);
                }
            }
        }

        public void Swap(int x, int y) {
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }




    }
}