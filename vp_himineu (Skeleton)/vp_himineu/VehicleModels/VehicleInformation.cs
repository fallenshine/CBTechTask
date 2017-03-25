namespace Himineu.VehicleModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Himineu.App_Data;

    public abstract class VehicleInformation
    {
        private int? parkedSector = null;

        private int? parkedPlace = null;

        private string licensePlate = string.Empty;

        private string owner = string.Empty;

        private int? reservedHours = null;

        private DateTime? registrationDate = null;

        private double? regularRate = null;

        private double? overtimeRate = null;

        public int ParkedSector
        {
            get
            {
                if (this.parkedSector == null)
                {
                    throw new ArgumentException("The the sector must be positive.");
                }

                return (int)this.parkedSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The the sector must be positive.");
                }

                this.parkedSector = value;
            }
        }

        public int ParkedPlace
        {
            get
            {
                if (this.parkedPlace == null)
                {
                    throw new ArgumentException("The the place must be positive.");
                }

                return (int)this.parkedPlace;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The the place must be positive.");
                }

                this.parkedPlace = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                if (!StaticData.ValidateLicensePlate(value))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                if (this.reservedHours == null)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                return (int)this.reservedHours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                if (this.registrationDate == null)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                return (DateTime)this.registrationDate;
            }

            set
            {
                this.registrationDate = value;
            }
        }

        public double RegularRate
        {
            get
            {
                if (this.regularRate == null)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                return (double)this.regularRate;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.regularRate = value;
            }
        }

        public double OvertimeRate
        {
            get
            {
                if (this.overtimeRate == null)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                return (double)this.overtimeRate;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.overtimeRate = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}], owned by {2}", GetType().Name, this.LicensePlate, this.Owner);
        }
    }
}
