namespace Bible2PPT.Extensions;

static class HttpClientExtension
{
    public static Task<string> PostAndGetStringAsync(this HttpClient client, string requestUri, HttpContent content) =>
        PostAndGetStringAsyncCore(client.PostAsync(requestUri, content));

    private static async Task<string> PostAndGetStringAsyncCore(Task<HttpResponseMessage> postTask)
    {
        // Wait for the response message.
        using var responseMessage = await postTask.ConfigureAwait(false);
        // Make sure it completed successfully.
        responseMessage.EnsureSuccessStatusCode();

        // Get the response content.
        var c = responseMessage.Content;
        if (c != null)
        {
            return await c.ReadAsStringAsync().ConfigureAwait(false);
        }

        // No content to return.
        return string.Empty;
    }
}
