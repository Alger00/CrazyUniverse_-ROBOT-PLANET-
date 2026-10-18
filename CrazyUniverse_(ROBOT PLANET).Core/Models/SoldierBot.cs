using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class SoldierBot : Robot, IChargeable, IRepair
    {
        public SoldierBot(string name) : base(name, 100)
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
            if (BatteryLevel < 10)
            {
                return $"{Name} is too tired to repair.";
            }

            BatteryLevel = BatteryLevel - 10;

            return $"{Name} repaired itself.";
        }

        public override string Work()
        {
            if (BatteryLevel < 8)
            {
                return $"{Name} is too tired to work.";
            }

            BatteryLevel = BatteryLevel - 15;

            return $"{Name} fought off the enemy.";
        }

        public override string CrazyAction()
        {
            if (BatteryLevel < 25)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 25;

            return $"{Name} disobeyed the orders of the general.";
        }
    }
}