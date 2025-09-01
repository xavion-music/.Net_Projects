using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S25W3IntroToInheritance
{
    public class CommissionEmployee
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private double _grossSales;

		public double GrossSales
		{
			get { return _grossSales; }
			set { _grossSales = value; }
		}

        private double _commissionRate;

        public double CommissionRate
        {
            get { return _commissionRate; }
            set { _commissionRate = value; }
        }

        public CommissionEmployee(int id, string name, double grossSales, double commissionRate)
		{
			Id = id;
            Name = name;
            GrossSales = grossSales;
            CommissionRate = commissionRate;
        }

		public double Earnings()
		{
			return GrossSales * CommissionRate;	
        }

        public override string ToString()
		{
            return $"Id: {Id}, \nName: {Name}, \nGross Sales: {GrossSales:C}, \nCommission Rate: {CommissionRate:P}";	
        }
    }
}
