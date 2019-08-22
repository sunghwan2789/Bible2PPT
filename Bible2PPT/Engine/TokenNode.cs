using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bible2PPT.Engine
{
    class TokenNode<T>
    {
        public bool IsTerminal => Children.Any();
        public T Value { get; private set; }

        private readonly Dictionary<char, TokenNode<T>> Children = new Dictionary<char, TokenNode<T>>();

        public void Set(string token, T value)
        {
            using (var sr = new StringReader(token))
            {
                Set(sr, value);
            }
        }

        public void Set(StringReader tokenReader, T value)
        {
            // 마지막 토큰 노드에 값 할당
            if (IsTokenEnd())
            {
                Value = value;
                return;
            }

            // 자식 노드가 없으면 만듦
            var ch = Convert.ToChar(tokenReader.Read());
            if (!Children.TryGetValue(ch, out var childNode))
            {
                childNode = new TokenNode<T>();
                Children[ch] = childNode;
            }

            // 자식 노드로 값 전달
            childNode.Set(tokenReader, value);

            bool IsTokenEnd() => tokenReader.Peek() == -1;
        }

        public bool TryGet(string token, out T value)
        {
            using (var sr = new StringReader(token))
            {
                return TryGet(sr, out value);
            }
        }
        
        public bool TryGet(StringReader tokenReader, out T value)
        {
            // 마지막 토큰 노드에서 값 반환
            if (IsTokenEnd())
            {
                value = Value;
                return true;
            }

            // 자식 노드가 없으면 오류 처리
            var ch = Convert.ToChar(tokenReader.Read());
            if (!Children.TryGetValue(ch, out var childNode))
            {
                value = default;
                return false;
            }

            // 자식 노드에서 값 찾기
            return childNode.TryGet(tokenReader, out value);

            bool IsTokenEnd() => tokenReader.Peek() == -1;
        }
    }
}
