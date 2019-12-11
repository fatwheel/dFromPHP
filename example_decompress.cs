using System.IO.Compression;

public static string Decompress(string input)
{
	byte[] compressed = Convert.FromBase64String(input);
	using (var mem = new MemoryStream())
	{
		mem.Write(new byte[] { 0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00 }, 0, 8);
		mem.Write(compressed, 0, compressed.Length);

		mem.Position = 0;

		using (var gzip = new GZipStream(mem, CompressionMode.Decompress))
		using (var reader = new StreamReader(gzip))
		{
			return reader.ReadToEnd();
		}
	}
}