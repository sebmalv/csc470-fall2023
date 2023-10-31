using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuetzalController : MonoBehaviour
{
    public float FlySpeed;
    public float YawAmount = 120;
    private float Yaw;
    Vector3 oldCamPos;
    public GameObject cameraObject;
    public Slider fuelMeter;
    public GameObject head;
    public GameObject bodyone;
    public GameObject bodytwo;
    public GameObject bodythree;
    public TMP_Text winner;
    public TMP_Text isKeyHere;
    public TMP_Text actualScore;
    Renderer rend;
    bool isWithMe; // checks if quetzal or character is active
    public int score;
    public bool isKey;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void keyGot()
    {
        isKey = true;
        isKeyHere.text = "You Got It!";
    }

    public void youWon()
    {
        if (isKey == true)
        {
            winner.text = "YOU WON!";

        }
    }

    public void updateScore()
    {
        score = score + 1;
        actualScore.text = score.ToString();
    }
    public void putCamera()
    {
        // CAMERA
        Vector3 newCamPos = transform.position + -transform.forward * 10 + Vector3.up * 5;
        if (oldCamPos == null)
        {
            oldCamPos = newCamPos;
        }
        cameraObject.transform.position = newCamPos;
        cameraObject.transform.LookAt(transform);
        oldCamPos = newCamPos;

    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Rings")
        {
            Renderer rend = head.GetComponent<Renderer>();
            rend.material.color = Color.red;
            Renderer rend2 = bodyone.GetComponent<Renderer>();
            rend2.material.color = Color.yellow;
            Renderer rend3 = bodytwo.GetComponent<Renderer>();
            rend3.material.color = Color.red;
            Renderer rend4 = bodythree.GetComponent<Renderer>();
            rend4.material.color = Color.yellow;
            if (fuelMeter.value < 700)
            {
                fuelMeter.value = fuelMeter.value + 100;
            }
            else
            {
                fuelMeter.value = fuelMeter.value + 1;
            }
            //If the GameObject has the same tag as specified, output this message in the console
        }
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("fixing");
            Rigidbody r = gameObject.GetComponent<Rigidbody>();
            r.isKinematic = true;
            r.useGravity = false;
            fuelMeter.value = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rings")
        {
            Renderer rend = head.GetComponent<Renderer>();
            rend.material.color = Color.yellow;
            Renderer rend2 = bodyone.GetComponent<Renderer>();
            rend2.material.color = Color.red;
            Renderer rend3 = bodytwo.GetComponent<Renderer>();
            rend3.material.color = Color.yellow;
            Renderer rend4 = bodythree.GetComponent<Renderer>();
            rend4.material.color = Color.red;
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        FlySpeed = 80;
        //move forward
        if(fuelMeter.value>2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.forward * FlySpeed * Time.deltaTime;
                fuelMeter.value = fuelMeter.value - 0.5f;
            }
            //input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // yaw pitch roll movements
            Yaw += horizontalInput * YawAmount * Time.deltaTime;
            float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput) * Mathf.Sign(verticalInput));
            float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput) * -Mathf.Sign(horizontalInput));
            transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
            if (Input.GetKey(KeyCode.UpArrow))
            {

                // Move the object upward in world space 1 unit/second.
                transform.Translate(0, 90 * Time.deltaTime, 0, Space.World);
            }

        }
        else
        {
            Debug.Log("almost");
            if (fuelMeter.value != 1)
            {
                Debug.Log("going down");
                Rigidbody r = gameObject.GetComponent<Rigidbody>();
                r.isKinematic = false;
                r.useGravity = true;
            }
        }


        // CAMERA
        Vector3 newCamPos = transform.position + -transform.forward * 10 + Vector3.up * 5;
        if (oldCamPos == null)
        {
            oldCamPos = newCamPos;
        }
        cameraObject.transform.position = newCamPos;
        cameraObject.transform.LookAt(transform);
        oldCamPos = newCamPos;


    }
}
