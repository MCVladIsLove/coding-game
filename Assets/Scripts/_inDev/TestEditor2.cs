using UnityEngine;
using Assets.Scripts.ScriptEditor;
using Assets.Scripts.LuaAPIs;
using Assets.Scripts.LuaIntegration;
using XLua;
using Assets.Scripts.LuaCommands;

public class TestEditor2 : MonoBehaviour
{
    ScriptEnvironment mainEnv;
    ScriptEnvironment env2;
    ScriptEnvironment env3;
    ScriptEnvironment env4;
    CatAPI cat;
    public static LuaEnv env;

    ScriptEnvironment[] _envs;
    ScriptEditorModel _model;
    ScriptEditorViewModel _viewModel;
    [SerializeField] ScriptEditorView _editor;

    private void Awake()
    {
        if (TestScriptEditor.env != null)
        {
            return;
        }

       // env = new LuaEnv();
    }


    private void Start()
    {
        env = TestScriptEditor.env;

        MoveCommand move = new MoveCommand(1.5f, true, transform);
        SayCommand say = new SayCommand(0, true);
        cat = new CatAPI(this, move, say);
        string s = @"
        Move(Vector3.up)
    ";
        string s2 = @"
        Move(Vector3.left)
    ";
        string s3 = @"
        Move(Vector3.down)
    ";        string s4 = @"
        Move(Vector3.right)
    ";

        mainEnv = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s,
            "onButtonI()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());
        env2 = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s2,
            "onButtonJ()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());
        env3 = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s3,
            "onButtonK()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());
        env4 = new ScriptEnvironment(
            env,
            new CatAPI(this, move, say),
            s4,
            "onButtonL()",
            new DefaultLuaTablePreparer(),
            new DefaultLuaScriptPreparer());

        mainEnv.TryCompileScript();
        //W = mainEnv.GetScriptAsDelegate();
        env2.TryCompileScript();
        //S = env2.GetScriptAsDelegate();
        env3.TryCompileScript();
        env4.TryCompileScript();
        //D = env3.GetScriptAsDelegate();


        _envs = new ScriptEnvironment[]
        {
            mainEnv,
            env2,
            env3,
            env4
        };

        _model = new ScriptEditorModel(_envs);
        _viewModel = new ScriptEditorViewModel(_model);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //W();
            mainEnv.TryExecuteScript();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //    S();
            env2.TryExecuteScript();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //  D();
            env3.TryExecuteScript();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //  D();
            env4.TryExecuteScript();
        }
    }

    private void OnMouseUpAsButton()
    {
        _editor.SetViewModel(_viewModel);
        _editor.Open();
    }
}
