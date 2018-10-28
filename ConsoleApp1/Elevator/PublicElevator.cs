using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public class PublicElevator : BaseElevator
    {
        public PublicElevator(int top) : base(top)
        {
        }
        public override void MoveDown(int floor)
        {
            Status = Status.GoingDown;
            Console.WriteLine("Going Down");
            for(int i=this.CurrentFloor;i>=floor;i--)
            {
                Console.WriteLine("Floor "+i);
                System.Threading.Thread.Sleep(1000);
            }
            CurrentFloor = floor;
            OpenDoor();
            CloseDoor();
        }

        public override void MoveUp(int floor)
        {
            Status = Status.GoingUp;
            Console.WriteLine("Going Up");
            for (int i = this.CurrentFloor; i <= floor; i++)
            {
                Console.WriteLine("Floor " + i);
                System.Threading.Thread.Sleep(1000);
            }
            CurrentFloor = floor;
            OpenDoor();
            CloseDoor();
        }
    }
}
