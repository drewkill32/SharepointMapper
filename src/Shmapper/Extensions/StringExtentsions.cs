using System;
using System.Security;

namespace Shmapper.Extensions
{
    public static class StringExtensions
    {
        private static readonly byte[] Entropy = System.Text.Encoding.Unicode.GetBytes("A dash of salt");


        public static string EncryptString(this SecureString input)
        {

            try
            {
                byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
            System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
            Entropy,
            System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encryptedData);
            }
            catch
            {
                return null;
            }
        }

        public static SecureString DecryptString(this string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    Entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(this string input)
        {
            SecureString secure = new SecureString();
            try
            {

                foreach (char c in input)
                {
                    secure.AppendChar(c);
                }

                secure.MakeReadOnly();
            }
            catch (Exception)
            {
                // ignored
            }
            return secure;
        }

        public static string ToInsecureString(this SecureString input)
        {
            string returnValue;
            if (input == null) return "";
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }

            return returnValue;
        }
    }
}
