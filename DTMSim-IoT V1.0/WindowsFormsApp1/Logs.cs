using ServiceStack.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Logs : Form
    {
        bool export_trust_table = false;
        bool export_network_log = false;
        ArrayList networkLogData = new ArrayList();
        ArrayList networkTableData = new ArrayList();
        public Logs()
        {
            InitializeComponent();
        }

        void dataGridView1_DataBindingComplete()
        {
            //dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Yellow;

            tablesGrid.DefaultCellStyle.BackColor = Color.Black;
            trustTableGridView.DefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            trustTableGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            trustTableGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            trustTableGridView.BackgroundColor = Color.LightGray;

            tablesGrid.DefaultCellStyle.SelectionBackColor = Color.White;
            tablesGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            tablesGrid.BackgroundColor = Color.LightGray;
        }

        private void logs_btn_Click(object sender, EventArgs e)
        {
            tablesGrid.Hide();
            trustTableGridView.Show();

            export_network_log = true;
            export_trust_table = false;

            networkLogData = getNetworkLogs();

            trustTableGridView.DataSource = networkLogData;
            dataGridView1_DataBindingComplete();
            SharedContent.networkLogs = networkLogData;          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Align the image and text on the button.
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.TextAlign = ContentAlignment.MiddleLeft;

            trustTableGridView.Hide();
            tablesGrid.Show();
            export_network_log = false;
            export_trust_table = true;

            networkTableData = getTrustTableLogs();
            dataGridView1_DataBindingComplete();
            tablesGrid.DataSource = networkTableData;
        }

        private ArrayList getNetworkLogs()
        {

            ArrayList loglist = new ArrayList();
            string id_lbl = "";
            string neighbour_lbl = "";
            string request_time_lbl = "";
            string request_lbl = "";
            string response_lbl = "";

            int success_lbl = 0;
            int failed_lbl = 0;
            int totalTransactions_lbl = 0;

            double reward_lbl = 0;
            double punishment_lbl = 0;
            double trust_lbl = 0;

            if (logDynamicRadio.Checked && SharedContent.dynamicLog)
            {
                if (SharedContent.dynamicNodesList.Count > 0)
                {
                    for (int i = 0; i < SharedContent.dynamicNodesList.Count; i++)
                    {

                        TrustTable table = SharedContent.dynamicNodesList[i].Node_trustTable;                        
                        List<Node> nodes = table.Neighbours_list;
                        id_lbl = "Node: " + SharedContent.dynamicNodesList[i].Node_id;// + (i + 1);
                        for (int j = 0; j < nodes.Count(); j++)
                        {

                            Node node = nodes.ElementAt(j);

                            if (node.Node_transactionsHistory.Count > 0)
                            {

                                for (int ss = 0; ss < node.Node_transactionsHistory.Count; ss++)//SharedContent.dynamicNodesList[i].Node_transactionsHistory.Count
                                {
                                    //if (SharedContent.dynamicNodesList[i].Node_id == node.Node_transactionsHistory[ss].Requester_id)---- commented on 12-12-18
                                    if (SharedContent.dynamicNodesList[i].Node_id == node.Node_transactionsHistory[ss].Requester_id && node.Node_id==node.Node_transactionsHistory[ss].Provider_id)//SharedContent.dynamicNodesList[i].Node_transactionsHistory[ss].Requester_id
                                    {
                                        neighbour_lbl = node.Node_transactionsHistory[ss].Provider_id.ToString();
                                        request_lbl = node.Node_transactionsHistory[ss].Service_requested.ToString();//SharedContent.dynamicNodesList[i].Node_transactionsHistory[ss].Service_requested.ToString();
                                        response_lbl = node.Node_transactionsHistory[ss].Response_type.ToString();// SharedContent.dynamicNodesList[i].Node_transactionsHistory[ss].Response_type.ToString();
                                        Console.WriteLine(" Requester ID:" + node.Node_transactionsHistory[ss].Requester_id + " Provider ID: " + node.Node_transactionsHistory[ss].Provider_id + " Response: " + node.Node_transactionsHistory[ss].Response_type);
                                        request_time_lbl = node.Node_transactionsHistory[ss].Request_time.ToString();
                                        if (response_lbl.Equals("1"))
                                        {
                                            reward_lbl = Math.Round(node.Reward, 2); //node.Node_transactionsHistory[ss].Service_requested ;
                                            punishment_lbl = 0;
                                            success_lbl = node.Node_transactionsHistory[ss].Success;//SharedContent.dynamicNodesList[i].Node_transactionsHistory[ss].Success;
                                            failed_lbl = 0;
                                        }
                                        else
                                        {
                                            punishment_lbl = Math.Round(node.Punishment, 2);
                                            reward_lbl = 0;
                                            failed_lbl = node.Node_transactionsHistory[ss].Failure;//SharedContent.dynamicNodesList[i].Node_transactionsHistory[ss].Failure;
                                            success_lbl = 0;
                                        }
                                        trust_lbl = Math.Round(node.Node_trust, 2);
                                        totalTransactions_lbl = ss + 1;//node.Node_transactionsHistory.Count;
                                        //if (ss > 0) if(j>0)
                                            //id_lbl = "";
                                        loglist.Add(new LogList(id_lbl, neighbour_lbl, request_time_lbl, request_lbl, response_lbl, success_lbl, failed_lbl, totalTransactions_lbl, reward_lbl, punishment_lbl, trust_lbl));
                                    }
                                }
                            }
                            Console.WriteLine("\n");
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Trust Table not exist.", "Sorry");
                }
            }

            else if (staticLogRadio.Checked && SharedContent.staticLog)
            {
                if (SharedContent.staticNodesList.Count > 0)
                {
                    for (int i = 0; i < SharedContent.staticNodesList.Count; i++)
                    {

                        TrustTable table = SharedContent.staticNodesList[i].Node_trustTable;
                        List<Node> nodes = table.Neighbours_list;
                        id_lbl = "Node: " + SharedContent.staticNodesList[i].Node_id;// + (i + 1);
                        for (int j = 0; j < nodes.Count(); j++)
                        {

                            Node node = nodes.ElementAt(j);

                            if (node.Node_transactionsHistory.Count > 0)
                            {

                                for (int ss = 0; ss < node.Node_transactionsHistory.Count; ss++)
                                {
                                    if (SharedContent.staticNodesList[i].Node_id == node.Node_transactionsHistory[ss].Requester_id)
                                    {
                                        neighbour_lbl = node.Node_transactionsHistory[ss].Provider_id.ToString();
                                        request_lbl = node.Node_transactionsHistory[ss].Service_requested.ToString();
                                        response_lbl = node.Node_transactionsHistory[ss].Response_type.ToString();
                                        Console.WriteLine(" Requester ID:" + node.Node_transactionsHistory[ss].Requester_id + " Provider ID: " + node.Node_transactionsHistory[ss].Provider_id + " Response: " + node.Node_transactionsHistory[ss].Response_type);

                                        if (response_lbl.Equals("1"))
                                        {
                                            reward_lbl = node.StaticReward;
                                            punishment_lbl = 0;
                                            success_lbl = node.Node_transactionsHistory[ss].Success;
                                            failed_lbl = 0;
                                        }
                                        else
                                        {
                                            punishment_lbl = node.StaticPunishment;
                                            reward_lbl = 0;
                                            failed_lbl = node.Node_transactionsHistory[ss].Failure;
                                            success_lbl = 0;
                                        }
                                        trust_lbl = node.Static_NodeTrust;
                                        totalTransactions_lbl = ss + 1;
                                        if (ss > 0)
                                            id_lbl = "";
                                        loglist.Add(new LogList(id_lbl, neighbour_lbl, request_time_lbl, request_lbl, response_lbl, success_lbl, failed_lbl, totalTransactions_lbl, reward_lbl, punishment_lbl, trust_lbl));

                                    }
                                }
                            }
                            Console.WriteLine("\n");
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Trust Table not exist.", "Sorry");
                }
            }
            else
            {

                MessageBox.Show("Network logs not available.", "Sorry");
            }

            return loglist;
        }

        private ArrayList getTrustTableLogs()
        {

            ArrayList loglist = new ArrayList();
            string id_lbl = "";
            string neighbour_lbl = "";
            string s1_lbl = SharedContent.servicesList[0].Service_value.ToString();
            string s2_lbl = SharedContent.servicesList[1].Service_value.ToString();
            string s3_lbl = SharedContent.servicesList[2].Service_value.ToString();
            double trust_lbl = 0;

            if (logDynamicRadio.Checked && SharedContent.dynamicLog)
            {
                if (SharedContent.dynamicNodesList.Count > 0)
                {
                    for (int i = 0; i < SharedContent.dynamicNodesList.Count; i++)
                    {

                        TrustTable table = SharedContent.dynamicNodesList[i].Node_trustTable;
                        List<Node> nodes = table.Neighbours_list;
                        id_lbl = "Node: " + (i + 1);
                        for (int j = 0; j < nodes.Count(); j++)
                        {

                            Node node = nodes.ElementAt(j);
                            neighbour_lbl = node.Node_id.ToString();
                            trust_lbl = Math.Round(node.Node_trust, 2);

                            //if (j > 0)
                                //id_lbl = "";
                            loglist.Add(new TableLogList(id_lbl, neighbour_lbl, s1_lbl, s2_lbl, s3_lbl, trust_lbl));
                            Console.WriteLine("\n");
                        }
                    }
                }
            }
            else if (staticLogRadio.Checked && SharedContent.staticLog)
            {
                if (SharedContent.staticNodesList.Count > 0)
                {
                    for (int i = 0; i < SharedContent.staticNodesList.Count; i++)
                    {

                        TrustTable table = SharedContent.staticNodesList[i].Node_trustTable;
                        List<Node> nodes = table.Neighbours_list;
                        id_lbl = "Node: " + (i + 1);
                        trust_lbl = 0;
                        for (int j = 0; j < nodes.Count(); j++)
                        {

                            Node node = nodes.ElementAt(j);
                            neighbour_lbl = node.Node_id.ToString();
                            trust_lbl += (node.StaticPunishment + node.StaticReward);

                            if (j > 0)
                                id_lbl = "";
                            loglist.Add(new TableLogList(id_lbl, neighbour_lbl, s1_lbl, s2_lbl, s3_lbl, trust_lbl));
                            Console.WriteLine("\n");
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("Trust Table not exist.", "Sorry");
            }

            return loglist;
        }

        private void createCustomTable()
        {
            // Create a Custom TableStyle  

            DataGridTableStyle tableStyle = new DataGridTableStyle();

            tableStyle.MappingName = "ArrayList";

            tableStyle.HeaderFont = new Font("Verdana", 9, FontStyle.Bold);

            tableStyle.HeaderForeColor = Color.OrangeRed;

            int colwidth = (trustTableGridView.ClientSize.Width - tableStyle.RowHeaderWidth

                  - SystemInformation.VerticalScrollBarWidth) / 6;

            // Create a DataGridColumn, set its header text and other properties 

            DataGridTextBoxColumn cs = new DataGridTextBoxColumn();

            cs.MappingName = "nodeID";

            cs.HeaderText = "Node ID";

            cs.Width = colwidth;

            // Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "neighbourID";

            cs.HeaderText = "Neighbour ID";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "serviceRequested";

            cs.HeaderText = "Service Requested";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "serviceResponse";

            cs.HeaderText = "Service Response";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);


            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "success";

            cs.HeaderText = "Success";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);


            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "failed";

            cs.HeaderText = "Failed";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "totalTransactions";

            cs.HeaderText = "Total Transactions";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            // Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "reward";

            cs.HeaderText = "Reward";

            cs.Width = colwidth + colwidth;

            // Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            // Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "punishment";

            cs.HeaderText = "Punishment";

            cs.Width = colwidth + colwidth;

            // Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            // Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "trustValue";

            cs.HeaderText = "Trust Value";

            cs.Width = colwidth + colwidth;

            //  Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //  Get rid of current table style 

            // trustTableGridView.TableStyles.Clear(); Check Error

            //  Add new table style to the Grid 

            // trustTableGridView.TableStyles.Add(tableStyle);Check Error
        }

        private void createSimpleTrustTable()
        {
            // Create a Custom TableStyle  

            DataGridTableStyle tableStyle = new DataGridTableStyle();

            tableStyle.MappingName = "ArrayList";

            tableStyle.HeaderFont = new Font("Verdana", 9, FontStyle.Bold);

            tableStyle.HeaderForeColor = Color.OrangeRed;

            int colwidth = (tablesGrid.ClientSize.Width - tableStyle.RowHeaderWidth

                  - SystemInformation.VerticalScrollBarWidth) / 6;

            // Create a DataGridColumn, set its header text and other properties 
            DataGridTextBoxColumn cs = new DataGridTextBoxColumn();

            cs.MappingName = "nodeID";

            cs.HeaderText = "Node ID";

            cs.Width = colwidth;

            // Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "neighbourID";

            cs.HeaderText = "Neighbour ID";

            cs.Width = colwidth;

            //Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            // Create a DataGridColumn, set its header text and other properties 

            cs = new DataGridTextBoxColumn();

            cs.MappingName = "trustValue";

            cs.HeaderText = "Trust Value";

            cs.Width = colwidth + colwidth;

            //  Add Column to GridColumnStyles 

            tableStyle.GridColumnStyles.Add(cs);

            //  Get rid of current table style 

            // trustTableGridView.TableStyles.Clear(); Check Error

            //  Add new table style to the Grid 

            // trustTableGridView.TableStyles.Add(tableStyle);Check Error
        }

        private void logDynamicRadio_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void drawChart_Click(object sender, EventArgs e)
        {
            var form = new PlotCharts();
            form.Show();
        }

        //Exporting toCsv File
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void ExportCsvBtn_Click(object sender, EventArgs e)
        {
            String hr = DateTime.Now.Hour.ToString();
            String min = DateTime.Now.Minute.ToString();
            String sec = DateTime.Now.Second.ToString();
            string logTime = hr + "_" + min + "_" + sec;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "NetworkLogs" + logTime + "Export.xls";

            if (export_network_log)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ToCsV(dataGridView1, @"c:\export.xls");
                    ToCsV(trustTableGridView, sfd.FileName); // Here trustTableGridView is grid view name            
                }
            }
            else
            {
                sfd.FileName = "TrustTableLogs" + logTime + "Export.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ToCsV(dataGridView1, @"c:\export.xls");
                    ToCsV(tablesGrid, sfd.FileName); // Here tablesGrid is grid view name
                }
            }
        }
    }
}