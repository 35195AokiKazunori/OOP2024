using System;
using System.Security.Policy;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }
    //[JsonPropertyName("name")]　    定義するのめんどくさい
    public string Name { get; set; }
    //[JsonPropertyName("nireDate")]  定義するのめんどくさい
    public DateTime HireDate { get; set; }
}