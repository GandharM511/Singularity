using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    // Checks for both players to be in the completion zone, at that point the level
    // is completed.
    public class LevelComplete : MonoBehaviour
    {
        public GameObject world1Goal;
        public GameObject world2Goal;

        private WorldGoal worldScript1;
        private WorldGoal worldScript2;

        void Start()
        {
            worldScript1 = world1Goal.GetComponent<WorldGoal>();
            worldScript2 = world2Goal.GetComponent<WorldGoal>();
        }

        void Update()
        {
            if (worldScript1.isComplete() && worldScript2.isComplete())
            {
                // TODO: This is where we will advance to the next level
                // stop the player control and do an animation. 
                Debug.Log("level complete");
            }
        }
    }
}
