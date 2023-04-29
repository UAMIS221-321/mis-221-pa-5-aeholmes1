namespace mis_221_pa_5_aeholmes1
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string trainerAddress;
        private string trainerEmail;
        static private int trainerCount;

        static private int maxTrainerID;

        public Trainer() {
            
        }

        public Trainer(int trainerID, string trainerName, string trainerAddress, string trainerEmail) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;
        }

        public void SetTrainerID(int trainerID) {
            this.trainerID = trainerID;
        }

        public int GetTrainerID() {
            return trainerID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public void SetTrainerAddress(string trainerAddress) {
            this.trainerAddress = trainerAddress;
        }

        public string GetTrainerAddress() {
            return trainerAddress;
        }

        public void SetTrainerEmail(string trainerEmail) {
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail() {
            return trainerEmail;
        }

        static public void SetTrainerCount(int trainerCount) {
            Trainer.trainerCount = trainerCount;
        }

        static public int GetTrainerCount() {
            return Trainer.trainerCount;
        }

        static public void IncTrainerCount() {
            Trainer.trainerCount++;
        }

        static public void DecTrainerCount() {
            Trainer.trainerCount--;
        }

       static public void IncMaxTrainerID() {
            Trainer.maxTrainerID++;
        }

        static public void SetMaxTrainerID(int maxTrainerID) {
            Trainer.maxTrainerID = maxTrainerID;
        }
        
        static public int GetMaxTrainerID() {
            return Trainer.maxTrainerID;
        }

        public override string ToString()
        {
            return ($"Trainer ID:   {trainerID}\nTrainer Name:  {trainerName}\nTrainer Address: {trainerAddress}\nTrainer Email:    {trainerEmail}");
        }

        public string ToFile() {
            return($"{trainerID}#{trainerName}#{trainerAddress}#{trainerEmail}");
        }
    }
}