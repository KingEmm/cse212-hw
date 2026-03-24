public class FeatureCollection
{
    public string type {get; set;}
    public MetaData metaData {get; set;}
    public List<Features>? features {get; set;} = new List<Features>() ;
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
}

public class MetaData
{
    public long generated{get; set;}
    public string? url{get; set;}
    public string? title{get; set;}
    public int status{get; set;}
    public string? api{get; set;}
    public int count{get; set;}
}

public class Features
{
    public string? type {get; set;}
    public Properties? properties {get; set;}
    public Geometry? geometry {get; set;}
    public string? id {get; set;}

}

public class Properties
{
    public double? mag {get; set;}
    public string? place {get; set;}
    public long? time {get; set;}
    public long? updated {get; set;}
    public int? tz {get; set;}
    public string? url {get; set;}
    public string? detail {get; set;}
    public int? felt {get; set;}
    public double? cdi {get; set;}
    public double? mmi {get; set;}
    public string? alert {get; set;}
    public string? status {get; set;}
    public int? tsunami {get; set;}
    public int? sig {get; set;}
    public string? net {get; set;}
    public string? code {get; set;}
    public string? ids {get; set;}
    public string? sources {get; set;}
    public string? types {get; set;}
    public int? nts {get; set;}
    public double? dmin {get; set;}
    public double? rms {get; set;}
    public double? gap {get; set;}
    public string? magtype {get; set;}
    public string? type {get; set;}
    public string? title {get; set;}
}

public class Geometry
{
    public string type {get; set;}
    public List<double>? coordinates {get; set;}
}
