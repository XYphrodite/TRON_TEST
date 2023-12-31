﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TRON_TEST.Models;
using static Program;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TRON_TEST.Services
{
    internal class TronAPI
    {
        private readonly ILogger logger;
#if DEBUG
        private string _baseUrl = "https://api.shasta.trongrid.io/v1/";
        private string _baseUrl_ = "https://api.shasta.trongrid.io/";
#else
        private string _baseUrl = "https://api.trongrid.io/";
        private string _baseUrl_ = "https://api.trongrid.io/";
        private string _tronApiKey = "16e358e8-151f-4255-8ce2-339ff1abee10";
#endif



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
#if RELEASE
            request.AddHeader("TRON-PRO-API-KEY", _tronApiKey);
#endif
            var response = await client.GetAsync(request);

            logger.Log(response.Content);
        }

        public async Task GetTransactionInfo(string address)
        {
            var options = new RestClientOptions(_baseUrl + "accounts/" + address + "/transactions");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
#if RELEASE
            request.AddHeader("TRON-PRO-API-KEY", _tronApiKey);
#endif
            var response = await client.GetAsync(request);

            logger.Log(response.Content);
        }
        public async Task GetContractTransactionInfo(string address)
        {
            var options = new RestClientOptions(_baseUrl + "accounts/" + address + "/transactions/trc20");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
#if RELEASE
            request.AddHeader("TRON-PRO-API-KEY", _tronApiKey);
#endif
            var response = await client.GetAsync(request);

            Console.WriteLine("{0}", response.Content);
        }

        public async Task BroadcastTransaction()
        {
            var options = new RestClientOptions(_baseUrl_ + "/wallet/broadcasttransaction");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
#if RELEASE
            request.AddHeader("TRON-PRO-API-KEY", _tronApiKey);
#endif

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
            string jsonBody = JsonSerializer.Serialize(rootObject);



            request.AddJsonBody(jsonBody, false);
            var response = await client.PostAsync(request);

            logger.Log(response.Content);
        }
        public async Task BroadcastHex()
        {
            var options = new RestClientOptions(_baseUrl_ + "/wallet/broadcasthex");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
#if RELEASE
            request.AddHeader("TRON-PRO-API-KEY", _tronApiKey);
#endif
            var jsonBody = JsonSerializer.Serialize(new
            {
                transaction = "0A8A010A0202DB2208C89D4811359A28004098A4E0A6B52D5A730802126F0A32747970652E676F6F676C65617069732E636F6D2F70726F746F636F6C2E5472616E736665724173736574436F6E747261637412390A07313030303030311215415A523B449890854C8FC460AB602DF9F31FE4293F1A15416B0580DA195542DDABE288FEC436C7D5AF769D24206412418BF3F2E492ED443607910EA9EF0A7EF79728DAAAAC0EE2BA6CB87DA38366DF9AC4ADE54B2912C1DEB0EE6666B86A07A6C7DF68F1F9DA171EEE6A370B3CA9CBBB00"
            });
            request.AddJsonBody(jsonBody, false);
            var response = await client.PostAsync(request);

            Console.WriteLine("{0}", response.Content);
        }
        public async Task CreateTransaction()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_baseUrl_ + "/wallet/createtransaction"),
                Headers = { { "accept", "application/json" },
                #if RELEASE
                    {"TRON-PRO-API-KEY", _tronApiKey }
#endif
                },
                Content = new StringContent("{\"owner_address\":\"TZ4UXDV5ZhNW7fb2AMSbgfAEZ7hWsnYS2g\",\"to_address\":\"TPswDDCAWhJAZGdHPidFg5nEf8TkNToDX1\",\"amount\":1000,\"visible\":true}")
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
        public async Task GetWallet(string walletAddress)
        {
            string apiUrl = "https://api.trongrid.io/v1/accounts/" + walletAddress;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(content);
                    var wallet = JsonSerializer.Deserialize<Root>(content);
                    var item = wallet.data[0];
                    Console.WriteLine($"Balance = {item.GetBalance()} Trx");
                    //Console.WriteLine($"USDT = {item.GetUSDT()}");
                    // Parse the JSON response to get the balance information.

                }
                else
                {
                    Console.WriteLine("Failed to retrieve balance.");
                }
            }
        }
        public async Task GetTRXTransacrions(string walletAddress)
        {
            using (HttpClient client = new HttpClient())
            {
                // TronScan API URL to get transactions by address
                string apiUrl = $"https://api.tronscan.org/api/transaction?address={walletAddress}";

                // Make an HTTP GET request to fetch the transactions
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Process the response data (in JSON format) to extract transaction details
                    // You can use a JSON parser library like Newtonsoft.Json to parse the response.

                    Console.WriteLine(responseContent);

                    TransactionRoot root = JsonConvert.DeserializeObject<TransactionRoot>(responseContent);

                    // Now you can access the data using C# objects
                    Console.WriteLine($"Total transactions: {root.total}");
                    foreach (var transaction in root.data)
                    {
                        if (!string.IsNullOrEmpty(transaction.toAddress))
                        {
                            Console.WriteLine($"Transaction Hash: {transaction.hash}");
                            Console.WriteLine($"Amount: {transaction.amount}");
                            Console.WriteLine($"OwnerAdress: {transaction.ownerAddress}");
                            Console.WriteLine($"ToAdress: {transaction.toAddress}");
                            Console.WriteLine($"Confirmed: {transaction.confirmed}");
                            if (transaction.tokenInfo is not null)
                            {
                                Console.WriteLine($"TokenName: {transaction.tokenInfo.tokenName}");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to fetch transactions for the wallet address.");
                }
            }
        }
        public async Task GetBalances(string walletAddress)
        {
            string apiUrl = $"https://apilist.tronscan.io/api/account?address={walletAddress}";
            using (HttpClient client = new HttpClient())
            {
                
                //client.DefaultRequestHeaders.Add("t", _tronApiKey);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(responseBody);
                    var content = JsonConvert.DeserializeObject<TokenBalanceWrapper>(responseBody);
                    Console.WriteLine(content.transactions); 
                    // Parse the JSON data in responseBody to extract USDT transactions.
                    // You'll need to navigate the JSON structure to find the relevant information.
                    // Deserialize the JSON using Newtonsoft.Json or any other JSON parsing library.
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
        public async Task GetUsdtTransactions(string walletAddress)
        {
            string usdtContractAddress = "TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t"; // USDT contract address on Tron

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    string url = $"https://api.trongrid.io/v1/accounts/{walletAddress}/transactions/trc20?&contract_address={usdtContractAddress}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }
    }
}
