using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himineu.VehicleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Himineu.Interfaces;

namespace Himineu.VehicleCommands.Tests
{
    [TestClass()]
    public class VehicleParkCommandsUnitTests
    {
        //The coverage of the methods cannot be 90% with the current structure
        //The variable checks need to be before the execution of the methods, which might be a better approach.

        #region InsertCar

        [TestMethod()]
        public void InsertCarTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the vehicle data is null
            testObject.InsertCar(null, "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertCarTest1()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the sector number is bigger than the existing one
            testObject.InsertCar(new VehicleModels.Car("VT2222VT", "John Doe", "3"), "33", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertCarTest2()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the place number is bigger than the existing one
            testObject.InsertCar(new VehicleModels.Car("VT2222VT", "John Doe", "3"), "1", "33", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertCarTest3()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the license plate is not valid
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertCar(new VehicleModels.Car("VT222V", "John Doe", "3"), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertCarTest4()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the object data is whitespace
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertCar(new VehicleModels.Car("", "", ""), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertCarTest5()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the data is not in valid format
            testObject.InsertCar(new VehicleModels.Car("VT2222VT", "Joe Doe", "4"), "1", "1", "04-04-2015");
        }

        [TestMethod()]
        public void InsertCarTest6()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertCar(new VehicleModels.Car("VT2222VT", "Joe Doe", "4"), "", "", "");
        }

        [TestMethod()]
        public void InsertCarTest7()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertCar(new VehicleModels.Car("VT2222VT", "Joe Doe", "4"), "two", "tree", "i have no watch");
        }

        #endregion

        #region InsertMotorbike

        [TestMethod()]
        public void InsertMotorbikeTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the vehicle data is null
            testObject.InsertMotorbike(null, "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertMotorbikeTest1()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the sector number is bigger than the existing one
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT2222VT", "John Doe", "3"), "33", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertMotorbikeTest2()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the place number is bigger than the existing one
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT2222VT", "John Doe", "3"), "1", "33", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertMotorbikeTest3()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the license plate is not valid
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT222V", "John Doe", "3"), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertMotorbikeTest4()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the object data is whitespace
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertMotorbike(new VehicleModels.Motorbike("", "", ""), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertMotorbikeTest5()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the data is not in valid format
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT2222VT", "Joe Doe", "4"), "1", "1", "04-04-2015");
        }

        [TestMethod()]
        public void InsertMotorbikeTest6()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT2222VT", "Joe Doe", "4"), "", "", "");
        }

        [TestMethod()]
        public void InsertMotorbikeTest7()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertMotorbike(new VehicleModels.Motorbike("VT2222VT", "Joe Doe", "4"), "two", "tree", "i have no watch");
        }

        #endregion

        #region InsertTruck

        [TestMethod()]
        public void InsertTruckTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the vehicle data is null
            testObject.InsertTruck(null, "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertTruckTest1()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the sector number is bigger than the existing one
            testObject.InsertTruck(new VehicleModels.Truck("VT2222VT", "John Doe", "3"), "33", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertTruckTest2()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the place number is bigger than the existing one
            testObject.InsertTruck(new VehicleModels.Truck("VT2222VT", "John Doe", "3"), "1", "33", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertTruckTest3()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the license plate is not valid
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertTruck(new VehicleModels.Truck("VT222V", "John Doe", "3"), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertTruckTest4()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the object data is whitespace
            //This will return a handled exception, but there are checks before creating the object in the code
            testObject.InsertTruck(new VehicleModels.Truck("", "", ""), "1", "1", "2015-04-04T10:30:00.0000000");
        }

        [TestMethod()]
        public void InsertTruckTest5()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the data is not in valid format
            testObject.InsertTruck(new VehicleModels.Truck("VT2222VT", "Joe Doe", "4"), "1", "1", "04-04-2015");
        }

        [TestMethod()]
        public void InsertTruckTest6()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertTruck(new VehicleModels.Truck("VT2222VT", "Joe Doe", "4"), "", "", "");
        }

        [TestMethod()]
        public void InsertTruckTest7()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.InsertTruck(new VehicleModels.Truck("VT2222VT", "Joe Doe", "4"), "two", "tree", "i have no watch");
        }

        #endregion

        #region Exit Vehicle
        [TestMethod()]
        public void ExitVehicleTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If parameters are null
            testObject.ExitVehicle("", "", "");

        }

        [TestMethod()]
        public void ExitVehicleTest1()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If license plate is not valid are null
            testObject.ExitVehicle("AAA333AAA", "2015-04-04T10:30:00.0000000", "100");

        }

        [TestMethod()]
        public void ExitVehicleTest2()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the data is not parsable
            testObject.ExitVehicle("VT2002VT", "2015-04-", "100");

        }

        [TestMethod()]
        public void ExitVehicleTest3()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.SetupPark("3", "3");
            //If the money paid is not numeric
            testObject.ExitVehicle("AAA333AAA", "2015-04-04T10:30:00.0000000", "five bucks");

        }
        #endregion

        #region GetStatus
        [TestMethod()]
        public void GetStatusTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            testObject.GetStatus();
        }

        #endregion

        #region FindVehiclesByOwner

        [TestMethod()]
        public void FindVehiclesByOwnerTest()
        {
            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the owner is not given
            testObject.FindVehiclesByOwner("");

        }

        [TestMethod()]
        public void FindVehiclesByOwnerTest1()
        {
            Mock<IVehicle> mock = new Mock<IVehicle>();
            mock.Setup(v => v.Owner).Returns("John Snow");

            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the owner is not given
            var result = testObject.FindVehiclesByOwner("John Snow", new List<Mock<IVehicle>>() { mock });

            Assert.AreEqual(result, "John Snow");
        }

        #endregion

        #region FindVehicle

        [TestMethod()]
        public void FindVehicleTest()
        {
            Mock<IVehicle> mock = new Mock<IVehicle>();
            mock.Setup(v => v.LicensePlate).Returns("VT2002VT");

            VehicleParkCommands testObject = new VehicleParkCommands();
            //If the owner is not given
            var result = testObject.FindVehicle("VT2002VT", new List<Mock<IVehicle>>() { mock });

            Assert.AreEqual(result, "VT2002VT");
        }

        #endregion
    }
}