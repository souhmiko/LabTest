using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LabTest.Q3Model
{
    
    public class PostRecordService
    {
        private readonly HttpClient _httpClient;

        public PostRecordService()
        {
            _httpClient = new HttpClient();
        }

        // Create
        public async Task<PostRecord> CreatePostRecord(PostRecord postRecord)
        {
            var content = new StringContent(JsonSerializer.Serialize(postRecord), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

            response.EnsureSuccessStatusCode();

            var createdPostRecord = await JsonSerializer.DeserializeAsync<PostRecord>(await response.Content.ReadAsStreamAsync());
            return createdPostRecord;
        }

        // Read (Get all)
        public async Task<List<PostRecord>> GetPostRecords()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<List<PostRecord>>(await response.Content.ReadAsStreamAsync());
        }

        // Read (Get by Id)
        public async Task<PostRecord> GetPostRecordById(int id)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts{id}");

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<PostRecord>(await response.Content.ReadAsStreamAsync());
        }

        // Update
        public async Task<PostRecord> UpdatePostRecord(PostRecord postRecord)
        {
            var content = new StringContent(JsonSerializer.Serialize(postRecord), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://jsonplaceholder.typicode.com/posts{postRecord.Id}", content);

            response.EnsureSuccessStatusCode();

            var updatedPostRecord = await JsonSerializer.DeserializeAsync<PostRecord>(await response.Content.ReadAsStreamAsync());
            return updatedPostRecord;
        }

        // Delete
        public async Task<bool> DeletePostRecord(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts{id}");

            return response.IsSuccessStatusCode;
        }
    }

    
}
