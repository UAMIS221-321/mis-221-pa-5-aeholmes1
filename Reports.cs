namespace mis_221_pa_5_aeholmes1
{
    public class Reports
    {
        
        Trainer[] trainers;
        Listing[] listings;
        Transaction[] transactions;

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

        }

        public void PrintAllListings() {

        }

        public void PrintAllTrainingSessions() {

        }


        // print all trainers

        // print all listings (used for listing menu for trainers and for available sessions for customers)

        // print all training sessions/transactions (like a receipt??)

            // binary search is an extra.. not sure where to put it or what function it serves, maybe to sort by date or ID?


// following report functions should have the option to save to a file (probably create files ahead of time that each thing will save to & writeline telling the user the file name)

        // report individual customer sessions/session history (enter an email and see associated session history)
            // search method for email, or control break report?

        // list of all sessions from all customers, sorted by customer name and then by date
            // add total number of sessions for each customer

        // revenue report: list of revenue by month and by year
            // add cost of each session/transaction, sorted by month and then by year (june, july, august... total for 2021, 2022, 2023...)
            // this should be similar functionality to listing of sessions per customer


    }
}