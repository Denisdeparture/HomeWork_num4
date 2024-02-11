using HomeTask6;
sealed class Work
{
    public static void Main()
    {
        UserInventory program = new UserInventory();
        while (true)
        {
            try
            {
                program.Start();
            }
            catch
            {
                Console.WriteLine("Error");
                break;
            }
        }
        
    }
}