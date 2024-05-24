using Assets.Scripts.LuaLexing;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.SyntaxHighlighting
{
    public class SyntaxHighlighter
    {
        private StringBuilder _styledTextBuilder = new StringBuilder();
        private StyleDeterminer _styleDeterminer = new StyleDeterminer();

        public string GetHighlightedText(string text, List<Token> tokenizedText)
        {
            _styledTextBuilder.Clear();

            foreach (Token token in tokenizedText)
            {
                if (token.type == TokenType.Whitespace || token.type == TokenType.Punctuation)
                    _styledTextBuilder.Append(token.text);
                else
                    _styledTextBuilder
                        .Append("<style=")
                        .Append(_styleDeterminer.GetStyleName(token.type))
                        .Append(">")
                        .Append(token.text)
                        .Append("</style>");
            }

            return _styledTextBuilder.ToString();
        }
    }

}