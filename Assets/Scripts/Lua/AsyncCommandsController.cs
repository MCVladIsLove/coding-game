using Assets.Scripts.Utils;
using System;
using UnityEngine;

namespace Assets.Scripts.LuaIntegration
{
    public class AsyncCommandsController
    {
        private Coroutine _activeCoroutine;
        private MonoBehaviour _coroutineRunner;

        public AsyncCommandsController(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        private void TrackAsyncCommand(Coroutine routine)
        {
            _activeCoroutine = routine;
        }

        private void RemoveAsyncCommand()
        {
            _activeCoroutine = null;
        }

        public void StopAsyncExecution()
        {
            _coroutineRunner.StopCoroutine(_activeCoroutine);
        }

        public void RunAsyncCommand(float executionTime, Action onFinish)
        {
            TrackAsyncCommand(
                AsyncUtils.ExecuteAfter(
                    _coroutineRunner, executionTime, () =>
                    {
                        RemoveAsyncCommand();
                        onFinish();
                    }));
        }
    }
}