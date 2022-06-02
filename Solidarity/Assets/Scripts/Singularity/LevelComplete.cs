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
        private GameObject world3Goal = null;

        private WorldGoal worldScript1;
        private WorldGoal worldScript2;
        private WorldGoal worldScript3 = null;

        public void setWorld3Goal(GameObject obj)
        {
            world3Goal = obj;
        }

        void Start()
        {
            worldScript1 = world1Goal.GetComponent<WorldGoal>();
            worldScript2 = world2Goal.GetComponent<WorldGoal>();

        }

        void Update()
        {
            // set world 3 up
            if (world3Goal != null && worldScript3 == null)
            {
                worldScript3 = world3Goal.GetComponent<WorldGoal>();
                worldScript3.character = GameObject.Find("Main Camera").GetComponent<CameraController>().character3;
            }


            if (gameObject.GetComponent<LevelController>().getWorldCombineState() == false)
            {
                if (worldScript1.isComplete() && worldScript2.isComplete())
                {
                    // TODO: This is where we will advance to the next level
                    // stop the player control and do an animation. 
                    Debug.Log("level complete");
                }
            }
            else
            {
                // only one exit
                if (worldScript3 != null && worldScript3.isComplete())
                {
                    // TODO: this is where we will advance to the next level
                    // stop the player control and do an animation
                    Debug.Log("level complete");
                }
            }
        }
    }
}
