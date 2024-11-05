namespace TECNM.Residencias.Data.Validators.Common;

/// <summary>
/// A utility class that provides methods to validate phone numbers.
/// </summary>
internal static class PhoneValidator
{
    /// <summary>
    /// Minimum length for a valid phone number.
    /// </summary>
    private const int PHONE_NUMBER_MIN_LENGTH = 7;

    /// <summary>
    /// Validates if the provided input string is a valid phone number.
    /// A phone number is considered valid if it is not null or empty,
    /// has a minimum length of 7 characters, and contains only valid phone number characters.
    /// </summary>
    /// <param name="input">The input string representing the phone number.</param>
    /// <returns><see langword="true"/> if the input string is a valid phone number, otherwise <see langword="false"/>.
    /// </returns>
    internal static bool BeAPhoneNumber(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < PHONE_NUMBER_MIN_LENGTH)
        {
            return false;
        }

        foreach (char c in input)
        {
            if (!IsValidPhoneNumberChar(c))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether a character is a valid phone number character.
    /// Valid characters include digits, spaces, plus sign ('+'), and hyphen ('-').
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns>
    /// <see langword="true"/> if the character is valid, otherwise <see langword="false"/>.
    /// </returns>
    private static bool IsValidPhoneNumberChar(char c)
    {
        return char.IsDigit(c) || c == ' ' || c == '+' || c == '-';
    }
}
