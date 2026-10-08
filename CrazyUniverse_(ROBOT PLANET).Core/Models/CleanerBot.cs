using System;
using System.Collections.Generic;
using System.Text;
using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class CleanerBot : Robot, IChargeable
    {
        public CleanerBot(string name) : base(name, 100)
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

        public override string Work()
        {
            if (BatteryLevel < 5)
            {
                return $"{Name} is too tired to work.";
            }

            BatteryLevel = BatteryLevel - 5;

            return $"{Name} cleaned the floor.";
        }

        public override string CrazyAction()
        {
            if (BatteryLevel < 15)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 15;

            return $"{Name} polished a banana until it looked like gold.";
        }
    }
}