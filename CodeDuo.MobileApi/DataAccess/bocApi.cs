﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace CodeDuo.MobileApi.DataAccess
{
    public class bocApi
    {
        static public Models.AccountBalance GetAccountBalance(string accountid, string viewid)
        {

            //var client = new HttpClient();
            //var queryString = HttpUtility.ParseQueryString(string.Empty);



            // Request headers
            //client.DefaultRequestHeaders.Add("Auth-Provider-Name", "01040939298400");
            //client.DefaultRequestHeaders.Add("Auth-ID", "123456789");
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", \");
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d4af6bd7a1164d8eb6c6fca3c72a809a");

            // Request parameters
            //queryString["subscription-key"] = "d4af6bd7a1164d8eb6c6fca3c72a809a";
            // http://api.bocapi.net/v1/api/banks/bda8eb884efcef7082792d45/accounts/bda8eb884efcea209b2a6240/5710bba5d42604e4072d1e92/account
            var uri = "http://api.bocapi.net/v1/api/banks/bda8eb884efcef7082792d45/accounts/" + accountid + "/" + viewid + "/account"; //?" + queryString;

            //var response =  client.GetAsync(uri);


            //var url = "http://localhost:8000/DEMOService/Client/156";
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
            webrequest.Headers.Add("Auth-Provider-Name", "01040939298400");
            webrequest.Headers.Add("Auth-ID", "123456789");
            webrequest.Headers.Add("Ocp-Apim-Subscription-Key", "");
            webrequest.Headers.Add("Ocp-Apim-Subscription-Key", "d4af6bd7a1164d8eb6c6fca3c72a809a");
            Models.AccountBalance accountBalance = new Models.AccountBalance();
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                //var result = ;
                dynamic results = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());

                accountBalance.label = results.label.Value;
                accountBalance.number = results.number.Value;
                accountBalance.iban = results.IBAN.Value;
                accountBalance.balance = results.balance.amount.Value;
                accountBalance.currency = results.balance.currency.Value;
            }
            return accountBalance;
        }


        static public Models.Transfer Transfer(string fromaccountid, string toaccountid, double amount)
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Track-ID", "4a9c41d5be483dd5bbbbaaaa");
            client.DefaultRequestHeaders.Add("Auth-Provider-Name", "01040939298400");
            client.DefaultRequestHeaders.Add("Auth-ID", "123456789");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d4af6bd7a1164d8eb6c6fca3c72a809a");

            // Request parameters
            //queryString["subscription-key"] = "{string}";
            var uri = "http://api.bocapi.net/v1/api/banks/bda8eb884efcef7082792d45/accounts/ea67f7c3c695b3dc9c1afb37/make-transaction";
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
            webrequest.Headers.Add("Track-ID", "4a9c41d5be483dd5bbbbaaaa");
            webrequest.Headers.Add("Auth-Provider-Name", "01040939298400");
            webrequest.Headers.Add("Auth-ID", "123456789");
            webrequest.Headers.Add("Ocp-Apim-Subscription-Key", "");
            webrequest.Headers.Add("Ocp-Apim-Subscription-Key", "d4af6bd7a1164d8eb6c6fca3c72a809a");
            //HttpResponseMessage response;
            string body = "{ \"description\": \"test\" , \"challenge_type\": \"test\", \"from\": {\"account_id\": \"bda8eb884efcea209b2a6240\", \"bank_id\": \"bda8eb884efcef7082792d45\"  },  \"to\": {  \"account_id\": \"bda8eb884efcea209b2a6287\", \"bank_id\": \"bda8eb884efcef7082792d45\"  },  \"value\": {  \"currency\": \"EUR\", \"amount\": 10.0} }";
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);
            Models.Transfer transferResult = new Models.Transfer();

            webrequest.Method = "POST";
            webrequest.ContentType = "application/json";
            webrequest.ContentLength = byteData.Length;
            using (var stream = webrequest.GetRequestStream())
            {
                stream.Write(byteData, 0, byteData.Length);
            }




            //using (var content = new ByteArrayContent(byteData))
            //{
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                //var result = ;
                dynamic results = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());
                transferResult.status = results.status.Value;


            }
            // }
            return transferResult;

        }




    }
}