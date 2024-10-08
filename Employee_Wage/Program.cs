using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage
{
    internal class EmpWageBuilderObject
    {
       
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        private string company;
        private int empRatePerHour;
        private int numOfWorkingDays;
        private int maxHoursPerMonth;
        private int totalEmpWage;

        public EmpWageBuilderObject(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
                {
                    this.company = company;
                    this.empRatePerHour =empRatePerHour;
                    this.numOfWorkingDays = numOfWorkingDays;
                    this.maxHoursPerMonth = maxHoursPerMonth;
                }

        public void ComputeEmpWage()
        {
            
            int empHrs= 8, totalEmpHrs =8, totalworkingDays = 0;
            
            while (totalEmpHrs <= this.maxHoursPerMonth && totalworkingDays < this.numOfWorkingDays)
            {
                totalworkingDays++;
                Random random = new Random();
                int empCheck =random.Next(0, 3);
                switch (empCheck)
                {
                    case IS_PART_TIME:
                        empHrs = 4;
                        break;
                    case IS_FULL_TIME:
                        empHrs = 8;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }
                totalEmpHrs += empHrs;
                Console.WriteLine("Day#:" + totalworkingDays + " Emp Hrs: " + empHrs);
            }
            totalEmpWage = totalEmpHrs * this.empRatePerHour;
            Console.WriteLine("Total Emp Wage for company:" + company +"is : " + totalEmpWage);
    }

        public string toString()
        {
            return "Total Emp Wage for company: "+ this.company + "is:" + this.totalEmpWage;
        }

}
    class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilderObject dMart = new EmpWageBuilderObject("DMart", 20, 2, 10);
            EmpWageBuilderObject reliance =new EmpWageBuilderObject("Reliance", 18, 4, 20);
            dMart.ComputeEmpWage();
            Console.WriteLine(dMart.toString());
            reliance.ComputeEmpWage();
            Console.WriteLine(reliance.toString());
            Console.ReadLine();
        }

       
          
        

    }
}

