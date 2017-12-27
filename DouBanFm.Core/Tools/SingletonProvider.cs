using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPHttpManager
{
    public class SingletonProvider<T> where T : new()
    {
        public SingletonProvider()
        {
        }

        public static T Instance
        {
            get
            {
                return SingletionCreator.instance;
            }
        }

        private class SingletionCreator
        {
            static SingletionCreator()
            {
            }

            internal static readonly T instance = new T();
        }
    }
}