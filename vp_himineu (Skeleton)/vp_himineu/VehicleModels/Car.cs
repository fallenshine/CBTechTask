namespace Himineu.VehicleModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.Interfaces;

    public class Car : VehicleInformation, IVehicle
    {
        public Car(string licensePlate, string owner, string hours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.RegularRate = 2.00;
            this.OvertimeRate = 3.50;

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
