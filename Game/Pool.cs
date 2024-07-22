using Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Pool<T>
    {
        public List<T> avaible;
        public List<T> inUse;
        public Pool()
        {
            avaible = new List<T>();
            inUse = new List<T>();
        }

        public T Pull()
        {
            if (avaible.Count == 0)
            {
                return default(T);
            }
            else
            {
                inUse.Add(avaible[0]);
                avaible.RemoveAt(0);
                Engine.Debug(avaible.Count.ToString());
                return inUse[inUse.Count - 1];
            }
        }

        public void Push(T obj)
        {
            inUse.Add(obj);
        }

        public void Return(T obj)
        {
            inUse.Remove(obj);
            avaible.Add(obj);
        }
    }
}
