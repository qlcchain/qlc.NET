using System;
using System.Collections.Generic;
using System.Text;

namespace Qlc.Objects
{
    public class BlockCountByType
    {
        public int Change { get; set; }
        public int ContractRefund { get; set; }
        public int ContractReward { get; set; }
        public int ContractSend { get; set; }
        public int Open { get; set; }
        public int Receive { get; set; }
        public int Send { get; set; }
    }
}
