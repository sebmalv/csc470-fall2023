using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public GameObject door;
    public Vector3 startPos;
    public Vector3 endPos;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        startPos = door.transform.position;
        endPos = new Vector3(startPos.x, startPos.y-19, startPos.z);
        target = new Vector3(startPos.x, startPos.y-19, startPos.z);
    }

    public void openDoor()
    {
        Vector3 currentPos = door.transform.position;

        if (currentPos == startPos)
        {
            target = endPos;
        }
        else if (currentPos == endPos)
        {
            target = startPos;
        }
        door.transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
