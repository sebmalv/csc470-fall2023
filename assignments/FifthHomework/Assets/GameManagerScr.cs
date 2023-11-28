using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScr : MonoBehaviour
{
    public GameObject cornMeter;
    public static GameManagerScr SharedInstance;
    public GameObject deerPrefab;
    public GameObject[] deerEnemies;
    public GameObject[] spawns;
    public GameObject[] ends;
    public TMP_Text theInstructions;
    public bool areInstructions;
    public bool allDeerAreAlive;
    public int amountOfDeerDead;
    public TMP_Text btnText;
    public int score;
    public TMP_Text winning;
   
    // Start is called before the first frame update

    void Awake()
    {
        if (SharedInstance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
        }
        SharedInstance = this;
        areInstructions = true;

    }


        void Start()
    {
        createDeer();
        amountOfDeerDead = 0;
        score = 0;
        winning.gameObject.SetActive(false);
    }

    public void youWon()
    {
        winning.gameObject.SetActive(true);

    }

    public void updateScore()
    {
        score = score + 5;
        string theScore = score.ToString();
        btnText.text = theScore;
        if (score == 15)
        {
            youWon();
        }
    }

    void createDeer()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            GameObject spawnPoint = spawns[i];
            Vector3 spawnPos = spawnPoint.transform.position;
            deerEnemies[i] = Instantiate(deerPrefab, spawns[i].transform);
            deerEnemies[i].GetComponent<DeerEnemyScript>().setSpawnAndEnd(spawns[i], ends[i]);
            deerEnemies[i].GetComponent<DeerEnemyScript>().setAlive();


        }
        allDeerAreAlive = true;

    }
    public bool checkIfAllDeerDead()
    {
        for (int i = 0; i < 10; i++)
        {
            bool deerAlive= deerEnemies[i].GetComponent<DeerEnemyScript>().isAlive();
            if (deerAlive != true)
            {
                amountOfDeerDead = amountOfDeerDead + 1;
            }
            
        }
        if (amountOfDeerDead == 10)
        {
            allDeerAreAlive = false;
        }
        else
        {
            allDeerAreAlive = true;
        }
        amountOfDeerDead = 0;
        return allDeerAreAlive;
    }
    public void setAllDeerAlive()
    {

        for (int i = 0; i < 10; i++)
        {
            deerEnemies[i].GetComponent<DeerEnemyScript>().setAlive();
        }
    }
    public void setInstructions()
    {
        theInstructions.gameObject.SetActive(true);
        areInstructions = true;

    }
    public void clearInstructions()
    {
        theInstructions.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            setInstructions();
        }
        bool deersStatus = checkIfAllDeerDead();
        if (areInstructions == true)
        {
            this.Invoke("clearInstructions", 5f);
            areInstructions = false;
        }

        if (deersStatus == false)
        {
            Debug.Log("Deer Are Back");
            this.Invoke("setAllDeerAlive",10f);

        }

    }
}

