using System;
using System.Security.Policy;
using System.Text.Json.Serialization;

public class Employee {
    [JsonIgnore]
    public int Id { get; set; }
    //[JsonPropertyName("name")]Å@    íËã`Ç∑ÇÈÇÃÇﬂÇÒÇ«Ç≠Ç≥Ç¢
    public string Name { get; set; }
    //[JsonPropertyName("nireDate")]  íËã`Ç∑ÇÈÇÃÇﬂÇÒÇ«Ç≠Ç≥Ç¢
    public DateTime HireDate { get; set; }
}