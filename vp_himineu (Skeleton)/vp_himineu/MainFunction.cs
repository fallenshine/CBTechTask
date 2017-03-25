namespace VehicleParkSystem1
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Himineu.App_Data;
    using Himineu.Interfaces;
    using Himineu.VehicleCommands;

    public static class MainFunction
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            IUserInterface userInterface = new UserCommands();

            while (true)
            {
                string commandLine = userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (!string.IsNullOrWhiteSpace(commandLine))
                {
                    try
                    {
                        if (StaticData.ApplicationData == null && !commandLine.Contains("SetupPark"))
                        {
                            Console.WriteLine("The vehicle park has not been set up.");
                        }
                        else
                        {
                            Commands.ExecuteCommand(commandLine, userInterface);
                        }
                    }
                    catch (Exception ex)
                    {
                        // PERFORMANCE: Using try/catch is usually causing a lot of performance issues, so i personally try to avoid it.
                        // Im leaving it here,as there could be some code that i havent saw.
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}