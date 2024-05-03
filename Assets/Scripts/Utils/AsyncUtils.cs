using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class AsyncUtils
    {
        public static Coroutine ExecuteAfter(MonoBehaviour coroutineRunner, float time, Action onFinish)
        {
            return coroutineRunner.StartCoroutine(Wait(time, onFinish));
        }

        private static IEnumerator Wait(float time, Action onFinish)
        {
            yield return new WaitForSeconds(time);
            onFinish();
        }
    }
}