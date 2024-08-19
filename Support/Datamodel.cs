
public class DataModel
{
    public Plant_Detail[] plant_detail { get; set; }
}

public class Plant_Detail
{
    public string id { get; set; }
    public Result[] results { get; set; }
}

public class Result
{
    public Plantname[] plantName { get; set; }
    public int hostRef { get; set; }
    public string eppoCode { get; set; }
}

public class Plantname
{
    public string type { get; set; }
    public object NAME { get; set; }
}
