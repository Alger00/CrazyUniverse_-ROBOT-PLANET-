using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class RepairBot : Robot, IChargeable, IRepair
    {
        public RepairBot(string name) : base(name, 100)
        {
        }

        public string Charge()
        {
            BatteryLevel = BatteryLevel + 20;
            if (BatteryLevel > 100)
            {
                BatteryLevel = 100;
            }
            return $"{Name} charged battery.";
        }

        public string Repair()
        {
            BatteryLevel = BatteryLevel - 10;

            return $"{Name} repaired another robot.";
        }

        public override string Work()
        {
            if (BatteryLevel < 8)
            {
                return $"{Name} is too tired to work.";
            }

            BatteryLevel = BatteryLevel - 8;

            return $"{Name} repaired a machine.";
        }

        public override string CrazyAction()
        {
            if (BatteryLevel < 25)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 25;

            return $"{Name} built a dancing spaceship.";
        }
    }
}