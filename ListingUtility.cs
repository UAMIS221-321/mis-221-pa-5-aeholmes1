namespace mis_221_pa_5_aeholmes1
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility() {

        }

        public ListingUtility(Listing[] listings) {
            this.listings = listings;
        }

        public void GetAllListings() {
            Listing.SetListingCount(0);
            System.Console.WriteLine("Please enter the listing trainer name or stop to stop.");
            string userInput = Console.ReadLine();
            while (userInput.ToUpper() != "STOP") {
                listings[Listing.GetListingCount()] = new Listing();
                listings[Listing.GetListingCount()].SetListingTrainerName(Console.ReadLine());

            // put try catch here
                System.Console.WriteLine("Please enter the session date in DDMMYY format.");
                listings[Listing.GetListingCount()].SetSessionDate(int.Parse(Console.ReadLine()));
            // set date to current date if incorrect

                System.Console.WriteLine("Please enter the hour time of the session in a 24 hour format.");
                listings[Listing.GetListingCount()].SetSessionHour(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Please enter the minute time of the session.");
                listings[Listing.GetListingCount()].SetSessionMinute(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Please enter the cost of the session in $DD.CC format.");
                listings[Listing.GetListingCount()].SetSessionCost(double.Parse(Console.ReadLine()));

                System.Console.WriteLine("Please enter the availability of the session as either 'Available' or 'Unavailable'.");
                listings[Listing.GetListingCount()].SetSessionAvailable(Console.ReadLine());
                Listing.IncListingCount();

                System.Console.WriteLine("Please enter the listing trainer name or stop to stop.");
                userInput = Console.ReadLine();                
            }
        }

         public void GetAllListingsFromFile() {
            StreamReader inFile = new StreamReader("listings.txt");

            Listing.SetListingCount(0);
            string line = inFile.ReadLine();
            while (!(line == null || line == "")) {
                string[] temp = line.Split('#');
                listings[Listing.GetListingCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]), double.Parse(temp[5]), temp[6], int.Parse(temp[7]));
                if (Listing.GetMaxListingID() < listings[Listing.GetListingCount()].GetListingID()){
                    Listing.SetMaxListingID(listings[Listing.GetListingCount()].GetListingID());
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
        }


        // add try catch
        public void AddListing() {
            System.Console.WriteLine("Please enter the listing trainer name.");
            Listing myListing = new Listing();
            myListing.SetListingTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the session date in DDMMYY format.");
            myListing.SetSessionDate(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the hour time of the session in a 24 hour format.");
            myListing.SetSessionHour(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the minute time of the session.");
            myListing.SetSessionMinute(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the cost of the session in $DD.CC format.");
            myListing.SetSessionCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the availability of the session as either 'Available' or 'Unavailable'.");
            myListing.SetSessionAvailable(Console.ReadLine());

            listings[Listing.GetListingCount()] = myListing;
            Listing.IncListingCount();

            Listing.IncMaxListingID();
            listings[Listing.GetMaxListingID()] = myListing;
            Listing.IncListingCount();

            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for (int i = 0; i < Listing.GetListingCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }

        public int Find(int searchVal) {
            listings[0].SetListingID(0);
            for (int i = 0; i < Listing.GetListingCount(); i++) {
                if (listings[i].GetListingID() == searchVal) {
                    return i;
                }
            }
            return -1;
        }

            // not 100% sure how to finish the update listing... need to switch search from trainer name to listingID
        // add try catch
        public void UpdateListing() {
            System.Console.WriteLine("What's the ID of the listing you'd like to update?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1) {
                System.Console.WriteLine("Please enter the listing trainer name.");
                listings[foundIndex].SetListingTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the session date in DDMMYY format.");
                listings[foundIndex].SetSessionDate(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the hour time of the session in a 24 hour format.");
                listings[foundIndex].SetSessionHour(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the minute time of the session.");
                listings[foundIndex].SetSessionMinute(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the cost of the session in $DD.CC format.");
                listings[foundIndex].SetSessionCost(double.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the availability of the session as either 'Available' or 'Unavailable'.");
                listings[foundIndex].SetSessionAvailable(Console.ReadLine());

                Save();
            }
            else {
                System.Console.WriteLine("Listing not found.");
            }
        }

        // add delete listing method that sets a boolean value for the listing to "deleted" or "false"

    }
}