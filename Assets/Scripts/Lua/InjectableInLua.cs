using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    [LuaCallCSharp]
    public abstract class InjectableInLua
    {
        protected Dictionary<string, LuaCsCommand> _commands = new Dictionary<string, LuaCsCommand>();
        protected MonoBehaviour _parentBehaviour;

        public Dictionary<string, LuaCsCommand> Commands => _commands;

        public InjectableInLua(MonoBehaviour parentBehaviour)
        {
            _parentBehaviour = parentBehaviour;
        }

        protected void RegisterCommand(LuaCsCommand command)
        {
            _commands.Add(command.CallName, command);
        }
    }
}