namespace LogParser.Models;

public class Log
{
    public string? DeviceVendor { get; set; } 
    public string? DeviceProduct { get; set; }
    public double? DeviceVersion { get; set; }
    public string? SignatureId {get; set;}
    public byte? Severity {get; set;}
    public string? Name {get; set;}
    public string? Start {get; set;}
    public float? Rt {get; set;}
    public string? Msg {get; set;}
    public string? Shost {get; set;}
    public string? Smac {get; set;}
    public string? Dhost {get; set;}
    public string? Dmac  {get; set;}
    public string? Suser {get; set;}
    public string? Suid {get; set;}
    public short? ExternalId {get; set;}
    public string? Cs1Label {get; set;}
}