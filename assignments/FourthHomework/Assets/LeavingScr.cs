using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingScr : MonoBehaviour
{
    public GameObject quetzal;
    QuetzalController qcontrol;
    GameObject actualLittleGuy;
    // Start is called before the first f
    // rame update
    void Start()
    {
        quetzal = GameObject.FindGameObjectWithTag("Quetzal");
        qcontrol= quetzal.GetComponent<QuetzalController>();

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LittleGuy")
        {
            Debug.Log("Delete little guy");
            LittleGuyMovement littleGuyHere = other.GetComponent<LittleGuyMovement>();
            littleGuyHere.destroyMe();
            qcontrol.putCamera();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
