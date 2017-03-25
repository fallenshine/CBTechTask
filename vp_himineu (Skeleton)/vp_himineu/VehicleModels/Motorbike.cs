namespace Himineu.VehicleModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.Interfaces;

    public class Motorbike : VehicleInformation, IVehicle
    {
        public Motorbike(string licensePlate, string owner, string hours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.RegularRate = 1.35;
            this.OvertimeRate = 3.00;

            int rawhours;
            if (int.TryParse(hours, out rawhours))
            {
                this.ReservedHours = rawhours;
            }
            else
            {
                throw new ArgumentException("The reserved hours must be numberic.");
            }
        }
    }
}
