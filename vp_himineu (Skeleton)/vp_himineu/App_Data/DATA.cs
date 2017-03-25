namespace Himineu.App_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.Interfaces;

    public class DATA
    {
        private Dictionary<int, Dictionary<int, IVehicle>> vehicleParkslots = null;

        private List<IVehicle> vehicles = null;

        public DATA(int numberOfSectors, int numberOfPlacesPerSector)
        {
            // PERFORMANCE: Mapping the layout of the park in such manner could cause a hitch ups if there are alot of spaces.
            // Ideally i would use a Database or even a XML in which the Linq would be a lot faster and wouldnt requair the data to be loeaded into the memory.
            for (int i = 1; i <= numberOfSectors; i++)
            {
                Dictionary<int, IVehicle> dummy = new Dictionary<int, IVehicle>();

                for (int j = 1; j <= numberOfPlacesPerSector; j++)
                {
                    dummy.Add(j, null);
                }

                this.VehicleParkslots.Add(i, dummy);
            }
        }

        public Dictionary<int, Dictionary<int, IVehicle>> VehicleParkslots
        {
            get
            {
                if (this.vehicleParkslots == null)
                {
                    this.vehicleParkslots = new Dictionary<int, Dictionary<int, IVehicle>>();
                }

                return this.vehicleParkslots;
            }

            set
            {
                this.vehicleParkslots = value;
            }
        }

        public List<IVehicle> Vehicles
        {
            get
            {
                if (this.vehicles == null)
                {
                    this.vehicles = new List<IVehicle>();
                }

                return this.vehicles;
            }

            set
            {
                this.vehicles = value;
            }
        }
    }
}
