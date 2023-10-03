using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellScript : MonoBehaviour
{
    // 0== dead, 1== alive 
    public int deadOrAlive;
    int[] neighbors;
    public GameObject bulletPreFab;
    GameObject cellBullet;
    float bulletxPosition;
    float bulletzPosition;
    bool isThereBullet;
    bool presentBullet;
    BulletScript[,] cellBulletScript;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void setBulletPosition(float x, float z)
    {
        bulletxPosition = x;
        bulletzPosition = z;
        presentBullet = false;

    }
    public void removeBullet()
    {
        //this.cellBulletScript[0,0].GetComponent<>
    }

    public int returnDeadOrAlive()
    {
        return this.deadOrAlive;
    }
    public void setIsThereBullet(int IsIt)
    {
        if (IsIt == 0)
        {
            this.isThereBullet = false;
        }
        if (IsIt == 1)
        {
            this.isThereBullet = true;
        }

    }
    public void setAliveOrDead(int isIt)
    {
        deadOrAlive = isIt;

    }

    public void addBullet()
    {
        bool isThere = this.isThereBullet;
        if (isThere == true)
        {
            cellBulletScript= new BulletScript[10, 10];
            Vector3 pos = transform.position;
            pos.y = 6;
            Debug.Log("adding");
            cellBullet = Instantiate(bulletPreFab, pos, transform.rotation);
            cellBulletScript[0,0]= cellBullet.GetComponent<BulletScript>();
            presentBullet = true;  
        }
    }


    public void destroyBullet()
    {
        bool isThere = this.isThereBullet;
        Debug.Log("before destroying");
        cellBulletScript[0,0].GetRid();
        Debug.Log("destroying");
        presentBullet = false;

    }

    public void neighborDeadOrAlive(int[] list,int size)
    {
        neighbors = list;
        int amountofAlive=0;
  
        int size1 = size;
        int copyOfDeadOrAlive = deadOrAlive + 0;
        for (int i= 0; i < size1; i++)
        {
            int aliveOrDead = neighbors[i];
            if (aliveOrDead == 1)
            {
                amountofAlive = amountofAlive + 1;
                Debug.Log("Neighbors");
            }
        }
        Debug.Log(amountofAlive.ToString());
        Debug.Log(copyOfDeadOrAlive.ToString());
        if (copyOfDeadOrAlive==1)
        {
            if (amountofAlive < 2)
            {
                this.setAliveOrDead(0);
                this.setIsThereBullet(0);
                this.destroyBullet();
            }
            if (amountofAlive == 2 || amountofAlive == 3)
            {
                this.setAliveOrDead(1);
                this.setIsThereBullet(1);
            }
            if (amountofAlive >= 4)
            {
                this.setAliveOrDead(0);
                this.setIsThereBullet(0);
                this.destroyBullet();
            }
        }
        if (copyOfDeadOrAlive == 0)
        {
            if (amountofAlive == 3)
            {
                this.setAliveOrDead(1);
                this.setIsThereBullet(1);
                this.addBullet();
            }

        }
    }
    public void OnMouseDown()

    {
        Debug.Log("Adding bullet 1");
        if (presentBullet == false)
        {
            isThereBullet = true;
            addBullet();
            Debug.Log("Adding bullet 2");

        }
    }

    public void randomAliveOrDead()
    {
        this.setAliveOrDead(1);
        deadOrAlive = Random.Range(0,2);
        int n = this.returnDeadOrAlive();
        this.setIsThereBullet(n);
        Debug.Log(deadOrAlive.ToString());
    }


    // Update is called once per frame
    void Update()
    {


    }
}
