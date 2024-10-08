using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Wage
{

    public class EmpWageBuilderArray
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        private int numOfCompany = 0;
        private CompanyEmpWage[] companyEmpwageArray;

        public EmpWageBuilderArray() {
            this.companyEmpwageArray = new CompanyEmpWage[5];
        }


        public void addCompanyEmpwage(string company, int empRatePerHour, int numOfworkingDays, int maxHoursPerMonth)
        {
            companyEmpwageArray[this.numOfCompany] = new CompanyEmpWage(company, empRatePerHour, numOfworkingDays, maxHoursPerMonth);
            numOfCompany++;
        }


        public void computeEmpWage()
        {
            for (int i = 0; i < numOfCompany; i++)
            {
                companyEmpwageArray[i].setTotalEmpWage(this.computeEmpWage(this.companyEmpwageArray[i]));
                Console.WriteLine(this.companyEmpwageArray[i].toString());
            }
        }


        public int computeEmpWage(CompanyEmpWage companyEmpWage)
        {

            int empHrs = 8, totalEmpHrs = 8, totalworkingDays = 0;

            while (totalEmpHrs <= companyEmpWage.maxHoursPerMonth && totalworkingDays < companyEmpWage.numOfWorkingDays)
            {
                totalworkingDays++;
                Random random = new Random();
                int empCheck = random.Next(0, 3);
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
            return totalEmpHrs * companyEmpWage.empRatePerHour;

        }
    }






    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHour;
        public int numOfWorkingDays;
        public int maxHoursPerMonth;
        public int totalEmpWage;

        public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
                {
                    this.company = company;
                    this.empRatePerHour=empRatePerHour;
                    this.numOfWorkingDays = numOfWorkingDays;
                    this.maxHoursPerMonth= maxHoursPerMonth;
                }

        public void setTotalEmpWage(int totalEmpWage)
                {
                    this.totalEmpWage=totalEmpWage;
                }


        public string toString()
                {
                    return "Total Emp Wage for company:" + this.company + " is: " + this.totalEmpWage;
                }

}
    class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilderArray empWageBuilder = new EmpWageBuilderArray();
            empWageBuilder.addCompanyEmpwage("DMart", 20, 2, 10);
            empWageBuilder.addCompanyEmpwage("Reliance", 10, 4, 20);
            empWageBuilder.computeEmpWage();
            Console.ReadLine();
        }

       
          
        

    }
}

