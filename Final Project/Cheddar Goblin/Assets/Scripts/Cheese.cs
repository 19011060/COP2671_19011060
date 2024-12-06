using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private ParticleSystem cheeseFX;
    private int pointValue = 1;
    public float spinSpeed = 50f;
    public float floatHeight = .5f;
    public float floatSpeed = 1f;

    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        cheeseFX = GameObject.Find("Cheese Collect").GetComponent<ParticleSystem>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        startPos = transform.position;
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.UpdateScore(pointValue);
        soundManager.PlayRandomGoblinSound();
        gameObject.SetActive(false);
        cheeseFX.Play();
    }
}
