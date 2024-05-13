using System;
using UnityEngine;
using XLua;
using Assets.Scripts.Utils;
using Assets.Scripts.LuaCommands;
using Assets.Scripts.LuaIntegration;

namespace Assets.Scripts.LuaAPIs
{
    [LuaCallCSharp]
    public class CatAPI : LuaAPI
    {
        private MoveCommand _moveCommand;
        private SayCommand _sayCommand;

        public CheckEnum en;

        public CatAPI(MonoBehaviour coroutineRunner, MoveCommand moveCommand, SayCommand sayCommand) : base(coroutineRunner)
        {
            _moveCommand = moveCommand;
            _sayCommand = sayCommand;
            RegisterCommand(_moveCommand);
            RegisterCommand(_sayCommand);
        }

        public void Move(Vector3 moveDirection, Action notifyFinish = null)
        {
            _asyncCommandsController.RunAsyncCommand(_moveCommand.ExecutionTime, () =>
            {
                _moveCommand.SetExecutionParams(moveDirection);
                _moveCommand.Execute();
                notifyFinish();
            });
        }
        public string Say(string say1, string say2)
        {
            _sayCommand.SetExecutionParams(say1, say2);
            _sayCommand.Execute();
            return _sayCommand.GetResult();
        }

        public void SSSS(CheckEnum d, CheckEnum2 dd, CheckEnum2 ddd)
        {

        }
        public void dddd(CheckEnum dffas)
        {

        }
    }

    [LuaCallCSharp] // todo: CLEAN THIS
    public enum CheckEnum
    {
        A,
        B,
        C
    }

    [LuaCallCSharp]
    public enum CheckEnum2
    {
        A,
        B,
        C
    }
    [LuaCallCSharp]
    public enum CheckEnum23
    {
        A,
        B,
        C
    }


}