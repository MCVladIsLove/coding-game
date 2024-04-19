using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LuaIntegration;
using XLua;

public class Test2 : MonoBehaviour
{
    private void Start()
    {
        LuaEnv env = new LuaEnv();
        MoveCommand move = new MoveCommand(2f, true, transform);
        SayCommand say = new SayCommand(0, true);
        CatLua cat = new CatLua(this, move, say);
        string s = @"
co = coroutine.create(function() 
--        while true do        
            Move(Vector3.up)
            Move(Vector3.right)
            Move(Vector3.down)
            Move(Vector3.left)
--        end
        print(Say('sas', 'sos'))
    end)
    assert(coroutine.resume(co))
        Say('sas', 'ssi')

    ";
        ScriptEnvironment mainEnv = new ScriptEnvironment(
            env, 
            cat, 
            s, 
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());

        mainEnv.GetScriptAsCsFuncton()();
    }
}
