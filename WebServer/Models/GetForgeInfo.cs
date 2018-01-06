using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebServer.Models
{
    public class GetForgeInfo
    {
        static string key = "m5O6diephXghGRCXYd8yQr5zRAAMmyZ7";
        static string secret = "WmRaRGGcujisV8VU";
        static string ClientUrl = "https://developer.api.autodesk.com";
       public static string token; 
        public static RestClient client;

        public static void Initialization()
        {
            client = new RestClient(ClientUrl);
            token =GetAccessToken(client, key, secret);

        }

        public static string GetProgress(RestClient client, string token, string urn)
        {
            RestRequest progressReq = new RestRequest();
            progressReq.Method = Method.GET;
            progressReq.Resource = string.Format("modelderivative/v2/designdata/{0}/manifest", urn);
            progressReq.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            progressReq.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            IRestResponse progressResp = client.Execute(progressReq);
            if (progressResp.StatusCode == System.Net.HttpStatusCode.OK)
            {

                return GetRespData(progressResp, "progress");
            }
            throw new Exception("Get Progress Failed" + progressResp.Content);
        }

        private static string GetAccessToken(RestClient client, string key, string secret)
        {
            string token;
            RestRequest authReq = new RestRequest();
            authReq.Resource = "authentication/v1/authenticate";
            authReq.Method = Method.POST;
            authReq.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            authReq.AddParameter("client_id", key);
            authReq.AddParameter("client_secret", secret);
            authReq.AddParameter("grant_type", "client_credentials");
            authReq.AddParameter("scope", "bucket:create bucket:read bucket:update data:read data:write data:create");
            IRestResponse result = client.Execute(authReq);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                token = GetRespData(result, "access_token");
                //now set the token.
                if (SetToken(client, token))
                    return token;
            }
            throw new Exception("Get Token Failed" + result.Content);

        }

        private static string GetRespData(IRestResponse result, string paramName)
        {
            paramName = "\"" + paramName + "\":\"";
            string responseString = result.Content.Replace(" ", "");
            int len = responseString.Length;
            int index = responseString.IndexOf(paramName) + paramName.Length;
            responseString = responseString.Substring(index, len - index - 1);
            int index2 = responseString.IndexOf("\"");
            string token = responseString.Substring(0, index2);
            return token;
        }

        private static bool SetToken(RestClient client, string token)
        {
            RestRequest setTokenReq = new RestRequest();
            setTokenReq.Resource = "utility/v1/settoken";
            setTokenReq.Method = Method.POST;
            setTokenReq.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            setTokenReq.AddParameter("access-token", token);
            IRestResponse resp = client.Execute(setTokenReq);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        
        public static string DownloadFile(string dir, RestClient client, string token, string fileurn)
        {
            RestRequest downReq = new RestRequest("viewingservice/v1/items/" + fileurn, Method.GET);
            downReq.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            var data = client.DownloadData(downReq);
            data.ToString();
            if (fileurn.Contains("/output/"))
            {
                fileurn = fileurn.Substring(fileurn.LastIndexOf("/output/") + 7);
            }
            string fileName = dir + fileurn.Replace("/", "\\");
            string fileDir = fileName.Substring(0, fileName.LastIndexOf("\\"));
            if ((!Directory.Exists(fileDir)) && fileDir != "" && fileDir != "\\")
            {
                Directory.CreateDirectory(fileDir);
            }
            FileStream fs = new FileStream(fileName, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Close();
            return fileName;
        }
        public  static string GetURN64(string urn)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(urn);
            string urn64 = Convert.ToBase64String(bytes);
            return urn64;
        }
    }
}