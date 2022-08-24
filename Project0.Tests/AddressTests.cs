using Project0.ClassLib.Models;

namespace Project0.Tests;

public class AddressTests
{
    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Name_ShouldThrow_WhenInvalid(string name)
    {
        try
        {
            new Address(name,
                "a",
                "a",
                "a",
                1
                );

            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Address1_ShouldThrow_WhenInvalid(string address1)
    {
        try
        {
            new Address("a",
                address1,
                "a",
                "a",
                1
                );
                
            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Address2_ShouldThrow_WhenInvalid(string address2)
    {
        try
        {
            new Address("a",
                "a",
                address2,
                "a",
                "a",
                1
                );
                
            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void City_ShouldThrow_WhenInvalid(string city)
    {
        try
        {
            new Address("a",
                "a",
                city,
                "a",
                1
                );
                
            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void State_ShouldThrow_WhenInvalid(string state)
    {
        try
        {
            new Address("a",
                "a",
                "a",
                state,
                1
                );
                
            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(100_000)]
    public void ZipCode_ShouldThrow_WhenOutOfRange(int zipCode)
    {
        try
        {
            new Address("a",
                "a",
                "a",
                "a",
                zipCode
                );
                
            Assert.Fail();
        }
        catch(ArgumentOutOfRangeException)
        {
            Assert.Pass();
        }
    }
}