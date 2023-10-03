using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject self1;
    public GameObject transform;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void GetRid()
    {
        Destroy(self1,0.8f);
        Destroy(this.gameObject,0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
