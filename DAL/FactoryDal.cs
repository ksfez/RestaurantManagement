using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDal
    {
        public static IDAL getDal()
        {
            return DesignPatterns.FactorySingleton<XmlDAL>.getInstance();
        }
    }
}
