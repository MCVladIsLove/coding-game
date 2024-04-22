using System;
using UnityEngine;
using XLua;
using Assets.Scripts.Utils;
using Assets.Scripts.LuaCommands;
using Assets.Scripts.LuaIntegration;

namespace Assets.Scripts.LuaObjects
{
    [LuaCallCSharp]
    public class CatLua : InjectedInLua
    {
        private MoveCommand _moveCommand;
        private SayCommand _sayCommand;

        public CatLua(MonoBehaviour coroutineRunner, MoveCommand moveCommand, SayCommand sayCommand) : base(coroutineRunner)
        {
            _moveCommand = moveCommand;
            _sayCommand = sayCommand;
            RegisterCommand(_moveCommand);
            RegisterCommand(_sayCommand);
        }

        public void Move(Vector3 moveDirection, Action notifyFinish = null)
        {
            AsyncUtils.ExecuteAfter(_coroutineRunner, _moveCommand.ExecutionTime, () =>
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
    }
}