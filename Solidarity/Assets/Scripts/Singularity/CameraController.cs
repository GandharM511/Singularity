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

    private void Awake()
    {
        this.managedCamera = this.gameObject.GetComponent<Camera>();
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
        currCharacter.GetComponent<PlayerController>().controlEnabled = true;
        otherCharacter.GetComponent<PlayerController>().controlEnabled = false;
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
}
