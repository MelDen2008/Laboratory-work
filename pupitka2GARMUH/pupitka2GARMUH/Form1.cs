using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pupitka2GARMUH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFund_Click(object sender, EventArgs e)
        {
            FundForm fund = new FundForm();
            fund.Show(); // Открывает окно фонда
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            ReadersForm readers = new ReadersForm();
            readers.Show(); // Открывает окно читателей
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
