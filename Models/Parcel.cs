namespace Project0.Models;

public abstract class Parcel
{
    public Address To { get; }
    public Address From { get; }
    
    public abstract decimal CalcCost();
}