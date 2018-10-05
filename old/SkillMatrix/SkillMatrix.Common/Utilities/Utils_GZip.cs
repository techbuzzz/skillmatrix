using System.IO;
using System.IO.Compression;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        public static byte[] GZip(byte[] rawData)
        {
            using (var outputStream = new MemoryStream())
            using(var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
            using (var sourceStream = new MemoryStream(rawData))
            {
                sourceStream.CopyTo(gZipStream);
                return outputStream.ToArray();
            }
        }
        public static byte[] UnGZip(byte[] zippedData)
        {
            using (var outputStream = new MemoryStream())
            using (var gZipStream = new GZipStream(outputStream, CompressionMode.Decompress))
            using (var sourceStream = new MemoryStream(zippedData))
            {
                sourceStream.CopyTo(gZipStream);
                return outputStream.ToArray();
            }
        }
    }
}