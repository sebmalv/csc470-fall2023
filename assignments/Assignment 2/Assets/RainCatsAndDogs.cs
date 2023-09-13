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
        while (number<=30){
            int x= 1;
            int y= 1;
            int z= number;
            Vector3 pos = new Vector3(x, y, z);
            GameObject adPreFabobj= Instantiate(adPreFab, pos, Quaternion.identity);
            number+= 5;
    }
        number= 30;
        if(number==30){
                firstCircle= adPreFab;}
        int numb2= 0;
        while(numb2<=30){
            int x= 5;
            int y= 1;
            int z= numb2;
            Vector3 pos = new Vector3(x, y, z);
            GameObject ringTailObj= Instantiate(ringTailPreFab, pos, Quaternion.identity);
            numb2+=5;

        }
        }

         
    

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
        Rigidbody rb= firstCircle.GetComponent<Rigidbody>();
        rb.AddForce(firstCircle.transform.forward*(100));}
        
    }
}
