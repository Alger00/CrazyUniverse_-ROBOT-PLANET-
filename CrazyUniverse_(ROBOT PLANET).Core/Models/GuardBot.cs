using CrazyUniverse__ROBOT_PLANET_.Core.Interfaces;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class GuardBot : Robot, IChargeable, IScan
    {
        public GuardBot(string name) : base(name, 100)
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
            if (BatteryLevel < 10)
            {
                return $"{Name} is too tired to scan.";
            }
            BatteryLevel = BatteryLevel - 10;
            return $"{Name} scanned the area for intruders.";
        }

        public override string Work()
        {
            if (BatteryLevel < 8)
            {
                return $"{Name} is too tired to work.";
            }
            BatteryLevel = BatteryLevel - 8;
            return $"{Name} guarded the area.";
        }
        public override string CrazyAction()
        {
            if (BatteryLevel < 25)
            {
                return $"{Name} is too tired for a crazy action.";
            }

            BatteryLevel = BatteryLevel - 25;

            return $"{Name} nuked an enemy planet.";

        }
    }
}