using XLua;

namespace Assets.Scripts.LuaIntegration
{
    [LuaCallCSharp]
    public abstract class LuaCsCommand
    {
        protected float _executionTime;
        protected bool _isAvaliable;

        public bool IsAvaliable => _isAvaliable;
        public bool IsAsync => _executionTime > 0;
        public float ExecutionTime => _executionTime;

        public abstract string CallName { get; }

        public LuaCsCommand(float executionTime, bool isAvaliable)
        {
            _executionTime = executionTime;
            _isAvaliable = isAvaliable;
        }

        public abstract void Execute();
    }
}