using CustomSkill.API.CustomSkills;
using CustomSkill.API.Laws;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomSkill.API.Tests
{
    public class SchemaTests
          : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> factory;

        public SchemaTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task EndpointShouldMatchInputRecordSchema()
        {
            // Arrange
            var url = "/api/laws";
            var client = factory.CreateClient();
            var input = CreateInput();

            // Act
            var response = await client.PostAsJsonAsync(url, input);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        private Input<LawInputData> CreateInput()
        {
            return new Input<LawInputData>()
            {
                Values = new List<InputRecord<LawInputData>>
                {
                    new InputRecord<LawInputData>()
                    {
                        Data = new LawInputData()
                        {
                            Finished = true,
                            Success = true
                        },
                        RecordId = "a1"
                    }
                }
            };
        }
    }
}
