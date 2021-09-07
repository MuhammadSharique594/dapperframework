using DapperModels.Operations;
using DapperModels.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DapperModels.Config
{
    internal delegate void Register(ref UnityContainer container);

    class IOC
    {
        private static UnityContainer _container;

        private void Register(Register method)
        {
            //method.Invoke();
        }

        public static T Resolve<T>()
        {
            if(_container == null)
            {
                _container = new UnityContainer();
                _container.RegisterType<IOperation, Operation_sql>();
            }

            return _container.Resolve<T>();
        }
    }
}
