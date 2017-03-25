namespace Himineu.VehicleCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using Himineu.App_Data;
    using Himineu.Interfaces;
    using Himineu.VehicleModels;

    public static class Commands
    {
        public static void ExecuteCommand(string commandLine, IUserInterface userInterface)
        {
            Match lineGroups = Regex.Match(commandLine, "^(?<command>[aA-zZ].+?){(?<parameters>.*?)}$", RegexOptions.Singleline | RegexOptions.Multiline);
            userInterface.WriteLine(ExecuteAndWrite(lineGroups.Groups["command"].Value.Trim(), new JavaScriptSerializer().Deserialize<Dictionary<string, string>>("{ " + lineGroups.Groups["parameters"].Value.Trim() + " }")));
        }

        private static string ExecuteAndWrite(string name, Dictionary<string, string> parameters)
        {
            var action = StaticData.GetAction.FirstOrDefault(x => x.Value.Equals(name)).Key;
            VehicleParkCommands commands = new VehicleParkCommands();

            switch (action)
            {
                case StaticData.Actions.SetupPark:
                    return commands.SetupPark(parameters["sectors"], parameters["placesPerSector"]);
                case StaticData.Actions.Park:

                    if (!StaticData.ValidateLicensePlate(parameters["licensePlate"]) || string.IsNullOrWhiteSpace(parameters["owner"]) || string.IsNullOrWhiteSpace(parameters["hours"]))
                    {
                        return "The license place is not valid.";
                    }

                    if (string.Compare(parameters["type"], "car", true) == 0)
                    {
                        return commands.InsertCar(new Car(parameters["licensePlate"], parameters["owner"], parameters["hours"]), parameters["sector"], parameters["place"], parameters["time"]);
                    }
                    else if (string.Compare(parameters["type"], "motorbike", true) == 0)
                    {
                        return commands.InsertMotorbike(new Motorbike(parameters["licensePlate"], parameters["owner"], parameters["hours"]), parameters["sector"], parameters["place"], parameters["time"]);
                    }
                    else if (string.Compare(parameters["type"], "truck", true) == 0)
                    {
                        return commands.InsertTruck(new Truck(parameters["licensePlate"], parameters["owner"], parameters["hours"]), parameters["sector"], parameters["place"], parameters["time"]);
                    }
                    else
                    {
                        return "The vehicle type is not recognized.";
                    }

                case StaticData.Actions.Exit:
                    if (!StaticData.ValidateLicensePlate(parameters["licensePlate"]))
                    {
                        return "The license place is not valid.";
                    }

                    return commands.ExitVehicle(parameters["licensePlate"], parameters["time"], parameters["paid"]);
                case StaticData.Actions.Status:
                    return commands.GetStatus();
                case StaticData.Actions.FindVehicle:
                    if (!StaticData.ValidateLicensePlate(parameters["licensePlate"]))
                    {
                        return "The license place is not valid.";
                    }

                    return commands.FindVehicle(parameters["licensePlate"]);
                case StaticData.Actions.VehiclesByOwner:
                    return commands.FindVehiclesByOwner(parameters["owner"]);
                case StaticData.Actions.Default:
                    throw new InvalidOperationException("Invalid command");
                default:
                    throw new InvalidOperationException("Invalid command");
            }
        }
    }
}
