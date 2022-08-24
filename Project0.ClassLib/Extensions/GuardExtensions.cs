namespace Project0.ClassLib.Extensions;

/// <summary>
/// Provides a useful API for throwing exceptions when evaluating the state of a given parameter.
/// </summary>
internal static class GuardExtensions
{
    /// <summary>
    /// Throws a <see cref="ArgumentOutOfRangeException"/> if the given value is null.
    /// </summary>
    /// <typeparam name="T">The generic type of the parameter.</typeparam>
    /// <param name="value">The instance to be checked if it's null.</param>
    /// <param name="paramName">Name of the parameter at the original caller site.</param>
    /// <param name="errorMessage">A meaningful error message to describe the rejected state.</param>
    /// <returns>The original value that is not null.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static T ThrowIfNull<T>(this T? value, string paramName, string errorMessage = "")
    {
        return value ?? throw new ArgumentOutOfRangeException(paramName, errorMessage); // I'd argue a System.ArgumentNullException is a better fit
    }

    /// <summary>
    /// Throws a <see cref="ArgumentException"/> if the given <see cref="string"/> is null.
    /// </summary>
    /// <param name="value">The instance to be checked if it's null.</param>
    /// <param name="paramName">Name of the parameter at the original caller site.</param>
    /// <param name="errorMessage">A meaningful error message to describe the rejected state.</param>
    /// <returns>The original value that is not null.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNullOrWhiteSpace(this string? value, string paramName, string errorMessage = "")
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(errorMessage, paramName);

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TComparable"></typeparam>
    /// <param name="value">The instance to be checked if it's null.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="paramName">Name of the parameter at the original caller site.</param>
    /// <param name="errorMessage">A meaningful error message to describe the rejected state.</param>
    /// <returns>The original value that is not null.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static TComparable ThrowIfOutOfRange<TComparable>(this TComparable value, TComparable max, TComparable min, string paramName, string errorMessage = "")
        where TComparable : IComparable
    {
        //  1 = Means Larger
        // -1 = Means Less than 
        //  0 = Means the same
        if (value.CompareTo(max) == 1 || value.CompareTo(min) == -1)
            throw new ArgumentOutOfRangeException(paramName, errorMessage);

        return value;
    }
}
