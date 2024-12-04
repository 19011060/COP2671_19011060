using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGoblin : MonoBehaviour
{
    private Rigidbody goblinRB;
    private TimeManager timeManager;
    public AudioClip chain;
    private AudioSource goblinSource;
    public float maxAngle = 45f;
    public float swingSpeed = 2f;
    private Quaternion initialRotation; // To store the initial global rotation
    private float time;

    void Start()
    {
        // Save the initial global rotation of the object
        initialRotation = transform.rotation;
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        goblinRB = GameObject.Find("TitlePlayer").GetComponent<Rigidbody>();
        goblinSource = GameObject.Find("TitlePlayer").GetComponent<AudioSource>();
        goblinRB.useGravity = false;
    }

    void Update()
    {
        // Calculate the angle using a sine wave
        float angle = maxAngle * Mathf.Sin(time * swingSpeed);

        // Create a rotation relative to the global X-axis (or change axis as needed)
        Quaternion swingRotation = Quaternion.AngleAxis(angle, Vector3.up);

        // Apply the swing rotation relative to the initial global rotation
        transform.rotation = initialRotation * swingRotation;

        // Increment time
        time += Time.deltaTime;
    }

    public void breakChain()
    {
        timeManager.StartTimer();
        goblinRB.useGravity = true;
        goblinSource.PlayOneShot(chain);
        goblinSource.PlayDelayed(0.5f);
    }
}
