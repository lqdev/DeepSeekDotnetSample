using Azure;
using Azure.AI.Inference;
using Microsoft.Extensions.AI;

IChatClient chatClient = 
    new ChatCompletionsClient(
        new Uri("https://models.inference.ai.azure.com"), 
        new AzureKeyCredential(Environment.GetEnvironmentVariable("GITHUB_TOKEN")))
        .AsChatClient("DeepSeek-R1");

var streamingResponse = chatClient.CompleteStreamingAsync("What appears once in a minute, twice in a moment, but never in a thousand years?");

await foreach (var response in streamingResponse)
{
    Console.Write(response.Text);
}
