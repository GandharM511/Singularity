using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Singularity
{
    public abstract class AbstractSwitchableObject : MonoBehaviour
    {
        public abstract void SubscribeTo(Action onFunc, Action offFunc);
        public abstract void UnsubscribeFrom(Action onFunc, Action offFunc);
    }
}