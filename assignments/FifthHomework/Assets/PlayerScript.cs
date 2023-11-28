using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    PlayerScript SharedInstance;
    CharacterController cc;
    public GameObject projectilePrefab;
    float forwardSpeed = 8;
    public GameObject[] arrows;
    public float launchForce = 200f;
    public bool isThereArrow;
    public GameObject arrow;
    public float speed = 5f;
    public float gravity = 9.8f;
    public Vector3 originalSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        createArrows();
    }

    void createArrows()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newObj = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);

            // Deactivate the instantiated object
            newObj.SetActive(false);
            arrows[i] = newObj;

        }
    }
    public void respawnPlayer()
    {
        this.gameObject.SetActive(false);
        this.transform.position = originalSpawn;
        this.gameObject.SetActive(true);
    }
    void Awake()
    {
        if (SharedInstance != null)
        {
            Debug.Log("Why is there more than one Player?");
        }
        SharedInstance = this;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeerEnemy")
        {
            Debug.Log("hi");
            respawnPlayer();
        }
        if (other.gameObject.tag == "OutOfBounds")
        {
            Debug.Log("hi");
            respawnPlayer();
        }

    }

    void aliveAllArrow()
    {
        for (int i = 0; i < 10; i++)
        {
            ArrowScript ar = arrows[i].GetComponent<ArrowScript>();
            ar.setAsAlive();
        }
    }

    public GameObject lookForAlive()
    {
        GameObject usingArrow = null;
        for (int i = 0; i < 10; i++)
        {
            GameObject ar1 = arrows[i];
            ArrowScript ar = arrows[i].GetComponent<ArrowScript>();
            bool isItAlive = ar.isAlive();
            if (isItAlive == false)
            {
                Debug.Log(i);
                usingArrow = arrows[i];
                isThereArrow = true;
                ar.setAsAlive();
                ar.setAsDead();
                break;
            }
            else
            {
                isThereArrow = false;
            }

        }
        if (isThereArrow == false)
        {
            aliveAllArrow();
            usingArrow = arrows[0];

        }

        return usingArrow;
    }

    void shootArrow()
    {
        // Get the mouse position in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            // Instantiate the projectile at the launch point
            GameObject projectile = lookForAlive();
            projectile.transform.position = this.transform.position;
            projectile.SetActive(true);
            // Calculate the launch direction based on the mouse position
            Vector3 launchDirection = (hit.point - this.transform.position).normalized;

            // Apply force to launch the projectile
            projectile.GetComponent<Rigidbody>().velocity = launchDirection * launchForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootArrow();
        }
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement = Vector3.ClampMagnitude(movement, 1f); // Ensure diagonal movement is not faster

        // Move the player
        cc.Move(movement * speed * Time.deltaTime);
    }
    }
