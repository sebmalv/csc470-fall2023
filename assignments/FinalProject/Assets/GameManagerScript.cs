using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//can have agamemanager in each or can transfer game managers over?
public class GameManagerScript : MonoBehaviour
{
    //everytime character encounters a bush, an animal pops out
    //each animal has a script, the script has it's Poton name
    //if they match then the animal dies

    int totalWordsRight;
    public string battleScene;
    public GameObject mainPlayer;
    int jade;
    public TMP_Text jadeAm;
    public TMP_Text battlesWon;
    bool timeToBattle;
    string whatScene;
    Vector3 lastPlayerLocation;
    public GameObject[] bushes = new GameObject[4];
    int numberOfBushes;
    int battleTries;

    // Start is called before the first frame update
    void Start()
    {

        jadeAm.text = "Jade: "+ PlayerPrefs.GetInt("Jade").ToString();
        battlesWon.text= "Battles Won: "+ PlayerPrefs.GetInt("correctQuizzes").ToString();
        numberOfBushes = PlayerPrefs.GetInt("bushNumber");
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        battleScene = "AnimalBattleScene";

    }
    public void isItTimeToBattle()
    {
        timeToBattle = true;
    }
    private void Awake()
    {
    }


    // Update is called once per frame
    void Update()
    {

        if (timeToBattle == true)
        {
            numberOfBushes = numberOfBushes - 1;
            PlayerPrefs.SetInt("bushNumber", numberOfBushes);
            SceneManager.LoadScene(battleScene);
            timeToBattle = false;
        }
        if (numberOfBushes == 3)
        {
            bushes[0].SetActive(false);
        }
        if (numberOfBushes == 2)
        {
            bushes[0].SetActive(false);
            bushes[1].SetActive(false);
        }
        if (numberOfBushes == 1)
        {
            bushes[0].SetActive(false);
            bushes[1].SetActive(false);
            bushes[2].SetActive(false);
        }
        if (numberOfBushes == 0)
        {
            bushes[0].SetActive(false);
            bushes[1].SetActive(false);
            bushes[2].SetActive(false);
            bushes[3].SetActive(false);
        }
    }
}