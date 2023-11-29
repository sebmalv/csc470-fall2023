using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedCollectorScript : MonoBehaviour
{
    public Slider SeedCollectorMeter;
    public ParticleSystem SeedParticles;
    public TMP_Text SeedCollectorText;
    public GameObject seedPlanter;
    public bool haveSeeds;
    public float seedTotal;


    // Start is called before the first frame update
    void Start()
    {
        SeedCollectorMeter.gameObject.SetActive(false);
        SeedCollectorText.gameObject.SetActive(false);
        var em = SeedParticles.emission;
        em.enabled = false;
        haveSeeds = false;
    }
    public void seedsRemoved()
    {
        haveSeeds = false;
    }

    public void removeMeterAndText()
    {
        SeedCollectorMeter.gameObject.SetActive(false);
        SeedCollectorText.gameObject.SetActive(false);
        SeedCollectorMeter.value = 0;
        seedsRemoved();

    }

    public void OnTriggerStay()
    {
        var em = SeedParticles.emission;
        em.enabled = true;
        SeedCollectorMeter.gameObject.SetActive(true);
        SeedCollectorText.gameObject.SetActive(true);
        for (float seeds = 0; seeds < 20; seeds=seeds +.1f)
        {
            SeedCollectorMeter.value = SeedCollectorMeter.value + .1f;
            seedTotal = seeds;
        }
        haveSeeds = true;

    }
    public void OnTriggerExit()
    {
        SeedParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
