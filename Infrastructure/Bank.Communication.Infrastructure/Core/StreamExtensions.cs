using System.IO;

namespace Bank.Communication.Infrastructure.Core
{
	public static class StreamExtensions
	{
		public static string ReadString(this Stream stream, int offset, int length)
		{
			return StreamExtensions.ReadString(stream, offset, length, System.Text.Encoding.UTF8);
		}

		public static string ReadString(this Stream stream, int offset, int length, System.Text.Encoding enc)
		{
			if (stream.CanSeek)
				stream.Seek(offset, SeekOrigin.Begin);

			byte[] buffer = new byte[length];
			stream.Read(buffer, 0, buffer.Length);

			return enc.GetString(buffer);
		}
	}
}
