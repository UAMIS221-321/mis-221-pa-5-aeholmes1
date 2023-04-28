namespace mis_221_pa_5_aeholmes1
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers) {
            this.trainers = trainers;
        }    

        // get all trainers method is probably unnecessary, just using add new trainer works too
        // add try catch

        // public void GetAllTrainers() {
        //     Trainer.SetTrainerCount(0);
        //     System.Console.WriteLine("Please enter the trainer name or stop to stop.");
        //     string userInput = Console.ReadLine();
        //     while (userInput.ToUpper() != "STOP") {
        //         trainers[Trainer.GetTrainerCount()] = new Trainer();
        //         trainers[Trainer.GetTrainerCount()].SetTrainerName(Console.ReadLine());

        //         System.Console.WriteLine("Please enter the trainer address.");
        //         trainers[Trainer.GetTrainerCount()].SetTrainerAddress(Console.ReadLine());

        //         System.Console.WriteLine("Please enter the trainer email.");
        //         trainers[Trainer.GetTrainerCount()].SetTrainerEmail(Console.ReadLine());
        //         Trainer.IncTrainerCount();

        //         System.Console.WriteLine("Please enter the trainer name or stop to stop.");
        //         userInput = Console.ReadLine();                
        //     }
        // }

        public void GetAllTrainersFromFile() {
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer.SetMaxTrainerID(0);
            Trainer.SetTrainerCount(0);
            string line = inFile.ReadLine();
            while (!(line == null || line == "")) {
                string[] temp = line.Split('#');
                trainers[Trainer.GetTrainerCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                if(Trainer.GetMaxTrainerID() < trainers[Trainer.GetTrainerCount()].GetTrainerID()){
                    Trainer.SetMaxTrainerID(trainers[Trainer.GetTrainerCount()].GetTrainerID());
                }
                Trainer.IncTrainerCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        // add try catch
        public void AddTrainer() {
            System.Console.WriteLine("Please enter the trainer name.");
            Trainer myTrainer = new Trainer();
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer address.");
            myTrainer.SetTrainerAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer email.");
            myTrainer.SetTrainerEmail(Console.ReadLine());

            myTrainer.SetTrainerID(Trainer.GetMaxTrainerID());

            trainers[Trainer.GetMaxTrainerID()] = myTrainer;
            Trainer.IncMaxTrainerID();
            Trainer.IncTrainerCount();

            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for (int i = 0; i < Trainer.GetTrainerCount(); i++) {
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

        private int Find(int trainerID) {
            for (int i = 0; i < Trainer.GetTrainerCount(); i++) {
                if (trainers[i].GetTrainerID() == trainerID) {
                    return i;
                }
            }
            return -1;
        }

        // add try catch
        public void UpdateTrainer() {
            System.Console.WriteLine("What's the ID of the trainer you'd like to update?");
            int trainerID = int.Parse(Console.ReadLine());
            int foundIndex = Find(trainerID);
            if (foundIndex != -1) {
                System.Console.WriteLine("Please enter the trainer name.");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer address.");
                trainers[foundIndex].SetTrainerAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer email.");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
            }
            else {
                System.Console.WriteLine("Trainer not found.");
            }
        }

        public void DeleteTrainer() {
            System.Console.WriteLine("What's the ID of the trainer you'd like to delete?");
            int trainerID = int.Parse(Console.ReadLine());
            int foundIndex = Find(trainerID);
            if (foundIndex != -1) {
                var trainerList = trainers.ToList();
                trainerList.RemoveAt(foundIndex);
                trainers = trainerList.ToArray();
                Trainer.DecTrainerCount();
                Save();
                System.Console.WriteLine("Trainer has been deleted.");
            }
            else {
                System.Console.WriteLine("Trainer not found.");
            }
        }
    }
}