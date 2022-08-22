namespace Project0.Models;

public class Address
{
    private const int MAX_ZIP_CODE = 99_999;

    public string Name { get; }
    public string Address1 { get; }
    public string Address2 { get; }
    public string City { get; }
    public string State { get; }
    public int ZipCode { get; }

    public Address(string name, string address1, string city, string state, int zipCode)
        : this(name, address1, "", city, state, zipCode)
    {
    }

    public Address(string name, string address1, string address2, string city, string state, int zipCode)
    {
        this.Name = name.ThrowIfNullOrWhitespace(nameof(name));
        this.Address1 = address1.ThrowIfNullOrWhitespace();
        this.Address2 = address2.ThrowIfNullOrWhitespace();
        this.City = city.ThrowIfNullOrWhitespace();
        this.State = state.ThrowIfNullOrWhitespace();

        if (zipCode > MAX_ZIP_CODE || zipCode <= 0)
            throw new ArgumentOutOfRangeException(nameof(zipCode), $"ZipCode cannot be larger than {MAX_ZIP_CODE}, or less than or equal to 0.");
        
        this.ZipCode = zipCode;
    }
}