using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public bool isItActive;
    // Start is called before the first frame update
    void Start()
    {
        isItActive = false;
    }

    public void setAsAlive()
    {
        isItActive = true;
    }

    public bool isAlive()
    {
        return isItActive;
    }
    public void setAsDead()
    {
        isItActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
