using System.Collections.ObjectModel;
using Newtonsoft.Json;


namespace LabTest;

public partial class Q3 : ContentPage
{
    private ObservableCollection<PostRecord> PostRecords { get; set; } = new ObservableCollection<PostRecord>();

    public Q3()
    {
        InitializeComponent();

        // Call the method to fetch data from the API
        FetchData();
    }

    private async void FetchData()
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                // Set the base address for the HttpClient
                httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                // Make a request to the posts endpoint
                var response = await httpClient.GetStringAsync("posts");

                // Deserialize the response using Newtonsoft.Json
                var postRecords = JsonConvert.DeserializeObject<ObservableCollection<PostRecord>>(response);

                // Update the collection with the fetched data
                foreach (var postRecord in postRecords)
                {
                    PostRecords.Add(postRecord);
                }

                // Set the binding context for the CollectionView
                PostCollectionView.ItemsSource = PostRecords;
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, e.g., connection error, API changes, etc.
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        // Display an input dialog to get user input
        var title = await DisplayPromptAsync("New Post", "Enter Title");
        var body = await DisplayPromptAsync("New Post", "Enter Body");

        // Validate if user canceled the input
        if (title == null || body == null)
            return;

        // Create a new post record
        var newPost = new PostRecord
        {
            Id = PostRecords.Count + 1,
            UserId = "1",
            Title = title,
            Body = body
        };

        // Add the new post record to the collection
        PostRecords.Add(newPost);
    }

}



public class PostRecord
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("body")]
    public string Body { get; set; }

}