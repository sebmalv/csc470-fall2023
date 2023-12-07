using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //everytime character encounters a bush, an animal pops out
    //each animal has a script, the script has it's Poton name
    //if they match then the animal dies
    
    int totalWordsRight;
    public GameObject[] animalsToPickFrom;
    public GameObject mainPlayer;
    private GameObject[] pickedAnimals = new GameObject[3];
    private List<string> animalsPotonNames = new List<string>();
    string correctAnimal;
    int correctQuizzes;
    int numberOfObjectsToPick = 3;
    int jade;
    // Start is called before the first frame update
    void Start()
    {
        animalsPotonNames= new List<string>() { "Wakash",
        "Kashlan","Guay","Shingo", "Yaru", "Aguan","Arka","Anan","Shuri","Kobobo","Coyote"};
        jade = 0;
        correctQuizzes = 0;

}

    void setDictionary()
    {

    }
    void pickAnimalsInBattle()
    {
      // Pick a random index
      int randomIndex = Random.Range(0, animalsToPickFrom.Length-1);
      if (randomIndex == animalsToPickFrom.Length-1)
        {
            pickedAnimals[0]=(animalsToPickFrom[randomIndex]);
            pickedAnimals[1]=(animalsToPickFrom[randomIndex-1]);
            pickedAnimals[2]=(animalsToPickFrom[randomIndex-2]);

        }
        if (randomIndex == 0)
        {
            pickedAnimals[0]= (animalsToPickFrom[randomIndex]);
            pickedAnimals[1]=(animalsToPickFrom[randomIndex + 1]);
            pickedAnimals[2]=(animalsToPickFrom[randomIndex + 2]);

        }
        if(randomIndex != 0 && randomIndex != animalsToPickFrom.Length-1)
        {
            pickedAnimals[0]=(animalsToPickFrom[randomIndex]);
            pickedAnimals[1]=(animalsToPickFrom[randomIndex-1]);
            pickedAnimals[2]=(animalsToPickFrom[randomIndex+1]);
        }
        Debug.Log(pickedAnimals[0].name);
        Debug.Log(pickedAnimals[1].name);
        Debug.Log(pickedAnimals[2].name);

    }

        void animalBattle()
    {
        int randomIndex = Random.Range(0, 2);



    }

    // Update is called once per frame
    void Update()
    {
        pickAnimalsInBattle();
        
    }
}
