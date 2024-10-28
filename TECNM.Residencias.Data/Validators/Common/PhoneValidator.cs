namespace TECNM.Residencias.Data.Validators.Common;

internal static class PhoneValidator
{
    private const int PHONE_NUMBER_MIN_LENGTH = 7;

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

    private static bool IsValidPhoneNumberChar(char c)
    {
        return char.IsDigit(c) || c == ' ' || c == '+' || c == '-';
    }
}
