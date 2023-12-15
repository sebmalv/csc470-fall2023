using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class wonScript : MonoBehaviour
{
    public TMP_Text wins;
    public TMP_Text totalJade;
    // Start is called before the first frame update
    void Start()
    {
        wins.text = "You got a total of " + PlayerPrefs.GetInt("correctQuizzes").ToString() + "quizzes right!";
        totalJade.text = "You finished with " + PlayerPrefs.GetInt("Jade").ToString() + " Jade";

    }

    void deleteAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuScene");
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("deleteAll", 5f);


        
    }
}
