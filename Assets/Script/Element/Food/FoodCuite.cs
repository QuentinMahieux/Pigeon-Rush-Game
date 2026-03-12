using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodCuite : DefaultFood
{
    [Header("Cooking Food")] 
    public string tagTransformator = "Baking Tray";
    public GameObject newFoodPrefab;

    public float timeToHot;
    public float actualTimeToHot;
    [SerializeField] private bool isCooking;
    
    [Header("Interface")]
    public Slider timeToHotSlider;

    [Header("Particle Systeme")] 
    public ParticleSystem[] particleHot;

    
    void OnEnable()
    {
        isCooking = false;
        timeToHotSlider.gameObject.SetActive(false);
        foreach (ParticleSystem particle in particleHot)
        {
            particle.enableEmission = false;
            particle.Stop();
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag(tagTransformator))
        {
            isCooking = true;
            
            if (timeToHotSlider)
            {
                timeToHotSlider.gameObject.SetActive(true);
            }
            foreach (ParticleSystem particle in particleHot)
            {
                particle.enableEmission = true;
                particle.Play();
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (isCooking && !other.gameObject.CompareTag(tagTransformator))
        {
            isCooking = false;
        }
    }

    void Update()
    {
        if (!isCooking)
        {
            return;
        }
        actualTimeToHot += Time.deltaTime;
        if (actualTimeToHot > timeToHot)
        { 
            Instantiate(newFoodPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }

        if (timeToHotSlider)
        {
            timeToHotSlider.value = actualTimeToHot/timeToHot;
        }
    }

    public override void isTaking()
    {
        base.isTaking();
        isCooking = false;
        if(timeToHotSlider)
        {
            timeToHotSlider.gameObject.SetActive(false);
        }

        foreach (ParticleSystem particle in particleHot)
        {
            particle.Stop();
        }
    }
}
