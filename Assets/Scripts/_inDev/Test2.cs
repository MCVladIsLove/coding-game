using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LuaIntegration;
using XLua;
using System.Text.RegularExpressions;
using Assets.Scripts.LuaCommands;
using Assets.Scripts.LuaObjects;
using System;

public class Test2 : MonoBehaviour
{
    private void Start()
    {
        LuaEnv env = new LuaEnv();
        MoveCommand move = new MoveCommand(0.7f, true, transform);
        SayCommand say = new SayCommand(0, true);
        CatLua cat = new CatLua(this, move, say);
        string s = @"
        --while true do
            Move(Vector3.up)
            Move(Vector3.right)
            Move(Vector3.down)
            Move(Vector3.left)
        --end
        print(Say('sss', 'aaa'))
        Say('bbb', 'vvv')
    ";

        ScriptEnvironment mainEnv = new ScriptEnvironment(
            env, 
            cat, 
            s, 
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());

        mainEnv.GetScriptAs<Action>()();
    }
}
