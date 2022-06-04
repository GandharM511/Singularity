using UnityEngine;
using System;

namespace Singularity
{
    public interface IOnOffPublisher
    {
        void Unsubscribe(Tuple<Action, Action> onAndOffFuncs);
        void Subscribe(Tuple<Action, Action> onAndOffFuncs);
        void NotifyOn();
        void NotifyOff();
    }
}