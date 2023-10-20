using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TRON_TEST.Models
{
    public class Parameter
    {
        [JsonPropertyName("value")]
        public Value Value { get; set; }

        [JsonPropertyName("type_url")]
        public string TypeUrl { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("owner_address")]
        public string OwnerAddress { get; set; }

        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; }
    }

    public class Contract
    {
        [JsonPropertyName("parameter")]
        public Parameter Parameter { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class RawData
    {
        [JsonPropertyName("contract")]
        public Contract[] Contract { get; set; }

        [JsonPropertyName("ref_block_bytes")]
        public string RefBlockBytes { get; set; }

        [JsonPropertyName("ref_block_hash")]
        public string RefBlockHash { get; set; }

        [JsonPropertyName("expiration")]
        public long Expiration { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }

    public class RootObject
    {
        [JsonPropertyName("raw_data")]
        public RawData RawData { get; set; }

        [JsonPropertyName("raw_data_hex")]
        public string RawDataHex { get; set; }
    }
}
