using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedPlanterScript : MonoBehaviour
{
    public GameObject gm;
    public Slider cornGrowthMeter;
    public TMP_Text cornGrowthText;
    public ParticleSystem cornGrowParticles;
    public GameObject cornStalks;
    public GameObject cornCollectablePrefab;
    public GameObject[] cornCollectables;
    public GameObject seedPreFab;
    public GameObject[] seedSpawns;
    public GameObject[] actualSeeds;
    public bool isCornGrowing;
    public GameObject plantButton;
    public GameObject collectButton;
    public GameObject seedCollector;
    public bool seedsPresent;
    public Vector3 startPos;
    public Vector3 endPos;
    private Vector3 target;
    public Button btn;
    public Button btn2;
    Animator animator;
    public bool cornDone;
    public bool cornCobsPresent;

    // Start is called before the first frame update
    void Start()
    {
        cornGrowthMeter.gameObject.SetActive(false);
        cornGrowthText.gameObject.SetActive(false);
        var em = cornGrowParticles.emission;
        em.enabled = false;
        createSeeds();
        createCobs();
        btn = plantButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn2 = collectButton.GetComponent<Button>();
        btn2.onClick.AddListener(clickedButton);
        btn2.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
        startPos = cornStalks.transform.position;
        endPos = new Vector3(startPos.x, startPos.y +2, startPos.z);
        target = new Vector3(startPos.x, startPos.y +2, startPos.z);
        animator = cornStalks.GetComponent<Animator>();

    }
    void clickedButton()
    {
        cornGrowthMeter.gameObject.SetActive(false);
        cornGrowthText.gameObject.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            cornCollectables[i].SetActive(false);
        }
        animator.SetBool("IsGrow", false);
        btn2.gameObject.SetActive(false);
        gm.GetComponent<GameManagerScr>().updateScore();


    }
    void createSeeds()
    {
        for (int i = 0; i < 5; i++)
        {
            actualSeeds[i] = Instantiate(seedPreFab, seedSpawns[i].transform);
            actualSeeds[i].SetActive(false);
        }
    }
    void createCobs()
    {
        for (int i = 0; i < 5; i++)
        {
            cornCollectables[i] = Instantiate(cornCollectablePrefab, seedSpawns[i].transform);
            cornCollectables[i].SetActive(false);
        }
    }
    void plantSeeds()
    {
        for (int i = 0; i < 5; i++)
        {
            actualSeeds[i].gameObject.SetActive(true);
        }
    }
    void deactivateSeeds()
    {
        for (int i = 0; i < 5; i++)
        {
            actualSeeds[i].gameObject.SetActive(false);
        }
    }
    void cornGrowVisuals()
    {
        deactivateSeeds();
        animator.SetBool("IsGrow",true);
        Invoke("collectableVisuals", 2f);
        btn2.gameObject.SetActive(true);

    }

    void collectableVisuals()
    {
        for (int i = 0; i < 5; i++)
        {
            cornCollectables[i].gameObject.SetActive(true);
        }


    }

    public bool areSeeds()
    {
        seedsPresent= seedCollector.GetComponent<SeedCollectorScript>().haveSeeds;
        return seedsPresent;
        
    }

    void TaskOnClick()
    {
        var em = cornGrowParticles.emission;
        em.enabled = true;
        seedCollector.GetComponent<SeedCollectorScript>().removeMeterAndText();
        cornGrowthMeter.gameObject.SetActive(true);
        cornGrowthText.gameObject.SetActive(true);
        isCornGrowing = true;
        seedsPresent = false;
        plantSeeds();
        btn.gameObject.SetActive(false);
    }

    public void OnTriggerEnter()
    {
        areSeeds();
        if (seedsPresent == true)
        {
            Button btn = plantButton.GetComponent<Button>();
            btn.gameObject.SetActive(true);
        }

    }

    void increaseCorn()
    {
        cornGrowthMeter.value = cornGrowthMeter.value + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCornGrowing == true)
        {
            Invoke("cornGrowVisuals", 1f);
            for (float seeds = 0; seeds < 100; seeds = seeds + .5f)
            {
                Invoke("increaseCorn", 1f);
            }
            cornDone = true;

            isCornGrowing = false;
        }

        }
        
    }

