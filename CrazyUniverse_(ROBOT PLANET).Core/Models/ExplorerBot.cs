using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class ExplorerBot : Robot, IChargeable, IScan
    {
        public ExplorerBot (string name) : base(name, 100)
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

        public string Scan()
        {
            if (BatteryLevel < 5)
            {
                return $"{Name} is too tired to scan.";
            }

            BatteryLevel = BatteryLevel - 5;

            return $"{Name} scanned a strange object.";
        }

        public override string Work()
        {
            if (BatteryLevel < 10)
            {
                return $"{Name} is too tired to work.";
            }

            BatteryLevel = BatteryLevel - 10;

            return $"{Name} explored a new area.";
        }

        public override string CrazyAction()
        {
            if (BatteryLevel < 20)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 20;

            return $"{Name} found a planet made of pizza.";
        }
    }
}