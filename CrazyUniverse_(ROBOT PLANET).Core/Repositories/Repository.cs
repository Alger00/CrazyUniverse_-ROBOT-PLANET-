using System;
using System.Collections.Generic;
using System.Text;
using CrazyUniverse__ROBOT_PLANET_.Core.Models;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : Robot
    {
        private readonly List<T> items = new();
        public event EventHandler<RepositoryEventArgs>? CharacterAdded;

        public event EventHandler<RepositoryEventArgs>? CharacterRemoved;

        public event EventHandler<RepositoryEventArgs>? CrazyActionPerformed;

        public void Add(T item)
        {
            items.Add(item);
            List<string> reactions = HandleCharacterAdded(item).ToList();
            CharacterAdded?.Invoke(this, new RepositoryEventArgs(item, reactions));
        }

        public void Remove(T item)
        {
            items.Remove(item);
            List<string> reactions = HandleCharacterRemoved(item).ToList();
            CharacterRemoved?.Invoke(this, new RepositoryEventArgs(item, reactions));
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public T? Find(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }
        public void NotifyCrazyAction(T item)
        {
            List<string> reactions = HandleCrazyAction(item).ToList();
            CrazyActionPerformed?.Invoke(this, new RepositoryEventArgs(item, reactions));
        }

        public IEnumerable<string> HandleCharacterAdded(T newRobot)
        {
            List<string> logs = new();

            foreach (var robot in items)
            {
                if (robot != newRobot)
                {
                    logs.Add(robot.Greet(newRobot));
                }
            }

            return logs;
        }

        public IEnumerable<string> HandleCharacterRemoved(T removedRobot)
        {
            List<string> logs = new();

            foreach (var robot in items)
            {
                if (robot != removedRobot)
                {
                    logs.Add(robot.Goodbye(removedRobot));
                }
            }

            return logs;
        }

        public IEnumerable<string> HandleCrazyAction(T actor)
        {
            List<string> logs = new();

            foreach (var robot in items)
            {
                if (robot != actor)
                {
                    logs.Add(robot.ReactToCrazyAction(actor));
                }
            }

            return logs;
        }
    }
}
