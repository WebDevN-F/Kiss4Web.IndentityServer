using System.Security.Cryptography;
using System.Text;

namespace Kiss4Web.Infrastructure.Authentication
{
    /// <summary>
    /// Hashing and symmetric encryption and decryption.
    /// </summary>
    public class Scrambler
    {
        private readonly SymmetricAlgorithm _algo;
        private readonly byte[] _iv;
        private readonly byte[] _key;

        /// <summary>
        /// Initialize with random key.
        /// </summary>
        /// <remarks>When using this constructor, decryption is only possible on data encrypted with the same instance of this object.</remarks>
        public Scrambler()
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            _algo = new DESCryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            _key = _algo.Key;
            _iv = _algo.IV;
        }

        /// <summary>
        /// Initialize with a password.
        /// </summary>
        /// <param name="password">Used to generate a key.</param>
        /// <remarks>Data encrypted with one instance of this object can be decrypted with another instance as long as the password is the same.</remarks>
        public Scrambler(string password)
            : this()
        {
            var hash = ComputeHash(password);
            Array.Copy(hash, 0, _key, 0, _key.Length);
            Array.Copy(hash, _key.Length, _iv, 0, _iv.Length);
        }

        /// <summary>
        /// Hashes a password to an array of <see cref="byte"/>s.
        /// </summary>
        public static byte[] ComputeHash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            // string to byte[]
            var buf = Encoding.UTF8.GetBytes(password);

            // hash key and iv from buf
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            HashAlgorithm ha = new MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            var hash = ha.ComputeHash(buf);
            return hash;
        }

        /// <summary>
        /// Decrypt an array of bytes.
        /// </summary>
        /// <returns>Decrypted bytes.</returns>
        public byte[] Decrypt(byte[] encrypted)
        {
            if (encrypted == null)
            {
                throw new ArgumentNullException(nameof(encrypted));
            }

            var msEncrypted = new MemoryStream(encrypted, false);

            var cs = new CryptoStream(msEncrypted, _algo.CreateDecryptor(_key, _iv), CryptoStreamMode.Read);

            var msPlain = new MemoryStream();
            using (cs)
            {
                int i;
                while ((i = cs.ReadByte()) > 0)
                {
                    msPlain.WriteByte((byte)i);
                }
            }

            return msPlain.ToArray();
        }

        /// <summary>
        /// Gets a decryption of a string encrypted with <see cref="EncryptString"/>.
        /// </summary>
        public string DecryptString(string encrypted)
        {
            if (encrypted == null)
            {
                throw new ArgumentNullException(nameof(encrypted));
            }

            var encBytes = Convert.FromBase64String(encrypted);
            var plainBytes = Decrypt(encBytes);
            var ret = Encoding.UTF8.GetString(plainBytes);
            return ret;
        }

        /// <summary>
        /// Encrypt an array of bytes.
        /// </summary>
        /// <returns>Encrypted bytes.</returns>
        public byte[] Encrypt(byte[] plain)
        {
            if (plain == null)
            {
                throw new ArgumentNullException(nameof(plain));
            }

            var msEncrypted = new MemoryStream();

            var cs = new CryptoStream(msEncrypted, _algo.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
            using (cs)
            {
                cs.Write(plain, 0, plain.Length);
                cs.FlushFinalBlock();
            }

            return msEncrypted.ToArray();
        }

        /// <summary>
        /// Gets a Base64 encryption of a string encoded with UTF8.
        /// </summary>
        public string EncryptString(string plain)
        {
            if (plain == null)
            {
                throw new ArgumentNullException(nameof(plain));
            }

            var plainBytes = Encoding.UTF8.GetBytes(plain);
            var encBytes = Encrypt(plainBytes);
            var ret = Convert.ToBase64String(encBytes);
            return ret;
        }
    }
}
