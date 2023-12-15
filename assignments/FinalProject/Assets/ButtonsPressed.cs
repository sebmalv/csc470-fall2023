using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonsPressed : MonoBehaviour
{
    public string startScene;
    public Button startButton;
    public Button purposeButton;
    public TMP_Text purposeText;

    public Button dictionaryButton;
    public TMP_Text dictionaryText;
    public GameObject explanationBackground;
    public GameObject originalBackground;
    public Button hideDictionaryButton;
    public Button hidePurposeButton;

    private void Start()
    {
        PlayerPrefs.SetInt("correctQuizzes", 0);
        PlayerPrefs.SetInt("bushNumber", 4);
        PlayerPrefs.SetInt("Jade", 5);

        // Add a listener to the button click event
        startButton.onClick.AddListener(ChangeSceneOnClick);
        purposeButton.onClick.AddListener(showPurposeStatement);
        dictionaryButton.onClick.AddListener(showDictionary);
        hidePurposeButton.onClick.AddListener(closePurposeStatement);
        hideDictionaryButton.onClick.AddListener(closeDictionaryStatement);
        explanationBackground.SetActive(false);
        purposeText.gameObject.SetActive(false);
        dictionaryText.gameObject.SetActive(false);
        hideDictionaryButton.gameObject.SetActive(false);
        hidePurposeButton.gameObject.SetActive(false);
    }

    // Function to change the scene
    private void ChangeSceneOnClick()
    {
        SceneManager.LoadScene("IntroScene");
    }

    private void closePurposeStatement()
    {
        purposeText.gameObject.SetActive(false);
        originalBackground.gameObject.SetActive(true);
        explanationBackground.SetActive(false);
        purposeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        dictionaryButton.gameObject.SetActive(true);
        hidePurposeButton.gameObject.SetActive(false);

    }
    private void closeDictionaryStatement()
    {
        dictionaryText.gameObject.SetActive(false);
        originalBackground.gameObject.SetActive(true);
        explanationBackground.SetActive(false);
        purposeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        dictionaryButton.gameObject.SetActive(true);
        hideDictionaryButton.gameObject.SetActive(false);

    }

    private void showDictionary()
    {
        purposeButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        dictionaryButton.gameObject.SetActive(false);
        explanationBackground.gameObject.SetActive(true);
        originalBackground.gameObject.SetActive(false);
        dictionaryText.gameObject.SetActive(true);
        hideDictionaryButton.gameObject.SetActive(true);
    }

    // Function to change the scene
    private void showPurposeStatement()
    {
        purposeButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        dictionaryButton.gameObject.SetActive(false);
        explanationBackground.gameObject.SetActive(true);
        originalBackground.gameObject.SetActive(false);
        purposeText.gameObject.SetActive(true);
        hidePurposeButton.gameObject.SetActive(true);
    }
}
