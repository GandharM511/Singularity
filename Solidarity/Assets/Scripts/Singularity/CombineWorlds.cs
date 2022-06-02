using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    // This script deals with setting up the third world where all of the platforms are combined and the players play as 1 character.
    public class CombineWorlds : MonoBehaviour
    {
        public GameObject world1;
        public GameObject world2;
        public GameObject goal;

        public GameObject platformPrefab;

        public GameObject levelController;


        // The world is to be created when the level starts.
        void Start()
        {
            foreach(Transform child in world1.transform)
            {
                if (child.gameObject.tag == "Untagged")
                {
                    addToWorld3(child.gameObject);
                }

                if (child.gameObject == goal)
                {
                    GameObject newObj = Instantiate(goal, transform, true);
                    newObj.transform.localPosition = new Vector3(0,0,0) + child.gameObject.transform.localPosition;
                    newObj.transform.localScale = child.gameObject.transform.localScale;

                    levelController.GetComponent<LevelComplete>().setWorld3Goal(newObj.transform.GetChild(0).gameObject);
                }
            }

            foreach(Transform child in world2.transform)
            {
                if (child.gameObject.tag == "Untagged")
                {
                    addToWorld3(child.gameObject);
                }

                if (child.gameObject == goal)
                {
                    GameObject newObj = Instantiate(goal, transform, true);
                    newObj.transform.localPosition = new Vector3(0,0,0) + child.gameObject.transform.localPosition;
                    newObj.transform.localScale = child.gameObject.transform.localScale;

                    levelController.GetComponent<LevelComplete>().setWorld3Goal(newObj.transform.GetChild(0).gameObject);
                }
            }
        }

        // adds an object to world3 as a child.
        private void addToWorld3(GameObject obj)
        {
            GameObject newObj = Instantiate(platformPrefab, transform, true);
            newObj.transform.localPosition = new Vector3(0,0,0) + obj.transform.localPosition;
            newObj.transform.localScale = obj.transform.localScale;
        }
    }
}
