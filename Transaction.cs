namespace mis_221_pa_5_aeholmes1
{
    public class Transaction
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int bookingTrainerID;
        private string bookingTrainerName;
        private string bookingStatus; // bool?

        static private int bookingCount;

        static private int maxSessionID;

        public Transaction() {

        }

        public Transaction(int sessionID, string customerName, string customerEmail, string trainingDate, int bookingTrainerID, string bookingTrainerName, string bookingStatus, int maxSessionID) {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.bookingTrainerID = bookingTrainerID;
            this.bookingTrainerName = bookingTrainerName;
            this.bookingStatus = bookingStatus;
        }

        public void SetSessionID(int sessionID) {
            this.sessionID = sessionID;
        }

        public int GetSessionID() {
            return sessionID;
        }

        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }

        public string GetCustomerName() {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail() {
            return customerEmail;
        }

        public void SetTrainingDate(string trainingDate) {
            this.trainingDate = trainingDate;
        }

        public string GetTrainingDate() {
            return trainingDate;
        }

        public void SetBookingTrainerID(int bookingTrainerID) {
            this.bookingTrainerID = bookingTrainerID;
        }

        public int GetBookingTrainingID() {
            return bookingTrainerID;
        }

        public void SetBookingTrainerName(string bookingTrainerName) {
            this.bookingTrainerName = bookingTrainerName;
        }

        public string GetBookingTrainerName() {
            return bookingTrainerName;
        }

        public void SetBookingStatus(string bookingStatus) {
            this.bookingStatus = bookingStatus;
        }

        public string GetBookingStatus() {
            return bookingStatus;
        }

        static public void SetBookingCount(int bookingCount) {
            Transaction.bookingCount = bookingCount;
        }

        static public void IncBookingCount() {
            Transaction.bookingCount++;
        }

        static public int GetBookingCount() {
            return Transaction.bookingCount;
        }

        static public void IncMaxSessionID() {
            Transaction.maxSessionID++;
        }

        static public void SetMaxTrainerID(int maxSessionID) {
            Transaction.maxSessionID = maxSessionID;
        }
        
        static public int GetMaxTrainerID() {
            return Transaction.maxSessionID;
        }

        public override string ToString()
        {
            return ($"Session ID:   {sessionID}\nCustomer Name:  {customerName}\nCustomer Email: {customerEmail}\nTraining Date:    {trainingDate}\nTrainer ID:    ${bookingTrainerID}\nTrainer Name:    {bookingTrainerName}\nBooking Status:   {bookingStatus}");
        }

        public string ToFile() {
            return($"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{bookingTrainerID}#{bookingTrainerName}#{bookingStatus}");
        }
    }
}