namespace Legion_OpenBot
{
    class Program
    {
        public static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsunk().GetAwaiter().GetResult();
        }
    }
    
}