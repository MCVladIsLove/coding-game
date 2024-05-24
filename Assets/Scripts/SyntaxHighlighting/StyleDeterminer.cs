using Assets.Scripts.LuaLexing;

namespace Assets.Scripts.SyntaxHighlighting
{
    public class StyleDeterminer
    {
        public string GetStyleName(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Identifier:
                    return "Normal"; // todo: add functionality to determine func, class etc
                case TokenType.Keyword:
                    return "Keyword";
                case TokenType.Number:
                    return "Number";
                case TokenType.Operator:
                    return "Operator";
                case TokenType.String:
                    return "String";
                case TokenType.Comment:
                    return "Comment";
                default:
                    return "Normal";
            }
        }
    }

}