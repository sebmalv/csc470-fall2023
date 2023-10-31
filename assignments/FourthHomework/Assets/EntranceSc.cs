using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSc : MonoBehaviour
{
    public GameObject littleGuy;
    GameObject actualLittleGuy;
    public GameObject spawn;
    LittleGuyMovement moving;
    GameObject quetzal;
    public bool isHeThere;
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        isHeThere = false;
        spawnPoint = spawn.GetComponent<Transform>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isHeThere == false)
        {
            if (other.gameObject.tag == "Quetzal")
            {
                quetzal = other.gameObject;
                Debug.Log("littleguy loading");
                actualLittleGuy= Instantiate(littleGuy, spawnPoint.position, spawnPoint.rotation);
                moving = actualLittleGuy.GetComponent<LittleGuyMovement>();
                moving.setIsWithMe();
                isHeThere = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
