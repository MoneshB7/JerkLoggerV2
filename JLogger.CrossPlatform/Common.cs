using System;
using System.Collections.Generic;
using System.Text;
using JLogger.CrossPlatform.Models;
using System.Linq;
using System.Data;

namespace JLogger.CrossPlatform
{
    public class Common
    {
         JerkdbContext context;

        public JerkdbContext Context { get { return context; } }

        int status = 0;
        int totalCount = 0;

        public Common()
        {
            context = new JerkdbContext();
        }


        //Get Total Count the User Did it
        public int GetTotalCount()
        {

            try
            {
                totalCount = Convert.ToInt32((from c in context.Jlog select c.Ntimes).Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                totalCount = -99;
            }
            
            return totalCount;
        }

        //Number of Times a User Did *insert a habit you wanna track here* on a Given Date 

        public int GetTotalCountByDate(DateTime date)
        {
            try
            {
                totalCount = (from c in context.Jlog where c.Date == date select c.Ntimes).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                totalCount = -99;
            }
            return totalCount;
        }

        //Add Details
        public int AddJerk(DateTime jdate,int jtimes,string jreasontxt)
        {
            Jlog jObj = new Jlog();
            jObj.Date = jdate;
            jObj.Ntimes = jtimes;
            jObj.Reason = jreasontxt;
            try
            {
                context.Jlog.Add(jObj);
                context.SaveChanges();
                status = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = -99;
                
            }
            return status;
        }

        //Modify the Count Based on the Date
        public int ModifyJerkCount(DateTime jdate,int jtimes)
        {
            try
            {
                Jlog jObj = context.Jlog.Find(jdate);

                if(jObj!=null)
                {
                    jObj.Ntimes = jtimes;
                    context.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = -99;
            }
            return status;
        }

        //Modify the Reason Based on the Date
        public int ModifyJerkReason(DateTime jdate, string jreasontxt)
        {
            try
            {
                Jlog jobj = context.Jlog.Find(jdate);

                if(jobj!=null)
                {
                    jobj.Reason = jreasontxt;
                    context.SaveChanges();
                    status = 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = -99;
            }
            return status;
        }

        //Delete Particular Entry Based on Date
        public int DeleteJerk(DateTime jdate)
        {
            try
            {
                Jlog jObj = context.Jlog.Find(jdate);

                if(jObj!=null)
                {
                    context.Jlog.Remove(jObj);
                    context.SaveChanges();
                    status = 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = -99;
            }
            return status;
        }

       

    }
}


