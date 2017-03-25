namespace Himineu.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Himineu.VehicleModels;
    using Moq;

    public interface IVehicle
    {
        int ParkedSector { get; }

        int ParkedPlace { get; }

        double RegularRate { get; }

        double OvertimeRate { get; }

        string LicensePlate { get; }

        string Owner { get; }

        int ReservedHours { get; }

        DateTime RegistrationDate { get; }
    }

    public interface IVehiclePark
    {
        // I would prefer to make one Insert Generic method using the interface as a combiner, or 
        // atleast to use to interface IVehicles instead of all the objects :) but it was written not to change the interface. :(

        /// <summary>
        /// Setup the park space
        /// </summary>
        /// <param name="numberOfSectors">Indicate the number of sectors</param>
        /// <param name="placesPerSector">Indicate the number of places in each sector</param>
        /// <returns></returns>
        string SetupPark(string numberOfSectors, string placesPerSector);

        /// <summary>
        /// The method corespond the Parking a car in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="car">Car object generated with the specific data</param>
        /// <param name="sector">The secor the car may be parked.</param>
        /// <param name="place">The place in the sector where the car may be parked</param>
        /// <param name="time">The time the car is parking</param>
        /// <returns></returns>
        string InsertCar(Car car, string sector, string placeNumber, string startTime);

        /// <summary>
        /// The method corespond the Parking a motorbike in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="moto">A Motorbike object which was generated with a specific data</param>
        /// <param name="sector">The secor the motorbike may be parked.</param>
        /// <param name="place">The place in the sector where the motorbike may be parked</param>
        /// <param name="time">The time the motorbike is parking</param>
        /// <returns></returns>
        string InsertMotorbike(Motorbike motorbike, string sector, string placeNumber, string startTime);

        /// <summary>
        /// The method corespond the Parking a truck in the VehiclePark. 
        /// It also is responsible for the managing the application data.
        /// </summary>
        /// <param name="truck">Truck object generated with the specific data</param>
        /// <param name="sector">The secor the truck may be parked.</param>
        /// <param name="place">The place in the sector where the truck may be parked</param>
        /// <param name="time">The time the truck is parking</param>
        /// <returns></returns>
        string InsertTruck(Truck truck, string sector, string placeNumber, string startTime);

        /// <summary>
        /// A method responsibile for billing the customer, 
        /// and removing the car from the application data
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle</param>
        /// <param name="endDate">The date when the vehicle is leaving</param>
        /// <param name="paid">The amount of money the customer paid</param>
        /// <returns></returns>
        string ExitVehicle(string licensePlate, string endTime, string amountPaid);

        /// <summary>
        /// Method which provide information about the current status of the vehicle park.
        /// </summary>
        /// <returns></returns>
        string GetStatus();

        /// <summary>
        /// Method which finds a vehicle parked in the vehicle park. 
        /// And display general information about it.
        /// </summary>
        /// <param name="licensePlate">The licence plate of the searched vehicle</param>
        /// <returns></returns>
        string FindVehicle(string licensePlate, List<Mock<IVehicle>> mockVehicles = null);

        /// <summary>
        /// Method which displays tbe vehicles currently parked in the park wich the same owner.
        /// </summary>
        /// <param name="owner">Owner name</param>
        /// <returns></returns>
        string FindVehiclesByOwner(string owner, List<Mock<IVehicle>> mockVehicles = null);
    }

    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format);
    }
}
