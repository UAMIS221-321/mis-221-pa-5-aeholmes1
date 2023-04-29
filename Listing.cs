namespace mis_221_pa_5_aeholmes1
{
    public class Listing
    {
        private int listingID;
        private string listingTrainerName;
        private int listingTrainerID;
        private int sessionDate;
        private int sessionHour;
        private int sessionMinute;
        private double sessionCost;
        private bool sessionAvailable;

        static private int listingCount;

        static private int maxListingID;

        public Listing() {

        }

        public Listing(int listingID, string listingTrainerName, int listingTrainerID, int sessionDate, int sessionHour, int sessionMinute, double sessionCost, bool sessionAvailable, int maxListingID) {
            this.listingID = listingID;
            this.listingTrainerName = listingTrainerName;
            this.listingTrainerID = listingTrainerID;
            this.sessionDate = sessionDate;
            this.sessionHour = sessionHour;
            this.sessionMinute = sessionMinute;
            this.sessionCost = sessionCost;
            this.sessionAvailable = sessionAvailable;
        }

        public void SetListingID(int listingID) {
            this.listingID = listingID;
        }

        public int GetListingID() {
            return listingID;
        }

        public void SetListingTrainerName(string listingTrainerName) {
            this.listingTrainerName = listingTrainerName;
        }

        public string GetListingTrainerName() {
            return listingTrainerName;
        }

        public void SetListingTrainerID(int listingTrainerID) {
            this.listingTrainerID = listingTrainerID;
        }

        public int GetListingTrainerID() {
            return listingTrainerID;
        }

        public void SetSessionDate(int sessionDate) {
            this.sessionDate = sessionDate;
        }

        public int GetSessionDate() {
            return sessionDate;
        }

        public void SetSessionHour(int sessionHour) {
            this.sessionHour = sessionHour;
        }

        public int GetSessionHour() {
            return sessionHour;
        }

         public void SetSessionMinute(int sessionMinute) {
            this.sessionMinute = sessionMinute;
        }

        public int GetSessionMinute() {
            return sessionMinute;
        }

         public void SetSessionCost(double sessionCost) {
            this.sessionCost = sessionCost;
        }

        public double GetSessionCost() {
            return sessionCost;
        }

         public void SetSessionAvailable(bool sessionAvailable) {
            this.sessionAvailable = sessionAvailable;
        }

        public bool GetSessionAvailable() {
            return sessionAvailable;
        }

        static public void SetListingCount(int listingCount) {
            Listing.listingCount = listingCount;
        }

        static public void IncListingCount() {
            Listing.listingCount++;
        }

        static public void DecListingCount() {
            Listing.listingCount--;
        }

        static public int GetListingCount() {
            return Listing.listingCount;
        }

        static public void IncMaxListingID() {
            Listing.maxListingID++;
        }

        static public void SetMaxListingID(int maxListingID) {
            Listing.maxListingID = maxListingID;
        }
        
        static public int GetMaxListingID() {
            return Listing.maxListingID;
        }

        public override string ToString()
        {
            return ($"Listing ID:   {listingID}\nTrainer Name:  {listingTrainerName}\nTrainer ID:   {listingTrainerID}\nSession Date: {sessionDate}\nSession Time:    {sessionHour}:{sessionMinute}\nSession Cost:    ${sessionCost}\nSession Availability:   {sessionAvailable}");
        }

        public string ToFile() {
            return($"{listingID}#{listingTrainerName}#{listingTrainerID}#{sessionDate}#{sessionHour}#{sessionMinute}#{sessionCost}#{sessionAvailable}");
        }
    }
}