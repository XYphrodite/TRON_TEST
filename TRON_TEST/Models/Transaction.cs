using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRON_TEST.Models
{
    public class ContractData
    {
        public int amount { get; set; }
        public string asset_name { get; set; }
        public string owner_address { get; set; }
        public string to_address { get; set; }
        public TokenInfo tokenInfo { get; set; }
    }

    public class TokenInfo
    {
        public string tokenId { get; set; }
        public string tokenAbbr { get; set; }
        public string tokenName { get; set; }
        public int tokenDecimal { get; set; }
        public int tokenCanShow { get; set; }
        public string tokenType { get; set; }
        public string tokenLogo { get; set; }
        public string tokenLevel { get; set; }
        public bool vip { get; set; }
    }

    public class Transaction
    {
        public long block { get; set; }
        public string hash { get; set; }
        public long timestamp { get; set; }
        public string ownerAddress { get; set; }
        public List<string> toAddressList { get; set; }
        public string toAddress { get; set; }
        public int contractType { get; set; }
        public bool confirmed { get; set; }
        public bool revert { get; set; }
        public ContractData contractData { get; set; }
        public string SmartCalls { get; set; }
        public string Events { get; set; }
        public string id { get; set; }
        public string data { get; set; }
        public string fee { get; set; }
        public string contractRet { get; set; }
        public string result { get; set; }
        public string amount { get; set; }
        public bool cheatStatus { get; set; }
        public Cost cost { get; set; }
        public TokenInfo tokenInfo { get; set; }
        public string tokenType { get; set; }
        public bool riskTransaction { get; set; }
    }

    public class Cost
    {
        public int net_fee { get; set; }
        public int energy_penalty_total { get; set; }
        public int energy_usage { get; set; }
        public int fee { get; set; }
        public int energy_fee { get; set; }
        public int energy_usage_total { get; set; }
        public int origin_energy_usage { get; set; }
        public int net_usage { get; set; }
    }

    public class TransactionRoot
    {
        public int total { get; set; }
        public int rangeTotal { get; set; }
        public List<Transaction> data { get; set; }
        public long wholeChainTxCount { get; set; }
        public Dictionary<string, bool> contractMap { get; set; }
        public Dictionary<string, object> contractInfo { get; set; }
        public Dictionary<string, NormalAddressInfo> normalAddressInfo { get; set; }
    }

    public class NormalAddressInfo
    {
        public bool risk { get; set; }
    }
}
