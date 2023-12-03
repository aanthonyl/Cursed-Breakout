using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{

    public float healAmount = 10.0f;
    private bool isHealing = false;

    private PlayerHealth playerHealth;
    public bool isPaused = false;

    private Light light;

    //public AudioSource audioSource;



    private void Start()
    {
        Debug.Log("Start");
        light = GameObject.Find("Fountain_Light").GetComponent<Light>();
        light.enabled = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        // Debug.Log("before if /OnTriggerEnter");
        if (col.gameObject.CompareTag("Player") && isPaused == false)
        {
            light.enabled = true;
            isHealing = true;

            Debug.Log("onTriggerEnter");

            //audioSource.Play();
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && isPaused == false)
        {
            light.enabled = false;
            Debug.Log("OnTriggerExit");
            isHealing = false;
            //audioSource.Stop();
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (isHealing && col.CompareTag("Player") && isPaused == false)
        {
            Debug.Log("OnTriggerStay");

            PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount * Time.deltaTime);
            }
        }
    }
}
