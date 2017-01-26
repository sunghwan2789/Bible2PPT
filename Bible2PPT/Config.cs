using System.IO;

namespace Bible2PPT
{
    abstract class Config : IConfig
    {
        protected string path;

        public Config(string path)
        {
            this.path = path;
        }

        public void Save()
        {
            try
            {
                using (var fs = File.OpenWrite(this.path))
                {
                    fs.WriteByte(this.Serialize());
                }
            }
            catch { }
        }

        public void Load()
        {
            try
            {
                using (var fs = File.OpenRead(this.path))
                {
                    this.Deserialize((byte) fs.ReadByte());
                }
            }
            catch { }
        }

        public abstract byte Serialize();
        public abstract void Deserialize(byte s);
    }
}
