using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField]
    private GameObject tank;

    public float turnSpeed = 10f;

    float speed =30f;
    Vector3 moveStep;
    float gravityValue = -9.81f;
    float jumpHeight = 1.0f;
    bool groundedPlayer;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && moveStep.y < 0)
        {
            moveStep.y = 0f;
        }

        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
      
        if(Mathf.Abs(dx)>0 && Mathf.Abs(dz) > 0)
        {
            dx /= Mathf.Sqrt(2f);
            dz /= Mathf.Sqrt(2f);
            
            State.isMoving = true;
        }
        else
        {
            State.isMoving = false;
        }

        Look();

        if (!Input.GetKey(KeyCode.LeftAlt))
        {

            Vector3 horizontalForward = Camera.main.transform.forward;
            horizontalForward.y = 0f;
            horizontalForward = horizontalForward.normalized;

            Vector3 horizontalRight = Camera.main.transform.right;
            horizontalRight.y = 0f;
            horizontalRight = horizontalRight.normalized;

            moveStep = dx * horizontalRight + dz * horizontalForward + moveStep.y * Vector3.up;
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            moveStep.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
     
        moveStep.y += gravityValue * Time.deltaTime;
        characterController.Move(Time.deltaTime * speed * moveStep);
    }

    private void Look()
    {
        //if (State.isMoving)
        //{
            if (moveStep == Vector3.zero) return;

            var rot = Quaternion.LookRotation(moveStep, Vector3.up);
            tank.transform.rotation = Quaternion.Lerp(tank.transform.rotation, rot, turnSpeed * Time.deltaTime);
        //}
    }

   
}
