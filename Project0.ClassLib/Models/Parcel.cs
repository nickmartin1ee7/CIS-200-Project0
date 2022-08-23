using System.Text;

using Project0.ClassLib.Extensions;

namespace Project0.ClassLib.Models;

/// <summary>
/// An abstraction describing a shippable parcel to and from two addresses at what cost.
/// </summary>
public abstract class Parcel
{
    /// <summary>
    /// The originating address being shipped from.
    /// </summary>
    public Address OriginAddress { get; }

    /// <summary>
    /// The receiving address being shipped to.
    /// </summary>
    public Address DestinationAddress { get; }

    /// <summary>
    /// Creates a validated instance of <see cref="Parcel"/>.
    /// </summary>
    /// <param name="originAddress">Cannot be null.</param>
    /// <param name="destinationAddress">Cannot be null.</param>
    public Parcel(Address originAddress, Address destinationAddress)
    {
        OriginAddress = originAddress.ThrowIfNull(nameof(originAddress), "Origin address cannot be null.");
        DestinationAddress = destinationAddress.ThrowIfNull(nameof(destinationAddress), "Destination address cannot be null.");
    }

    /// <summary>
    /// Calculates the shipping cost of the parcel.
    /// </summary>
    /// <returns>The cost of the parcel.</returns>
    public abstract decimal CalcCost();

    /// <summary>
    /// Pretty prints the <see cref="Parcel"/>'s properties.
    /// </summary>
    /// <returns>The formatted string representation of the <see cref="Parcel"/>.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("To:");
        sb.AppendLine(OriginAddress.ToString());
        sb.AppendLine("From:");
        sb.AppendLine(DestinationAddress.ToString());
        sb.AppendLine($"Shipping Price: {CalcCost():C}");

        return sb.ToString();
    }
}