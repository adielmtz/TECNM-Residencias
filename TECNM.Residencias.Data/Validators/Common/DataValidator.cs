namespace TECNM.Residencias.Data.Validators.Common
{
    internal static class DataValidator
    {
        internal static bool BeAPhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 7)
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!IsValidPhoneChar(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidPhoneChar(char c)
        {
            return char.IsDigit(c) || c == ' ' || c == '+' || c == '-';
        }
    }
}
