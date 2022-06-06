using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Singularity
{
    // A switch notifies on if it is switched on otherwise notifies off.
    // Only the active character can flip a switch.
    public class Switch : AbstractSwitchableObject
    {
        private OnOffPublisher switchPublisher = new OnOffPublisher();
        public GameObject switchObject;

        public AudioClip switchOn;
        public AudioClip switchOff;

        private bool switchedOn = false;
        private bool collided = false;
        private GameObject characterTouchingSwitch = null;
        private GameObject cameraController;

        // Subscribes to the publisher by making a tuple of onFunc and offFunc.
        // These functions should execute the expected behavior for when the switch
        // is turned On and when it is turned Off.
        public override void SubscribeTo(Action onFunc, Action offFunc)
        {
            switchPublisher.Subscribe(Tuple.Create(onFunc, offFunc));
        }

        // Unsubscribes from the publisher
        public override void UnsubscribeFrom(Action onFunc, Action offFunc)
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
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
                {
                    // TODO: play switch audio
                    if (switchedOn == false)
                    {
                        AudioSource.PlayClipAtPoint(switchOn, transform.position);
                        gameObject.transform.GetChild(0).transform.Rotate(0f, 0f, 65.991f, Space.Self);
                        // When the switch is turned on we must call notify On.
                        switchPublisher.NotifyOn();
                        switchedOn = true;
                    }
                    else if (switchedOn == true)
                    {
                        AudioSource.PlayClipAtPoint(switchOff, transform.position);
                        gameObject.transform.GetChild(0).transform.Rotate(0f, 0f, -65.991f, Space.Self);
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
