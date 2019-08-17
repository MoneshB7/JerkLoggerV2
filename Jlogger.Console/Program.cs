using System;
using System.Text;
using System.IO;
using JLogger.CrossPlatform;

namespace Jlogger.Console
{
    class Program
    {
        Common obj = new Common();
        int TotalCount = 0;

        public void CountByDate()
        {
            System.Console.WriteLine("Enter Date(eg: 2019-08-15)");
            DateTime DOJ = Convert.ToDateTime(System.Console.ReadLine());
            TotalCount = obj.GetTotalCountByDate(DOJ);
            string dojDate = DOJ.ToShortDateString();
            System.Console.WriteLine("You have Smoked {0} times on {1}", TotalCount, dojDate);
        }

        public void CountAll()
        {
            TotalCount = obj.GetTotalCount();
            System.Console.WriteLine("You have Smoked {0} times till now", TotalCount);
        }

        public void AddJerkDetails()
        {
            System.Console.WriteLine("Enter Date(eg: 2019-08-15)");
            DateTime jdate0 =  Convert.ToDateTime(System.Console.ReadLine());
            DateTime jdate1 = Convert.ToDateTime(jdate0.ToShortDateString());
            System.Console.WriteLine("How many times ?");
            int jtimes = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("What made you to?");
            string jreasontxt = System.Console.ReadLine();
            int value = obj.AddJerk(jdate1,jtimes,jreasontxt);
            if(value ==1)
            {
                System.Console.WriteLine("Details Added Successfully!");
            }
            else
            {
                System.Console.WriteLine("Details Could Not Be Added..");
            }
        }

        public void FModifyCount()
        {
            System.Console.WriteLine("Enter Date(eg: 2019-08-15)");
            DateTime jdate0 = Convert.ToDateTime(System.Console.ReadLine());
            DateTime jdate1 = Convert.ToDateTime(jdate0.ToShortDateString());
            System.Console.WriteLine("Enter New Count");
            int jtimes = Convert.ToInt32(System.Console.ReadLine());
            int value = obj.ModifyJerkCount(jdate1, jtimes);
            if (value == 1)
            {
                System.Console.WriteLine("Details Modified Successfully!");
            }
            else
            {
                System.Console.WriteLine("Details Could Not Be Modified..");
            }

        }
        public void FModifyReason()
        {
            System.Console.WriteLine("Enter Date(eg: 2019-08-15)");
            DateTime jdate0 = Convert.ToDateTime(System.Console.ReadLine());
            DateTime jdate1 = Convert.ToDateTime(jdate0.ToShortDateString());
            System.Console.WriteLine("Enter New Reason");
            string jreasontxt = System.Console.ReadLine();
            int value = obj.ModifyJerkReason(jdate1,jreasontxt);
            if (value == 1)
            {
                System.Console.WriteLine("Details Modified Successfully!");
            }
            else
            {
                System.Console.WriteLine("Details Could Not Be Modified..");
            }
        }
        
        public void FDeleteJerk()
        {
            System.Console.WriteLine("Enter Date(eg: 2019-08-15)");
            DateTime jdate0 = Convert.ToDateTime(System.Console.ReadLine());
            DateTime jdate1 = Convert.ToDateTime(jdate0.ToShortDateString());
            int value = obj.DeleteJerk(jdate1);
            if(value==1)
            {
                System.Console.WriteLine("Details Deleted Successfully");
            }
            else
            {
                System.Console.WriteLine("Details Could Not Be Deleted..");
            }
        }

static void Main(string[] args)
        {
            Program call = new Program();
            //call.CountAll();
            //call.CountByDate();
            //call.AddJerkDetails();
            //call.FModifyCount();
            //call.FModifyReason();
            //call.FDeleteJerk();
            //Fetch Details Based on a Given Date Range should be added.


        }
    }
}
