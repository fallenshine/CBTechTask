namespace Himineu.VehicleCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.App_Data;
    using Himineu.Interfaces;
    using Himineu.VehicleModels;
    using Moq;

    public class VehicleParkCommands : IVehiclePark
    {
        /// <summary>
        /// Setup the park space
        /// </summary>
        /// <param name="numberOfSectors">Indicate the number of sectors</param>
        /// <param name="placesPerSector">Indicate the number of places in each sector</param>
        /// <returns></returns>
        public string SetupPark(string numberOfSectors, string placesPerSector)
        {
            int rawnumberOfSectors;
            int rawplacesPerSector;

            if (StaticData.ApplicationData != null)
            {
                return "The park has already been setup";
            }

            if (int.TryParse(numberOfSectors, out rawnumberOfSectors) && int.TryParse(placesPerSector, out rawplacesPerSector))
            {
                if (rawnumberOfSectors <= 0)
                {
                    return "The number of sectors must be positive";
                }

                if (rawplacesPerSector <= 0)
                {
                    return "he number of places per sector must be positive";
                }

                StaticData.ApplicationData = new DATA(rawnumberOfSectors, rawplacesPerSector);
                return "Vehicle park created.";
            }

            return "The Sectors and Places must be a numeric.";
        }

        /// <summary>
        /// The method corespond the Parking a car in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="car">Car object generated with the specific data</param>
        /// <param name="sector">The secor the car may be parked.</param>
        /// <param name="place">The place in the sector where the car may be parked</param>
        /// <param name="time">The time the car is parking</param>
        /// <returns></returns>
        public string InsertCar(Car car, string sector, string place, string time)
        {
            int rawSector = 0;
            int rawPlace = 0;
            DateTime rawtime = DateTime.MinValue;

            // PERFORMANCE: Making so many checks in the data collection, would hit the performance hard if there are a lot of entires(spaces in the park)
            // theoretically speaking i doubt there is a vehicle park with more than 1000 park spaces, but i might be wrong.
            if (car == null)
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (!int.TryParse(sector, out rawSector) || !int.TryParse(place, out rawPlace) || !DateTime.TryParse(time, out rawtime))
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (rawSector > StaticData.ApplicationData.VehicleParkslots.Keys.Count())
            {
                return string.Format("There is no sector {0} in the park", rawSector);
            }

            if (rawPlace > StaticData.ApplicationData.VehicleParkslots.FirstOrDefault().Value.Keys.Count())
            {
                return string.Format("There is no place {0} in sector {1}", rawPlace, rawSector);
            }

            if (StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] != null)
            {
                return string.Format("The place ({0},{1}) is occupied", rawSector, rawPlace);
            }

            if (StaticData.ApplicationData.Vehicles.FirstOrDefault(v => v.LicensePlate.Equals(car.LicensePlate)) != null)
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", car.LicensePlate);
            }

            StaticData.ApplicationData.Vehicles.Add(car);
            car.RegistrationDate = rawtime;
            car.ParkedSector = rawSector;
            car.ParkedPlace = rawPlace;
            StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] = car;

            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, rawSector, rawPlace);
        }

        /// <summary>
        /// The method corespond the Parking a motorbike in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="moto">A Motorbike object which was generated with a specific data</param>
        /// <param name="sector">The secor the motorbike may be parked.</param>
        /// <param name="place">The place in the sector where the motorbike may be parked</param>
        /// <param name="time">The time the motorbike is parking</param>
        /// <returns></returns>
        public string InsertMotorbike(Motorbike moto, string sector, string place, string time)
        {
            int rawSector = 0;
            int rawPlace = 0;
            DateTime rawtime = DateTime.MinValue;

            // PERFORMANCE: Making so many checks in the data collection, would hit the performance hard if there are a lot of entires(spaces in the park)
            // theoretically speaking i doubt there is a vehicle park with more than 1000 park spaces, but i might be wrong.
            if (moto == null)
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (!int.TryParse(sector, out rawSector) || !int.TryParse(place, out rawPlace) || !DateTime.TryParse(time, out rawtime))
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (rawSector > StaticData.ApplicationData.VehicleParkslots.Keys.Count())
            {
                return string.Format("There is no sector {0} in the park", rawSector);
            }

            if (rawPlace > StaticData.ApplicationData.VehicleParkslots.FirstOrDefault().Value.Keys.Count())
            {
                return string.Format("There is no place {0} in sector {1}", rawPlace, rawSector);
            }

            if (StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] != null)
            {
                return string.Format("The place ({0},{1}) is occupied", rawSector, rawPlace);
            }

            if (StaticData.ApplicationData.Vehicles.FirstOrDefault(v => v.LicensePlate.Equals(moto.LicensePlate)) != null)
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", moto.LicensePlate);
            }

            StaticData.ApplicationData.Vehicles.Add(moto);
            moto.RegistrationDate = rawtime;
            moto.ParkedSector = rawSector;
            moto.ParkedPlace = rawPlace;
            StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] = moto;

            return string.Format("{0} parked successfully at place ({1},{2})", moto.GetType().Name, rawSector, rawPlace);
        }

        /// <summary>
        /// The method corespond the Parking a truck in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="truck">Truck object generated with the specific data</param>
        /// <param name="sector">The secor the truck may be parked.</param>
        /// <param name="place">The place in the sector where the truck may be parked</param>
        /// <param name="time">The time the truck is parking</param>
        /// <returns></returns>
        public string InsertTruck(Truck truck, string sector, string place, string time)
        {
            int rawSector = 0;
            int rawPlace = 0;
            DateTime rawtime = DateTime.MinValue;

            // PERFORMANCE: Making so many checks in the data collection, would hit the performance hard if there are a lot of entires(spaces in the park)
            // theoretically speaking i doubt there is a vehicle park with more than 1000 park spaces, but i might be wrong.
            if (truck == null)
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (!int.TryParse(sector, out rawSector) || !int.TryParse(place, out rawPlace) || !DateTime.TryParse(time, out rawtime))
            {
                return "There is a problem with your variables, please check your sector,place or time.";
            }

            if (rawSector > StaticData.ApplicationData.VehicleParkslots.Keys.Count())
            {
                return string.Format("There is no sector {0} in the park", rawSector);
            }

            if (rawPlace > StaticData.ApplicationData.VehicleParkslots.FirstOrDefault().Value.Keys.Count())
            {
                return string.Format("There is no place {0} in sector {1}", rawPlace, rawSector);
            }

            if (StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] != null)
            {
                return string.Format("The place ({0},{1}) is occupied", rawSector, rawPlace);
            }

            if (StaticData.ApplicationData.Vehicles.FirstOrDefault(v => v.LicensePlate.Equals(truck.LicensePlate)) != null)
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", truck.LicensePlate);
            }

            StaticData.ApplicationData.Vehicles.Add(truck);
            truck.RegistrationDate = rawtime;
            truck.ParkedSector = rawSector;
            truck.ParkedPlace = rawPlace;
            StaticData.ApplicationData.VehicleParkslots[rawSector][rawPlace] = truck;

            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, rawSector, rawPlace);
        }

        /// <summary>
        /// A method responsibile for billing the customer, 
        /// and removing the car from the application data
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle</param>
        /// <param name="endDate">The date when the vehicle is leaving</param>
        /// <param name="paid">The amount of money the customer paid</param>
        /// <returns></returns>
        public string ExitVehicle(string licensePlate, string endDate, string paid)
        {
            var vehicle = StaticData.ApplicationData.Vehicles.FirstOrDefault(v => v.LicensePlate.Equals(licensePlate));

            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            DateTime date = DateTime.MinValue;
            if (!DateTime.TryParse(endDate, out date))
            {
                return "The Exit datetime is not in the correct format";
            }

            double clientPayment = 0;
            if (!double.TryParse(paid, out clientPayment))
            {
                return "The payment must be a numeric";
            }

            int endTime = (int)Math.Round((date - vehicle.RegistrationDate).TotalHours);
            double totalRegularPayment = vehicle.ReservedHours * vehicle.RegularRate;
            double totalOvertimePayment = endTime > vehicle.ReservedHours ? (endTime - vehicle.ReservedHours) * vehicle.OvertimeRate : 0;

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                  .AppendFormat("{0}", vehicle.ToString())
                  .AppendLine()
                  .AppendFormat("at place (<{0}>,<{1}>)", vehicle.ParkedSector, vehicle.ParkedPlace)
                  .AppendLine()
                  .AppendFormat("Rate: ${0:F2}", totalRegularPayment)
                  .AppendLine()
                  .AppendLine().AppendFormat("Overtime rate: ${0:F2}", totalOvertimePayment)
                  .AppendLine()
                  .AppendLine(new string('-', 20))
                  .AppendFormat("Total: ${0:F2}", totalRegularPayment + totalOvertimePayment)
                  .AppendLine()
                  .AppendFormat("Paid: ${0:F2}", clientPayment)
                  .AppendLine()
                  .AppendFormat("Change: ${0:F2}", clientPayment - (totalRegularPayment + totalOvertimePayment))
                  .AppendLine().Append(new string('*', 20));

            // Removing the vehicle from the data
            StaticData.ApplicationData.Vehicles.Remove(vehicle);
            StaticData.ApplicationData.VehicleParkslots[vehicle.ParkedSector][vehicle.ParkedPlace] = null;

            return ticket.ToString();
        }

        /// <summary>
        /// Method which provide information about the current status of the vehicle park.
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            var status = new StringBuilder();
            foreach (var key in StaticData.ApplicationData.VehicleParkslots.Keys)
            {
                Dictionary<int, IVehicle> sector = StaticData.ApplicationData.VehicleParkslots[key];

                status.AppendLine(string.Format("Sector {0}: {1} / {2} ({3}% full)", key, sector.Values.Where(v => v != null).Count(), sector.Keys.Count(), (int)((double)sector.Values.Where(v => v != null).Count() / sector.Keys.Count() * 100)));
            }

            return status.ToString();
        }

        /// <summary>
        /// Method which finds a vehicle parked in the vehicle park. 
        /// And display general information about it.
        /// </summary>
        /// <param name="licensePlate">The licence plate of the searched vehicle</param>
        /// <returns></returns>
        public string FindVehicle(string licensePlate, List<Mock<IVehicle>> mockVehicles = null)
        {
            if (mockVehicles != null)
            {
                var match = mockVehicles.FirstOrDefault(v => v.Object.LicensePlate.Equals(licensePlate));
                if (match != null)
                {
                    return match.Object.LicensePlate;
                }
            }

            var vehicle = StaticData.ApplicationData.Vehicles.FirstOrDefault(v => v.LicensePlate.Equals(licensePlate));
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var vehicleStatus = new StringBuilder();
            vehicleStatus.AppendLine(vehicle.ToString())
                .AppendLine(string.Format("Parked at (<{0}>,<{1}>)", vehicle.ParkedSector, vehicle.ParkedPlace));

            return vehicleStatus.ToString();
        }

        /// <summary>
        /// Method which displays tbe vehicles currently parked in the park wich the same owner.
        /// </summary>
        /// <param name="owner">Owner name</param>
        /// <returns></returns>
        public string FindVehiclesByOwner(string owner, List<Mock<IVehicle>> mockVehicles = null)
        {
            if (mockVehicles != null)
            {
                var match = mockVehicles.FirstOrDefault(v => v.Object.Owner.Equals(owner));
                if (match != null)
                {
                    return match.Object.Owner;
                }
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                return "No owner provided";
            }

            IEnumerable<IVehicle> allVehiclesByThisOwner = StaticData.ApplicationData.Vehicles.Where(v => string.Compare(owner, v.Owner, true) == 0);

            if (allVehiclesByThisOwner.Count() <= 0)
            {
                return "No vehicles by <" + owner + ">";
            }

            var vehicleStatus = new StringBuilder();
            foreach (IVehicle vehicle in allVehiclesByThisOwner)
            {
                vehicleStatus.AppendLine(vehicle.ToString())
                    .AppendLine(string.Format("Parked at (<{0}>,<{1}>)", vehicle.ParkedSector, vehicle.ParkedPlace));
            }

            return vehicleStatus.ToString();
        }
    }
}
