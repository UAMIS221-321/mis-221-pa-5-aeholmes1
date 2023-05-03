namespace mis_221_pa_5_aeholmes1
{
    public class ListingUtility
    {
        private Listing[] listings;

        private TrainerUtility trainerUtility;

        public ListingUtility() {

        }

        public ListingUtility(Listing[] listings, TrainerUtility trainerUtility) {
            this.listings = listings;
            this.trainerUtility = trainerUtility;
        }

         public void GetAllListingsFromFile() {
            StreamReader inFile = new StreamReader("listings.txt");
            Listing.SetMaxListingID(0);
            Listing.SetListingCount(0);
            string line = inFile.ReadLine();
            while (!(line == null || line == "")) {
                string[] temp = line.Split('#');
                listings[Listing.GetListingCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]), int.Parse(temp[5]), double.Parse(temp[6]), bool.Parse(temp[7]), int.Parse(temp[8]));
                if (Listing.GetMaxListingID() < listings[Listing.GetListingCount()].GetListingID()){
                    Listing.SetMaxListingID(listings[Listing.GetListingCount()].GetListingID());
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
        }


        public void AddListing() {
            System.Console.WriteLine("Please enter the listing trainer ID.");
            int searchVal = int.Parse(Console.ReadLine());
            Trainer trainer = trainerUtility.Get(searchVal);
            if (trainer.GetTrainerID() != -1) {
                Listing myListing = new Listing();
                myListing.SetListingTrainerID(trainer.GetTrainerID());          
                myListing.SetListingTrainerName(trainer.GetTrainerName());
                System.Console.WriteLine("Please enter the session date in YYMMDD format.");
                myListing.SetSessionDate(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the hour time of the session in a 24 hour format.");
                myListing.SetSessionHour(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the minute time of the session.");
                myListing.SetSessionMinute(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the cost of the session in $DD.CC format.");
                myListing.SetSessionCost(double.Parse(Console.ReadLine()));
                myListing.SetSessionAvailable(true);

                myListing.SetListingID(Listing.GetMaxListingID());
                
                listings[Listing.GetListingCount()] = myListing;
                Listing.IncMaxListingID();
                Listing.IncListingCount();

                Save();


            }
            else {
                System.Console.WriteLine("Trainer not found.");
            }  
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

        public Listing Get(int searchVal) {
            listings[0].SetListingID(0);
            for (int i = 0; i < Listing.GetListingCount(); i++) {
                if (listings[i].GetListingID() == searchVal) {
                    return listings[i];
                }
            }
            return new Listing(-1, "", -1, -1, -1, -1, -1, false, -1);
        }


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
                listings[foundIndex].SetSessionAvailable(GetAvailabilityFromUser());

                Save();

            }
            else {
                System.Console.WriteLine("Listing not found.");
            }
        }

        private bool GetAvailabilityFromUser() {
            string userInput = Console.ReadLine();
            if(userInput.ToUpper() == "AVAILABLE") {
                return true;    
            }
            return false;
        }

        public void DeleteListing() {
            System.Console.WriteLine("What's the ID of the listing you'd like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1) {
                var listingList = listings.ToList();
                listingList.RemoveAt(foundIndex);
                listings = listingList.ToArray();
                Listing.DecListingCount();
                Save();
            }
            else {
                System.Console.WriteLine("Listing not found.");
            }
        }
    }
}