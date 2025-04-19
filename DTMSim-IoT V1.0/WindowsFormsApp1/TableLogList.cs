using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TableLogList
    {

        private string nodeID;
        private string neighbourID;
        private string s1;
        private string s2;
        private string s3;    
        private double trustValue;

        public TableLogList(string nodeID, string neighbourID, string s1, string s2, string s3, double trustValue)
        {
            this.nodeID = nodeID;
            this.neighbourID = neighbourID;

            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;

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

        //S1

        public string S1
        {
            get { return this.s1; }
        }

        //S2

        public string S2
        {
            get { return this.s2; }
        }

        //S3

        public string S3
        {
            get { return this.s3; }
        }

        //TrustValue

        public double TrustValue
        {
            get { return this.trustValue; }
        }             
    }
}
