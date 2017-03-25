namespace Himineu.VehicleModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.Interfaces;

    public class Truck : VehicleInformation, IVehicle
    {
        public Truck(string licensePlate, string owner, string hours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.RegularRate = 4.75;
            this.OvertimeRate = 6.20;

            int rawHours;
            if (int.TryParse(hours, out rawHours))
            {
                this.ReservedHours = rawHours;
            }
            else
            {
                throw new ArgumentException("The reserved hours must be numberic.");
            }
        }
    }
}
