using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(delayTimeBox.Text) && !string.IsNullOrEmpty(interactionsBox.Text))// && !string.IsNullOrEmpty(percentageBox.Text)
            {
                SharedContent.transaction_delay_time = int.Parse(delayTimeBox.Text); 
                SharedContent.transactions_per_node = int.Parse(interactionsBox.Text);
                //SharedContent.malicious_percentage = int.Parse(percentageBox.Text);

                MessageBox.Show("Preference values Stored.");

                if (Application.MessageLoop)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter preference fields values.");
            }
        }       
    }
}
