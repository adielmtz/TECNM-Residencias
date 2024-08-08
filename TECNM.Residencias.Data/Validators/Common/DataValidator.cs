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
                if (!char.IsDigit(c) && c != '+' && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
