using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Models
{
    public class SimulationResult
    {
        public string RobotName { get; set; } = "";
        public string Status { get; set; } = "";
        public double Result { get; set; }
        public long DurationMs { get; set; }
        public string ErrorMessage { get; set; } = "";
    }
}
