using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Students.Entities.Models;

public class PBLResponse
{
    [JsonPropertyName("status")]
    public string? status { get; set; }

    [JsonPropertyName("message")]
    public string? message { get; set; }


    public Details? details;

    [JsonPropertyName("statusMessage")]
    public string? statusMessage { get; set; }

}
