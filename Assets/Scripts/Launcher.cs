using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firlatici : MonoBehaviour
{
    float power;
    public float powerMin = 0f;
    public float powerMax = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    bool ballReady;

    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = powerMax;
        ballList = new List<Rigidbody>();
    }


    void Update()
    {
        if (ballReady) 
        {
            powerSlider.gameObject.SetActive(true);
        }
        else 
        {
            powerSlider.gameObject.SetActive(false);
        }
        powerSlider.value = power;
        if(ballList.Count > 0)
        { 
            ballReady = true;        
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= powerMax)
                {
                    power += Time.deltaTime * 50;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
               foreach (Rigidbody r in ballList) 
                {
                    r.AddForce(power * transform.forward);
                }     
            }
            
        }
        else
        {
            ballReady=false;
            power = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.GetComponent<Rigidbody>());
            power = 0f;
        }
    }

}




