using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Before "Start" we can define variables
    [SerializeField] float transSpeed = 20.0f;
    [SerializeField] float steerSpeed = 400.0f;
    [SerializeField] float bumpSpeed = 15.0f;
    [SerializeField] float boostSpeed = 25.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float transAmount = Input.GetAxis("Vertical") * transSpeed * Time.deltaTime;

        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,transAmount,0);

    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            Debug.Log("SPEED DEMON!!!");
            transSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        transSpeed = bumpSpeed;
    }
}
