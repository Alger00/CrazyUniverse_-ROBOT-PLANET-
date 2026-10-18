using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public abstract class Robot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        public string Name { get; }

        private int batteryLevel;

        public int BatteryLevel
        {
            get { return batteryLevel; }
            protected set
            {
                batteryLevel = value;
                OnPropertyChanged(nameof(BatteryLevel));
            }
        }

        public string RobotType
        {
            get
            {
                return GetType().Name;
            }
        }

        public Robot(string name, int batterylevel)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            Name = name;
            BatteryLevel = batterylevel;
        }

        public abstract string Work();

        public abstract string CrazyAction();
        public virtual string Greet(Robot newRobot)
        {
            return $"{Name} welcomed {newRobot.Name}.";
        }

        public virtual string Goodbye(Robot removedRobot)
        {
            return $"{Name} said goodbye to {removedRobot.Name}.";
        }

        public virtual string ReactToCrazyAction(Robot actor)
        {
            return $"{Name} reacted to {actor.Name}'s crazy action.";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}