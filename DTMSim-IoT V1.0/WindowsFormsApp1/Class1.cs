using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    static class SharedContent
    {
        public static List<Node> dynamicNodesList = new List<Node>();
        public static List<Node> staticNodesList = new List<Node>();
        public static List<Service> servicesList = new List<Service>();
        public static int transaction_delay_time = 1200;
        public static int transactions_per_node = 2;
        public static int transaction_response_delay = 700;
        public static Boolean dynamicMode = true;
        public static Boolean staticMode = false;
        public static Boolean dynamicLog = false;
        public static Boolean staticLog = false;
        public static int malicious_percentage = 10;
        public static ArrayList blackList = new ArrayList();
        public static ArrayList networkLogs = new ArrayList();
    }
}
