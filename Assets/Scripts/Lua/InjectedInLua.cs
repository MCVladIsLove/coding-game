using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LuaIntegration
{
    public abstract class InjectedInLua
    {
        protected Dictionary<string, LuaCsCommand> _commands = new Dictionary<string, LuaCsCommand>();
        protected MonoBehaviour _coroutineRunner;

        public Dictionary<string, LuaCsCommand> Commands => _commands;

        public InjectedInLua(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        protected void RegisterCommand(LuaCsCommand command)
        {
            _commands.Add(command.CallName, command);
        }
    }
}