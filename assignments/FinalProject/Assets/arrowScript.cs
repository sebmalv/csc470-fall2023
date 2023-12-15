using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    GameObject gm;
    bool collisionDone;
    // Start is called before the first frame update
    void Start()
    {
        collisionDone = false;
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "arrow")
        {
            gm.GetComponent<animalBattleScript>().setCollided(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
