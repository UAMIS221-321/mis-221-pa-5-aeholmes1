namespace mis_221_pa_5_aeholmes1
{
    public class TransactionUtility
    {
        private Transaction[] transactions;
        private ListingUtility listingUtility;

        public TransactionUtility(Transaction[] transactions, ListingUtility listingUtility) {
            this.transactions = transactions;
            this.listingUtility = listingUtility;
        }

        
        public void BookASession() {
            Transaction.SetBookingCount(0);
            Transaction.SetMaxSessionID(0);
            System.Console.WriteLine("Please enter the listing ID of the training session you want to book.");
            int searchVal = int.Parse(Console.ReadLine());
            Listing listing = listingUtility.Get(searchVal);
            if (listing.GetListingID() != -1) {
                Transaction myTransaction = new Transaction();
                myTransaction.SetSessionID(listing.GetListingID());
                System.Console.WriteLine("Please enter the customer name.");
                myTransaction.SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the customer email.");
                myTransaction.SetCustomerEmail(Console.ReadLine());
                myTransaction.SetTrainingDate(listing.GetSessionDate());
                myTransaction.SetBookingTrainerID(listing.GetListingTrainerID());
                myTransaction.SetBookingTrainerName(listing.GetListingTrainerName());
                System.Console.WriteLine("Please enter the booking status as either 'booked', 'completed', or 'cancelled'.");
                myTransaction.SetBookingStatus(GetBookingStatusFromUser());

                transactions[Transaction.GetBookingCount()] = myTransaction;
                Transaction.IncMaxSessionID();
                Transaction.IncBookingCount();

                Save();

            }
            else {
                System.Console.WriteLine("Listing not found.");
            }            
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                outFile.WriteLine(transactions[i].ToFile());
            }
            outFile.Close();
        }

        private int Find(int sessionID) {
            for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                if (transactions[i].GetSessionID() == sessionID) {
                    return i;
                }
            }
            return -1;
        }

        public Transaction Get(string customerEmail) {
            for (int i = 0; i < Transaction.GetBookingCount(); i++) {
                if (transactions[i].GetCustomerEmail() == customerEmail) {
                    return transactions[i];
                }
            }
            return new Transaction(-1, "", "", -1, -1, "", "", -1);
        }


        public void UpdateStatus() {
            System.Console.WriteLine("Please enter the ID of the training session whose status you'd like to update.");
            int sessionID = int.Parse(Console.ReadLine());
            int foundIndex = Find(sessionID);
            if (foundIndex != -1) {
                transactions[foundIndex].SetBookingStatus(GetBookingStatusFromUser());
            }
            else {
                System.Console.WriteLine("Session not found.");
            }
        }

        private string GetBookingStatusFromUser() {
            System.Console.WriteLine("Please enter the booking status as either 'booked', 'completed', or 'cancelled'.");
            string userInput = Console.ReadLine();
            while (!ValidBookingChoice(userInput)) {
                System.Console.WriteLine("Invalid input. Please enter a valid booking status.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                
                System.Console.WriteLine("Please enter the booking status as either 'booked', 'completed', or 'cancelled'.");
                userInput = Console.ReadLine();
            }
            return userInput.ToLower();            
        }

        static bool ValidBookingChoice(string userInput) {
            var userChoice = userInput;
            bool bookingTruth = userInput.ToUpper() == "BOOKED" || userInput.ToUpper() == "COMPLETED" || userInput.ToUpper() == "CANCELLED";
            return bookingTruth;
        }
    }
}