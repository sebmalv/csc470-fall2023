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
    private List<string> animalsEnglishNames = new List<string>();
    Dictionary<string, string> languageDictionary;
    string correctAnimal;
    int correctAnimalOriginalPosition;
    int correctQuizzes;
    int numberOfObjectsToPick = 3;
    int jade;
    // Start is called before the first frame update
    void Start()
    {
        languageDictionary = new Dictionary<string, string>();
        animalsPotonNames = new List<string>() { "Wakash",
        "Kashlan","Guay","Shingo", "Yaru", "Aguan","Arka","Anan","Shuri","Kobobo","Shua"};
        animalsEnglishNames = new List<string>() { "Cow",
        "Chicken","Racoon"," Cat", "Monkey", "Deer","Snake","Lizard","Squirell","Toad","Coyote"};
        jade = 0;
        correctQuizzes = 0;
        setDictionary();

}
    public string animalEnglishToPoton(string animalEnglishName)
    {
        string finalName = "";
        // Check if the sign exists in the dictionary
        if (languageDictionary.ContainsKey(animalEnglishName))
        {
            // Return the translation
            finalName= languageDictionary[animalEnglishName];
        }

        return finalName;
    }

    void setDictionary()
    {
        for(int i = 0; i < 11; i++)
        {
            languageDictionary.Add(animalsEnglishNames[i], animalsPotonNames[i]);
        }

    }

    void pickCorrectAnimal()
    {
        int randomIndex2 = Random.Range(0, 2);
        correctAnimal = pickedAnimals[randomIndex2].name;

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
            correctAnimalOriginalPosition = randomIndex;

        }
        if (randomIndex == 0)
        {
            pickedAnimals[0]= (animalsToPickFrom[randomIndex]);
            pickedAnimals[1]=(animalsToPickFrom[randomIndex + 1]);
            pickedAnimals[2]=(animalsToPickFrom[randomIndex + 2]);
            correctAnimalOriginalPosition = randomIndex;

        }
        if(randomIndex != 0 && randomIndex != animalsToPickFrom.Length-1)
        {
            pickedAnimals[0]=(animalsToPickFrom[randomIndex]);
            pickedAnimals[1]=(animalsToPickFrom[randomIndex-1]);
            pickedAnimals[2]=(animalsToPickFrom[randomIndex+1]);
            correctAnimalOriginalPosition = randomIndex;
        }
        pickCorrectAnimal();

    }

        void animalBattle()
    {
        pickAnimalsInBattle();




    }

    // Update is called once per frame
    void Update()
    {


    }
}
