using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        static int x = 0;
        static int y = 0;
        static int id = 1;
        int total_nodes = 0;
        int circleSize = 300;
        int timer_progress = 0;
        int neighbour_distance = 150;//135
        int panel_width = 48; //according to icon size e.g. 48x48
        int panel_height = 48;
        //double serviceWeight = 1 * 0.05;
        //List<Service> SharedContent.servicesList = new List<Service>();
        //List<Node> SharedContent.nodesList = new List<Node>();
        List<Node> neighbourList = new List<Node>();
        //List<TrustTable> trustTable = new List<TrustTable>();
        List<DrawLines> drawLines = new List<DrawLines>();
        List<ServiceRequestResponse> requestList = new List<ServiceRequestResponse>();
        String path = "F://VisualStudioProjects/WindowsFormsApp1/NetworkScreens/";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Main()
        {
            InitializeComponent();
            label2.Hide();
            progressBar1.Hide();

            SharedContent.servicesList.Clear();
            SharedContent.servicesList.Add(new Service("S1", 0.1));
            SharedContent.servicesList.Add(new Service("S2", 0.02));
            SharedContent.servicesList.Add(new Service("S3", 0.05));
            //Icons
            networkBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\create_network.png"));
            getInfoBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\network_info.png"));
            requestServiceBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\service_request.png"));
            serviceEvaluationBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\service_evaluation.png"));
            computeTrustBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\compute_trust.png"));
            gbNodes.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"images\graphBg.png"));
            gbNodes_static.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"images\graphBg.png"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDirectory(path);

            logTitle.Text = "Create Network: " + "Creating Network of IoT Nodes";
            loglbl.Text = "";

            //create network
            createNetwork();
        }

        void createNetwork()//no need to add delay time in case of creating network.
        {
            Random rnd = new Random();

            for (int new_node = 0; new_node < total_nodes; new_node++)
            {
                x = rnd.Next(15, 1050); //starting from 15 to avoid overlapping / crossing boundaries (left, right, top, bottom)
                y = rnd.Next(15, 440);

                if (total_nodes == 0)
                {
                    MessageBox.Show("Please enter total nodes.");
                }
                else if (id <= total_nodes)
                {
                    Node currentNode = new Node(id, SharedContent.servicesList, new Point(x, y), new TrustTable(id, new List<Node>()), new List<TransactionHistory>(), false, false, Image.FromFile(Path.Combine(Application.StartupPath, "circle_black.png")));//lBox.Location
                    Console.WriteLine("going to compare node " + id);
                    bool drawNewNodes = true;
                    int attempts = 1;

                    while (drawNewNodes)
                    {
                        if (attempts >= 5)
                        {
                            break;
                        }
                        if (!isExist(x, y))
                        {
                            currentNode.Node_location = new Point(x, y);
                            drawNewNodes = false;
                        }
                        else
                        {
                            x = rnd.Next(15, 1050); //starting from 15 to avoid overlapping / crossing boundaries (left, right, top, bottom)
                            y = rnd.Next(15, 445);
                        }
                        attempts++;
                    }
                    SharedContent.dynamicNodesList.Add(currentNode);
                    SharedContent.staticNodesList.Add(currentNode);

                    loglbl.Text = "Node ID: " + id + " created.";
                    id++;
                }
                else
                {
                    MessageBox.Show("No more nodes to be added.");
                }
            }

            this.Invalidate();
            MessageBox.Show("Network created.");

            createNetworkBtn.Enabled = false;
            button2.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            total_nodes = Convert.ToInt32(nodeInput.Value);

            int val = Convert.ToInt32(((UpDownBase)nodeInput).Text);

            if (total_nodes > 0 && val > 0)
            {
                createNetworkBtn.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            saveImage("network");//screenshot of network
            Console.WriteLine("\nCreating Trust Table of Node(s)");

            if (SharedContent.dynamicMode)
            {
                initialInfo();
                SharedContent.dynamicLog = true;
            }
            else
            {
                staticInitialInfo();
                SharedContent.staticLog = true;
            }

        }

        void initialInfo()
        {
            logTitle.Text = "Get Initial Info: " + "Creating Trust Table of Node(s)";
            loglbl.Text = "";

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.dynamicNodesList.Count;

            for (int i = 0; i < SharedContent.dynamicNodesList.Count; i++)
            {

                Node node = SharedContent.dynamicNodesList.ElementAt(i);
                neighbourList = new List<Node>();
                Console.WriteLine("\nNeighbour List of Node: " + node.Node_id);

                for (int n = 0; n < SharedContent.dynamicNodesList.Count(); n++)
                {
                    if (i != n)
                    {
                        Node neighbour = SharedContent.dynamicNodesList.ElementAt(n);
                        Point node_location = node.Node_location;
                        double distance = GetDistance(node_location.X, node_location.Y, neighbour.Node_location.X, neighbour.Node_location.Y);

                        if (distance != 0)
                        {

                            if (distance <= neighbour_distance)
                            {
                                neighbourList.Add(neighbour);
                                Console.WriteLine("Neighbour Node: " + neighbour.Node_id + " Distance: " + distance);
                                loglbl.Text = "Node: " + node.Node_id + " sending packet(s) to Neighbour Node: " + neighbour.Node_id;

                                int request_time = DateTime.Now.Millisecond;
                                drawLines.Add(new DrawLines(id, new Point((node_location.X + node_location.X + 40) / 2, (node_location.Y + node_location.Y + 40) / 2), new Point((neighbour.Node_location.X + neighbour.Node_location.X + 40) / 2, (neighbour.Node_location.Y + neighbour.Node_location.Y + 40) / 2), request_time));// new Point(point.X, point.Y);                                
                            }
                            this.Invalidate();
                        }
                    }
                    //await Task.Delay(SharedContent.transaction_delay_time);
                }

                TrustTable table = new TrustTable(i, neighbourList);
                SharedContent.dynamicNodesList.Find(x => x.Node_id == (i + 1)).Node_trustTable = table;
                //trustTable.Add(table);
                Console.WriteLine("\n");

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            printTrustTable();

            MessageBox.Show("Initial Info done.");
            saveImage("initial_info");

            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            if (drawLines.Count > 0)
            {
                drawLines.Clear();
                this.Refresh();
                this.Invalidate();
            }
            button2.Enabled = false;
            button3.Enabled = true;
        }

        void staticInitialInfo()
        {
            logTitle.Text = "Get Initial Info: " + "Creating Trust Table of Node(s)";
            loglbl.Text = "";

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            for (int i = 0; i < SharedContent.staticNodesList.Count; i++)
            {

                Node node = SharedContent.staticNodesList.ElementAt(i);
                neighbourList = new List<Node>();
                Console.WriteLine("\nNeighbour List of Node: " + node.Node_id);

                for (int n = 0; n < SharedContent.staticNodesList.Count(); n++)
                {
                    if (i != n)
                    {
                        Node neighbour = SharedContent.staticNodesList.ElementAt(n);
                        Point node_location = node.Node_location;
                        double distance = GetDistance(node_location.X, node_location.Y, neighbour.Node_location.X, neighbour.Node_location.Y);

                        if (distance != 0)
                        {

                            if (distance <= neighbour_distance)
                            {
                                neighbourList.Add(neighbour);
                                Console.WriteLine("Neighbour Node: " + neighbour.Node_id + " Distance: " + distance);
                                loglbl.Text = "Node: " + node.Node_id + " sending packet(s) to Neighbour Node: " + neighbour.Node_id;

                                int request_time = DateTime.Now.Millisecond;
                                drawLines.Add(new DrawLines(id, new Point((node_location.X + node_location.X + 40) / 2, (node_location.Y + node_location.Y + 40) / 2), new Point((neighbour.Node_location.X + neighbour.Node_location.X + 40) / 2, (neighbour.Node_location.Y + neighbour.Node_location.Y + 40) / 2), request_time));// new Point(point.X, point.Y);
                                this.Invalidate();
                            }
                        }
                    }
                    //await Task.Delay(SharedContent.transaction_delay_time);
                }

                TrustTable table = new TrustTable(i, neighbourList);
                detail_lbl.Text = " NeighbourList of " + neighbourList.Count() + " node(s) added to the Trust Table of Node ID: " + (i + 1);
                SharedContent.staticNodesList.Find(x => x.Node_id == (i + 1)).Node_trustTable = table;
                //trustTable.Add(table);
                Console.WriteLine("\n");

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            printStaticTrustTable();

            MessageBox.Show("Initial Info done.");
            saveImage("initial_info");

            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            if (drawLines.Count > 0)
            {
                drawLines.Clear();
                this.Refresh();
                this.Invalidate();
            }
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //serviceRequest();
            //serviceRequestUpdated();
            //staticServiceRequestUpdated();
            //failureScenario();

            if (SharedContent.dynamicMode)
            {
                serviceRequestUpdated();
            }
            else
            {
                staticServiceRequestUpdated();
            }
        }

        async void serviceRequestUpdated()//created on 25 September 2018
        {
            logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
            loglbl.Text = "";
            int id = 1;
            resetProgressBar();

            //do
            //{


            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.dynamicNodesList.Count;

            for (int item = 0; item < SharedContent.dynamicNodesList.Count; item++)
            {
                
                if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    Node requester = SharedContent.dynamicNodesList[item];
                    for (int request = 0; request < SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {
                        Random rnd_provider = new Random();
                        int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                        int provider_index = rnd_provider.Next(0, max);
                        Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];
                        Console.WriteLine("Provider ID: " + provider.Node_id.ToString());

                        int failedRepeation = 0;
                        int prevResp = 0;
                        int onoff = 0;

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                            //int max = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count;
                            //int provider_index = rnd_provider.Next(0, max);

                            //Node requester = SharedContent.dynamicNodesList[item];
                            //Node provider = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index];

                            int[] response_values = { 0, 1, 1, 1, 1, 1, 1 };
                            Random rnd_response = new Random();
                            int response_max = rnd_response.Next(0, response_values.Count() - 1);
                            int response_index = response_values[response_max];

                            Random rnd_service = new Random();
                            int service_max = 3;//2
                            int random_service_index = rnd_service.Next(0, service_max);

                            int request_time = DateTime.Now.Millisecond;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_index);

                            loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;
                            
                            if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count > 0)
                            {
                                failedRepeation = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].FailedRepeatation;
                                prevResp = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].Response_type;
                                onoff = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].OnOff;

                                if (response_index == 0)
                                {

                                    if (prevResp == 0)
                                    {
                                        failedRepeation++;
                                    }
                                }

                                if (prevResp == 1 && response_index == 0)
                                {
                                    onoff++;
                                }
                            }
                            SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(onoff, requester, SharedContent.servicesList[random_service_index].Service_value, response_index, failedRepeation, 0, 0));
                            this.Invalidate();
                            // await Task.Delay(SharedContent.transaction_delay_time);
                        }

                    }

                    //to draw lines - repaint 
                    if (drawLines.Count > 0)
                    {
                        //forcefully redraw form here
                        drawLines.Clear();
                        this.Refresh();
                        this.Invalidate();
                    }
                }
                
                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }



            //to draw lines - repaint 
            //if (drawLines.Count > 0)
            //{
            //    //forcefully redraw form here
            //    this.Invalidate();
            //}

            //await Task.Delay(SharedContent.transaction_delay_time);
            Console.WriteLine("Request-delay: " + DateTime.Now);
            //} while (id < (total_nodes * 2));//stop_request----on stop, this loop will end

            MessageBox.Show("Service Request Done.");
            
            saveImage("service_request");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            //button3.Enabled = false;
            button5.Enabled = true;

            this.Invalidate();
            
        }

        async void staticServiceRequestUpdated()//created on 25 September 2018
        {
            logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
            loglbl.Text = "";
            int id = 1;
            resetProgressBar();

            //do
            //{

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            for (int item = 0; item < SharedContent.staticNodesList.Count; item++)
            {

                if (SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {
                    Node requester = SharedContent.staticNodesList[item];

                    for (int request = 0; request < SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {

                        Random rnd_provider = new Random();
                        int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                        int provider_index = rnd_provider.Next(0, max);
                        Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];
                        Console.WriteLine("Provider ID: " + provider.Node_id.ToString());

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                            //int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                            //int provider_index = rnd_provider.Next(0, max);

                            //Node requester = SharedContent.staticNodesList[item];
                            //Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];

                            int[] response_values = { 0, 1, 1, 1, 1, 1, 1 };
                            Random rnd_response = new Random();
                            int response_max = rnd_response.Next(0, response_values.Count() - 1);
                            int response_value = response_values[response_max];

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);

                            if (response_value == 0)//failed transaction - send failed = 1 for unsuccessful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(0, requester, SharedContent.servicesList[random_service_index].Service_value, response_value, 0, 0, 1));//success-0, failure-1
                            }
                            else//successful transaction - send success = 1 for successful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(0, requester, SharedContent.servicesList[random_service_index].Service_value, response_value, 0, 1, 0));//success-1, failure-0
                            }

                            int request_time = DateTime.Now.Millisecond;
                            loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);
                            this.Invalidate();
                            await Task.Delay(SharedContent.transaction_delay_time);                            
                        }                        
                    }
                    //to draw lines - repaint 
                    if (drawLines.Count > 0)
                    {
                        //forcefully redraw form here
                        drawLines.Clear();
                        this.Refresh();
                        this.Invalidate();
                    }
                }

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            Console.WriteLine("Request-delay: " + DateTime.Now);

            MessageBox.Show("Service Request Done.");
            
            saveImage("service_request");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            //button3.Enabled = false;
            button5.Enabled = true;

            this.Invalidate();
            
        }

        async void failureScenario()//created on 02 October 2018
        {
            logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
            loglbl.Text = "";
            int id = 1;
            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            for (int item = 0; item < SharedContent.staticNodesList.Count; item++)
            {

                if (SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    for (int request = 0; request < SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {
                        Random rnd_provider = new Random();

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                            Console.WriteLine("count: " + counter + " node: " + SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[request].Node_id);
                            int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                            int provider_index = rnd_provider.Next(0, max);

                            Node requester = SharedContent.staticNodesList[item];
                            Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];

                            int[] response_values = { 1, 1, 0 };
                            int response_index = response_values[counter];

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);

                            if (response_index == 0)//failed transaction - send failed = 1 for unsuccessful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(0, requester, SharedContent.servicesList[random_service_index].Service_value, response_index, 0, 0, 1));
                            }
                            else//successful transaction - send success = 1 for successful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(0, requester, SharedContent.servicesList[random_service_index].Service_value, response_index, 0, 1, 0));
                            }

                            int request_time = DateTime.Now.Millisecond;
                            loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_index);

                            await Task.Delay(SharedContent.transaction_delay_time);

                            //to draw lines - repaint 
                            if (drawLines.Count > 0)
                            {
                                //forcefully redraw form here
                                this.Invalidate();
                            }

                            //loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;

                        }
                    }
                }

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            Console.WriteLine("Request-delay: " + DateTime.Now);

            MessageBox.Show("Service Request Done.");
            {

                button3.Enabled = false;
                button5.Enabled = true;
                saveImage("service_request");
                logTitle.Text = "";
                loglbl.Text = "";
                detail_lbl.Text = "";
                drawLines.Clear();
                this.Invalidate();
            }
        }


        async void staticServiceRequest()//created on 29 September 2018
        {
            logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
            loglbl.Text = "";
            int id = 1;
            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            for (int item = 0; item < SharedContent.staticNodesList.Count; item++)
            {
                if (SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    for (int request = 0; request < SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {
                        Random rnd_provider = new Random();

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                            int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                            int provider_index = rnd_provider.Next(0, max);

                            Node requester = SharedContent.staticNodesList[item];
                            Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];

                            int[] response_values = { 0, 1, 1, 1, 1, 1, 1 };
                            Random rnd_response = new Random();
                            int response_max = rnd_response.Next(0, response_values.Count() - 1);
                            int response_index = response_values[response_max];

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);

                            SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(0, requester, SharedContent.servicesList[random_service_index].Service_value, response_index, 0, 0, 0));

                            int request_time = DateTime.Now.Millisecond;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_index);

                            loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;                                                   
                            await Task.Delay(SharedContent.transaction_delay_time);
                            //to draw lines - repaint 
                            if (drawLines.Count > 0)
                            {
                                //forcefully redraw form here
                                this.Invalidate();
                            }
                        }
                    }
                }

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            Console.WriteLine("Request-delay: " + DateTime.Now);

            MessageBox.Show("Service Request Done.");
            {

                button3.Enabled = false;
                button5.Enabled = true;
                saveImage("service_request");
                logTitle.Text = "";
                loglbl.Text = "";
                detail_lbl.Text = "";
                this.Invalidate();
            }
        }

        /* async void serviceRequest()
         {

             logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
             loglbl.Text = "";
             int id = 1;
             resetProgressBar();

             do
             {

                 label2.Show();
                 progressBar1.Show();

                 Random rnd_requester = new Random();
                 int index = rnd_requester.Next(0, SharedContent.dynamicNodesList.Count - 1);

                 Random rnd_provider = new Random();
                 if (SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list.Count > 0)
                 {
                     int max = SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list.Count - 1;
                     int provider_index = rnd_provider.Next(0, max);

                     Node requester = SharedContent.dynamicNodesList[index];
                     Node provider = SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index];

                     int[] response_values = { 0, 1, 1, 1, 1 };
                     Random rnd_response = new Random();
                     int response_max = rnd_response.Next(0, response_values.Count() - 1);//to select between 0 and 1. therefore, upper bound 2.
                     int response_index = response_values[response_max];

                     int failedRepeation = 0;
                     int prevResp = 0;
                     int onoff = 0;

                     Random rnd_service = new Random();
                     int service_max = 2;
                     int random_service_index = rnd_service.Next(0, service_max);

                     if (SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count > 0)
                     {
                         failedRepeation = SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].FailedRepeatation;
                         prevResp = SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].Response_type;
                         onoff = SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].OnOff;
                     }

                     if (response_index == 0)
                     {

                         if (prevResp == 0)
                         {
                             failedRepeation++;
                         }
                     }

                     if (prevResp == 1 && response_index == 0)
                     {
                         onoff++;
                     }

                     SharedContent.dynamicNodesList[index].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(onoff, requester, SharedContent.servicesList[random_service_index].Service_value, response_index, failedRepeation,0,0));//,0,0 added on 27 Sep for success and failed transactions

                     int request_time = DateTime.Now.Millisecond;//new Point((node_location.X + node_location.X + 40) / 2, (node_location.Y + node_location.Y + 40) / 2), new Point((neighbour.Node_location.X + neighbour.Node_location.X + 40) / 2
                     drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));// new Point(point.X, point.Y);
                     Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_index);//+ " Note Value: " + provider.Node_trust

                     loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;
                 }

                 //to draw lines - repaint 
                 if (drawLines.Count > 0)
                 {
                     //forcefully redraw form here
                     //this.Refresh();
                     this.Invalidate();
                 }

                 await Task.Delay(SharedContent.transaction_delay_time);
                 Console.WriteLine("Request-delay: " + DateTime.Now); 
             } while (id < (total_nodes * 2));//stop_request----on stop, this loop will end

             MessageBox.Show("Service Request Done.");
             {

                 saveImage("service_request");
                 logTitle.Text = "";
                 loglbl.Text = "";
                 detail_lbl.Text = "";
                 drawLines.Clear();
                 this.Refresh();
             }
         }*/

        private void button5_Click(object sender, EventArgs e)
        {
            logTitle.Text = "Service Evaluation: " + "Evaluating node(s) Reward OR Punishment values based on provided or rejected services.";
            loglbl.Text = "";
            //serviceEvaluation();
            //staticServiceEvaluation();
            if (SharedContent.dynamicMode)
            {
                serviceEvaluation();
            }
            else
            {
                staticServiceEvaluation();
            }
        }

        async void serviceEvaluation()
        {
            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.dynamicNodesList.Count;

            Console.WriteLine("Service Evaluation");

            foreach (Node node in SharedContent.dynamicNodesList)
            {

                int total = node.Node_transactionsHistory.Count;
                int success = node.Node_transactionsHistory.FindAll(x => x.Response_type == 1).Count;
                int failure = node.Node_transactionsHistory.FindAll(x => x.Response_type == 0).Count;


                for (int service = 0; service < node.Node_transactionsHistory.Count; service++)
                {

                    if (node.Node_transactionsHistory[service].Response_type == 1)
                    {
                        SharedContent.dynamicNodesList[node.Node_id - 1].Node_transactionsHistory[service].Success += 1;
                    }
                    else
                    {
                        SharedContent.dynamicNodesList[node.Node_id - 1].Node_transactionsHistory[service].Failure += 1;
                    }
                }

                int onoff = 0;
                int failedRep = 0;

                if (node.Node_transactionsHistory.Count > 0)
                {
                    onoff = node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].OnOff;
                    failedRep = node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].FailedRepeatation;
                }

                double rewardScore = CalculateRewardScore(total, success);
                double penaltyScore = CalculatePenaltyScore(total, failure, onoff, failedRep);

                node.RewardScore = rewardScore;
                node.PenaltyScore = penaltyScore;

                loglbl.Text = "Node ID: " + node.Node_id + " Reward Score: " + node.RewardScore + " Penalty Score: " + node.PenaltyScore;

                await Task.Delay(SharedContent.transaction_delay_time);
                progressBar1.Value += 1;
            }

            //Print Trust Table
            printTrustTable();

            MessageBox.Show("Service Evaluation Done.");
            {
                logTitle.Text = "";
                loglbl.Text = "";
                detail_lbl.Text = "";

                drawLines.Clear();
                this.Refresh();

                //button5.Enabled = false;
                button4.Enabled = true;
            }
        }

        async void staticServiceEvaluation()
        {
            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            Console.WriteLine("Service Evaluation");

            foreach (Node node in SharedContent.staticNodesList)
            {

                int total = node.Node_transactionsHistory.Count;
                int success = node.Node_transactionsHistory.FindAll(x => x.Success == 1).Count;//x.Response_type == 1
                int failure = node.Node_transactionsHistory.FindAll(x => x.Failure == 1).Count;//x.Response_type == 0

                for (int service = 0; service < node.Node_transactionsHistory.Count; service++)
                {

                    if (node.Node_transactionsHistory[service].Response_type == 1)
                    {
                        SharedContent.staticNodesList[node.Node_id - 1].Node_transactionsHistory[service].Success = 1;//+= 1;
                        node.StaticReward = CalculateStaticReward(SharedContent.staticNodesList[node.Node_id - 1].Node_transactionsHistory[service].Success, node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].Service_requested);
                        loglbl.Text = "Node ID: " + node.Node_id + " Reward Score: " + node.StaticReward;
                    }
                    else
                    {
                        SharedContent.staticNodesList[node.Node_id - 1].Node_transactionsHistory[service].Failure = 1;//+= 1;
                        node.StaticPunishment = CalculateStaticPunishment(SharedContent.staticNodesList[node.Node_id - 1].Node_transactionsHistory[service].Failure, node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].Service_requested);
                        loglbl.Text = "Node ID: " + node.Node_id + " Punishment Score: " + node.StaticPunishment;
                    }
                }

                await Task.Delay(SharedContent.transaction_delay_time);

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            }

            printStaticTrustTable();

            MessageBox.Show("Service Evaluation Done.");
            {
                logTitle.Text = "";
                loglbl.Text = "";
                detail_lbl.Text = "";

                drawLines.Clear();
                this.Invalidate();

                //button5.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logTitle.Text = "Compute Trust: " + "Computing Trust value of Nodes based on Reward AND / OR Punishment Nj.";
            loglbl.Text = "";
            //computeTrust();
            //computeStaticTrust();
            if (SharedContent.dynamicMode)
            {
                computeTrust();
            }
            else
            {
                computeStaticTrust();
            }
        }

        async void computeTrust()
        {

            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.dynamicNodesList.Count;

            Console.WriteLine("Computing Node(s) Trust");
            foreach (Node node in SharedContent.dynamicNodesList)
            {

                for (int trans = 0; trans < node.Node_transactionsHistory.Count; trans++)
                {
                    double service = node.Node_transactionsHistory[trans].Service_requested;
                    double Ws = 1 * service;

                    node.Reward = node.RewardScore * Ws;
                    node.Punishment = node.PenaltyScore * Ws;
                    node.Node_trust = node.Reward + node.Punishment;

                    if (node.Node_trust < 0)
                    {
                        if (!SharedContent.blackList.Contains("dynamic" + node.Node_id))
                        {
                            SharedContent.blackList.Add("dynamic" + node.Node_id);
                        }
                        Console.WriteLine("Node ID: " + node.Node_id + " Node Trust: " + node.Node_trust);
                        node.IsMalicious = true;
                        loglbl.Text = "\n\nMalicious Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Node_trust;
                        //node.Image = Image.FromFile(Path.Combine(Application.StartupPath, "circle_red.png"));//devices_malicious
                    }
                }

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
                await Task.Delay(SharedContent.transaction_delay_time);
            }


            //drawNodes();
            MessageBox.Show("Trust Computation Done.");

            saveImage("trust_computation");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            //button4.Enabled = false;

        }

        async void computeStaticTrust()
        {

            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.staticNodesList.Count;

            Console.WriteLine("Computing Node(s) Trust");
            foreach (Node node in SharedContent.staticNodesList)
            {

                for (int trans = 0; trans < node.Node_transactionsHistory.Count; trans++)
                {
                    node.Static_NodeTrust += (node.StaticReward + node.StaticPunishment);

                    if (node.Static_NodeTrust < 0)
                    {
                        if (!SharedContent.blackList.Contains("static" + node.Node_id))
                        {
                            SharedContent.blackList.Add("static" + node.Node_id);
                        }

                        Console.WriteLine("Node ID: " + node.Node_id + " Node Trust: " + node.Static_NodeTrust);
                        node.IsMalicious = true;
                        loglbl.Text = "\n\nMalicious Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Static_NodeTrust;
                    }
                    else
                    {
                        node.IsMalicious = false;
                        loglbl.Text = "Node ID: " + node.Node_id + " Trust Value: " + node.Static_NodeTrust;
                    }
                }

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
                await Task.Delay(SharedContent.transaction_delay_time);
            }


            //drawNodes();
            MessageBox.Show("Trust Computation Done.");
                 
            saveImage("trust_computation");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";
            this.Invalidate();
            //button4.Enabled = false;
            
        }

        public void printTrustTable()
        {

            for (int i = 0; i < SharedContent.dynamicNodesList.Count; i++)
            {

                TrustTable table = SharedContent.dynamicNodesList[i].Node_trustTable;
                List<Node> nodes = table.Neighbours_list;
                Console.WriteLine("Trust Table of Node: " + (i + 1));
                loglbl.Text = "Trust Table of Node: " + (i + 1);

                if (nodes.Count() > 0)
                {
                    for (int j = 0; j < nodes.Count(); j++)
                    {

                        Node node = nodes.ElementAt(j);
                        int id = node.Node_id;
                        double trust_value = node.Node_trust;
                        detail_lbl.Text = "Neighbour Node ID: " + id + " ServiceList: S1: " + node.ServiceList[0].Service_value.ToString() + ", S2: " + node.ServiceList[1].Service_value.ToString() + ", S3: " + node.ServiceList[2].Service_value.ToString() + " Node Trust: " + trust_value;
                        Console.WriteLine("Neighbour Node ID: " + id + " ServiceList: S1: " + node.ServiceList[0].Service_value.ToString() + ", S2: " + node.ServiceList[1].Service_value.ToString() + ", S3: " + node.ServiceList[2].Service_value.ToString() + " Node Trust: " + trust_value);

                        if (node.Node_transactionsHistory.Count > 0)
                        {
                            for (int ss = 0; ss < node.Node_transactionsHistory.Count; ss++)//SharedContent.nodesList[i].Node_transactionsHistory.Count
                            {
                                detail_lbl.Text = "Neighbour Node ID: " + id + " Requested Service: " + node.Node_transactionsHistory[ss].Service_requested.ToString() + " Service Response: " + node.Node_transactionsHistory[ss].Response_type.ToString();// +                                        
                            }
                        }
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    detail_lbl.Text = "Node ID: " + (i + 1).ToString() + " has no neighbour.";
                    Console.WriteLine("\n" + "Node ID: " + (i + 1).ToString() + " has no neighbour.");
                }
            }
        }

        public void printStaticTrustTable()
        {

            for (int i = 0; i < SharedContent.staticNodesList.Count; i++)
            {

                TrustTable table = SharedContent.staticNodesList[i].Node_trustTable;
                List<Node> nodes = table.Neighbours_list;
                Console.WriteLine("Trust Table of Node: " + (i + 1));
                loglbl.Text = "Trust Table of Node: " + (i + 1);

                if (nodes.Count() > 0)
                {
                    for (int j = 0; j < nodes.Count(); j++)
                    {

                        Node node = nodes.ElementAt(j);
                        int id = node.Node_id;
                        double trust_value = node.Node_trust;
                        detail_lbl.Text = "Neighbour Node ID: " + id + " ServiceList: S1: " + node.ServiceList[0].Service_value.ToString() + ", S2: " + node.ServiceList[1].Service_value.ToString() + ", S3: " + node.ServiceList[2].Service_value.ToString() + " Node Trust: " + trust_value;
                        Console.WriteLine("Neighbour Node ID: " + id + " ServiceList: S1: " + node.ServiceList[0].Service_value.ToString() + ", S2: " + node.ServiceList[1].Service_value.ToString() + ", S3: " + node.ServiceList[2].Service_value.ToString() + " Node Trust: " + trust_value);

                        if (node.Node_transactionsHistory.Count > 0)
                        {
                            for (int ss = 0; ss < node.Node_transactionsHistory.Count; ss++)//SharedContent.nodesList[i].Node_transactionsHistory.Count
                            {
                                detail_lbl.Text = "Neighbour Node ID: " + id + " Requested Service: " + node.Node_transactionsHistory[ss].Service_requested.ToString() + " Service Response: " + node.Node_transactionsHistory[ss].Response_type.ToString();// +                                        
                            }
                        }
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    detail_lbl.Text = "Node ID: " + (i + 1).ToString() + " has no neighbour.";
                    Console.WriteLine("\n" + "Node ID: " + (i + 1).ToString() + " has no neighbour.");
                }
            }
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        private double CalculateRewardScore(int total, int success)
        {
            double rewardScore = 0;
            if (total != 0)
            {
                double result = (Convert.ToDouble(success) / Convert.ToDouble(total));
                rewardScore = 1 * result;
            }
            else
            {
                return 0;
            }

            loglbl.Text += "\n" + "Reward Score: " + rewardScore.ToString();
            Console.WriteLine("Reward Score: " + rewardScore.ToString());
            return rewardScore;
        }

        private double CalculateStaticReward(int success, double service)
        {
            double Ws = 1 * Convert.ToDouble(service);
            double result = Convert.ToDouble(success) * Convert.ToDouble(Ws);
            loglbl.Text += "\n" + "StaticReward: " + result.ToString();
            return result;
        }

        private double CalculateStaticPunishment(int failed, double service)
        {
            double Ws = -2 * Convert.ToDouble(service);
            double result = Convert.ToDouble(failed) * Convert.ToDouble(Ws);
            loglbl.Text += "\n" + "StaticPunishment: " + result.ToString();
            return result;
        }

        private double CalculatePenaltyScore(int total, int failed, int onoff, int failedrep)
        {
            double penaltyScore = 0;

            if (total != 0)
            {
                double result = 0;
                if (failedrep != 0)
                {
                    result = (2 * (((Convert.ToDouble(failed) / (Convert.ToDouble(total))) + Convert.ToDouble(onoff)) * Convert.ToDouble(failedrep)));
                    if (result == 0)
                    {
                        penaltyScore = 0;
                    }
                    else
                    {
                        penaltyScore = -Math.Log10(result);
                    }

                }
                else
                {
                    result = 2 * (((Convert.ToDouble(failed) / (Convert.ToDouble(total))) + Convert.ToDouble(onoff)));
                    if (result == 0)
                    {
                        penaltyScore = 0;
                    }
                    else
                    {
                        penaltyScore = -Math.Log10(result);
                    }
                }
            }
            loglbl.Text += "\n" + "Penalty Score: " + penaltyScore.ToString();
            Console.WriteLine("Penalty Score: " + penaltyScore.ToString());
            return penaltyScore;
        }

        private void resetProgressBar()
        {
            //RESETTING
            timer_progress = 0;
            progressBar1.Value = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dynamicGraphicsObj;
            dynamicGraphicsObj = gbNodes.CreateGraphics();

            Graphics staticGraphicsObj;
            staticGraphicsObj = gbNodes_static.CreateGraphics();

            Pen nodePen = new Pen(Color.Red, 5);
            nodePen.DashStyle = DashStyle.Solid;
            nodePen.Width = 2;

            if (SharedContent.staticNodesList.Count > 0)
            {

                for (int border = 0; border < SharedContent.staticNodesList.Count; border++)
                {

                    if (SharedContent.dynamicNodesList[border].IsMalicious)
                    {
                        nodePen.Color = Color.Red;
                    }
                    if (SharedContent.staticNodesList[border].IsMalicious)
                    {
                        nodePen.Color = Color.Red;
                    }
                    else
                    {
                        nodePen.Color = Color.Green;
                    }

                    Rectangle staticRectangle = new Rectangle(SharedContent.staticNodesList[border].Node_location.X, SharedContent.staticNodesList[border].Node_location.Y, 30, 30);
                    staticGraphicsObj.DrawEllipse(nodePen, staticRectangle);

                    //Add labels to Node(s)
                    Label static_lbl = new Label();
                    static_lbl.Text = SharedContent.staticNodesList[border].Node_id.ToString();
                    static_lbl.Font = new Font("times", 9, FontStyle.Bold);
                    static_lbl.Size = new Size(20, 12);

                    static_lbl.ForeColor = Color.Green;
                    static_lbl.Location = new Point(SharedContent.staticNodesList[border].Node_location.X + 7, SharedContent.staticNodesList[border].Node_location.Y + 8);
                    static_lbl.Tag = SharedContent.staticNodesList[border].Node_id;
                    static_lbl.Click += new EventHandler(Static_LB_Click);

                    gbNodes_static.Controls.Add(static_lbl);

                    Rectangle myRectangle = new Rectangle(SharedContent.dynamicNodesList[border].Node_location.X, SharedContent.dynamicNodesList[border].Node_location.Y, 30, 30);
                    dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);

                    Label lbl = new Label();
                    lbl.Text = SharedContent.dynamicNodesList[border].Node_id.ToString();
                    lbl.Font = new Font("times", 9, FontStyle.Bold);
                    lbl.Size = new Size(20, 12);

                    lbl.ForeColor = Color.Green;
                    lbl.Location = new Point(SharedContent.dynamicNodesList[border].Node_location.X + 7, SharedContent.dynamicNodesList[border].Node_location.Y + 8);
                    lbl.Tag = SharedContent.dynamicNodesList[border].Node_id;
                    lbl.Click += new EventHandler(LB_Click);
                    gbNodes.Controls.Add(lbl);
                }

                Pen myPen = new Pen(Color.DarkGreen, 5);
                myPen.DashStyle = DashStyle.Dash;
                myPen.Width = 2;

                for (int border = 0; border < SharedContent.dynamicNodesList.Count; border++)
                {
                    if (SharedContent.dynamicNodesList[border].IsDraw)
                    {
                        Rectangle myRectangle = new Rectangle(SharedContent.dynamicNodesList[border].Node_location.X - neighbour_distance + 20, SharedContent.dynamicNodesList[border].Node_location.Y - neighbour_distance + 20, circleSize, circleSize);
                        dynamicGraphicsObj.DrawEllipse(myPen, myRectangle);

                        Rectangle staticRectangle = new Rectangle(SharedContent.staticNodesList[border].Node_location.X - neighbour_distance + 20, SharedContent.staticNodesList[border].Node_location.Y - neighbour_distance + 20, circleSize, circleSize);
                        staticGraphicsObj.DrawEllipse(myPen, staticRectangle);
                    }
                }
            }

            if (drawLines.Count > 0)
            {
                Random rnd_color = new Random();

                for (int line = 0; line < drawLines.Count; line++)
                {

                    Pen arrowPen = null;
                    if (line % 2 == 0)
                    {
                        arrowPen = new Pen(Color.Blue, 2);
                    }
                    else
                    {
                        arrowPen = new Pen(Color.Red, 2);
                    }

                    AdjustableArrowCap arrow = new AdjustableArrowCap(5, 5);
                    arrowPen.CustomEndCap = arrow;

                    if (drawLines[line].Request_time <= 1000)
                    {
                        dynamicGraphicsObj.DrawLine(arrowPen, drawLines[line].Start.X, drawLines[line].Start.Y, drawLines[line].End.X, drawLines[line].End.Y);
                        staticGraphicsObj.DrawLine(arrowPen, drawLines[line].Start.X, drawLines[line].Start.Y, drawLines[line].End.X, drawLines[line].End.Y);
                    }
                }
            }
        }

        protected void LB_Click(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            if (SharedContent.dynamicNodesList.FindAll(x => x.IsDraw == true).Count > 0)
            {
                SharedContent.dynamicNodesList.Find(x => x.IsDraw == true).IsDraw = false;
            }

            SharedContent.dynamicNodesList[Convert.ToInt32(pb.Tag) - 1].IsDraw = true;
            this.Invalidate();
        }


        protected void Static_LB_Click(object sender, EventArgs e)
        {
            Label pb = (Label)sender;
            if (SharedContent.staticNodesList.FindAll(x => x.IsDraw == true).Count > 0)
            {
                SharedContent.staticNodesList.Find(x => x.IsDraw == true).IsDraw = false;
            }

            SharedContent.staticNodesList[Convert.ToInt32(pb.Tag) - 1].IsDraw = true;
            this.Invalidate();
        }

        private bool isExist(float x, float y)//To check Existing node location
        {
            for (int border = 0; border < SharedContent.dynamicNodesList.Count; border++)
            {
                //Console.WriteLine("Node:" + SharedContent.nodesList[border].Node_id + " Node.X:" + SharedContent.nodesList[border].Node_location.X + " Node.Y:" + SharedContent.nodesList[border].Node_location.Y + "X: " + x + " Y: " + y);
                //Console.WriteLine("C1: " + (x >= SharedContent.nodesList[border].Node_location.X) + " && " + " C2: " + (x <= SharedContent.nodesList[border].Node_location.X + 40) + " && " + " C3: " + (y >= SharedContent.nodesList[border].Node_location.Y) + " && " + " C4: " + (y <= SharedContent.nodesList[border].Node_location.Y + 40) + "");
                //Console.WriteLine((x + " >= " + SharedContent.nodesList[border].Node_location.X).ToString() + " && " + x + " <= " + (SharedContent.nodesList[border].Node_location.X + 40).ToString() + " || " + y + " >= " + (SharedContent.nodesList[border].Node_location.Y).ToString() + " && " + y + " <= " + (SharedContent.nodesList[border].Node_location.Y + 40).ToString());
                // if ((x >= SharedContent.nodesList[border].Node_location.X || x <= SharedContent.nodesList[border].Node_location.X + 40) || (y >= SharedContent.nodesList[border].Node_location.Y || y <= SharedContent.nodesList[border].Node_location.Y + 40))//40 is circle size
                Rectangle existingNode = new Rectangle(SharedContent.dynamicNodesList[border].Node_location.X, SharedContent.dynamicNodesList[border].Node_location.Y, circleSize, circleSize);
                Rectangle newNode = new Rectangle((int)x, (int)y, circleSize, circleSize);
                if (existingNode.IntersectsWith(newNode))
                {
                    Console.WriteLine("Result True");
                    return true;
                }
            }

            Console.WriteLine("Result False");
            return false;
        }

        private void saveImage(String name)
        {
            try
            {
                Bitmap network_screenshot = new Bitmap(this.Width, this.Height);
                Graphics graphics = Graphics.FromImage(network_screenshot);
                graphics.CopyFromScreen(this.Location, new Point(0, 0), this.Size);

                String hr = DateTime.Now.Hour.ToString();
                String min = DateTime.Now.Minute.ToString();

                String image_location = path + name + "_" + hr + "_" + min + ".png";
                network_screenshot.Save(image_location, ImageFormat.Png);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.ToString());
            }
        }

        public void CreateDirectory(string path)
        {
            try
            {
                //If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                // Fail
            }
        }

        private void preToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var form2 = new Preferences();
            form2.Show();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = new Logs();
            form3.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var help = new Help();
            help.Show();
        }

        private void dynamicButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dynamicButton.Checked == true)
            {
                SharedContent.dynamicMode = true;
                SharedContent.staticMode = false;
                tabControl1.SelectedTab = tabPage1;
            }

        }

        private void staticButton_CheckedChanged(object sender, EventArgs e)
        {
            if (staticButton.Checked == true)
            {
                SharedContent.staticMode = true;
                SharedContent.dynamicMode = false;
                tabControl1.SelectedTab = tabPage2;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                dynamicButton.Checked = true;
            }
            else
            {
                staticButton.Checked = true;
            }
        }
    }
}