using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Branch
    {
        public int BranchNum { get; set; } //BranchID
        public string BranchName { get; set; }
        public string BranchAdress { get; set; }
        public Town BranchTown { get; set;}
        public int Phone { get; set; }
        public string Director { get; set; }
        public int Workers { get; set; }
        public int BranchSenders { get; set; }
        public Hechsher BranchHechsher { get; set; }

        public override string ToString()
        {
            string result = "Branch details: \n";
            result += string.Format("\t Branch name: {0}", BranchName);
            result += string.Format("the branch number is: {0} and the hechsher is: {1}\n", BranchNum, BranchHechsher);
            return result;
        }
    }
}
