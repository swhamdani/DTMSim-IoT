using System;
using System.Collections.Generic;
using System.Drawing;//for Point Class

namespace WindowsFormsApp1.Model
{
    class Service
    {
        String service_id;
        double service_value;

        public Service(String id, double value)
        {
            Service_id = id;
            Service_value = value;
        }

        public string Service_id { get => service_id; set => service_id = value; }
        public double Service_value { get => service_value; set => service_value = value; }
    }

    //public struct ServiceList
    //{
    //    public const double S1 = 0.02;
    //    public const double S2 = 0.05;
    //    public const double S3 = 0.10;
    //}

    class Node
    {
        int node_id;
        Point node_location;
        TrustTable trustTable;
        double node_trust_value;// = 0;
        List<Service> serviceList;
        List<double> noteList;
        List<TransactionHistory> transactionHistory;
        double rewardScore = 0;
        double penaltyScore = 0;

        double staticReward = 0;
        double staticPunishment = 0;
        double static_NodeTrust = 0;

        Image image;
        double reward = 0;
        double punishment = 0;
        bool isMalicious;
        bool isDraw;
        bool isRequester=false;
        bool isProvider = false;

        public Node(int id, List<Service> services, Point location, TrustTable table, List<TransactionHistory> history, bool isDraw, bool isMalicious, Image image)
        {         
            node_id = id;
            this.isDraw = isDraw;
            this.IsMalicious = isMalicious;
            trustTable = table;
            this.image = image;
            ServiceList = services;
            node_location = location;
            transactionHistory = history;
        }

        public Point Node_location { get => node_location; set => node_location = value; }

        public double Node_trust { get => node_trust_value; set => node_trust_value = value; }

        public double Static_NodeTrust { get => static_NodeTrust; set => static_NodeTrust = value; }

        public List<double> Node_noteList { get => noteList; set => noteList = value; }

        public int Node_id { get => node_id; set => node_id = value; }       

        public TrustTable Node_trustTable { get => trustTable; set => trustTable = value; }

        public List<TransactionHistory> Node_transactionsHistory { get => transactionHistory; set => transactionHistory = value; }

        public double RewardScore { get => rewardScore; set => rewardScore = value; }
        public double PenaltyScore { get => penaltyScore; set => penaltyScore = value; }
        public double Reward { get => reward; set => reward = value; }
        public double Punishment { get => punishment; set => punishment = value; }
        public bool IsDraw { get => isDraw; set => isDraw = value; }
        public Image Image { get => image; set => image = value; }
        public bool IsMalicious { get => isMalicious; set => isMalicious = value; }
        public double StaticReward { get => staticReward; set => staticReward = value; }
        public double StaticPunishment { get => staticPunishment; set => staticPunishment = value; }
        public bool IsRequester { get => isRequester; set => isRequester = value; }
        public bool IsProvider { get => isProvider; set => isProvider = value; }
        internal List<Service> ServiceList { get => serviceList; set => serviceList = value; }
    }

    class ServiceRequestResponse
    {
        int request_id;
        Node service_requester;
        Node service_provider;
        double provider_note_value;
        String response_type;

        public ServiceRequestResponse(int id, Node reqstr, Node providr, String res_type)
        {
            request_id = id;
            service_requester = reqstr;
            service_provider = providr;
           // provider_note_value = note;
            response_type = res_type;
        }

        public int Request_id { get => request_id; set => request_id = value; }
        public double Note_value { get => provider_note_value; set => provider_note_value = value; }
        public String Response_type { get => response_type; set => response_type = value; }
    }

    class TrustTable
    {
        int node_id;
        //Node neighbour;
        //double trust_value;
        List<Node> neighbourList;

        public TrustTable(int id, List<Node> neighbours)//, Node n, double tv
        {
            node_id = id;
            neighbourList = neighbours;
            //neighbour = n;
            //trust_value = tv;
        }

        public int Node_id { get => node_id; set => node_id = value; }

        //public Node Node { get => neighbour; set => neighbour = value; }
        public List<Node> Neighbours_list { get => neighbourList; set => neighbourList = value; }
    }

    class TransactionHistory
    {
       
        int onOff;
        int requester_id;
        int provider_id;
        double service_requested;
        int response_type;// 0 | 1
        int failedRepeatation;
        int success;
        int failure;
        string request_time;
       
        public TransactionHistory(int requester_id, string request_time, int provider_id, double requested_service, int response, int onOff, int failedRep, int success, int failure)
        {
            this.onOff = onOff;
            this.request_time = request_time;
            this.Requester_id = requester_id;
            this.Provider_id = provider_id;
            this.success = success;
            this.failure = failure;
            this.service_requested = requested_service;
            Response_type = response;
            FailedRepeatation = failedRep;
        }

        public int OnOff { get => onOff; set => onOff = value; }

        public int Response_type { get => response_type; set => response_type = value; }
        public int FailedRepeatation { get => failedRepeatation; set => failedRepeatation = value; }
        public double Service_requested { get => service_requested; set => service_requested = value; }
        public int Success { get => success; set => success = value; }
        public int Failure { get => failure; set => failure = value; }
        public int Requester_id { get => requester_id; set => requester_id = value; }
        public int Provider_id { get => provider_id; set => provider_id = value; }
        public string Request_time { get => request_time; set => request_time = value; }
        //internal Node Requester { get => requester; set => requester = value; }
    }

    class DrawLines
    {
        int request_id;
        Point start;
        Point end;
        int request_time;
        //Node neighbour;
        //double trust_value;
        //List<Node> neighbourList;

        public DrawLines(int id, Point requester, Point provider, int time)//, Node n, double tv
        {
            request_id = id;
            Start = requester;
            End = provider;
            Request_time = time;
        }

        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }
        public int Request_time { get => request_time; set => request_time = value; }
    }
}
