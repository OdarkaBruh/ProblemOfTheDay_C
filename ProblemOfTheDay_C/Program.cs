namespace ProblemOfTheDay_C
{
    internal class Program
    {
        private const int Day = 15;
        public static void Main(string[] args)
        {
            if (Day <= 7) FirstWeek.launchDay();
            else if (Day <= 14) SecondWeek.launchDay();
            else ThirdWeek.launchDay();
        }
    }
}