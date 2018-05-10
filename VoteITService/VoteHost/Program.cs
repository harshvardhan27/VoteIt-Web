using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VoteHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost voteHost = new ServiceHost(typeof(VoteITServiceLibrary.Vote)))
            {
                voteHost.Open();
                Console.WriteLine("Host started press any key to stop");
                Console.ReadLine();
            }
        }
    }
}
