namespace Himineu.App_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StaticData
    {
        #region Data

        // PERFORMANCE: Keeping the data allocated in the memory, while the application is running could cause some hitch ups
        // Eventually if there are alot of entries
        // Additionally there are two StyleCop errors here, which i think can be ignored :(
        public static DATA ApplicationData = null;

        public static Dictionary<Actions, string> GetAction = new Dictionary<Actions, string>()
        {
            { Actions.Default, "Default" },
            { Actions.SetupPark, "SetupPark" },
            { Actions.Park, "Park" },
            { Actions.Exit, "Exit" },
            { Actions.Status, "Status" },
            { Actions.FindVehicle, "FindVehicle" },
            { Actions.VehiclesByOwner, "VehiclesByOwner" }
        };

        public enum Actions
        {
            Default,
            SetupPark,
            Park,
            Exit,
            Status,
            FindVehicle,
            VehiclesByOwner
        }

        #endregion

        #region Utilities

        public static bool ValidateLicensePlate(string licensePlace)
        {
            if (Regex.IsMatch(licensePlace, @"^[aA-zZ]{1,2}\d{4}[aA-zZ]{2}$"))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
