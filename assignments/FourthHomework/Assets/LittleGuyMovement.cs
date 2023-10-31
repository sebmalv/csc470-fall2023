using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuyMovement : MonoBehaviour
{
    public GameObject quetzal;
    QuetzalController qcontroller;
    public GameObject gameManaging;
    // These are the variables that will scale the effect of the movement, gravity,
    // and rotation code in update.
    GameObject cameraObject;
    Vector3 oldCamPos;
    float forwardSpeed = 6;
    float rotateSpeed = 60;
    float jumpForce = 18;
    float gravityModifier = 4.5f;
    // This is the variable we will use to accumulate gravity.
    float yVelocity = 0;
    CharacterController cc;
    bool isWithMe; // checks if quetzal or character is active
    // Start is called before the first frame update
    void Start()
    {
        quetzal = GameObject.FindWithTag("Quetzal");
        qcontroller = quetzal.GetComponent<QuetzalController>();
        cameraObject = GameObject.FindWithTag("MainCamera");
        cc = gameObject.GetComponent<CharacterController>();

    }
    public void destroyMe()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Ferret")
        {
            FerretMove angryFerret = other.GetComponent<FerretMove>();
            angryFerret.destroyMe();
        }
        if (other.gameObject.tag == "Collectable")
        {

            CollectableScr collect = other.GetComponent<CollectableScr>();
            collect.destroyMe();
            qcontroller.updateScore();
        }
        if (other.gameObject.tag == "Key")
        {

            KeyMoving keyone = other.GetComponent<KeyMoving>();
            keyone.destroyMe();
            qcontroller.keyGot();

        }
        if (other.gameObject.tag == "Door")
        {

            DoorMove actualDoor = other.GetComponent<DoorMove>();
            if(qcontroller.score==10 && qcontroller.isKey == true)
            {
                actualDoor.openDoor();
                qcontroller.youWon();

            }


        }

    }

    public void setIsWithMe()
    {
        // CAMERA
        Vector3 newCamPos = transform.position + -transform.forward * 10 + Vector3.up * 5;
        cameraObject = GameObject.FindWithTag("MainCamera");
        if (oldCamPos == null)
        {
            oldCamPos = newCamPos;
        }
        cameraObject.transform.position = newCamPos;
        cameraObject.transform.LookAt(transform);
        oldCamPos = newCamPos;
        isWithMe = true;

    }
    void checkIsWithMe()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isWithMe==true)
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            // --- ROTATION ---
            // Rotate on the y axis based on the hAxis value
            // NOTE: If the player isn't pressing left or right, hAxis will be 0 and there will be no rotation
            transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

            // --- DEALING WITH GRAVITY ---
            if (!cc.isGrounded)
            {
                // If we go in this block of code, cc.isGrounded is false, which means
                // the last time cc.Move was called, we did not try to enter the ground.
                yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
            }
            else
            {
                // If we are in this block of code, we are on the ground.
                // Set the yVelocity to be some small number to try to push us into
                // the ground and thus make cc.isGrounded be true.
                yVelocity = -2;


                // JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
                // make the player start moving upwards, and gravity will start slowing the movement upward
                // and eventually make the player hit the ground (thus landing in the 'if' statment above)
                if (Input.GetKeyDown(KeyCode.J))
                {
                    yVelocity = jumpForce;
                }
            }

            // --- TRANSLATION ---
            // Move the player forward based on the vAxis value
            // Note, If the player isn't pressing up or down, vAxis will be 0 and there will be no movement
            // based on input. However, yVelocity will still move the player downward.
            Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
            amountToMove.y = yVelocity;

            // This will move the player according to the forward vector and the yVelocity using the
            // CharacterController.
            cc.Move(amountToMove * Time.deltaTime);
            setIsWithMe();
        }
    }
}
