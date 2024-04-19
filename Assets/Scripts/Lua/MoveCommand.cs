using UnityEngine;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    public class MoveCommand : LuaCsCommand
    {
        private Transform _moveTransform;
        private Vector3 _moveDirection;

        public override string CallName => "Move";

        public MoveCommand(float executionTime, bool isAvaliable, Transform moveTransform) : base(executionTime, isAvaliable)
        {
            _moveTransform = moveTransform;
        }

        public void SetExecutionParams(Vector3 moveDirection)
        {
            _moveDirection = moveDirection;
        }

        public override void Execute()
        {
            if (!_isAvaliable)
                throw new LuaException($"attempt to call a nil value(method '{CallName}')");

            _moveTransform.Translate(_moveDirection);
        }
    }
}