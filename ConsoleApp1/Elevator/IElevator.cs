using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public interface IElevator
    {
        int TopFloor { get; set; }
        int CurrentFloor { get; set; }
        Status Status { get; set; }
        void MoveUp(int floor);
        void MoveDown(int floor);
        void OpenDoor();
        void CloseDoor();
        void MaxFloorMsg();
        void NoBasementsMsg();
    }
}
