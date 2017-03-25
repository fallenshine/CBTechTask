namespace Himineu.VehicleCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Himineu.Interfaces;

    public class UserCommands : IUserInterface
    {
        /// <summary>
        /// Input
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Output
        /// </summary>
        /// <param name="format"></param>
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
