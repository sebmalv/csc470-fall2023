using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsPressed : MonoBehaviour
{
    public string startScene;
    public Button startButton;

    private void Start()
    {
        // Assuming you have a Button component attached to the GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button click event
        startButton.onClick.AddListener(ChangeSceneOnClick);
    }

    // Function to change the scene
    private void ChangeSceneOnClick()
    {
        SceneManager.LoadScene(startScene);
    }
}
