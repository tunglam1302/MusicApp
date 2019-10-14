using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assignment.Constant;
using Assignment.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment.Service
{
    class MemberServiceApi : MemberService
    {

        public String Login(MemberLogin memberLogin)
        {
            var token = GetTokenFromApi(memberLogin);
            SaveTokenToFile(token);
            return token;
        }

        private void SaveTokenToFile(string token)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync("token.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(sampleFile, token).GetAwaiter().GetResult();
        }

        private String GetTokenFromApi(MemberLogin memberLogin)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(memberLogin),Encoding.UTF8,"application/json");
            HttpClient httpClient = new HttpClient();
            var responseContent = httpClient.PostAsync(ApiUrl.LOGIN_URL,content).Result.Content.ReadAsStringAsync().Result;
            var jsonJObject = JObject.Parse(responseContent);
            Debug.WriteLine(jsonJObject);
            if (jsonJObject["token"] == null)
            {
                throw new Exception("Login Fail");
            }

            return jsonJObject["token"].ToString();
        }


        public Member Register(Member member)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(member),Encoding.UTF8,"application/json");
                var httpRequest = httpClient.PostAsync(ApiUrl.REGISTER_URL, httpContent);
                var responseContent = httpRequest.Result.Content.ReadAsStringAsync().Result;
                var jsonJObject = JObject.Parse(responseContent);
                Debug.WriteLine(jsonJObject);
                var resMember = JsonConvert.DeserializeObject<Member>(responseContent);
                return resMember;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public Member GetInformation(string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var httpRequestMessage = httpClient.GetAsync(ApiUrl.GET_INFORMATION_URL);
            var jsonResult = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            var memberInfo = JsonConvert.DeserializeObject<Member>(jsonResult);
            return memberInfo;
        }
    }
}
