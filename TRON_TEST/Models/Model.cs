using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TRON_TEST.Models
{
    [DataContract]
    public class Parameter
    {
        [DataMember(Name = "value")]
        public Value Value { get; set; }

        [DataMember(Name = "type_url")]
        public string TypeUrl { get; set; }
    }

    [DataContract]
    public class Value
    {
        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "owner_address")]
        public string OwnerAddress { get; set; }

        [DataMember(Name = "to_address")]
        public string ToAddress { get; set; }
    }

    [DataContract]
    public class Contract
    {
        [DataMember(Name = "parameter")]
        public Parameter Parameter { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class RawData
    {
        [DataMember(Name = "contract")]
        public Contract[] Contract { get; set; }

        [DataMember(Name = "ref_block_bytes")]
        public string RefBlockBytes { get; set; }

        [DataMember(Name = "ref_block_hash")]
        public string RefBlockHash { get; set; }

        [DataMember(Name = "expiration")]
        public long Expiration { get; set; }

        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "raw_data")]
        public RawData RawData { get; set; }

        [DataMember(Name = "raw_data_hex")]
        public string RawDataHex { get; set; }
    }
}
