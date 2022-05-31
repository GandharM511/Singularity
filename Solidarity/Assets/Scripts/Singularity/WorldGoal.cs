using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    // This class implements the completion state of a world (uses a public bool).
    public class WorldGoal : MonoBehaviour
    {
        private bool completed = false;

        public GameObject character;
        

        // Check that character is in the collision zone.
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == character)
            {
                completed = true;
            }
        }

        // Check that character left collision zone.
        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject == character)
            {
                completed = false;
            }
        }

        public bool isComplete()
        {
            return completed;
        }
    }
}
