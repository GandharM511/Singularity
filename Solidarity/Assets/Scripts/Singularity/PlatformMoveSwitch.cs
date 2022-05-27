using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    public class PlatformMoveSwitch : MonoBehaviour, ISwitchableObject
    {
        public Vector3 moveVector;
        public float totalTime;
        public GameObject switchToSubscribe;

        private Vector3 startPosition;
        private Vector3 goalLocation;
        private Vector3 finalPosition;
        private Vector3 currLocation;
        private float speed;

        private CameraController cameraController;

        void Start()
        {
            cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();

            if (switchToSubscribe.tag == "Switch")
            {
                switchToSubscribe.GetComponent<Switch>().SubscribeTo(On, Off);
            }
            else
            {
                switchToSubscribe.GetComponent<PressurePlate>().SubscribeTo(On, Off);
            }
                
            startPosition = transform.position;
            currLocation = startPosition;
            finalPosition = startPosition + moveVector;
            goalLocation = startPosition;
            speed = Vector2.Distance(finalPosition, startPosition) / totalTime;
        }

        // set the parent of the player to this object so that the character moves with it while standing on it
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject == cameraController.character1 || col.gameObject == cameraController.character2)
            {
                col.collider.transform.SetParent(transform);
            }
        }

        // unset the parent
        private void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject == cameraController.character1)
            {
                col.collider.transform.SetParent(GameObject.Find("World 1").transform);
            }
            else if (col.gameObject == cameraController.character2)
            {
                col.collider.transform.SetParent(GameObject.Find("World 2").transform);
            }
        }

        public void On()
        {
            goalLocation = finalPosition;
        }

        public void Off()
        {
            goalLocation = startPosition;
        }

        // move the gameObject to the goal Position
        void FixedUpdate()
        {
            float step = Time.deltaTime * speed;
            currLocation = Vector2.MoveTowards(currLocation, goalLocation, step);
            transform.position = currLocation;
        }
    }
}

