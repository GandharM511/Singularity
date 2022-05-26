using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Singularity
{
    public class Switch : MonoBehaviour 
    {
        private OnOffPublisher switchPublisher = new OnOffPublisher();
        [SerializeField]
        public GameObject switchObject;
        private bool switchedOn = false;
        private bool collided = false;
        private GameObject characterTouchingSwitch = null;
        private GameObject cameraController;

        // Subscribes to the publisher by making a tuple of onFunc and offFunc.
        // These functions should execute the expected behavior for when the switch
        // is turned On and when it is turned Off.
        public void SubscribeToSwitch(Action onFunc, Action offFunc)
        {
            switchPublisher.Subscribe(Tuple.Create(onFunc, offFunc));
        }

        // Unsubscribes from the publisher
        public void UnsubscribeFromSwitch(Action onFunc, Action offFunc)
        {
            switchPublisher.Unsubscribe(Tuple.Create(onFunc, offFunc));
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // Check if player is active
            characterTouchingSwitch = col.gameObject;
            collided = true;
        }

        void OnTriggerExit2D(Collider2D col)
        {
            characterTouchingSwitch = null;
            collided = false;
        }

        void Update()
        {
            // check that there is something touching the switch and that it is the active character
            if (collided && characterTouchingSwitch != null && cameraController.GetComponent<CameraController>().isCharacterActive(characterTouchingSwitch))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    if (switchedOn == false)
                    {
                        // When the switch is turned on we must call notify On.
                        switchPublisher.NotifyOn();
                        switchedOn = true;
                    }
                    else if (switchedOn == true)
                    {
                        // When the switch is turned off we must call notify Off.
                        switchPublisher.NotifyOff();
                        switchedOn = false;
                    }
                }
            }
        }

        void Start()
        {
            cameraController = GameObject.Find("Main Camera");
        }


        /*void OnTriggerStay2D(Collider2D col)
        {
            // TODO: Check the current collider is active character,
            // don't want player to hit switches when not in that world
            if (Input.GetButtonDown("Fire2"))
            {
                if (switchedOn == false)
                {
                    // When the switch is turned on we must call notify On.
                    switchPublisher.NotifyOn();
                    switchedOn = true;
                }
                else if (switchedOn == true)
                {
                    // When the switch is turned off we must call notify Off.
                    switchPublisher.NotifyOff();
                    switchedOn = false;
                }
            }
        }*/
    }
}
