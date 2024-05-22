using System.Text.RegularExpressions;

namespace LuaLexing
{
    public class LuaLexerRules
    {
        private LuaLexerRule[] _rules = new LuaLexerRule[]
        {
            new LuaLexerRule(new Regex(@"^[\t\n\r \xA0]+"), TokenType.Whitespace),
            new LuaLexerRule(new Regex("^\'(((?<=\\\\)\')?([^\n\r\'])*)*\'"), TokenType.String),
            new LuaLexerRule(new Regex("^\"(((?<=\\\\)\")?([^\n\r\"])*)*\""), TokenType.String),
            new LuaLexerRule(new Regex(@"^--(?:\[(=*)\[[\s\S]*?(?:\]\1\]|$)|[^\r\n]*)[-]*"), TokenType.Comment),
            new LuaLexerRule(new Regex(@"^\[(=*)\[[\s\S]*?(?:\]\1\]|$)"), TokenType.String),
            new LuaLexerRule(new Regex(@"^(?:and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b"), TokenType.Keyword),
            new LuaLexerRule(new Regex(@"^(?:\+|\-|\*|\/|\%|\^|\#|\=\=|\~\=|\<\=|\>\=|\<|\>|\=|\(|\)|\{|\}|\;|\:|\.|\.\.|\.\.\.|\!\=|\!)"), TokenType.Operator),
            new LuaLexerRule(new Regex(@"^[+-]?(?:0x[\da-f]+|(?:(?:\.\d+|\d+(?:\.\d*)?)(?:e[+\-]?\d+)?))"), TokenType.Number),
            new LuaLexerRule(new Regex(@"^[A-Za-z_]\w*"), TokenType.Identifier),
            new LuaLexerRule(new Regex(@"^[^\w\t\n\r \xA0][^\w\t\n\r \xA0\" + "\"" + @"\'\-\+=]*"), TokenType.Punctuation)
        };

        public LuaLexerRule[] Rules => _rules;
    }
}