using System;
using System.Security.Policy;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }
    //[JsonPropertyName("name")]�@    ��`����̂߂�ǂ�����
    public string Name { get; set; }
    //[JsonPropertyName("nireDate")]  ��`����̂߂�ǂ�����
    public DateTime HireDate { get; set; }
}