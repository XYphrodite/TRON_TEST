using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRON_TEST.Models
{
    public class TokenBalance
    {
        public string tokenId { get; set; }
        public string balance { get; set; }
        public string tokenName { get; set; }
        public string tokenAbbr { get; set; }
        public int tokenDecimal { get; set; }
        public int tokenCanShow { get; set; }
        public string tokenType { get; set; }
        public string tokenLogo { get; set; }
        public bool vip { get; set; }
        public double tokenPriceInTrx { get; set; }
        public double amount { get; set; }
        public int nrOfTokenHolders { get; set; }
        public long transferCount { get; set; }
    }

    public class TransferOwnerPermission
    {
        public List<TransferKey> keys { get; set; }
        public int threshold { get; set; }
        public string permission_name { get; set; }
    }

    public class TransferKey
    {
        public string address { get; set; }
        public int weight { get; set; }
    }

    public class TokenBalanceWrapper
    {
        public List<TokenBalance> trc20token_balances { get; set; }
        public int transactions_out { get; set; }
        public int acquiredDelegateFrozenForBandWidth { get; set; }
        public int rewardNum { get; set; }
        public TransferOwnerPermission ownerPermission { get; set; }
        public List<TokenBalance> tokenBalances { get; set; }
        public int delegateFrozenForEnergy { get; set; }
        public List<TokenBalance> balances { get; set; }
        public List<object> trc721token_balances { get; set; }
        public int balance { get; set; }
        public int voteTotal { get; set; }
        public int totalFrozen { get; set; }
        public List<TokenBalance> tokens { get; set; }
        public Dictionary<string, object> delegated { get; set; }
        public int transactions_in { get; set; }
        public int totalTransactionCount { get; set; }
        public Representative representative { get; set; }
        public int frozenForBandWidth { get; set; }
        public int reward { get; set; }
        public string addressTagLogo { get; set; }
        public List<object> allowExchange { get; set; }
        public string address { get; set; }
        public List<object> frozen_supply { get; set; }
        public Bandwidth bandwidth { get; set; }
        public long date_created { get; set; }
        public int accountType { get; set; }
        public List<object> exchanges { get; set; }
        //public FrozenResource frozenForEnergy { get; set; }
        public int transactions { get; set; }
        public int witness { get; set; }
        public int delegateFrozenForBandWidth { get; set; }
        public string name { get; set; }
        public int frozenForEnergy { get; set; }
        public int acquiredDelegateFrozenForEnergy { get; set; }
        public List<object> activePermissions { get; set; }
    }

    public class Representative
    {
        public int lastWithDrawTime { get; set; }
        public int allowance { get; set; }
        public bool enabled { get; set; }
        public string url { get; set; }
    }

    public class Bandwidth
    {
        public int energyRemaining { get; set; }
        public long totalEnergyLimit { get; set; }
        public long totalEnergyWeight { get; set; }
        public int netUsed { get; set; }
        public int storageLimit { get; set; }
        public double storagePercentage { get; set; }
        public Dictionary<string, BandwidthAsset> assets { get; set; }
        public double netPercentage { get; set; }
        public int storageUsed { get; set; }
        public int storageRemaining { get; set; }
        public int freeNetLimit { get; set; }
        public int energyUsed { get; set; }
        public int freeNetRemaining { get; set; }
        public int netLimit { get; set; }
        public int netRemaining { get; set; }
        public int energyLimit { get; set; }
        public int freeNetUsed { get; set; }
        public long totalNetWeight { get; set; }
        public double freeNetPercentage { get; set; }
        public double energyPercentage { get; set; }
        public long totalNetLimit { get; set; }
    }

    public class BandwidthAsset
    {
        public double netPercentage { get; set; }
        public int netLimit { get; set; }
        public int netRemaining { get; set; }
        public int netUsed { get; set; }
    }
}
