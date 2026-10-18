using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class TankBot : Robot, IChargeable
    {
        public TankBot(string name) : base(name, 100)
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
            if (BatteryLevel < 15)
            {
                return $"{Name} is too tired to work.";
            }

            BatteryLevel = BatteryLevel - 8;

            return $"{Name} fired upon the enemy.";
        }

        public override string CrazyAction()
        {
            if (BatteryLevel < 100)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 100;

            return $"{Name} destroyed the entire enemy planet.";
        }
    }
}