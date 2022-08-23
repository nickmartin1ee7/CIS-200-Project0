using Project0.ClassLib.Extensions;

namespace Project0.ClassLib.Models;

/// <summary>
/// A fixed-rate shipping cost parcel.
/// </summary>
public class Letter : Parcel
{
    private readonly decimal _fixedCost; // The shipping cost for the letter

    /// <summary>
    /// Creates a validated instance of <see cref="Letter"/>.
    /// </summary>
    /// <param name="originAddress">Cannot be null.</param>
    /// <param name="destinationAddress">Cannot be null.</param>
    /// <param name="fixedCost">Cannot be less than 0.</param>
    public Letter(Address originAddress, Address destinationAddress, decimal fixedCost)
        : base(originAddress, destinationAddress)
    {
        _fixedCost = fixedCost.ThrowIfOutOfRange(decimal.MaxValue, 0M, nameof(fixedCost), "Cost cannot be less than 0.");
    }

    /// <summary>
    /// Doesn't really calculate anything.
    /// </summary>
    /// <returns>The fixed cost for shipping provided during instantiation.</returns>
    public override decimal CalcCost()
    {
        return _fixedCost;
    }

    // Note: ToString override not needed. Parcel's implementation suffices.
}