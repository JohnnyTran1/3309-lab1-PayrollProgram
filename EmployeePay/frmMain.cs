using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeePay
{
    public partial class frmTitleBar : Form
    {
        public frmTitleBar()
        {
            InitializeComponent();
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoursWorked.Clear();
            txtHourlyRate.Clear();
            lblDisplay.Text = "";
            
        }

        private void btnCalculatePay_Click(object sender, EventArgs e)
        {
            double StateIncomeTaxDeduction = 0.035;
            double FederalIncomeTaxDeduction = 0.15;
            double SocialSecurity = 0.062;
            double Medicare = 0.029;
            double NetPay;

            double Hours, Rate;

            // Try parsing txtHoursWorked.Text
            if (!double.TryParse(txtHoursWorked.Text, out Hours) || Hours < 0)
            {
                lblDisplay.Text = "Please enter valid numbers for hours worked and hourly rate.";
                lblDisplay.Visible = true;
                return; 
            }

            // Try parsing txtHourlyRate.Text
            if (!double.TryParse(txtHourlyRate.Text, out Rate))
            {
                lblDisplay.Text = "Please enter valid numbers for hourly rate and hours worked.";
                lblDisplay.Visible = true;
                return; 
            }

            double GrossPay = Hours * Rate;
            GrossPay = Math.Round(GrossPay, 2);

            //TaxDeduction
            StateIncomeTaxDeduction *= GrossPay;
            StateIncomeTaxDeduction =  Math.Round(StateIncomeTaxDeduction, 2);
            FederalIncomeTaxDeduction *= GrossPay;
            FederalIncomeTaxDeduction = Math.Round(FederalIncomeTaxDeduction, 2);


            // FICA deductions
            SocialSecurity *= GrossPay;
            SocialSecurity = Math.Round(SocialSecurity, 2);
            Medicare *= GrossPay;
            Medicare = Math.Round(Medicare, 2);

            NetPay = Math.Round(GrossPay - StateIncomeTaxDeduction - FederalIncomeTaxDeduction
                    - SocialSecurity - Medicare,2);



            lblDisplay.Text = "The gross pay is " + GrossPay.ToString() +
                              ". \nThe State Income Tax deduction is " + StateIncomeTaxDeduction.ToString() +
                              ". \nThe Federal Income tax deduction is " + FederalIncomeTaxDeduction.ToString() +
                              ". \nThe Social Security is " + SocialSecurity.ToString() +
                              ". \nThe Medicare is " + Medicare.ToString() + 
                              ". \nThe net pay is " + NetPay.ToString();

            lblDisplay.Visible = true;

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
