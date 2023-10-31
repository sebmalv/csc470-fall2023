using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerretMove : MonoBehaviour
{
    public Rigidbody rg;
    public Vector3 startPos;
    public Vector3 endPos;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        startPos = transform.position;
        endPos= new Vector3(startPos.x + 30, startPos.y, startPos.z);
        target = new Vector3(startPos.x + 30, startPos.y, startPos.z);
    }

    public void destroyMe()
    {
        Destroy(this.gameObject);
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


// Update is called once per frame
void Update()
    {

    }
}
