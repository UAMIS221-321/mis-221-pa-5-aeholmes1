namespace mis_221_pa_5_aeholmes1
{
    public class TransactionUtility
    {
        private Transaction[] transactions;
        private ListingUtility listingUtility = new ListingUtility();

        public TransactionUtility(Transaction[] transactions) {
            this.transactions = transactions;
        }

        // private int Find(string searchVal) {
        //     for (int i = 0; i < Transaction.GetBookingCount(); i++) {
        //         if (transactions[i].GetSessionID() == int.Parse(searchVal)) {
        //             return i;
        //         }
        //     }
        //     return -1;
        // }

        public void BookASession() {
            Transaction.SetBookingCount(0);
            System.Console.WriteLine("Please enter the listing ID of the training session you want to book.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = listingUtility.Find(searchVal);
            if (foundIndex != -1) {
                Transaction myTransaction = new Transaction();
                myTransaction.SetSessionID();
                myTransaction.SetBookingStatus;
            }
            else {
                System.Console.WriteLine("Listing not found.");
            }


            // and use it as session ID, session date, trainer ID, and trainer name)
            // add customer name and email
            while (searchVal.ToUpper() != "STOP") { // && while userInput == existing listing ID
                transactions[Transaction.GetBookingCount()] = new Transaction();
                // needs to be completed

                // add try catches
            }
        }

        public bool ValidListingID() {

            bool listingIDTruth = ;
            return listingIDTruth;
        }

        public void UpdateStatus() {
            System.Console.WriteLine("Please enter the ID of the training session whose status you'd like to update.");

        }

        // update status method (booked, completed, or cancelled; initially set to booked)
            // maybe have it function so users can change their own booking status?
            // also potentially have an if statement with two bools for completed or cancelled/no show (but would be hard)

    }
}