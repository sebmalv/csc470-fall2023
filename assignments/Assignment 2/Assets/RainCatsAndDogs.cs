using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCatsAndDogs : MonoBehaviour{

    // Start is called before the first frame update
    public GameObject adPreFab;
    public GameObject ringTailPreFab;
    public GameObject circle;
    GameObject firstCircle;
    void Start()
    {
    
        generateRain();
  
        
    }
    void generateRain()
    {
        int number= 0;
        while (number<=50){
            int x= 8;
            int y= 5;
            int z= number;
            Vector3 pos = new Vector3(x, y, z);
            GameObject adPreFabobj= Instantiate(adPreFab, pos, Quaternion.identity);
            number+= 10;
            if(number==30){
                firstCircle= adPreFabobj;
            }
        }
        int numb2= 0;
        while(numb2<=50){
            int x= 5;
            int y= 5;
            int z= numb2;
            Vector3 pos = new Vector3(x, y, z);
            GameObject ringTailObj= Instantiate(ringTailPreFab, pos, Quaternion.identity);
            numb2+=10;
        }
    }

         
    

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
        Debug.Log("Yes working");
        Rigidbody rb= firstCircle.GetComponent<Rigidbody>();
        if(rb!=null){
            rb.AddForce(firstCircle.transform.forward*(300000));}

        }
        
    }
}
