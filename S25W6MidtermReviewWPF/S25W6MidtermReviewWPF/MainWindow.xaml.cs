﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using S25W6MidtermReview;

namespace S25W6MidtermReviewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee _emp;
        private List<Employee> _employees;   
        public MainWindow()
        {
            InitializeComponent();

            rdoHourly.IsChecked = true;
            _employees = new List<Employee>();  
        }

        private void rdhourly_Checked(object sender, RoutedEventArgs e)
        {
            lblInput2.Content = "Hours Worked:";    
            lblInput3.Content = "Hourly Wage:"; 
        }   

        private void rdoCommission_Checked(object sender, RoutedEventArgs e)
        {
            lblInput2.Content = "Gross Sales:";
            lblInput3.Content = "Commission Rate:";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rdoHourly.IsChecked = true; 
            txtName.Text = txtInput2.Text = txtInput3.Text = "";
            txtGrossEarnings.Text = txtTax.Text = txtNetEarnings.Text = ""; 
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();   
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            
            if (rdoHourly.IsChecked == true)
            {
                int hours = int.Parse(txtInput2.Text);
                double wage = double.Parse(txtInput3.Text); 

                _emp = new HourlyEmployee(name, hours, wage);
            }

            else
            {
                double grossSales = double.Parse(txtInput2.Text);
                double commissionRate = double.Parse(txtInput3.Text) / 100;
                _emp = new CommissionEmployee(name, grossSales, commissionRate);
            }
            
            txtGrossEarnings.Text = _emp.GrossEarnings().ToString("C");
            txtTax.Text = _emp.Tax().ToString("C");
            txtNetEarnings.Text = _emp.NetEarnings().ToString("C");

            _employees.Add(_emp);  // Add the employee to the list
            lstEmployees.Items.Add(name);
        }

        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployees.SelectedItems != null)
            {
                int index = lstEmployees.SelectedIndex;
                _emp = _employees[index];

                txtName.Text = _emp.Name;

                if (_emp is HourlyEmployee hrEmp)
                {
                   // HourlyEmployee hrEmp = (HourlyEmployee)_emp;    
                    txtInput2.Text = hrEmp.hours.ToString();    
                    txtInput3.Text = hrEmp.wage.ToString();
                    rdoHourly.IsChecked = true; // Ensure the radio button is checked for Hourly Employee   
                }

                else if (_emp is CommissionEmployee commEmp)
                {
                    txtInput2.Text = commEmp.GrossSales.ToString(); 
                    txtInput3.Text = (commEmp.CommissionRate * 100).ToString(); // Convert to percentage
                    rdoCommission.IsChecked = true; // Ensure the radio button is checked for Commission Employee
                }

                txtGrossEarnings.Text = _emp.GrossEarnings().ToString("C");
                txtTax.Text = _emp.Tax().ToString("C");
                txtNetEarnings.Text = _emp.NetEarnings().ToString("C"); 
            }
        }
    }
}