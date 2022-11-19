namespace MagicVilla_VillaAPI.Logging
{
    public class LoggingV2:Ilogging
    {
        public void Log(string message,string type)
        {
            if(type == "error")
            {
                Console.BackgroundColor=ConsoleColor.Red;
                Console.WriteLine("Error"+message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if(type == "information")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Error" + message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.WriteLine(message); 
            }

        }
    }
}
