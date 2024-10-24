using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;
    private int pointValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore(pointValue);
        Debug.Log("Score increase");
        Destroy(gameObject);     
    }
}
