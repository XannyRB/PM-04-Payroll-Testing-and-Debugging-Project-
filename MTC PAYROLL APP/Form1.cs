using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTC_PAYROLL_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Calculate Button Click Event
        private void btnClaculate(object sneder, EventArgs e)
        {
            //Validation: Contractor Name
            if (string.IsNullOrWhiteSpace(txtContractorName.Text))
            {
                MessageBox.Show("Please enter the contractor's name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContractorName.Focus();
                return; //Stop Execution
            }
            //Validation: Hours Worked (Must be positive)
            double hoursWorked;
            if(!double.TryParse(txtHoursWorked.Text, out hoursWorked) || hoursWorked < 0)
            {
                MessageBox.Show("Please enter a valid positve number for hours worked.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoursWorked.Focus();
                return;
            }
            //Validation: Dependents (Whole number, 0 or higher)
            int dependents;
            if (!int.TryParse(txtDependents.Text, out dependents) || dependents < 0)
            {
                MessageBox.Show("Please enter a valid number (0 or more) for dependents.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDependents.Focus();
                return;
            }

            //Connect to Brain

            //Instance of math class
            PayRollCalculator calculator = new PayRollCalculator();

            //Pass validated inputs into math method
            calculator.CalculatePayroll(hoursWorked, dependents);

            //Display Results
            lblGrossPay.Text = calculator.GrossPay.ToString("C");
            lblUIF.Text = calculator.UifDeduction.ToString("C");
            lblPAYE.Text = calculator.PayeTax.ToString("C");
            lblMembership.Text = calculator.MembershipFee.ToString("C");
            lblTotalDeductions.Text = calculator.TotalDeductions.ToString("C");
            lblNetPay.Text = calculator.NetPay.ToString("N");
        }

        // Reset Button
        private void btnReset_Click(object sender, EventArgs e)
        {
            //Clear Input Boxes
            txtContractorName.Text = "";
            txtHoursWorked.Text = "";
            txtDependents.Text = "";

            //Reset Placeholder Labels
            lblGrossPay.Text = "R0.00";
            lblUIF.Text = "R0.00";
            lblPAYE.Text = "R0.00";
            lblMembership.Text = "R0.00";
            lblTotalDeductions.Text = "R0.00";
            lblNetPay.Text = "R0.00";

            //Puts Focus back on first input
            txtContractorName.Focus();
        }

        // Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
