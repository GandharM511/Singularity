using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    public class SwitchableObjectExample : MonoBehaviour, ISwitchableObject
    {
        public GameObject switchToSubscribe;

        void Start()
        {
            switchToSubscribe.GetComponent<Switch>().SubscribeTo(On, Off);
        }

        public void On()
        {
            Debug.Log("Switched On");
        }

        public void Off()
        {
            Debug.Log("Switched Off");
        }
    }
}