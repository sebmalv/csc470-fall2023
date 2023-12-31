using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayerScript : MonoBehaviour
{
    float moveSpeed;
    public float jumpHeight = 7f;
    private CharacterController controller;
    private Vector3 velocity;
    public float rotationSpeed = 10f;
    private bool isGrounded;
    public GameObject healthMeter;
    public GameObject healthParticles;
    public GameObject cameraObject;
    Vector3 oldCamPos;
    GameObject gameManager;

    void Start()

    {
        moveSpeed = 45;
        controller = GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    public void healthChange(string posorneg)
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            gameManager.GetComponent<GameManagerScript>().isItTimeToBattle();
        }
        if (other.gameObject.tag == "Cave")
        {
            string village = "VillageScene";
            SceneManager.LoadScene(village);
        }
        if (other.gameObject.tag == "CaveTwo")
        {
            string village = "BossBattleScene";
            SceneManager.LoadScene(village);
        }
        if (other.gameObject.tag == "Villager")
        {
            Transform tr= other.gameObject.GetComponent<Transform>();
            transform.LookAt(tr);
            gameManager.GetComponent<VillageManager>().villagerEncounter();
        }




    }
    public void setIsWithMe()
    {
        // CAMERA
        Vector3 newCamPos = transform.position + -transform.forward * 30 + Vector3.up * 7;
        cameraObject = GameObject.FindWithTag("MainCamera");
        if (oldCamPos == null)
        {
            oldCamPos = newCamPos;
        }
        cameraObject.transform.position = newCamPos;
        cameraObject.transform.LookAt(transform);
        oldCamPos = newCamPos;

    }

    void Update()
    {

        setIsWithMe();
        // Check if the character is on the ground
        isGrounded = controller.isGrounded;

        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize(); // Normalize to ensure diagonal movement is not faster

        // Apply movement to the player
        controller.Move(movement * moveSpeed * Time.deltaTime);
        // Rotate the character to face the movement direction
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Jumping
        if (isGrounded)
        {
            // Reset velocity if grounded
            velocity.y = -2f;

            if (Input.GetKeyDown("space"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            }
        }

        // Apply gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // Apply final movement with gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
