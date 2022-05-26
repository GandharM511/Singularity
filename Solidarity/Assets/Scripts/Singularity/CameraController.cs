using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class CameraController : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    
    private Camera managedCamera;
    private GameObject currCharacter;
    private GameObject otherCharacter;
    private Vector2 storedVelo;

    private void Awake()
    {
        this.managedCamera = this.gameObject.GetComponent<Camera>();
        storedVelo = Vector2.zero;
    }

    void Start()
    {
        currCharacter = character1;
        otherCharacter = character2;

        setMovementPerms();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            swapCharacter();
        }
    }


    private void setMovementPerms()
    {
        var currController = currCharacter.GetComponent<PlayerController>();
        currController.controlEnabled = true;
        // enable gravity to "resume" world
        var rb1 = currCharacter.GetComponent<Rigidbody2D>();
        rb1.constraints = RigidbodyConstraints2D.FreezeRotation;
        currController.setVelocity(storedVelo);

        var otherController = otherCharacter.GetComponent<PlayerController>();
        otherController.controlEnabled = false;
        // disable gravity to "pause" world
        var rb2 = otherCharacter.GetComponent<Rigidbody2D>();
        rb2.constraints = RigidbodyConstraints2D.FreezeAll;
        otherController.setStopJump(true);
        storedVelo = otherController.getVelocity();



    }

    // moves the camera and allows player to begin controlling the other character
    private void swapCharacter()
    {
        var cameraPosition = this.managedCamera.transform.position;
        if (currCharacter == character1)
        {
            // move camera down
            cameraPosition.y = cameraPosition.y - 18.785f;
        }
        else
        {
            // move camera up
            cameraPosition.y = cameraPosition.y + 18.785f;
        }

        this.managedCamera.transform.position = cameraPosition;

        GameObject temp = currCharacter;
        currCharacter = otherCharacter;
        otherCharacter = temp;

        setMovementPerms();
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
}
