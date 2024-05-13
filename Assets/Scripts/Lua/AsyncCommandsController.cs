using Assets.Scripts.Utils;
using System;
using System.Collections;
using UnityEngine;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    [LuaCallCSharp]
    public class AsyncCommandsController
    {
        private Coroutine _activeCoroutine;
        private MonoBehaviour _coroutineRunner;

        public event Action<LuaException> AsyncExecutionFailed;

        public AsyncCommandsController(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        private IEnumerator WaitFrame(Action onFinish)
        {
            yield return 0;
            RemoveAsyncCommand();
            onFinish();
        }

        public void RunLoopIteration(Action onFinish)
        {
            _activeCoroutine = _coroutineRunner.StartCoroutine(WaitFrame(onFinish));
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
            RemoveAsyncCommand();
        }

        public void RunAsyncCommand(float executionTime, Action onFinish)
        {
            TrackAsyncCommand(
                AsyncUtils.ExecuteAfter(
                    _coroutineRunner, executionTime, () =>
                    {
                        RemoveAsyncCommand();
                        try
                        {
                            onFinish();
                        }
                        catch (LuaException e)
                        {
                            AsyncExecutionFailed(e);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError(e);
                        }
                    }));
        }
    }
}