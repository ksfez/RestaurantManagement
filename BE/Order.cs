using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int Order_ID { get; set; }
        public DateTime Date { get; set; }
        public int OrderBranch { get; set; }
        public Hechsher Hechsher { get; set; }
        public int Sender { get; set; }
        public string OrderName { get; set; }
        public string OrderAdress { get; set; }
        public string DeliveryAdress { get; set; }
        public int Card { get; set; }
        public Town Town { get; set; }
        public override string ToString()
        {
            string result = "Order Details: \n";
            result += string.Format("\tOrder name: {0}\n", OrderName);
            return result;
        }

    }
}
