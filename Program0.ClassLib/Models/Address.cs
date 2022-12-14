using System.Text;

using Program0.ClassLib.Extensions;

namespace Program0.ClassLib.Models;

/// <summary>
/// A class describing a shippable address in the United States.
/// </summary>
public class Address
{
    private const int MAX_ZIP_CODE = 99_999; // Upper limit on ZipCodes

    /// <summary>
    /// A friendly name for the address.
    /// Will never be null, empty, or whitespace.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The primary address.
    /// </summary>
    public string Address1 { get; }

    /// <summary>
    /// The optional, secondary address.
    /// Can be be empty, but never whitespace or null.
    /// </summary>
    public string Address2 { get; }

    /// <summary>
    /// The address's city.
    /// Will never be null, empty, or whitespace.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// The address's state.
    /// Will never be null, empty, or whitespace.
    /// </summary>
    public string State { get; }

    /// <summary>
    /// The address's zip code.
    /// Value limited from 0 - 99_9999.
    /// </summary>
    public int ZipCode { get; }

    /// <summary>
    /// Constructs a <see cref="Address"/> instance with validated parameters.
    /// Optional overload without an <see cref="Address2"/> that is set to an empty string.
    /// </summary>
    /// <param name="name">Cannot be null or whitespace</param>
    /// <param name="address1">Cannot be null or whitespace</param>
    /// <param name="city">Cannot be null or whitespace</param>
    /// <param name="state">Cannot be null or whitespace</param>
    /// <param name="zipCode">Cannot be larger than <see cref="MAX_ZIP_CODE"/>, or less than or equal to 0."</param>
    public Address(string name, string address1, string city, string state, int zipCode)
    {
        Name = name.ThrowIfNullOrWhiteSpace(nameof(name)).Trim();
        Address1 = address1.ThrowIfNullOrWhiteSpace(nameof(address1)).Trim();

        Address2 ??= string.Empty; // Possibly set in ctor overload

        City = city.ThrowIfNullOrWhiteSpace(nameof(city)).Trim();
        State = state.ThrowIfNullOrWhiteSpace(nameof(state)).Trim();

        ZipCode = zipCode.ThrowIfOutOfRange(
            max: MAX_ZIP_CODE,
            min: 1,
            nameof(zipCode),
            $"Cannot be larger than {MAX_ZIP_CODE}, or less than or equal to 0.");
    }

    /// <summary>
    /// Constructs a <see cref="Address"/> instance with validated parameters.
    /// </summary>
    /// <param name="name">Cannot be null or whitespace. String is trimmed.</param>
    /// <param name="address1">Cannot be null or whitespace. String is trimmed.</param>
    /// <param name="address2">Cannot be null or whitespace. String is trimmed.</param>
    /// <param name="city">Cannot be null or whitespace. String is trimmed.</param>
    /// <param name="state">Cannot be null or whitespace. String is trimmed.</param>
    /// <param name="zipCode">Cannot be larger than <see cref="MAX_ZIP_CODE"/>, or less than or equal to 0."</param>
    public Address(string name, string address1, string address2, string city, string state, int zipCode)
        : this(name, address1, city, state, zipCode)
    {
        Address2 = address2.ThrowIfNullOrWhiteSpace(nameof(address2)).Trim();
    }

    /// <summary>
    /// Pretty prints the <see cref="Address"/>'s properties.
    /// </summary>
    /// <returns>The formatted string representation of the <see cref="Address"/>.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Name);
        sb.AppendLine(Address1);

        if (!string.IsNullOrEmpty(Address2))
            sb.AppendLine(Address2);

        sb.AppendLine($"{City}, {State} {ZipCode:D5}");

        return sb.ToString();
    }
}