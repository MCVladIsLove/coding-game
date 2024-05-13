using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.LuaIntegration;
using XLua;
using System.Text.RegularExpressions;
using Assets.Scripts.LuaCommands;
using Assets.Scripts.LuaAPIs;
using System;

public class Test2 : MonoBehaviour
{
    ScriptEnvironment mainEnv;
    CatAPI cat;
    static LuaEnv env;

    private void Start()
    {
        if (env != null)
            return;
        
        env = new LuaEnv();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!mainEnv.IsScriptRunning)
            {
                LuaException e = mainEnv.TryExecuteScript();
                if (e != null)
                {
                    Debug.Log(e.Message);
                }
            }
              //  act();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveCommand move = new MoveCommand(0.7f, true, transform);
            SayCommand say = new SayCommand(0, true);
            cat = new CatAPI(this, move, say);
            string s = @"
       -- print(CheckEnum.A)
        --print(CheckEnum.B)
        --print(CheckEnum.C)
        --print(CheckEnum.D)
        --print(self)
        x = 1
        --print(x)
        Move(Vector3.up * x)
        Move(Vector3.right * x)
        Move(Vector3.down * x)
        Move(Vector3.left * x)
        --print(Say('sss', 'aaa'))
        --Say('bbb', 'vvv')
        x = x + 1
        --print(x)
    ";

            mainEnv = new ScriptEnvironment(
                env,
                cat,
                s,
                "mainCat",
                new DefaultLuaTablePreparer(),
                new DefaultLuaScriptPreparer());
            mainEnv.RuntimeExceptionThrown += (e) =>
            {
                Debug.Log("Msg: " + e.Message);
            };
            mainEnv.TryCompileScript();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            string script2 = @"
          --  print('Hello from second script')
          --  print('Now i Move left')
            Move(Vector3.left)
            Move(Vector3.left)
            Move(22) --runtime exception
            Move(Vector3.left)
            --Say('I', ' Reached the end')
";
            mainEnv.SetScript(script2);
            mainEnv.ReloadTable();
            LuaException e = mainEnv.TryCompileScript();
            if (e != null)
            {
                Debug.Log(e.Message);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            string script3 = @"
            print('Hello from third script')
            print('Now i Move right')
            Move(Vector3.right)
            Move(Vector3.right)
            Say('asdas', 'sdsds').Create = 2 --runtime exception
            Move(Vector3.right)
            Say('I', ' Reached the end')
";
            mainEnv.SetScript(script3);
            mainEnv.ReloadTable();
            mainEnv.TryCompileScript();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            string script2 = @"
            print('Hello from second script')
            print('Now i Move left')
            Move(Vector3.left)
            Move(Vector3.left)
            Move(Vector3.left)
            Say('I', ' Reached the end')
";
            mainEnv.SetScript(script2);
            mainEnv.ReloadTable();
            mainEnv.TryCompileScript();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            mainEnv.Reset();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            string script2 = @"
            Move(Vector3.up)            
            i = 0
            x = 0
            e = 0
            repeat
                repeat
                    e = 0
                    while e < 20 do
                        e = e + 1
                            for s=0,10,1


                            do
                                print(s)
                            end
                     
                        print(e)
                    end
                    print('hello from Infinite loop ' .. i)
                    i = i + 1
                until i > 99
                i = 0
                x = x + 1
                print('XXXX ' .. x)
            until x > 99
";
            mainEnv.SetScript(script2);
            mainEnv.ReloadTable();
            mainEnv.TryCompileScript();
        }

    }
}