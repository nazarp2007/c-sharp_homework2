using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IWarranty
    {
        void GetWarrantyInfo();
    }

    public interface ISellable
    {
        double CalculateFinalPrice();
    }
}
