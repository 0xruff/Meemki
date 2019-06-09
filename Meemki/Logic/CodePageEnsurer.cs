using System;
using System.Text;

namespace Meemki.Logic
{
    public static class CodePageEnsurer
    {
        private static string encoderFailFlag = "[[ENCODER-FAIL-FLAG]]";
        private static string decoderFailFlag = "[[DECODER-FAIL-FLAG]]";
        
        public static void EnsureLegitCP850(string input)
        {
            Encoding cp850 = Encoding.GetEncoding(850, new EncoderReplacementFallback(encoderFailFlag), new DecoderReplacementFallback(decoderFailFlag));
            byte[] encodedBytes = new byte[cp850.GetByteCount(input)];
            cp850.GetBytes(input, 0, input.Length, encodedBytes, 0);
            string decodedString = cp850.GetString(encodedBytes);

            if (decodedString.Contains(encoderFailFlag) || decodedString.Contains(decoderFailFlag))
            {
                throw new ArgumentOutOfRangeException($"String {input} is not part of CP850!\nDecoded string: {decodedString}");
            }
        }

        public static void EnsureLegitCP850(char input)
        {
            Encoding cp850 = Encoding.GetEncoding(850, new EncoderReplacementFallback(encoderFailFlag), new DecoderReplacementFallback(decoderFailFlag));
            char[] charArray = new char[1] { input };
            byte[] encodedBytes = new byte[cp850.GetByteCount(charArray)];
            cp850.GetBytes(charArray, 0, 1, encodedBytes, 0);
            string decodedString = cp850.GetString(encodedBytes);

            if (decodedString.Contains(encoderFailFlag) || decodedString.Contains(decoderFailFlag))
            {
                throw new ArgumentOutOfRangeException($"Char {input} is not part of CP850!\nDecoded string: {decodedString}");
            }
        }
    }
}
