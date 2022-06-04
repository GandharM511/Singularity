using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Implements the OnOffPublisher interface
// which has subscribers  that each have their own functionality
// for when a switch is turn on and off.
namespace Singularity
{
    public class OnOffPublisher : IOnOffPublisher
    {
        private List<Tuple<Action, Action>> subscribers;

        public OnOffPublisher()
        {
            // Constructor.
            subscribers = new List<Tuple<Action, Action>>();
        }

        // Unsubcribe method.
        public void Unsubscribe(Tuple<Action, Action> onAndOffFuncs)
        {
            subscribers.Remove(onAndOffFuncs);
        }

        // Subscribe method.
        public void Subscribe(Tuple<Action, Action> onAndOffFuncs)
        {
            subscribers.Add(onAndOffFuncs);
        }

        // Calls each subscribers On() method.
        public void NotifyOn()
        {
            foreach(Tuple<Action, Action> callback in subscribers)
            {
                callback.Item1();
            }
        }

        // Calls each subscribers Off() method.
        public void NotifyOff()
        {
            foreach(Tuple<Action, Action> callback in subscribers)
            {
                callback.Item2();
            }
        }
    }
}
