using System;
using UnityEngine;

namespace Helper
{
    public class AnimEvent : MonoBehaviour
    {
        public Action EventAnimFinish = null;

        public void AnimationCallBack(string attack)
        {
            EventAnimFinish?.Invoke();
        }
    }
}