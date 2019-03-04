using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public static class FactorySingleton<T> where T : new()
    {
        private static T instance = default(T);
        private static object synklock = new object();

        public static T getInstance()
        {
            lock (synklock)
            {
                if (instance == null)
                {
                    instance = new T();
                }
            }
            return instance;
        }
    }
}
