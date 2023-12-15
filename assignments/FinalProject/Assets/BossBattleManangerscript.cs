using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBattleManangerscript : MonoBehaviour
{
    private List<string> bodyPotonNames = new List<string>();
    private List<string> bodyEnglishNames = new List<string>();
    Dictionary<string, string> languageDictionary;
    public Button buttonOne;
    public Button buttonTwo;
    public TMP_Text dictionary;
    public Button buttonThree;
    public Button buttonFour;
    public Button buttonFive;
    public Slider bossHealth;
    public TMP_Text whichBody;
    public Slider playerHealth;
    public GameObject legArrow;
    public GameObject noseArrow;
    public GameObject mouthArrow;
    public GameObject eyeArrow;
    public GameObject armArrow;
    public int tries;
    private List<string> correctOrder = new List<string>();
    int orderNumberAt;
    public Button jade;
    public GameObject backGround;
    int amountofJade;
    int correctQuiz;
    // Start is called before the first frame update
    void Start()
    {
        jade.onClick.AddListener(jadeButtonClick);
        amountofJade = PlayerPrefs.GetInt("Jade");
        jade.gameObject.SetActive(false);
        orderNumberAt = 0;
        legArrow.SetActive(false);
        noseArrow.SetActive(false);
        mouthArrow.SetActive(false);
        eyeArrow.SetActive(false);
        armArrow.SetActive(false);
        dictionary.gameObject.SetActive(false);
        backGround.SetActive(false);
        tries = 3;
        buttonOne.onClick.AddListener(buttonOneChange);
        buttonTwo.onClick.AddListener(buttonTwoChange);
        buttonThree.onClick.AddListener(buttonThreeChange);
        buttonFour.onClick.AddListener(buttonFourChange);
        buttonFive.onClick.AddListener(buttonFiveChange);
        bodyPotonNames = new List<string>() {
        "Bosna","Nep-kuru","Kenin","Ingori","Sarin"};
        languageDictionary = new Dictionary<string, string>();
        bodyEnglishNames = new List<string>() {
        "Leg","Nose","Arm", "Mouth","Eye"};
        correctOrder= new List<string>() {
        "","","", "",""};
        setDictionary();
        selectCorrectOrder();
    }
    public string bodyEnglishToPoton(string bodyEnglishName)
    {
        string potonName = "";
        // Check if the sign exists in the dictionary
        if (languageDictionary.ContainsKey(bodyEnglishName))
        {
            // Return the translation
            potonName = languageDictionary[bodyEnglishName];
        }

        return potonName;
    }

    void selectCorrectOrder()
    {
        int randomIndex2 = Random.Range(0, 1);
        int r = 0;
        int n = 4;
        if (randomIndex2 == 0)
        {
            for(int i=0; i < 5; i++)
            {
                correctOrder[r] = bodyEnglishNames[i];
                r = r + 1;
            }
        }
        if (randomIndex2 == 1)
        {
            for (int i = 5; i > 0; i--)
            {
                correctOrder[n] = bodyEnglishNames[i];
                n = n - 1;
            }
        }
        string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
        whichBody.text = "You Must Shoot his" + " " + poton;
    }
    public bool isItCorrect(string name)
    {
        bool tof;
        if (name == correctOrder[orderNumberAt])
        {
            tof = true;
        }
        else
        {
            tof = false;
        }

        return tof;

    }

    void buttonOneChange()
    {
        bool tof = isItCorrect("Leg");
        if (tof == false)
        {
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "No! You Must Shoot his" + " " + poton;
            playerHealth.value = playerHealth.value - 20;
        }
        if (tof == true)
        {
            legArrow.SetActive(true);
            Debug.Log(orderNumberAt);
            orderNumberAt = orderNumberAt + 1;
            correctQuiz = correctQuiz + 1;
            bossHealth.value = bossHealth.value - 20;
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "Yes! Next You Must Shoot his" + " " + poton;
        }
    }

    void buttonTwoChange()
    {
        bool tof = isItCorrect("Nose");
        if (tof == false)
        {
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "No! You Must Shoot his" + " " + poton;
            playerHealth.value = playerHealth.value - 20;
        }
        if (tof == true)
        {
            noseArrow.SetActive(true);
            Debug.Log(orderNumberAt);
            orderNumberAt = orderNumberAt + 1;
            correctQuiz = correctQuiz + 1;
            bossHealth.value = bossHealth.value - 20;
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "Yes! Next You Must Shoot his" + " " + poton;

        }


    }
    void buttonThreeChange()
    {
        bool tof = isItCorrect("Arm");
        if (tof == false)
        {
            Debug.Log("false");
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "No! You Must Shoot his" + " " + poton;
            playerHealth.value = playerHealth.value - 20;
        }
        if (tof == true)
        {
            armArrow.SetActive(true);
            orderNumberAt = orderNumberAt + 1;
            Debug.Log(orderNumberAt);
            correctQuiz = correctQuiz + 1;
            bossHealth.value = bossHealth.value - 20;
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "Yes! Next You Must Shoot his" + " " + poton;

        }

    }
    void buttonFourChange()
    {
        bool tof = isItCorrect("Mouth");
        if (tof == false)
        {
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "No! You Must Shoot his" + " " + poton;
            playerHealth.value = playerHealth.value - 20;
        }
        if (tof == true)
        {
            mouthArrow.SetActive(true);
            orderNumberAt = orderNumberAt + 1;
            correctQuiz = correctQuiz + 1;
            bossHealth.value = bossHealth.value - 20;
            Debug.Log(orderNumberAt);
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "Yes! Next You Must Shoot his" + " " + poton;

        }
    }
    void buttonFiveChange()
    {
        bool tof = isItCorrect("Eye");
        if (tof == false)
        {
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "No! You Must Shoot his" + " " + poton;
            playerHealth.value = playerHealth.value - 20;
        }
        if (tof == true)
        {
            eyeArrow.SetActive(true);
            orderNumberAt = orderNumberAt + 1;
            correctQuiz = correctQuiz + 1;
            bossHealth.value = bossHealth.value - 20;
            Debug.Log(orderNumberAt);
            string poton = bodyEnglishToPoton(correctOrder[orderNumberAt]);
            whichBody.text = "Yes! Next You Must Shoot his" + " " + poton;

        }

    }
    void setDictionary()
    {
        for (int i = 0; i < 5; i++)
        {
            languageDictionary.Add(bodyEnglishNames[i], bodyPotonNames[i]);
        }

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

        if (playerHealth.value == 0)
        {
            SceneManager.LoadScene("VillageScene");
        }
        if (bossHealth.value == 0)
        {
            int c = PlayerPrefs.GetInt("correctQuizzes");
            correctQuiz = c + correctQuiz;
            PlayerPrefs.SetInt("correctQuizzes", correctQuiz);
            SceneManager.LoadScene("WinningScene");
        }

    }
}
