using NUnit.Framework;
using FluentAssertions;
using RestSharp;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        public void TestUpload()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/FileName.txt\", \"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer YfUKeoObE7QAAAAAAAAAAagQhOlLXgQrwRubC-3ahYva1lTr2vaVxxXfSwP4p89k");
            var body = @"";
            request.AddParameter("application/octet-stream", body, ParameterType.RequestBody);
            IRestResponse response = client.Post(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test, Order(2)]
        public void TestGetMetaData()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer YfUKeoObE7QAAAAAAAAAAagQhOlLXgQrwRubC-3ahYva1lTr2vaVxxXfSwP4p89k");
            var body = @"{
" + "\n" +
            @"    ""path"": ""/FileName.txt""
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Post(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test, Order(3)]
        public void TestDelete()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer YfUKeoObE7QAAAAAAAAAAagQhOlLXgQrwRubC-3ahYva1lTr2vaVxxXfSwP4p89k");
            var body = @"{
" + "\n" +
            @"    ""path"": ""/FileName.txt""
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Post(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}