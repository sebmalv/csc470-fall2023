using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformS : MonoBehaviour
{
    public GameObject littleGuy;
    GameObject actualLittleGuy;
    LittleGuyMovement moving;
    public GameObject spawn;
    GameObject quetzal;
    Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = spawn.GetComponent<Transform>();
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
