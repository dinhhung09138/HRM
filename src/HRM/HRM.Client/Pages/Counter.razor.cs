using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HRM.Model.Common;
using System.Text;

namespace HRM.Client.Pages
{
    public partial class Counter
    {
        [Inject]
        public HttpClient httpClient { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }


        private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
        private bool getBranchesError;
        private bool shouldRender;

        //protected override bool ShouldRender() => shouldRender;

        //protected override async Task OnInitializedAsync()
        //{

        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //    "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches");
        //    request.Headers.Add("Accept", "application/vnd.github.v3+json");
        //    request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

        //    var client = ClientFactory.CreateClient();

        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        //branches = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(responseStream);
        //    }
        //    else
        //    {
        //        getBranchesError = true;
        //    }

        //    shouldRender = true;

        //    CertificatedGridParameterModel parameters = new CertificatedGridParameterModel();


        //    StringContent context = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

        //    var response = await httpClient.PostAsync("https://localhost:44300//api/Certificated/grid", context);

        //    int tmp = 0;
        //}

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }

    }

    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
