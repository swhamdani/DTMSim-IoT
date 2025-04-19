using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class PlotCharts : Form
    {
        public PlotCharts()
        {
            InitializeComponent();
            readDataGridView();
        }

        private void readCSV_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            ToCsV(dataGridView);

            /*if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                MessageBox.Show(fileName);
                try
                {
                    // your code here 
                    string CSVFilePathName = fileName;
                    string[] Lines = File.ReadAllLines(CSVFilePathName);
                    string[] Fields;
                    Fields = Lines[0].Split(new char[] { ',' });
                    int Cols = Fields.GetLength(0);
                    DataTable dt = new DataTable();
                    //1st row must be column names; force lower case to ensure matching later on.
                    for (int i = 0; i < Cols; i++)
                        dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                    DataRow Row;
                    for (int i = 1; i < Lines.GetLength(0); i++)
                    {
                        Fields = Lines[i].Split(new char[] { ',' });
                        Row = dt.NewRow();
                        for (int f = 0; f < Cols; f++)
                            Row[f] = Fields[f];
                        dt.Rows.Add(Row);
                    }
                    dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error is " + ex.ToString());
                    throw;
                }
            }*/
        }

        private void readDataGridView()
        {

            dataGridView.DataSource = SharedContent.networkLogs;
        }

        private void ToCsV(DataGridView dGV)
        {
            if(dGV.Columns.Count > 1)
            {
                string stOutput = "";
                // Export titles:
                string sHeaders = "";

                dGV.AutoGenerateColumns = false;
                dGV.Columns.Remove("ServiceRequested");
                dGV.Columns.Remove("ServiceResponse");
                dGV.Columns.Remove("Success");
                dGV.Columns.Remove("Failed");
                dGV.Columns.Remove("TotalTransactions");
                dGV.Columns.Remove("Reward");
                dGV.Columns.Remove("Punishment");

                Series series = chart1.Series.Add("Total Trust");
                series.ChartType = SeriesChartType.Spline;

                for (int j = 0; j < dGV.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.
                string stLine = "";
                for (int i = 0; i < dGV.RowCount - 1; i++)
                {

                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    {
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                        string value = "" + dGV.Rows[i].Cells[0].Value;
                        series.Points.AddXY(value, dGV.Rows[i].Cells[3].Value);
                        //chart1.Series[i].Points.AddXY(value, dGV.Rows[i].Cells[3].Value);
                        stOutput += stLine + "\r\n";
                    }
                }



                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                Console.WriteLine(stOutput);
            }
            else
            {
                MessageBox.Show("CSV file not found!", "Sorry");
            }
        }
    }
}
