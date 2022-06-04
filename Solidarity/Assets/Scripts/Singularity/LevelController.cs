using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity
{
    // This script is in charge of keeping track of the state of the combined worlds and actually doing the combining (by calling combineWorldScript).
    public class LevelController : MonoBehaviour
    {
        private bool worldsCombined = false;

        // Gets the state of the world view.
        public bool getWorldCombineState()
        {
            return worldsCombined;
        }

        // Addresses the changes that need to occur to combine the worlds (MainCamera)
        public void CombineWorlds()
        {
            if (worldsCombined == false)
            {
                worldsCombined = true;
                GameObject.Find("Main Camera").GetComponent<CameraController>().combineWorlds();
            }
        }

        // Go back to 2 character state.
        // This is called by the camera controller.
        public void UnCombineWorlds()
        {
            worldsCombined = false;
        }
    }
}