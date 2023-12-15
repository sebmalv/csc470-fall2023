using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    private List<string> prompts = new List<string>();
    private List<string> answers = new List<string>();
    string currentPrompt;
    string correctAnswer;
    public Button answerOne;
    public Button answerTwo;
    public Button answerThree;
    int jadeAm;
    public TMP_Text jadeAmount;
    public TMP_Text correctQuizz;
    public TMP_Text villagerDiscussion;
    int tries;
    int correctQuizzes;
    int whichVillager;
    public GameObject[] villagers;

    // Start is called before the first frame update
    void Start()
    {
        whichVillager = 0;
        tries = 0;
        correctQuizz.text = "Battles Won " +PlayerPrefs.GetInt("correctQuizzes").ToString();
        correctQuizzes = PlayerPrefs.GetInt("correctQuizzes");
        jadeAmount.text = "Jade: " +PlayerPrefs.GetInt("Jade").ToString();
        jadeAm = PlayerPrefs.GetInt("Jade");
        answerOne.onClick.AddListener(answerOneClick);
        answerTwo.onClick.AddListener(answerTwoClick);
        answerThree.onClick.AddListener(answerThreeClick);
        answerOne.gameObject.SetActive(false);
        answerTwo.gameObject.SetActive(false);
        answerThree.gameObject.SetActive(false);
        villagerDiscussion.gameObject.SetActive(false);
        prompts = new List<string>() { "What is a man after he gets married?", "What is inside of your limbs?", "What comes before nine?" };
        answers = new List<string>() { "Ashu", "Seig", "Guizka" };

    }
    void answerOneClick()
    {
        if (correctAnswer == answers[0])
        {
            jadeAm = jadeAm + 5;
            jadeAmount.text = "Jade: " + jadeAm;
            correctQuizzes = correctQuizzes + 1;
            villagerDiscussion.text = "You know so much! Here's some jade for your troubles!";
            villagers[whichVillager].SetActive(false);
            answerOne.gameObject.SetActive(false);
            answerTwo.gameObject.SetActive(false);
            answerThree.gameObject.SetActive(false);
            whichVillager = whichVillager + 1;
        }
        if (correctAnswer != answers[0])
        {
            tries = tries + 1;
            villagerDiscussion.text = "It's okay, try again!" + currentPrompt;
            if (tries == 2)
            {
                villagerDiscussion.text = "Aw, man, better luck next time! Gotta go!";
                villagers[whichVillager].SetActive(false);
                whichVillager = whichVillager + 1;
                answerOne.gameObject.SetActive(false);
                answerTwo.gameObject.SetActive(false);
                answerThree.gameObject.SetActive(false);
            }

        }

    }
    void answerTwoClick()
    {
        if (correctAnswer == answers[1])
        {

            jadeAm = jadeAm + 5;
            jadeAmount.text = "Jade: " + jadeAm;
            correctQuizzes = correctQuizzes + 1;
            villagerDiscussion.text = "You know so much! Here's some jade for your troubles!";
            villagers[whichVillager].SetActive(false);
            answerOne.gameObject.SetActive(false);
            answerTwo.gameObject.SetActive(false);
            answerThree.gameObject.SetActive(false);
            whichVillager = whichVillager + 1;
        }
        if (correctAnswer != answers[1])
        {
            tries = tries + 1;
            villagerDiscussion.text = "It's okay, try again!" + currentPrompt;
            if (tries == 2)
            {
                villagerDiscussion.text = "Aw, man, better luck next time! Gotta go!";
                villagers[whichVillager].SetActive(false);
                answerOne.gameObject.SetActive(false);
                answerTwo.gameObject.SetActive(false);
                answerThree.gameObject.SetActive(false);
                whichVillager = whichVillager + 1;
            }


        }
    }
        void answerThreeClick()
        {
            if (correctAnswer == answers[2])
            {
              correctQuizzes = correctQuizzes + 1;
              jadeAm = jadeAm + 5;
              jadeAmount.text = "Jade: " + jadeAm;
              villagerDiscussion.text = "You know so much! Here's some jade for your troubles!";
              villagers[whichVillager].SetActive(false);
              answerOne.gameObject.SetActive(false);
              answerTwo.gameObject.SetActive(false);
              answerThree.gameObject.SetActive(false);
              whichVillager = whichVillager + 1;
              villagerDiscussion.gameObject.SetActive(false);
        }
            if (correctAnswer != answers[2])
            {
                tries = tries + 1;
                villagerDiscussion.text = "It's okay, try again!" + currentPrompt;
                if (tries == 2)
                {
                    villagerDiscussion.text = "Aw, man, better luck next time! Gotta go!";
                    villagers[whichVillager].SetActive(false);
                    villagerDiscussion.gameObject.SetActive(false);
                    answerOne.gameObject.SetActive(false);
                    answerTwo.gameObject.SetActive(false);
                    answerThree.gameObject.SetActive(false);
                    whichVillager = whichVillager + 1;

                }


            }
        }
        void pickPrompt()
        {
            tries = 0;
            int randomIndex2 = Random.Range(0, 2);
            currentPrompt = prompts[randomIndex2];
            correctAnswer = answers[randomIndex2];
            villagerDiscussion.text = currentPrompt;
            answerOne.gameObject.SetActive(true);
            answerTwo.gameObject.SetActive(true);
            answerThree.gameObject.SetActive(true);
            villagerDiscussion.gameObject.SetActive(true);
    }


        public void villagerEncounter()
    {
        pickPrompt();

    }
        // Update is called once per frame
        void Update()
        {
        PlayerPrefs.SetInt("Jade", jadeAm);
        PlayerPrefs.SetInt("correctQuizzes", correctQuizzes);

    }
    } 
