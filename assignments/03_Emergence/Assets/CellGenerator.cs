using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{

    public GameObject cellPreFab;
    CellScript[,] allCells;
    int cellSize;
    // Start is called before the first frame update
    void Start()
    {

        cellSize = 10;
        allCells = new CellScript[10, 10];
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // Create a position based on x, y
                Vector3 pos = transform.position;
                float cellWidth = 1;
                float spacing = 0.1f;
                pos.x = pos.x + x * (cellWidth + spacing);
                pos.z = pos.z + y * (cellWidth + spacing);
                pos.y = 1;
                GameObject cellObj = Instantiate(cellPreFab, pos, transform.rotation);
                // (x,y) is the index in the 2D array. Store a reference to the
                // CellScript of the instantiated object because that is the
                // object that contains the information we will be intereated in
                // (the 'alive' variable.
                allCells[x, y] = cellObj.GetComponent<CellScript>();
                cellObj.GetComponent<CellScript>().randomAliveOrDead();
                cellObj.GetComponent<CellScript>().setBulletPosition(pos.x,pos.z);
                cellObj.GetComponent<CellScript>().addBullet();

            }
        }
  
    }
    void GameOfLife()
    {
        //go through each one and check if they should be alive or dead
        // if theyre alive have a capsule fall on them
        for (int x1 = 0; x1 < 10; x1++)
        {
            for (int y1 = 0; y1 < 10; y1++)
            {
                if (x1 == 0)
                {
                    if (y1 == 0)
                      
                    {
                        CellScript cellobj = allCells[x1, y1];

                        int size = 3;
                        int[] actualNeighbors = new int[size];
                        int yIndex2 = y1 + 1;
                        int xIndex2 = x1 + 1;
                        CellScript cellObj1 = allCells[x1, yIndex2]; //gets the one to right
                        CellScript cellObj2 = allCells[xIndex2, y1]; //gets one under it
                        CellScript cellObj3 = allCells[xIndex2, yIndex2]; // parellel
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                    if (y1 >= 1 && y1 <= 8)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 5;
                        int[] actualNeighbors = new int[size];
                        int yIndex1 = y1 - 1; // gets one ontop
                        int yIndex2 = y1 + 1; //gets one right of it
                   
                        int xIndex2 = x1 + 1; //gets one under it
                        CellScript cellObj1 = allCells[x1, yIndex2]; //right of it
                        
                        CellScript cellObj2 = allCells[xIndex2, yIndex2];//parellel
                        CellScript cellObj3 = allCells[xIndex2, y1]; //under it
                        CellScript cellObj4 = allCells[xIndex2, yIndex2]; //other paralell
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
            
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        int cellObj4Status = cellObj4.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
        
                        actualNeighbors[2] = cellObj2Status;
                        actualNeighbors[3] = cellObj3Status;
                        actualNeighbors[4] = cellObj4Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                    if (y1 == 9)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 3;
                        int[] actualNeighbors = new int[size];
                        int yIndex2 = y1 + 1;
                        int yIndex1 = y1 - 1;
                        int xIndex1 = x1 + 1;
                        int xIndex2 = x1 - 1;
                        CellScript cellObj1 = allCells[x1, yIndex1];// gets left
                        CellScript cellObj2 = allCells[xIndex1, y1]; //gets bottom
                        CellScript cellObj3 = allCells[xIndex1, yIndex1]; //gets parellel
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }


                }
                if(x1>=1 && x1 <= 8)
                {
                    if (y1 == 0)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 5;
                        int[] actualNeighbors = new int[size];
                        int xIndex1 = x1 - 1; // gets one ontop
                        int yIndex2 = y1 + 1;
                        int yIndex1 = y1 - 1;
                        int xIndex2 = x1 + 1; //gets one under it
                        CellScript cellObj1 = allCells[xIndex1, y1]; //over it
                        CellScript cellObj2 = allCells[x1, yIndex2];//right of it
                        CellScript cellObj3 = allCells[xIndex2, yIndex2];//parellel
                        CellScript cellObj4 = allCells[xIndex2, y1]; //under it
                        CellScript cellObj5 = allCells[xIndex1, yIndex2]; //other paralell
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        int cellObj4Status = cellObj4.returnDeadOrAlive();
                        int cellObj5Status = cellObj5.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        actualNeighbors[3] = cellObj4Status;
                        actualNeighbors[4] = cellObj5Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);

                    }
                    if(y1 >= 1 && y1 <= 8)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 8;
                        int[] actualNeighbors = new int[size];
                        int yIndex1 = y1 + 1;
                        int xIndex1 = x1 + 1;
                        int yIndex2 = y1 - 1;
                        int xIndex2 = x1 - 1;
                        CellScript cellObj1 = allCells[x1, yIndex1];// gets right
                        CellScript cellObj2 = allCells[xIndex2, y1]; //gets ontop
                        CellScript cellObj3 = allCells[xIndex2, yIndex2]; //gets top left parellel
                        CellScript cellObj4 = allCells[xIndex2, yIndex1]; //gets top right parellel
                        CellScript cellObj5 = allCells[x1, yIndex2];// gets left
                        CellScript cellObj6 = allCells[xIndex1, y1]; //gets bottom
                        CellScript cellObj7 = allCells[xIndex1, yIndex1];// gets bottom right paralell
                        CellScript cellObj8 = allCells[xIndex1, yIndex2]; //gets bottom left paralel
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        int cellObj4Status = cellObj4.returnDeadOrAlive();
                        int cellObj5Status = cellObj5.returnDeadOrAlive();
                        int cellObj6Status = cellObj6.returnDeadOrAlive();
                        int cellObj7Status = cellObj7.returnDeadOrAlive();
                        int cellObj8Status = cellObj8.returnDeadOrAlive();

                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        actualNeighbors[3] = cellObj4Status;
                        actualNeighbors[4] = cellObj5Status;
                        actualNeighbors[5] = cellObj6Status;
                        actualNeighbors[6] = cellObj7Status;
                        actualNeighbors[7] = cellObj8Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());

                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                    if (y1 == 9)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 5;
                        int[] actualNeighbors = new int[size];
                        int yIndex2 = y1 - 1;
                        int xIndex2 = x1 - 1;
                        int xIndex1 = x1 + 1;
                        CellScript cellObj1 = allCells[x1, yIndex2];// gets left
                        CellScript cellObj2 = allCells[xIndex2, y1]; //gets ontop
                        CellScript cellObj3 = allCells[xIndex2, yIndex2]; //gets top left parellel
                        CellScript cellObj4 = allCells[xIndex1, y1]; //gets under
                        CellScript cellObj5 = allCells[x1, yIndex2]; //gets left bottom
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        int cellObj4Status = cellObj4.returnDeadOrAlive();
                        int cellObj5Status = cellObj5.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        actualNeighbors[3] = cellObj4Status;
                        actualNeighbors[4] = cellObj5Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                }
                if (x1 == 9)
                {
                    if (y1 == 0)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 3;
                        int[] actualNeighbors = new int[3];
                        int yIndex2 = y1 - 1;
                        int yIndex1 = y1 + 1;
                        int xIndex2 = x1 - 1;
                        CellScript cellObj1 = allCells[x1, yIndex1]; //gets one right of it
                        CellScript cellObj2 = allCells[xIndex2, y1]; //gets top of it
                        CellScript cellObj3 = allCells[xIndex2, yIndex1]; //gets parallel
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        actualNeighbors[2] = cellObj3Status;
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);

                    }
                    if (y1 >= 1 && y1 <= 8)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 5;
                        int[] actualNeighbors = new int[size];
                        int yIndex2 = y1 - 1;
                        int yIndex1 = y1 + 1;
                        int xIndex1 = x1 + 1;
                        int xIndex2 = x1 - 1;
                        CellScript cellObj1 = allCells[x1, yIndex1]; //right of it
                        CellScript cellObj2 = allCells[x1, yIndex2];//left of it
                        CellScript cellObj3 = allCells[xIndex2, yIndex2];//parellel
                        CellScript cellObj4 = allCells[xIndex2, y1]; //top of it
                        CellScript cellObj5 = allCells[xIndex2, yIndex1]; //other paralell
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        int cellObj4Status = cellObj4.returnDeadOrAlive();
                        int cellObj5Status = cellObj5.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        actualNeighbors[3] = cellObj4Status;
                        actualNeighbors[4] = cellObj5Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                    if (y1 == 9)
                    {
                        CellScript cellobj = allCells[x1, y1];
                        int size = 3;
                        int[] actualNeighbors = new int[3];
                        int yIndex2 = y1 - 1;
                        int xIndex2 = x1 - 1;
                        int yIndex1 = y1 + 1;
                        CellScript cellObj1 = allCells[x1, yIndex2];// gets left
                        CellScript cellObj2 = allCells[xIndex2, y1]; //gets ontop
                        CellScript cellObj3 = allCells[xIndex2, yIndex2]; //gets parellel
                        int cellObj1Status = cellObj1.returnDeadOrAlive();
                        int cellObj2Status = cellObj2.returnDeadOrAlive();
                        int cellObj3Status = cellObj3.returnDeadOrAlive();
                        actualNeighbors[0] = cellObj1Status;
                        actualNeighbors[1] = cellObj2Status;
                        actualNeighbors[2] = cellObj3Status;
                        Debug.Log("x and y should be this:");
                        Debug.Log(x1.ToString());
                        Debug.Log(y1.ToString());
                        cellobj.neighborDeadOrAlive(actualNeighbors, size);
                    }
                }

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
            GameOfLife();

  
   
    }
}
