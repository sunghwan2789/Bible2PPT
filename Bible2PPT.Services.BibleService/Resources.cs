using System.Reflection;

namespace Bible2PPT;

public static class Resources
{
    public static byte[] Get(string name)
    {
        using var stream = GetStream(name);
        if (stream == null)
        {
            return null;
        }

        var buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        return buffer;
    }

    public static async Task<byte[]> GetAsync(string name)
    {
        using var stream = GetStream(name);
        if (stream == null)
        {
            return null;
        }

        var buffer = new byte[stream.Length];
        await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
        return buffer;
    }

    public static Stream GetStream(string name)
    {
        var assembly = Assembly.GetCallingAssembly();
        var prefix = $"{assembly.GetName().Name}.Resources";
        return assembly.GetManifestResourceStream($"{prefix}.{name.Replace('-', '_')}");
    }
}
