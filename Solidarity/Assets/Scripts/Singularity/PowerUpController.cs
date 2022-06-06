using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    // This class deals with both players standing on their respective powerups.
    public class PowerUpController : MonoBehaviour
    {
        private bool standingOn1 = false;
        private bool standingOn2 = false;

        public void setStandingOn1(bool b)
        {
            standingOn1 = b;
        }

        public void setStandingOn2(bool b)
        {
            standingOn2 = b;
        }

        public bool getStandingOn1()
        {
            return standingOn1;
        }

        public bool getStandingOn2()
        {
            return standingOn2;
        }

        // Checks for button press to enable power up if both characters are standing on their own respective item.
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
            {
                if (standingOn1 && standingOn2)
                {
                    GameObject.Find("Level Controller").GetComponent<LevelController>().CombineWorlds();
                }
            }
        }
    }
}