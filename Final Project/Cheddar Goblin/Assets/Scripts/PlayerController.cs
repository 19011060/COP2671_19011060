using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject goblin;
    private Vector3 goblinOffset = new Vector3(0, 0.77f, 0); // Offset to keep goblin centered inside the ball
    public float moveSpeed = 1.5f;   // Speed of the ball's movement
    public float rotationSpeed = 100.0f; // Speed of goblin's rotation
    private bool isOnGround = false;  // To check if the ball is on the track

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        goblin = GameObject.Find("Goblin"); 
        goblin.transform.position = transform.position - goblinOffset; // Center goblin inside the ball
    }

    // Update is called once per frame
    void Update()
    {
        // If the player's touching the ground:
        if (isOnGround)
        {
            // Move the ball forward and backward based based on which way the player's facing.
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.AddForce(goblin.transform.forward * moveSpeed); // Move forward
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRb.AddForce(-goblin.transform.forward * moveSpeed); // Move backward
            }
        }

        // Rotate the player right and left
        if (Input.GetKey(KeyCode.A))
        {
            goblin.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime); // Rotate left
        }
        if (Input.GetKey(KeyCode.D))
        {
            goblin.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Rotate right
        }
        
        // Keep the goblin's position centered inside the ball
        goblin.transform.position = transform.position - goblinOffset;
    }

    // Repeated collision detection to check if the ball is on the ground
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Track")) // Ball is on the track
        {
            isOnGround = true;
        }
    }

    // Detect when the ball leaves the track
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Track")) // Ball is off the track
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Cheese")) // Detect when the goblin gets cheese
        {
            Destroy(other.gameObject); // Destroy cheese
            // add Points
            // play sound
            // partice effects
        }

        if (other.CompareTag("Booster")) // Detect when the goblin hits a speed boost
        {
            // speed up player with impulse
            // play sounds
        }
    }
}