using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;
namespace WindowsFormsApp1.DataApi
{
    class API
    {
        string app_key;
        public string check_login(string data)
        {

            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("App_Key", "7dc3e464107ad4a108e98ac6add68513");
            String response = client.UploadString("http://test.quangbeo216.com/truong/api/public/api/login", "POST", data);
            return response;
        }
        public object VBC_den(string app_key)
        {
            WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key); 
            String json = client.DownloadString("http://test.quangbeo216.com/truong/api/public/api/vbcden");
            List<VanBanDen_C> listvanban = JsonConvert.DeserializeObject<List<VanBanDen_C>>(json);
            return listvanban;
        }
        public object VBC_di(string app_key)
        {
            WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key);
            String json = client.DownloadString("http://test.quangbeo216.com/truong/api/public/api/vbcdi");
            List<VanBanDi_C> listvanban = JsonConvert.DeserializeObject<List<VanBanDi_C>>(json);
            return listvanban;
        }
        public object VBM_den(string app_key)
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://test.quangbeo216.com/truong/api/public/api/vbmden");
            List<VanBanDen_M> listvanban = JsonConvert.DeserializeObject<List<VanBanDen_M>>(json);
            return listvanban;
        }
        public object VBM_di(string app_key)
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://test.quangbeo216.com/truong/api/public/api/vbmdi");
            List<VanBanDi_M> listvanban = JsonConvert.DeserializeObject<List<VanBanDi_M>>(json);
            return listvanban;
        }
        public void update(string data, int id)
        {
             WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString("http://test.quangbeo216.com/truong/api/public/api/update/" + id, "POST", data);
        }
        public void delete(int id)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add("App_Key", app_key);
            String response = client.UploadString("http://test.quangbeo216.com/truong/api/public/api/wfdeletec/" + id, "DELETE", "");
        }
        public void add (string data)
        {
            WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString("http://test.quangbeo216.com/truong/api/public/api/create", "POST", data);
        }
        public void add_history(string data)
        {
            WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String response = client.UploadString("http://test.quangbeo216.com/truong/api/public/api/add_history", "POST", data);
        }
        public object history(int id)
        {
            WebClient client = new WebClient();
            client.Headers.Add("App_Key", app_key);
            String json = client.DownloadString("http://test.quangbeo216.com/truong/api/public/api/history/" + id);
            List<History> listvanban = JsonConvert.DeserializeObject<List<History>>(json);
            return listvanban;
        }
    }
}
