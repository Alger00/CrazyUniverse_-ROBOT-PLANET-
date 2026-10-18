using System;
using System.Collections.Generic;
using System.Text;
using CrazyUniverse__ROBOT_PLANET_.Core.Models;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Repositories
{
    public class RepositoryEventArgs : EventArgs
    {
        public Robot Source { get; }

        public List<string> Messages { get; }

        public RepositoryEventArgs(Robot source, List<string>? messages = null)
        {
            Source = source;
            Messages = messages ?? new List<string>();
        }
    }
}
