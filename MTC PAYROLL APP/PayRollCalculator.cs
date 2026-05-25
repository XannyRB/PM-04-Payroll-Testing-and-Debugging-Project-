using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTC_PAYROLL_APP
{
    public class PayRollCalculator
    {
        //Contstant Rates (NB RULES!)
        private const double HOURLY_RATE = 950.00;
        private const double UIF_RATE = 0.01; //1% UIF
        private const double MEMBERSHIP_RATE = 0.13; //13% Fee
        private const double PAYE_TAX_RATE = 0.25; //25% PAYE Tax
        private const double DEPENDENT_ALLOWANCE = 0.0575; //5.75% per dependent

        //Properties (Answers so Form1 can read them)
        public double GrossPay { get; private set; }
        public double UIFDeduction { get; private set; }
        public double UifDeduction { get; private set; }
        public double PayeTax { get; private set; }
        public double MembershipFee { get; private set; }
        public double TotalDeductions { get; private set; }
        public double NetPay { get; private set; }

        //Math Method(Form1 pass hours and dependents here)
        public void CalculatePayroll(double hoursWorked, int dependents)
        {
            //Math logic formulas

            //Gross Pay
            GrossPay = hoursWorked * HOURLY_RATE;

            //UIF Deduction
            UifDeduction = GrossPay * UIF_RATE;

            //PAYE Tax
            double taxBase = GrossPay - (GrossPay * DEPENDENT_ALLOWANCE * dependents);
            PayeTax = taxBase * PAYE_TAX_RATE;

            //Membership Fee
            MembershipFee = GrossPay * MEMBERSHIP_RATE;

            //Total Deductions
            TotalDeductions = UifDeduction + PayeTax + MembershipFee;

            //Net Pay
            NetPay = GrossPay - TotalDeductions;
        }
    }
}
