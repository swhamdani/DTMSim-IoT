using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using ServiceStack.Text;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        static int x = 0;
        static int y = 0;
        static int id = 1;
        int total_nodes = 0;
        int circleSize = 500;
        int timer_progress = 0;
        int neighbour_distance = 250;//135
        int panel_width = 48; //according to icon size e.g. 48x48
        int panel_height = 48;
        //double serviceWeight = 1 * 0.05;
        //List<Service> SharedContent.servicesList = new List<Service>();
        //List<Node> SharedContent.nodesList = new List<Node>();
        List<Node> neighbourList = new List<Node>();
        //List<TrustTable> trustTable = new List<TrustTable>();
        List<DrawLines> drawLines = new List<DrawLines>();
        List<ServiceRequestResponse> requestList = new List<ServiceRequestResponse>();

        bool broadCastMessage = false;

        String path = "F://MSCS - 22/Fourth Semester/Final Defense Data/DDTMS/Simulation Tool/WindowsFormsApp1/NetworkScreens/";//"F://VisualStudioProjects/WindowsFormsApp1/NetworkScreens/";
        String csvpath = "F://VisualStudioProjects/WindowsFormsApp1/ExcelFiles/";


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Main()
        {
            InitializeComponent();
            label2.Hide();
            progressBar1.Hide();

            menuStrip1.ForeColor = Color.WhiteSmoke;          
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());

            //UpdateTitleTextPosition();
        
            //screenshotBox.Image = Image.FromFile("F://MSCS - 22/Fourth Semester/Final Defense Data/DDTMS/Simulation Tool/WindowsFormsApp1/icons/camera.png");

            SharedContent.servicesList.Clear();
            SharedContent.servicesList.Add(new Service("S1", 0.1));
            SharedContent.servicesList.Add(new Service("S2", 0.05));
            SharedContent.servicesList.Add(new Service("S3", 0.02));

            nodeInfoBox.Visible = true;
            multicastBox.Visible = false;

            gbNodes.Visible = true;
            gbNodes_static.Visible = false;

            //Icons
            /* networkBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\create_network.png"));
             getInfoBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\network_info.png"));
             requestServiceBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\service_request.png"));
             serviceEvaluationBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\service_evaluation.png"));
             computeTrustBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\compute_trust.png"));
             gbNodes.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"images\graphBg.png"));
             gbNodes_static.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"images\graphBg.png"));*/
        }

        //Center align Title bar Text
        private void UpdateTitleTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2); //
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }

        //Menu String Color
        public class MyColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color MenuBorder
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return Color.White;
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return Color.DarkGray;
                }
            }

            public override Color MenuStripGradientBegin
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color MenuStripGradientEnd
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.Navy;
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.Navy;
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.Gray;
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.Gray;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDirectory(path);

            logTitle.Text = "Create Network: " + "Creating Network of IoT Nodes";
            loglbl.Text = "";

            //create network
            createNetwork();
        }

        async void createNetwork()//no need to add delay time in case of creating network.
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
                    this.Invalidate();
                    await Task.Delay(SharedContent.transaction_delay_time);
                    
                }
                else
                {
                    MessageBox.Show("No more nodes to be added.");
                }
            }

            this.Invalidate();
            //MessageBox.Show("Network created.");

            createNetworkBtn.Enabled = true;
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

        async void initialInfo()
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
                    await Task.Delay(SharedContent.transaction_delay_time);
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

            //MessageBox.Show("Initial Info done.");
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
            //button2.Enabled = false;
            button3.Enabled = true;
        }

        async void staticInitialInfo()
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

           // MessageBox.Show("Initial Info done.");
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
                //serviceRequestFailureScenario();
            }
            else
            {
                //staticServiceRequestUpdated();
                staticfailureScenario();
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

            List<Node> unselectedProviders = new List<Node>();
            for (int item = 0; item < SharedContent.dynamicNodesList.Count; item++)
            {
                
                if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    Node requester = SharedContent.dynamicNodesList[item];
                    if (SharedContent.blackList.Contains("dynamic" + requester.Node_id))
                    {
                        loglbl.Text = "Requester Node:ID " + requester.Node_id + " is malicious.";
                        continue;
                    }
                    else
                    {
                        SharedContent.dynamicNodesList[item].IsRequester = true;
                        this.Invalidate();
                    }


                    for (int u = 0; u< SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count; u++)
                    {
                        unselectedProviders.Add(SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[u]);
                    }
                    for (int request = 0; request < SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {

                        Random rnd_provider = new Random();
                        int max = unselectedProviders.Count;// SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                        int provider_index = rnd_provider.Next(0, max);
                        Node provider = unselectedProviders[provider_index];// SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];

                        //if (SharedContent.dynamicNodesList.FindAll(x => x.Node_id == provider.Node_id).Count > 0)
                        //{
                        //    SharedContent.dynamicNodesList.Find(x => x.Node_id == provider.Node_id).IsProvider = true;
                        //}

                        Console.WriteLine("Provider: " + provider.Node_id.ToString());

                        int failedRepeation = 0;
                        int prevResp = 0;
                        int onoff = 0;

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                          
                            int[] response_values = { 0, 1, 1, 1, 0, 1, 1 };
                            Random rnd_response = new Random();
                            int response_max = rnd_response.Next(0, response_values.Count() - 1);
                            int response_value = response_values[response_max];

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);
                                                        
                            if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count > 0)
                            {
                                failedRepeation = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].FailedRepeatation;
                                prevResp = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].Response_type;
                                onoff = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].OnOff;

                                if (response_value == 0)
                                {

                                    if (prevResp == 0)
                                    {
                                        failedRepeation++;
                                    }
                                }

                                if (prevResp == 1 && response_value == 0)
                                {
                                    onoff++;
                                }
                            }

                            String hr = DateTime.Now.Hour.ToString();
                            String min = DateTime.Now.Minute.ToString();
                            String sec = DateTime.Now.Second.ToString();
                            //String millis = DateTime.Now.Millisecond.ToString();
                            string service_request_time = hr + ":" + min + ":" + sec;// + ":" + millis;
                            loglbl.Text = "Request Time: " + service_request_time + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;
                            int request_time = DateTime.Now.Millisecond;
                            //drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            //Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);

                            await Task.Delay(SharedContent.transaction_response_delay);//delay for each request to get response from provider
                            this.Invalidate();
                            if (response_value == 1)
                            {

                                if (SharedContent.blackList.Contains("dynamic"+provider.Node_id)){

                                    loglbl.Text = " Node " + provider.Node_id + " is Blacklisted Node.";
                                }
                                else
                                {

                                    drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                                    Console.WriteLine("Request ID: " + (id++) + "Request Time: " + service_request_time + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);

                                    SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].IsProvider = true;
                                    SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_value, onoff, failedRepeation, 1, 0));//success(1), failure(0)
                                }
                            }
                            else
                            {
                                if (SharedContent.blackList.Contains("dynamic" + provider.Node_id))
                                {
                                    loglbl.Text = " Node " + provider.Node_id + " is Blacklisted Node.";
                                }
                                else
                                {

                                    drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                                    Console.WriteLine("Request ID: " + (id++) + "Request Time: " + service_request_time + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);
                                    SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_value, onoff, failedRepeation, 0, 1));//success(0), failure(1)
                                }
                            }                                                        
                            await Task.Delay(SharedContent.transaction_delay_time);
                            unselectedProviders.Remove(provider);
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

            //MessageBox.Show("Service Request Done.");
            
            saveImage("service_request");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            //button3.Enabled = false;
            button5.Enabled = true;

            this.Invalidate();
            
        }

        async void serviceRequestFailureScenario()//created on 02 Novemeber 2018
        {
            logTitle.Text = "Service Request: " + "Requester node sends service request to Provider node.";
            loglbl.Text = "";
            int id = 1;
            resetProgressBar();

            label2.Show();
            progressBar1.Show();
            progressBar1.Maximum = SharedContent.dynamicNodesList.Count;

            List<Node> unselectedProviders = new List<Node>();

            for (int item = 0; item < SharedContent.dynamicNodesList.Count; item++)
            {

                if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    Node requester = SharedContent.dynamicNodesList[item];
                    for (int u = 0; u < SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count; u++)
                    {
                        unselectedProviders.Add(SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[u]);
                    }
                    for (int request = 0; request < SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {

                        Random rnd_provider = new Random();
                        int max = unselectedProviders.Count;// SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                        int provider_index = rnd_provider.Next(0, max);
                        Node provider = unselectedProviders[provider_index];// SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];                                                                           

                        Console.WriteLine("Provider: " + provider.Node_id.ToString());

                        int failedRepeation = 0;
                        int prevResp = 0;
                        int onoff = 0;

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {

                            int response_value = 0;
                            switch (counter)
                            {
                                case 0:
                                    response_value = 1;
                                    break;
                                case 1:
                                    response_value = 1;
                                    break;
                                case 2:
                                    response_value = 0;
                                    break;
                            }

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);

                            if (SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count > 0)
                            {
                                failedRepeation = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].FailedRepeatation;
                                prevResp = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].Response_type;
                                onoff = SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory[SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Count - 1].OnOff;

                                if (response_value == 0)
                                {

                                    if (prevResp == 0)
                                    {
                                        failedRepeation++;
                                    }
                                }

                                if (prevResp == 1 && response_value == 0)
                                {
                                    onoff++;
                                }
                            }

                            String hr = DateTime.Now.Hour.ToString();
                            String min = DateTime.Now.Minute.ToString();
                            String sec = DateTime.Now.Second.ToString();
                            String millis = DateTime.Now.Millisecond.ToString();
                            string service_request_time = hr + ":" + min + ":" + sec + ":" + millis;
                            loglbl.Text = "Request Time: " + service_request_time + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;// + " Response: " + response_index;

                            int request_time = DateTime.Now.Millisecond;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);
                            this.Invalidate();

                            if (response_value == 1)
                            {
                                SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_value, onoff, failedRepeation, 1, 0));//success(1), failure(0)
                            }
                            else
                            {
                                SharedContent.dynamicNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_value, onoff, failedRepeation, 0, 1));//success(0), failure(1)
                            }

                            await Task.Delay(SharedContent.transaction_delay_time);
                            unselectedProviders.Remove(provider);
                        }

                    }

                    //to draw lines - repaint 
                    /*if (drawLines.Count > 0)
                    {
                        //forcefully redraw form here
                        drawLines.Clear();
                        this.Refresh();
                        this.Invalidate();
                    }*/
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
                          
                            int[] response_values = { 0, 1, 1, 1, 1, 1, 1 };
                            Random rnd_response = new Random();
                            int response_max = rnd_response.Next(0, response_values.Count() - 1);
                            int response_value = response_values[response_max];

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = rnd_service.Next(0, service_max);

                            String hr = DateTime.Now.Hour.ToString();
                            String min = DateTime.Now.Minute.ToString();
                            String sec = DateTime.Now.Second.ToString();
                            String millis = DateTime.Now.Millisecond.ToString();
                            string service_request_time = hr + ":" + min + ":" + sec + ":" + millis;
                            loglbl.Text = "Request Time: " + service_request_time + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;
                            int request_time = DateTime.Now.Millisecond;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_value);
                            this.Invalidate();

                            if (response_value == 1)//successful transaction - send success = 1 for successful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id  ,SharedContent.servicesList[random_service_index].Service_value, response_value, 0, 0, 1, 0));//success-1, failure-0
                            }
                            else//failed transaction - send failed = 1 for unsuccessful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_value, 0, 0, 0, 1));//success-0, failure-1
                            }

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

            //MessageBox.Show("Service Request Done.");
            
            saveImage("service_request");
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            //button3.Enabled = false;
            button5.Enabled = true;

            this.Invalidate();
            
        }

        async void staticfailureScenario()//created on 02 October 2018
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
                Node requester = SharedContent.staticNodesList[item];

                if (SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count > 0)
                {

                    for (int request = 0; request < SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count; request++)
                    {
                        Random rnd_provider = new Random();
                        int max = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list.Count;
                        int provider_index = rnd_provider.Next(0, max);
                        Node provider = SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index];
                        Console.WriteLine("Provider ID: " + provider.Node_id.ToString());

                        for (int counter = 0; counter < SharedContent.transactions_per_node; counter++)
                        {
                            int response_index = 0;

                            switch (counter)
                            {
                                case 0:
                                    response_index = 1;
                                    break;
                                case 1:
                                    response_index = 1;
                                    break;
                                case 2:
                                    response_index = 0;
                                    break;
                            }

                            Random rnd_service = new Random();
                            int service_max = 3;
                            int random_service_index = 1;// rnd_service.Next(0, service_max); - Requesting same service for Failure case

                            String hr = DateTime.Now.Hour.ToString();
                            String min = DateTime.Now.Minute.ToString();
                            String sec = DateTime.Now.Second.ToString();
                            String millis = DateTime.Now.Millisecond.ToString();
                            string service_request_time = hr + ":" + min + ":" + sec + ":" + millis;
                            if (response_index == 0)//failed transaction - send failed = 1 for unsuccessful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_index, 0, 0, 0, 1));
                            }
                            else//successful transaction - send success = 1 for successful transaction
                            {
                                SharedContent.staticNodesList[item].Node_trustTable.Neighbours_list[provider_index].Node_transactionsHistory.Add(new TransactionHistory(requester.Node_id, service_request_time, provider.Node_id, SharedContent.servicesList[random_service_index].Service_value, response_index, 0, 0, 1, 0));
                            }

                            int request_time = DateTime.Now.Millisecond;
                            loglbl.Text = "Request Time: " + DateTime.Now + " Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Service ID: " + SharedContent.servicesList[random_service_index].Service_id + " Provider ID: " + provider.Node_id;
                            drawLines.Add(new DrawLines(id, new Point((requester.Node_location.X + requester.Node_location.X + 40) / 2, (requester.Node_location.Y + requester.Node_location.Y + 40) / 2), new Point((provider.Node_location.X + provider.Node_location.X + 40) / 2, (provider.Node_location.Y + provider.Node_location.Y + 40) / 2), request_time));
                            Console.WriteLine("Request ID: " + (id++) + " Requester ID:" + requester.Node_id + " Provider ID: " + provider.Node_id + " Response: " + response_index);
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
            {

                //button3.Enabled = false;
                button5.Enabled = true;
                saveImage("service_request");
                logTitle.Text = "";
                loglbl.Text = "";
                detail_lbl.Text = "";
                drawLines.Clear();
                this.Invalidate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            logTitle.Text = "Service Evaluation: " + "Evaluating node(s) Reward OR Punishment values based on provided or rejected services.";
            loglbl.Text = "";
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

                if (node.Node_transactionsHistory.Count > 0)
                {
                    int success = 0;
                    int failure = 0;
                    double service = 0;
                    double Ws = 1;
                    for (int trans = 0; trans < node.Node_transactionsHistory.Count; trans++)
                    {

                        int total = (trans + 1);// node.Node_transactionsHistory.Count;                        

                        if (node.Node_transactionsHistory[trans].Response_type == 1)
                        {
                            success += node.Node_transactionsHistory[trans].Success;// node.Node_transactionsHistory.FindAll(x => x.Response_type == 1).Count;
                            double rewardScore = CalculateRewardScore(total, success);
                            node.RewardScore = rewardScore;
                            service = node.Node_transactionsHistory[trans].Service_requested;
                            Ws = 1 * service;
                            node.Reward += node.RewardScore * Ws;// * success;
                            Console.WriteLine("Node ID: "+node.Node_id+" Reward Score:"+ node.RewardScore + " Reward:" + node.Reward);
                        }
                        else
                        {
                            failure += node.Node_transactionsHistory[trans].Failure;// node.Node_transactionsHistory.FindAll(x => x.Response_type == 0).Count;
                            int onoff = node.Node_transactionsHistory[trans].OnOff; //node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].OnOff;
                            int failedRep = node.Node_transactionsHistory[trans].FailedRepeatation;//node.Node_transactionsHistory[node.Node_transactionsHistory.Count - 1].FailedRepeatation;

                            double penaltyScore = CalculatePenaltyScore(total, failure, onoff, failedRep);
                            node.PenaltyScore = penaltyScore;

                            service = node.Node_transactionsHistory[trans].Service_requested;
                            Ws = 1 * service;
                            node.Punishment += node.PenaltyScore * Ws;// * failure;
                            Console.WriteLine("Node ID: " + node.Node_id + " Reward Score:" + node.PenaltyScore + " Punishment:" + node.Punishment);
                        }

                        loglbl.Text = "Node ID: " + node.Node_id + " Reward Score: " + node.RewardScore + " Penalty Score: " + node.PenaltyScore + "\n" + 
                                                                   " Reward: " + node.Reward + " Punishment: " + node.Punishment;
                        //this.Invalidate();
                        //node.Node_trust = node.Reward + node.Punishment;                        
                    }
                }
                await Task.Delay(SharedContent.transaction_delay_time);
                //loglbl.Text = "Node ID: " + node.Node_id + " Reward: " + node.Reward + " Punishment: " + node.Punishment + " Trust: " + node.Node_trust;

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
                //this.Refresh();
            }
           

            //Print Trust Table
            //printTrustTable();

            //MessageBox.Show("Service Evaluation Done.");
            
            logTitle.Text = "";
            loglbl.Text = "";
            detail_lbl.Text = "";

            drawLines.Clear();
            this.Refresh();
            this.Invalidate();

            //button5.Enabled = false;
            button4.Enabled = true;
            
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

                if (node.Node_transactionsHistory.Count > 0)
                {
                    int success = 0;
                    int failure = 0;
                    for (int trans = 0; trans < node.Node_transactionsHistory.Count; trans++)
                    {
                        
                        double service = node.Node_transactionsHistory[trans].Service_requested;

                        if (node.Node_transactionsHistory[trans].Response_type == 1)
                        {
                            success += node.Node_transactionsHistory[trans].Success;
                            node.StaticReward = CalculateStaticReward(success, service);
                            loglbl.Text = "Node ID: " + node.Node_id + " Reward Score: " + node.StaticReward;
                        }
                        else
                        {
                            failure += node.Node_transactionsHistory[trans].Failure;
                            node.StaticPunishment = CalculateStaticPunishment(failure, service);
                            loglbl.Text = "Node ID: " + node.Node_id + " Punishment Score: " + node.StaticPunishment;
                        }
                    }
                }
                //await Task.Delay(SharedContent.transaction_delay_time);

                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
            };
            
            printStaticTrustTable();

            //MessageBox.Show("Service Evaluation Done.");
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
            this.Invalidate();

            //broadCastMessage = true;
            try {

                multicastBox.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            //multicastBox.Visible = true;
            //exportExcel(SharedContent.dynamicNodesList);        
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

                Console.WriteLine("Node ID: " + node.Node_id + " Node Trust: " + node.Node_trust);
                
                for (int trans = 0; trans < node.Node_transactionsHistory.Count; trans++)
                {

                    //node.Node_trust = node.Reward + node.Punishment;
                    node.Node_trust += node.Reward + node.Punishment;

                    if(node.Node_trust > 0)
                    {
                        node.Node_trust = 1;
                    }

                    if (node.Node_trust < 0)
                    {
                        if (!SharedContent.blackList.Contains("dynamic" + node.Node_id))
                        {
                            SharedContent.blackList.Add("dynamic" + node.Node_id);
                            loglbl.Text = "\nMalicious Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Node_trust +" added to BlackList";
                            blackListlbl.Text += "Node ID: " + node.Node_id+"\n";
                        }
                        //Console.WriteLine("Node ID: " + node.Node_id + " Node Trust: " + node.Node_trust);
                        node.IsMalicious = true;
                        //loglbl.Text = "\n\nMalicious Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Node_trust;
                        //node.Image = Image.FromFile(Path.Combine(Application.StartupPath, "circle_red.png"));//devices_malicious

                        if (node.Node_trust < -1)
                        {
                            node.Node_trust = -1;
                        }
                    }

                    String hr = DateTime.Now.Hour.ToString();
                    String min = DateTime.Now.Minute.ToString();
                    String sec = DateTime.Now.Second.ToString();
                    //String millis = DateTime.Now.Millisecond.ToString();
                    string compute_trust_time = hr + ":" + min + ":" + sec;// + ":" + millis;

                    loglbl.Text = "\n" + "Compute Trust Time: " + compute_trust_time + "Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Node_trust;
                    Console.WriteLine("Compute Trust Time: " + compute_trust_time + "Node ID: " + node.Node_id + " Trust Value: " + node.Node_trust);
                }
                //await Task.Delay(SharedContent.transaction_delay_time);
                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value += 1;
                }
                
            }


            //drawNodes();
            //MessageBox.Show("Trust Computation Done.");

            saveImage("trust_computation");
            //logTitle.Text = "";
            //loglbl.Text = "";
            //detail_lbl.Text = "";

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

                    node.Static_NodeTrust = (node.StaticReward + node.StaticPunishment);
                    if (node.Static_NodeTrust < 0)
                    {
                        if (!SharedContent.blackList.Contains("static" + node.Node_id))
                        {
                            SharedContent.blackList.Add("static" + node.Node_id);
                        }

                        Console.WriteLine("Node ID: " + node.Node_id + " Node Trust: " + node.Static_NodeTrust);
                        node.IsMalicious = true;
                        loglbl.Text = "\nMalicious Node: " + "Node ID: " + node.Node_id + " Trust Value: " + node.Static_NodeTrust;
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
            //MessageBox.Show("Trust Computation Done.");
                 
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




        private void exportExcel(List<Node> dynamicNodesList)
        {
            String sec = DateTime.Now.Second.ToString();

            String csv_location = csvpath + "dynamicNodesList"+ "_" + sec+".csv";

            string csvFile =  CsvSerializer.SerializeToCsv(dynamicNodesList);
            WriteCSV(csvFile, @csv_location);
        }

        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
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

        bool isDragger = false;
        int clickX = 0, clickY = 0;

        private void Lbl_MouseDown(object sender, MouseEventArgs args)
        {
            clickX = args.X;
            clickY = args.Y;
            isDragger = true;
            //gbNodes.Controls.Remove((Label)sender);
        }

        private void Lbl_MouseUp(object sender, MouseEventArgs args)
        {
            Label lbl = (Label)sender;
            Node node = SharedContent.dynamicNodesList.Find(x => x.Node_id == Convert.ToInt32(lbl.Text));

            if (node != null)
            {
                SharedContent.dynamicNodesList.Find(x => x.Node_id == Convert.ToInt32(lbl.Text)).Node_location = lbl.Location;
            }
            isDragger = false;

            /*for (int i = 0; i < gbNodes.Controls.Count; i++)
            {
                gbNodes.Controls.RemoveAt(i);
            }*/
            this.Refresh();
            this.Invalidate();
        }

        private void Lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragger)
            {
                Label lbl = (Label)sender;
                lbl.Top += e.Y - clickY;
                lbl.Left += e.X - clickX;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!isDragger)
            {
                Graphics dynamicGraphicsObj;
                dynamicGraphicsObj = gbNodes.CreateGraphics();

                Graphics staticGraphicsObj;
                staticGraphicsObj = gbNodes_static.CreateGraphics();

                Pen nodePen = new Pen(Color.Red, 5);
                nodePen.DashStyle = DashStyle.Solid;
                nodePen.Width = 2;

                if (SharedContent.dynamicMode)
                {
                    for (int border = 0; border < SharedContent.dynamicNodesList.Count; border++)
                    {
                        Rectangle myRectangle = new Rectangle(SharedContent.dynamicNodesList[border].Node_location.X, SharedContent.dynamicNodesList[border].Node_location.Y, 30, 30);
                        //dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);

                        Label lbl = new Label();
                        lbl.Text = SharedContent.dynamicNodesList[border].Node_id.ToString();
                        lbl.Font = new Font("times", 9, FontStyle.Bold);
                        lbl.Size = new Size(20, 12);
                        lbl.BackColor = Color.Transparent;
                        //lbl.MouseDown += new MouseEventHandler(this.Lbl_MouseDown);
                        //lbl.MouseMove += new MouseEventHandler(this.Lbl_MouseMove);
                        //lbl.MouseUp += new MouseEventHandler(this.Lbl_MouseUp);

                        if (SharedContent.dynamicNodesList[border].IsMalicious)
                        {
                            nodePen.Color = Color.Red;
                            dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);
                        }
                        else
                        {
                            nodePen.Color = Color.Green;
                            if (SharedContent.dynamicNodesList[border].IsRequester)
                            {
                                lbl.ForeColor = Color.White;
                                lbl.BackColor = Color.Green;
                                nodePen.Color = Color.Yellow;
                                //SolidBrush myBrush = new SolidBrush(Color.Green);
                                //dynamicGraphicsObj.FillEllipse(myBrush, myRectangle);
                                dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);
                                SharedContent.dynamicNodesList[border].IsRequester = false;
                            }
                            else
                            {
                                nodePen.Color = Color.Green;
                                dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);
                            }

                            if (SharedContent.dynamicNodesList[border].IsProvider)
                            {
                                lbl.ForeColor = Color.White;
                                lbl.BackColor = Color.Blue;
                                nodePen.Color = Color.Blue;
                                //SolidBrush myBrush = new SolidBrush(Color.Blue);
                                //dynamicGraphicsObj.FillEllipse(myBrush, myRectangle);
                                dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);
                                SharedContent.dynamicNodesList[border].IsProvider = false;
                            }
                            else
                            {
                                nodePen.Color = Color.Green;
                                dynamicGraphicsObj.DrawEllipse(nodePen, myRectangle);
                            }
                        }

                        lbl.Location = new Point(SharedContent.dynamicNodesList[border].Node_location.X + 7, SharedContent.dynamicNodesList[border].Node_location.Y + 8);
                        lbl.Tag = SharedContent.dynamicNodesList[border].Node_id;
                        lbl.Click += new EventHandler(LB_Click);
                        //gbNodes.Controls.Add(lbl);
                        try          //added on 23 Dec, 2018
                        {

                            gbNodes.Controls.Add(lbl);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("" + ex.StackTrace.ToString());
                        }
                    }
                }
                else
                {
                    for (int border = 0; border < SharedContent.staticNodesList.Count; border++)
                    {

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
                        //gbNodes_static.Controls.Add(static_lbl);
                        try           //added on 23 Dec, 2018
                        {

                            gbNodes_static.Controls.Add(static_lbl);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("" + ex.StackTrace.ToString());
                        }
                    }
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
                            if (SharedContent.dynamicMode)
                            {
                                dynamicGraphicsObj.DrawLine(arrowPen, drawLines[line].Start.X, drawLines[line].Start.Y, drawLines[line].End.X, drawLines[line].End.Y);
                            }
                            else
                            {
                                staticGraphicsObj.DrawLine(arrowPen, drawLines[line].Start.X, drawLines[line].Start.Y, drawLines[line].End.X, drawLines[line].End.Y);
                            }
                        }
                    }
                }

                if (broadCastMessage)
                {
                    broadCastMaliciousNotification(dynamicGraphicsObj);
                    broadCastMessage = false;
                    this.Refresh();
                }
            }
        }

        async void broadCastMaliciousNotification(Graphics dynamicGraphicsObj)
        {

            for (int i = 0; i < SharedContent.dynamicNodesList.Count; i++)
            {

                if (!SharedContent.dynamicNodesList[i].IsMalicious)
                {

                    TrustTable table = SharedContent.dynamicNodesList[i].Node_trustTable;
                    List<Node> neighbours = table.Neighbours_list;
                
                    for (int j = 0; j < neighbours.Count(); j++)
                    {

                        Node node = neighbours.ElementAt(j);
                        Pen arrowPen = new Pen(Color.Green, 2);

                        AdjustableArrowCap arrow = new AdjustableArrowCap(5, 5);
                        arrowPen.CustomEndCap = arrow; //add 

                        if (!node.IsMalicious)//Multicast message
                        {
                            int mid_X = ((SharedContent.dynamicNodesList[i].Node_location.X + 10) + (node.Node_location.X + 10)) / 2;
                            int mid_Y = ((SharedContent.dynamicNodesList[i].Node_location.Y + 10) + (node.Node_location.Y + 10))/ 2;
                            dynamicGraphicsObj.DrawLine(arrowPen, SharedContent.dynamicNodesList[i].Node_location.X + 20, SharedContent.dynamicNodesList[i].Node_location.Y + 20, node.Node_location.X + 20, node.Node_location.Y + 20);

                            var picture = new PictureBox
                            {
                                Name = "messageBox",
                                Size = new Size(25, 25),
                                Location = new Point(mid_X, mid_Y),
                                Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\msg_icon.png")),
                            };

                            picture.SizeMode = PictureBoxSizeMode.StretchImage;
                            gbNodes.Controls.Add(picture);

                            await Task.Delay(200);
                            gbNodes.Controls.Remove(picture);
                        }

                        //if (!node.IsMalicious)//Broadcast message
                        //{
                           /* int mid_X = ((SharedContent.dynamicNodesList[i].Node_location.X + 10) + (node.Node_location.X + 10)) / 2;
                            int mid_Y = ((SharedContent.dynamicNodesList[i].Node_location.Y + 10) + (node.Node_location.Y + 10)) / 2;
                            dynamicGraphicsObj.DrawLine(arrowPen, SharedContent.dynamicNodesList[i].Node_location.X + 20, SharedContent.dynamicNodesList[i].Node_location.Y + 20, node.Node_location.X + 20, node.Node_location.Y + 20);

                            var picture = new PictureBox
                            {
                                Name = "messageBox",
                                Size = new Size(25, 25),
                                Location = new Point(mid_X, mid_Y),
                                Image = Image.FromFile(Path.Combine(Application.StartupPath, @"images\msg_icon.png")),
                            };

                            picture.SizeMode = PictureBoxSizeMode.StretchImage;
                            gbNodes.Controls.Add(picture);

                            await Task.Delay(100);*/
                        //}
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
            nodeInfoBox.Visible = true;

            IDlbl.Text = SharedContent.dynamicNodesList[Convert.ToInt32(pb.Tag) - 1].Node_id.ToString();
            serviceslbl.Text = SharedContent.servicesList[0].Service_value+", "+ SharedContent.servicesList[1].Service_value+", "+ SharedContent.servicesList[2].Service_value;
            neighbourlbl.Text = SharedContent.dynamicNodesList[Convert.ToInt32(pb.Tag) - 1].Node_trustTable.Neighbours_list.Count.ToString();
            trustlbl.Text = Math.Round(SharedContent.dynamicNodesList[Convert.ToInt32(pb.Tag) - 1].Node_trust, 2).ToString();

            this.Refresh();
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
            nodeInfoBox.Visible = true;
            this.Refresh();
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
                String sec = DateTime.Now.Second.ToString();

                String image_location = path + name + "_" + min + "_" + sec + ".png";
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
                //tabControl1.SelectedTab = tabPage1;
                gbNodes.Visible = true;
                gbNodes_static.Visible = false;
            }

        }

        private void staticButton_CheckedChanged(object sender, EventArgs e)
        {
            if (staticButton.Checked == true)
            {
                SharedContent.staticMode = true;
                SharedContent.dynamicMode = false;
                //tabControl1.SelectedTab = tabPage2;
                gbNodes_static.Visible = true;
                gbNodes.Visible = false;
                this.Invalidate();
                
            }

        }

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabControl1.SelectedIndex == 0)
        //    {
        //        dynamicButton.Checked = true;
        //    }
        //    else
        //    {
        //        staticButton.Checked = true;
        //    }
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void screenshotBox_Click(object sender, EventArgs e)
        {
            saveImage("screenshot");
        }
        
        private void multicastBox_Click(object sender, EventArgs e)
        {
            broadCastMessage = true;
            this.Invalidate();
        }
    }
}