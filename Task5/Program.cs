namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<DateTime>> vacationDictionary = new Dictionary<string, List<DateTime>>()
            {
                ["Иванов Иван Иванович"] = new List<DateTime>(),
                ["Петров Петр Петрович"] = new List<DateTime>(),
                ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
                ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
                ["Павлов Павел Павлович"] = new List<DateTime>(),
                ["Георгиев Георг Георгиевич"] = new List<DateTime>()
            };

            Vacation vacation = new Vacation(vacationDictionary);

            vacationDictionary = vacation.DistributeVacation();

            IOutput output = new OutputConsole();
            output.Output(vacationDictionary);



            Console.ReadKey();
        }
    }
}
