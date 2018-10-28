using Common;
using Elevator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Manager : IManager
    {
        private readonly Queue<Request> _downRequests = new Queue<Request>();
        readonly IElevator _elevator;
        private readonly Queue<Request> _upRequests = new Queue<Request>();

        public Manager(IElevator elevator)
        {
            _elevator = elevator;
        }
        public void ButtonPressed(int floor)
        {
            if (floor > _elevator.TopFloor)
            {
                Console.WriteLine("Only have {0} floors...", _elevator.TopFloor);
                return;
            }
            if (floor <0)
            {
                Console.WriteLine("No Basement floors...");
                return;
            }

            if (floor > _elevator.CurrentFloor)
                _upRequests.Enqueue(new Request(floor));
            else if (floor == _elevator.CurrentFloor)
            {
                _elevator.OpenDoor();
                _elevator.CloseDoor();
                return;
            }
            else
                _downRequests.Enqueue(new Request(floor));

            Move(floor);
        }

        private void Move(int floor)
        {
            switch (_elevator.Status)
            {
                case Status.GoingDown:
                    while (_downRequests.Count > 0)
                        _elevator.MoveDown(_downRequests.Dequeue().Floor);
                    _elevator.Status = Status.Stopped;
                    break;

                case Status.GoingUp:
                    while (_upRequests.Count > 0)
                        _elevator.MoveUp(_upRequests.Dequeue().Floor);

                    _elevator.Status = Status.Stopped;
                    break;

                case Status.Stopped:
                    if (floor > _elevator.CurrentFloor)
                        _elevator.Status = Status.GoingUp;
                    else if (floor <= _elevator.CurrentFloor)
                        _elevator.Status = Status.GoingDown;

                    Move(floor);

                    break;
                default:
                    break;
            }
        }
    }
}
