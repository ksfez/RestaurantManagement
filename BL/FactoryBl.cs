using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        //the function allows to access to the BL when we are in the UI
        public static IBL getBL()
        {
            return DesignPatterns.FactorySingleton<ListBl>.getInstance();
        }
    }
}

