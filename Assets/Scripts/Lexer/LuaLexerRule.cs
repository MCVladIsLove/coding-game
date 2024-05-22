using System.Text.RegularExpressions;

namespace LuaLexing
{
    public class LuaLexerRule
    {
        private TokenType _tokenType;
        private Regex _regularExpression;

        public TokenType TokenType => _tokenType;

        public LuaLexerRule(Regex regularExpression, TokenType tokenType)
        {
            _regularExpression = regularExpression;
            _tokenType = tokenType;
        }

        public Match Match(string s, int startIndex)
        {
            return _regularExpression.Match(s.Substring(startIndex));
        }
    }
}