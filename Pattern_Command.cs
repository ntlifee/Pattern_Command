using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command
{
    interface ICommand
    {
        void Positive();
        void Negative();
    }
    class Conveyor
    {
        public void On() => Console.WriteLine("Конвейер запущен");
        public void Off() => Console.WriteLine("Конвейер остановлен");
        public void SpeedIncrease() => Console.WriteLine("Увеличена скорость конвейера");
        public void SpeedDecrease() => Console.WriteLine("Уменьшена скорость конвейера");
    }
    class ConveyorWorkCommand:ICommand
    {
        private Conveyor conveyor;
        public ConveyorWorkCommand(Conveyor conveyor) => this.conveyor = conveyor;

        public void Positive() => conveyor.On();

        public void Negative() => conveyor.Off();
    }

    class ConveyorSpeedCommand : ICommand
    {
        private Conveyor conveyor;
        public ConveyorSpeedCommand(Conveyor conveyor) => this.conveyor = conveyor;

        public void Positive() => conveyor.SpeedIncrease();

        public void Negative() => conveyor.SpeedDecrease();
    }
    class Multipult
    {
        private Dictionary<int ,ICommand> commands;
        private Stack<ICommand> history;
        public Multipult()
        {
            commands = new Dictionary<int, ICommand>();
            history = new Stack<ICommand>();
        }
        public void SetCommand(int button, ICommand command) => commands[button] = command; 
        public void PressOn(int  button)
        {
            commands[button].Positive();
            history.Push(commands[button]);
        }

        public void PressCansel()
        {
            if (history.Count > 0)
            {
                history.Pop().Negative();
            }
        }
    }
}
