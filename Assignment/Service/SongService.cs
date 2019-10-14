using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assignment.Constant;
using Assignment.Entity;
using Newtonsoft.Json;

namespace Assignment.Service
{
    class SongService : ISongService
    {
        public string PostSongFree(Song song)
        {
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8, "application/json");
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            string token = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var httpRequestMessage = httpClient.PostAsync(ApiUrl.UPLOAD_SONG_URL, content);
            var jsonResult = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(jsonResult);
            return jsonResult;
        }

        public ObservableCollection<Song> GetFreeSong()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            HttpClient httpClient = new HttpClient();
            var content = httpClient.GetAsync(ApiUrl.GET_FREE_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(content);
            return songs;
        }

        public ObservableCollection<Song> GetMySong()
        {
            ObservableCollection<Song> mysongs = new ObservableCollection<Song>();
            HttpClient httpClient = new HttpClient();
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            string token = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var songcontent = httpClient.GetAsync(ApiUrl.MY_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            mysongs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(songcontent);
            return mysongs;
        }
    }
}
