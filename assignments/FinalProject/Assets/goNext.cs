using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void nextScene()
    {
        SceneManager.LoadScene("BeginningScene");
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("nextScene", 4f);
        
    }
}
