
try
{
    string url = "https://jsonplaceholder.typicode.com/invalid-url";
    string data = await FetchDataAsync(url);
    Console.WriteLine(data);
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Request error: {ex.Message}");
}

async Task<string> FetchDataAsync(string url)
{
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseData = await response.Content.ReadAsStringAsync();
        return responseData;
    }
}