using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conveyor conveyor = new Conveyor();
            Multipult multipult = new Multipult();
            multipult.SetCommand(0, new ConveyorWorkCommand(conveyor));
            multipult.SetCommand(1, new ConveyorSpeedCommand(conveyor));
            multipult.PressOn(0);
            multipult.PressOn(1);
            multipult.PressCansel();
            multipult.PressCansel();
        }
    }
}
