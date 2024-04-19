using UnityEngine;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    [LuaCallCSharp]
    public class SayCommand : LuaCsCommand, ICommandReturnResult<string>
    {
        private string _sayPart1;
        private string _sayPart2;

        public SayCommand(float executionTime, bool isAvaliable) : base(executionTime, isAvaliable)
        {
        }

        public override string CallName => "Say";

        public void SetExecutionParams(string sayPart1, string sayPart2)
        {
            _sayPart1 = sayPart1;
            _sayPart2 = sayPart2;
        }

        public override void Execute()
        {
            if (!_isAvaliable)
                throw new LuaException($"attempt to call a nil value(method '{CallName}')");

            Debug.Log(_sayPart1 + _sayPart2);
        }

        public string GetResult()
        {
            return _sayPart2 + _sayPart1;
        }
    }
}