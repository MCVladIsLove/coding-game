using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace LuaLexing
{
    public class LuaLexer
    {
        private LuaLexerRules _rules = new LuaLexerRules();

        public List<Token> Tokenize(string text)
        {
            List<Token> result = new List<Token>();
            int textPosition = 0;
            int textLen = text.Length;
            Match match;
            while (textPosition < textLen)
            {
                match = null;
                foreach (LuaLexerRule rule in _rules.Rules)
                {
                    match = rule.Match(text, textPosition);
                    if (match.Success)
                    {
                        int matchLen = match.Length;
                        result.Add(new Token(rule.TokenType,
                            textPosition,
                            matchLen,
                            match.Value));
                        textPosition += matchLen;
                        break;
                    }
                }

                if (match == null)
                {
                    Debug.LogError($"Cant Tokenize string (pos: {textPosition}): {text.Substring(textPosition, 15)}");
                    textPosition++;
                }
            }

            return result;
        }
    }
}