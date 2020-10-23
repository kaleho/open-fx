using System.Threading.Tasks;

namespace System.IO
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ToArrayAsync(
            this Stream stream)
        {
            await using var memoryStream = new MemoryStream();

            await stream.CopyToAsync(memoryStream).ConfigureAwait(false);

            var returnValue = memoryStream.ToArray();

            return returnValue;
        }
    }
}