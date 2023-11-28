using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerEnemyScript : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 target;
    public GameObject spawn;
    public GameObject end;
    bool amAlive;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void setAlive()
    {
        amAlive = true;
        this.gameObject.SetActive(true);
    }
    public bool isAlive()
    {
        return amAlive;
    }
    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        if (currentPos == startPos)
        {
            target = endPos;
        }
        else if (currentPos == endPos)
        {
            target = startPos;
        }
        if (transform.position != target) transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Debug.Log("Dead Deer");
            amAlive = false;
            this.gameObject.SetActive(false);
        }

    }
    public void setSpawnAndEnd(GameObject s, GameObject e)
    {
        this.spawn = s;
        this.end = e;
        startPos = spawn.transform.position;
        endPos = end.transform.position;
        target = end.transform.position;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
