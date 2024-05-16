using UnityEngine;
using Assets.Scripts.ScriptEditor;
using System;
using Assets.Scripts.LuaAPIs;
using Assets.Scripts.LuaIntegration;
using XLua;
using Assets.Scripts.LuaCommands;
using System.Collections.Generic;

public class TestScriptEditor : MonoBehaviour
{
    ScriptEnvironment mainEnv;
    ScriptEnvironment env2;
    ScriptEnvironment env3;
    CatAPI cat;
    public static LuaEnv env;
    Action W;
    Action D;
    Action S;

    ScriptEnvironment[] _envs;
    ScriptEditorModel _model;
    ScriptEditorViewModel _viewModel;
    [SerializeField] ScriptEditorView _editor;

    private void Awake()
    {
        if (env != null)
            return;

        env = new LuaEnv();
    }


    private void Start()
    {
        MoveCommand move = new MoveCommand(0.7f, true, transform);
        SayCommand say = new SayCommand(0, true);
        cat = new CatAPI(this, move, say);
        string s = @"
        Move(Vector3.up)
        Move(Vector3.left)
    ";
        string s2 = @"
        Move(Vector3.down)
        Move(Vector3.left)
    ";
        string s3 = @"
        Move(Vector3.right)
    ";

        mainEnv = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s,
            "onButtonW()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());
        env2 = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s2,
            "onButtonS()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());
        env3 = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s3,
            "onButtonD()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());

        mainEnv.TryCompileScript();
        //W = mainEnv.GetScriptAsDelegate();
        env2.TryCompileScript();
        //S = env2.GetScriptAsDelegate();
        env3.TryCompileScript();
        //D = env3.GetScriptAsDelegate();


        _envs = new ScriptEnvironment[]
        {
            mainEnv,
            env2,
            env3
        };

        _model = new ScriptEditorModel(_envs);
        _viewModel = new ScriptEditorViewModel(_model);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //W();
            mainEnv.TryExecuteScript();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //    S();
            env2.TryExecuteScript();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //  D();
            env3.TryExecuteScript();
        }
    }

    private void OnMouseUpAsButton()
    {
        _editor.SetViewModel(_viewModel);

        _editor.Open();
    }
}
