
using Program0.ClassLib.Models;

namespace Program0.Tests;

public class AddressTests
{
    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Name_ShouldThrow_WhenInvalid(string name)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Address(name, "a", "a", "a", 1);
        });
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Address1_ShouldThrow_WhenInvalid(string address1)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Address("a", address1, "a", "a", 1);
        });
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Address2_ShouldThrow_WhenInvalid(string address2)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Address("a", "a", address2, "a", "a", 1);
        });
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void City_ShouldThrow_WhenInvalid(string city)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Address("a", "a", city, "a", 1);
        });
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void State_ShouldThrow_WhenInvalid(string state)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Address("a", "a", "a", state, 1);
        });
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(100_000)]
    public void ZipCode_ShouldThrow_WhenOutOfRange(int zipCode)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Address("a", "a", "a", "a", zipCode);
        });
    }
}