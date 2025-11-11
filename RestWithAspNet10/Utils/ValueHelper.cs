namespace RestWithAspNet10.ValueHelper
{
    internal class Verifications
    {
        public static bool IsNumeric (string value)
        {
            bool isNumeric = decimal.TryParse
                (
                value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _
                );

            return isNumeric;
        }
    }

    internal class Convertions
    {
        public static decimal ConvertToDecimal (string stringValue)
        {
            bool decimalValue = decimal.TryParse
                (
                stringValue,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal decimalValueConverted
                );

            if (decimalValue) return decimalValueConverted;
            else throw new Exception();
        }
    }
}
