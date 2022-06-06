using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Singularity;

public class CameraController : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    
    private Camera managedCamera;
    private GameObject currCharacter;
    private GameObject otherCharacter;
    public float worldDistance = 16.84f;

    private void Awake()
    {
        this.managedCamera = this.gameObject.GetComponent<Camera>();
    }

    void Start()
    {
        currCharacter = character1;
        otherCharacter = character2;

        if (character3 != null)
            character3.GetComponent<PlayerController>().controlEnabled = false;

        setMovementPerms();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Z)) && !PauseMenu.isPaused)
        {
            LevelController levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
            if (levelController == null || levelController.getWorldCombineState() == false)
            {
                swapCharacter();
            }
            else
            {
                UnCombineWorlds();
            }
        }
    }


    private void setMovementPerms()
    {
        var currController = currCharacter.GetComponent<PlayerController>();
        currController.controlEnabled = true;
        // enable gravity to "resume" world
        var rb1 = currCharacter.GetComponent<Rigidbody2D>();
        rb1.constraints = RigidbodyConstraints2D.FreezeRotation;

        var otherController = otherCharacter.GetComponent<PlayerController>();
        otherController.controlEnabled = false;
        // disable gravity to "pause" world
        var rb2 = otherCharacter.GetComponent<Rigidbody2D>();
        rb2.constraints = RigidbodyConstraints2D.FreezeAll;
        otherController.setStopJump(true);
        otherController.setVelocity(new Vector2 (0,0));
    }

    // moves the camera and allows player to begin controlling the other character
    private void swapCharacter()
    {
        var cameraPosition = this.managedCamera.transform.position;
        if (currCharacter == character1)
        {
            // move camera down
            cameraPosition.y = cameraPosition.y - worldDistance;
        }
        else
        {
            // move camera up
            cameraPosition.y = cameraPosition.y + worldDistance;
        }

        this.managedCamera.transform.position = cameraPosition;

        GameObject temp = currCharacter;
        currCharacter = otherCharacter;
        otherCharacter = temp;

        setMovementPerms();
    }

    public void combineWorlds()
    {
        if (character3 != null)
        {
            var cameraPosition = this.managedCamera.transform.position;
            if (currCharacter == character1)
            {
                // Move camera right
                cameraPosition.x = cameraPosition.x + 25.0f;
            }
            else
            {
                // Move camera up and right.
                cameraPosition.y = cameraPosition.y + worldDistance;
                cameraPosition.x = cameraPosition.x + 25.0f;
            }

            this.managedCamera.transform.position = cameraPosition;

            currCharacter = character3;
            character1.GetComponent<PlayerController>().controlEnabled = false;
            character2.GetComponent<PlayerController>().controlEnabled = false;
            character3.GetComponent<PlayerController>().controlEnabled = true;
            var currController = currCharacter.GetComponent<PlayerController>();
            currController.controlEnabled = true;
            // enable gravity to "resume" world
            var rb1 = currCharacter.GetComponent<Rigidbody2D>();
            rb1.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void UnCombineWorlds()
    {
        if (character3 != null)
        {
            var cameraPosition = this.managedCamera.transform.position;
            // move camera back to world 1
            cameraPosition.x = cameraPosition.x - 25.0f;

            this.managedCamera.transform.position = cameraPosition;

            // enable character 1 and disable character 3
            currCharacter = character1;
            otherCharacter = character2;

            var c3Controller = character3.GetComponent<PlayerController>();
            c3Controller.controlEnabled = false;
            // disable gravity to "pause" world
            var rb3 = c3Controller.GetComponent<Rigidbody2D>();
            rb3.constraints = RigidbodyConstraints2D.FreezeAll;
            c3Controller.setStopJump(true);
            c3Controller.setVelocity(new Vector2(0,0));

            setMovementPerms();

            GameObject.Find("Level Controller").GetComponent<LevelController>().UnCombineWorlds();
        }
    }

    // Returns true if the GameObject c is the same as the active character.
    public bool isCharacterActive(GameObject c)
    {
        if (c == currCharacter)
            return true;

        return false; 
    }

    // Returns true if the GameObject c is the same as the inactive character.
    public bool isCharacterInActive(GameObject c)
    {
        if (c == otherCharacter)
            return true;
        
        return false;
    }

    // Returns the Game Object of the active character.
    public GameObject activeCharacter()
    {
        return currCharacter;
    }
}
