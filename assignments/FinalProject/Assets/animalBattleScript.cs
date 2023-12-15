using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class animalBattleScript : MonoBehaviour
{
    public GameObject[] animalsToPickFrom;
    public string beginningScene;
    public GameObject[] pickedAnimals = new GameObject[3];
    public Vector3[] spawnPoints = new Vector3[3];
    private List<string> animalsPotonNames = new List<string>();
    private List<string> animalsEnglishNames = new List<string>();
    Dictionary<string, string> languageDictionary;
    string correctAnimal;
    string potonCorrectName;
    public float launchForce = 200f;
    public TMP_Text whichAnimal;
    public TMP_Text dictionary;
    public Button buttonOne;
    public Button jade;
    public GameObject backGround;
    int amountofJade;
    public Button buttonTwo;
    public Button buttonThree;
    public GameObject[] arrowsForOne;
    public GameObject[] arrowsForTwo;
    public GameObject[] arrowsForThree;
    int correctAnimalOriginalPosition;
    int correctQuizzes;
    int numberOfObjectsToPick = 3;
    bool battleContinue;
    int leftTries;
    GameObject mainPlayer;
    GameObject collided;

    // Start is called before the first frame update
    void Start()
    {
        backGround.SetActive(false);
        dictionary.gameObject.SetActive(false);
        jade.onClick.AddListener(jadeButtonClick);
        amountofJade = PlayerPrefs.GetInt("Jade");
        jade.gameObject.SetActive(false);
        beginningScene = "BeginningScene";
        arrowsForOne[0].SetActive(false);
        arrowsForOne[1].SetActive(false);
        arrowsForOne[2].SetActive(false);
        arrowsForTwo[0].SetActive(false);
        arrowsForTwo[1].SetActive(false);
        arrowsForTwo[2].SetActive(false);
        arrowsForThree[0].SetActive(false);
        arrowsForThree[1].SetActive(false);
        arrowsForThree[2].SetActive(false);
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        buttonOne.onClick.AddListener(buttonOneChange);
        buttonTwo.onClick.AddListener(buttonTwoChange);
        buttonThree.onClick.AddListener(buttonThreeChange);
        languageDictionary = new Dictionary<string, string>();
        animalsPotonNames = new List<string>() {
        "Kashlan","Guay","Shingo","Arka","Shuri","Kobobo","Susu"};
        animalsEnglishNames = new List<string>() {
        "Chicken(Clone)","Racoon(Clone)","Cat(Clone)", "Snake(Clone)","Squirell(Clone)","Toad(Clone)","Dog(Clone)"};
        setDictionary();
        animalBattle();
        correctQuizzes = PlayerPrefs.GetInt("correctQuizzes");
        leftTries = 2;
    }

    public void setCollided(GameObject other)
    {
        string n = other.name;
        if (n == correctAnimal)
        {
            amountofJade = amountofJade + 5;
            correctQuizzes = correctQuizzes + 1;
            whichAnimal.text = "Yes! That is a" + " " + potonCorrectName + "!";
            leftTries = 0;
        }
        if (n != correctAnimal)
        {
            string poton = animalEnglishToPoton(other.name);
            whichAnimal.text = "Try again! That is a"+ " "+ poton+ " "+ "Shoot the" + " " + potonCorrectName + "!";
            leftTries = leftTries-1;
            if (amountofJade > 5)
            {
                amountofJade = amountofJade - 5;
            }

        }
    }
    public string animalEnglishToPoton(string animalEnglishName)
    {
        string potonName = "";
        // Check if the sign exists in the dictionary
        if (languageDictionary.ContainsKey(animalEnglishName))
        {
            // Return the translation
            potonName = languageDictionary[animalEnglishName];
        }

        return potonName;
    }

    void buttonOneChange()
    {
        arrowsForOne[0].SetActive(true);
        arrowsForOne[1].SetActive(true);
        arrowsForOne[2].SetActive(true);

    }

    void buttonTwoChange()
    {
        arrowsForTwo[0].SetActive(true);
        arrowsForTwo[1].SetActive(true);
        arrowsForTwo[2].SetActive(true);

    }
    void buttonThreeChange()
    {
        arrowsForThree[0].SetActive(true);
        arrowsForThree[1].SetActive(true);
        arrowsForThree[2].SetActive(true);

    }

    void setDictionary()
    {
        for (int i = 0; i < 7; i++)
        {
            languageDictionary.Add(animalsEnglishNames[i], animalsPotonNames[i]);
        }

    }
    void pickCorrectAnimal()
    {
        int randomIndex2 = Random.Range(0, 2);
        correctAnimal = pickedAnimals[randomIndex2].name;
        string potonCorrect = animalEnglishToPoton(correctAnimal);
        potonCorrectName = potonCorrect;
        Debug.Log(correctAnimal);
        whichAnimal.text = "Shoot the" + " " + potonCorrect + "!";

    }
    void pickAnimalsInBattle()
    {
        // Pick a random index
        int randomIndex = Random.Range(0, animalsToPickFrom.Length - 1);
        if (randomIndex == animalsToPickFrom.Length - 1)
        {
            pickedAnimals[0] = Instantiate(animalsToPickFrom[randomIndex], spawnPoints[0],Quaternion.identity);
            pickedAnimals[1] = Instantiate(animalsToPickFrom[randomIndex - 1], spawnPoints[1], Quaternion.identity);
            pickedAnimals[2] = Instantiate(animalsToPickFrom[randomIndex-2], spawnPoints[2], Quaternion.identity);
            correctAnimalOriginalPosition = randomIndex;

        }
        if (randomIndex == 0)
        {
            pickedAnimals[0] = Instantiate(animalsToPickFrom[randomIndex], spawnPoints[0], Quaternion.identity);
            pickedAnimals[1] = Instantiate(animalsToPickFrom[randomIndex + 1], spawnPoints[1], Quaternion.identity);
            pickedAnimals[2] = Instantiate(animalsToPickFrom[randomIndex + 2], spawnPoints[2], Quaternion.identity);
            correctAnimalOriginalPosition = randomIndex;

        }
        if (randomIndex != 0 && randomIndex != animalsToPickFrom.Length - 1)
        {
            pickedAnimals[0] = Instantiate(animalsToPickFrom[randomIndex], spawnPoints[0], Quaternion.identity);
            pickedAnimals[1] = Instantiate(animalsToPickFrom[randomIndex - 1], spawnPoints[1], Quaternion.identity);
            pickedAnimals[2] = Instantiate(animalsToPickFrom[randomIndex + 1], spawnPoints[2], Quaternion.identity);
            correctAnimalOriginalPosition = randomIndex;
        }
        pickCorrectAnimal();

    }

    void animalBattle()
    {
        pickAnimalsInBattle();

    }
    void jadeButtonClick()
    {
        backGround.SetActive(true);
        dictionary.gameObject.SetActive(true);
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
        amountofJade = amountofJade - 5;
        PlayerPrefs.SetInt("Jade", amountofJade);
        Invoke("closeDic", 5f);

    }
    void closeDic()
    {
        if (amountofJade < 5)
        {
          jade.gameObject.SetActive(false);

        }

        dictionary.gameObject.SetActive(false);
        backGround.SetActive(false);
        buttonOne.gameObject.SetActive(true);
        buttonTwo.gameObject.SetActive(true);
        buttonThree.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (amountofJade >= 5)
        {
            jade.gameObject.SetActive(true);

        }

        if (leftTries == 0)
        {
            PlayerPrefs.SetInt("correctQuizzes", correctQuizzes);
            PlayerPrefs.SetInt("Jade", amountofJade);
            SceneManager.LoadScene(beginningScene);
        }
        
        
    }
}
