using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singularity
{
    // Checks for both players to be in the completion zone, at that point the level
    // is completed.
    public class LevelComplete : MonoBehaviour
    {
        public GameObject world1Goal;
        public GameObject world2Goal;
        public AudioClip finishSound;
        private GameObject world3Goal = null;

        private WorldGoal worldScript1;
        private WorldGoal worldScript2;
        private WorldGoal worldScript3 = null;


        private bool levelCompleted = false;

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
                if (worldScript1.isComplete() && worldScript2.isComplete() && !levelCompleted)
                {
                    // TODO: This is where we will advance to the next level
                    // stop the player control and do an animation.
                    // play finish level sound.
                    levelCompleted = true;
                    AudioSource.PlayClipAtPoint(finishSound, transform.position);
                    Invoke("CompleteLevel",  2f);
                }
            }
            else
            {
                // only one exit
                if (worldScript3 != null && worldScript3.isComplete() && !levelCompleted)
                {
                    // TODO: this is where we will advance to the next level
                    // stop the player control and do an animation
                    // play finish level sound.
                    levelCompleted = true;
                    AudioSource.PlayClipAtPoint(finishSound, transform.position);
                    Invoke("CompleteLevel", 2f);
                }
            }
        }

        private void CompleteLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
