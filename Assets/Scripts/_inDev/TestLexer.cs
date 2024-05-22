using UnityEngine;
using LuaLexing;
using System.Text.RegularExpressions;

public class TestLexer : MonoBehaviour
{
    private void Start()
    {
        string text = @"
hi
hello
my name is lUA LEXER
do
end for <>  >       --dsds[[]] --[[--]]]
-a-sdsa 
--[[ asdsa sa


--]]


[[sads
    sada
]]";

        LuaLexer lexer = new LuaLexer();

        var res = lexer.Tokenize(text);
        foreach (var v in res)
        {
            Debug.Log(v.type + ": " + v.text);
        }
        
    }
}