using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class LogList
    {

        private string nodeID;
        private string neighbourID;

        private string requestTime;
        private string serviceRequested;
        private string serviceResponse;

        private int success;
        private int failed;
        private int totalTransactions;

        private double reward;
        private double punishment;
        private double trustValue;

        public LogList(string nodeID, string neighbourID, string requestTime, string serviceRequested, string serviceResponse, int success, int failed, int totalTransactions, double reward, double punishment, double trustValue)
        {
            this.nodeID = nodeID;
            this.neighbourID = neighbourID;

            this.requestTime = requestTime;
            this.serviceRequested = serviceRequested;
            this.serviceResponse = serviceResponse;

            this.success = success;
            this.failed = failed;
            this.totalTransactions = totalTransactions;

            this.reward = reward;
            this.punishment = punishment;
            this.trustValue = trustValue;
        }

        //NodeID

        public string NodeID
        {
            get { return this.nodeID; }
        }

        //NeighbourID

        public string NeighbourID
        {
            get { return this.neighbourID; }
        }

        //RequestTime

        public string RequestTime
        {
            get { return this.requestTime; }
        }

        //ServiceRequested

        public string ServiceRequested
        {
            get { return this.serviceRequested; }
        }

        //ServiceResponse

        public string ServiceResponse
        {
            get { return this.serviceResponse; }
        }

        //Success

        public int Success
        {
            get { return this.success; }
        }

        //Failed

        public int Failed
        {
            get { return this.failed; }
        }

        //TotalTransactions

        public int TotalTransactions
        {
            get { return this.totalTransactions; }
        }

        //Reward

        public double Reward
        {
            get { return this.reward; }
        }
        
        //Punishment
        
        public double Punishment
        {
            get { return this.punishment; }
        }

        //TrustValue

        public double TrustValue
        {
            get { return this.trustValue; }
        }      
    }
}
