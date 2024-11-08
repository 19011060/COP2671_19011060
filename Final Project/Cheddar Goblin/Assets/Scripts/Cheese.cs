using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private int pointValue = 100;
    public float spinSpeed = 50f;
    public float floatHeight = .5f;
    public float floatSpeed = 1f;

    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        startPos = transform.position;
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Floating effect (sinusoidal movement)
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Spinning effect (rotation)
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.UpdateScore(pointValue);
        soundManager.PlayRandomGoblinSound();
        Destroy(gameObject);     
    }
    
}
