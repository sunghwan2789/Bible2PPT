using System.IO;

namespace Bible2PPT
{
    abstract class ByteConfig
    {
        protected string path;

        public ByteConfig(string path)
        {
            this.path = path;
            Reload();
        }

        public void Save()
        {
            try
            {
                using (var fs = File.OpenWrite(path))
                {
                    fs.WriteByte(Serialize());
                }
            }
            catch { }
        }

        public void Reload()
        {
            try
            {
                using (var fs = File.OpenRead(path))
                {
                    Deserialize((byte) fs.ReadByte());
                }
            }
            catch { }
        }

        protected abstract byte Serialize();
        protected abstract void Deserialize(byte s);
    }
}
