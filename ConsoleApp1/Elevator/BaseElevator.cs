using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public abstract class BaseElevator : IElevator
    {
        public BaseElevator(int top)
        {
            TopFloor = top;
            CurrentFloor = 0;
            Status = Status.Stopped;
        }
        public int TopFloor { get; set; }
        public int CurrentFloor { get; set; }
        public Status Status { get; set; }
        public virtual void OpenDoor()
        {
            Console.WriteLine("Door opening");
        }          
        public virtual void CloseDoor()
        {
            Console.WriteLine("Door closing, at floor: {0}", this.CurrentFloor);
        }
        public abstract void MoveDown(int floor);
        public abstract void MoveUp(int floor);        
    }
}
