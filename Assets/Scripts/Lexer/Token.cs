namespace LuaLexing
{
    public struct Token
    {
        public TokenType type;
        public int position;
        public int length;
        public string text;

        public Token(TokenType type, int position, int length, string text)
        {
            this.type = type;
            this.position = position;
            this.length = length;
            this.text = text;
        }
    }
}