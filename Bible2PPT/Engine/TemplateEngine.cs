using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bible2PPT.Engine
{
    class TemplateEngine
    {
        public char StartSymbol { get; }
        public char EndSymbol { get; }
        public char Delimiter { get; }

        public TemplateEngine() : this('[', ']', ':') { }

        public TemplateEngine(char startSymbol, char endSymbol, char delimiter)
        {
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            Delimiter = delimiter;
        }

        private readonly TokenNode<string> TokenTree = new TokenNode<string>();

        public void Register(string token, string value) => TokenTree.Set(token, value);

        public string Process(string text)
        {
            using (var sr = new StringReader(text))
            {
                return Process(sr);
            }
        }

        public string Process(StringReader reader)
        {
            var builder = new StringBuilder();

            while (reader.Peek() != -1)
            {

            }

            return builder.ToString();
        }
    }
}
