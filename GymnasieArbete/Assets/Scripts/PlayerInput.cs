using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;
    float movementSpeed = 2.0f;
    

    void Start()
    {
        player = GetComponent<Player>();
    }

  
    void Update()
    {
        /*float rTriggerFloat = Input.GetAxis("Right Trigger");
        float lTriggerFloat = Input.GetAxis("Left Trigger");
        bool leftBumper = Input.GetButton("Left Bumper");
        bool rightBumper = Input.GetButton("Right Bumper");
        bool backButton = Input.GetButton("Back");
        bool startButton = Input.GetButton("Start");
        bool aButton = Input.GetButton("A Button");
        bool bButton = Input.GetButton("B Button");
        bool xButton = Input.GetButton("X Button");
        bool yButton = Input.GetButton("Y Button");
        float dpadHorizontal = Input.GetAxis("Dpad Horizontal") * movementSpeed;
        float dpadVertical = Input.GetAxis("Dpad Vertical") * movementSpeed;
        float moveH = Input.GetAxis("Horizontal") * movementSpeed;
        float moveV = Input.GetAxis("Vertical") * movementSpeed;
        float moveHR = Input.GetAxis("Mouse X") * movementSpeed;
        float moveVR = Input.GetAxis("Mouse Y") * movementSpeed;*/

        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);
        
        if (Input.GetButtonDown("A Button"))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetButtonUp("A Button"))
        {
            player.OnJumpInputUp();
        }
        if (Input.GetButtonDown("B Button"))
        {
            player.OnSprintInputDown();
        }
        if (Input.GetButtonUp("B Button"))
        {
            player.OnSprintInputUp();
        }

        if (Input.GetButtonDown("X Button"))
        {
            player.OnFireInputDown();
        }
    }
}
