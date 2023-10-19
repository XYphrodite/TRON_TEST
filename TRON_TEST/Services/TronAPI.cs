using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TRON_TEST.Models;
using static Program;

namespace TRON_TEST.Services
{
    internal class TronAPI
    {
        private readonly ILogger logger;
        private string _baseUrl = "https://api.shasta.trongrid.io/v1/";
        private string _baseUrl_ = "https://api.shasta.trongrid.io/";

        public TronAPI(ILogger logger)
        {
            this.logger = logger;
        }
        public async Task GetAccountInfo(string address)
        {
            var options = new RestClientOptions(_baseUrl + "accounts/" + address);
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            var response = await client.GetAsync(request);

            logger.Log(response.Content);
        }

        public async Task GetTransactionInfo(string address)
        {
            var options = new RestClientOptions(_baseUrl + "accounts/" + address + "/transactions");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            var response = await client.GetAsync(request);

            logger.Log(response.Content);
        }
        public async Task GetContractTransactionInfo(string address)
        {
            var options = new RestClientOptions(_baseUrl + "accounts/" + address + "/transactions/trc20");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            var response = await client.GetAsync(request);

            Console.WriteLine("{0}", response.Content);
        }

        public async Task BroadcastTransaction()
        {
            var options = new RestClientOptions(_baseUrl_ + "/wallet/broadcasttransaction");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");

            Value value = new Value
            {
                Amount = 1000,
                OwnerAddress = "41608f8da72479edc7dd921e4c30bb7e7cddbe722e",
                ToAddress = "41e9d79cc47518930bc322d9bf7cddd260a0260a8d"
            };

            // Create a Parameter instance
            Models.Parameter parameter = new Models.Parameter
            {
                Value = value,
                TypeUrl = "type.googleapis.com/protocol.TransferContract"
            };

            // Create a Contract instance
            Contract contract = new Contract
            {
                Parameter = parameter,
                Type = "TransferContract"
            };

            // Create a RawData instance
            RawData rawData = new RawData
            {
                Contract = new Contract[] { contract },
                RefBlockBytes = "5e4b",
                RefBlockHash = "47c9dc89341b300d",
                Expiration = 1591089627000,
                Timestamp = 1591089567635
            };

            // Create a RootObject instance
            RootObject rootObject = new RootObject
            {
                RawData = rawData,
                RawDataHex = "0a025e4b220847c9dc89341b300d40f8fed3a2a72e5a66080112620a2d747970652e676f6f676c65617069732e636f6d2f70726f746f636f6c2e5472616e73666572436f6e747261637412310a1541608f8da72479edc7dd921e4c30bb7e7cddbe722e121541e9d79cc47518930bc322d9bf7cddd260a0260a8d18e8077093afd0a2a72e"
            };

            //request.AddJsonBody(JsonSerializer.Serialize(rootObject), false);
            string jsonBody = JsonSerializer.Serialize(new
            {
                raw_data = JsonSerializer.Serialize(rootObject.RawData),
                raw_data_hex = rootObject.RawDataHex
            });



            request.AddJsonBody(jsonBody, false);
            var response = await client.PostAsync(request);

            logger.Log(response.Content);
        }
    }
}
