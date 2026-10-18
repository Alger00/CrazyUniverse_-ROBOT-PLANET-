using System;
using System.Collections.Generic;
using System.Text;
using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class GeneralBot : Robot, IChargeable, IScan
    {
        public GeneralBot(string name) : base(name, 100)
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
            return $"{Name} is scouting the enemy planet.";
        }
        public override string Work()
        {
            if (BatteryLevel < 10)
            {
                return $"{Name} is too tired to work.";
            }
            BatteryLevel = BatteryLevel - 10;
            return $"{Name} is planning the next move.";
        }
        public override string CrazyAction()
        {
            if (BatteryLevel < 50)
            {
                return $"{Name} is too tired for a crazy action.";
            }
            BatteryLevel = BatteryLevel - 50;
            return $"{Name} is leading an army of robots to conquer the universe.";
        }
    }
}