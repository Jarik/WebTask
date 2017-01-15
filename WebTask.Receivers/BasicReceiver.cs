using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.Receivers
{
    public class BasicReceiver
    {
        const string MediaType = "application/json";

        public async Task<HttpResponseMessage> Get(
            string path)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Properties.Settings.Default.ApiPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

            var response = await client.GetAsync(path);

            return response;
        }

        public async Task<HttpResponseMessage> Add<T>(string path, T val)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Properties.Settings.Default.ApiPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

            HttpResponseMessage response = await client.PostAsJsonAsync(path, val);
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> Update<T>(string path, T val)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Properties.Settings.Default.ApiPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

            HttpResponseMessage response = await client.PutAsJsonAsync(path, val);
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> Delete(string path)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(Properties.Settings.Default.ApiPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));

            HttpResponseMessage response = await client.DeleteAsync(path);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
