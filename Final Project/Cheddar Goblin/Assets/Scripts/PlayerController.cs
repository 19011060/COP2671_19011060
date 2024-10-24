using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject goblin;
    private GameManager gameManager;
    private const string track = "Track";
    public float moveSpeed = 1.5f;   // Speed of the ball's movement
    public float rotationSpeed = 100.0f; // Speed of goblin's rotation
    private bool isOnGround = false;  // To check if the ball is on the track

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        goblin = GameObject.Find("Goblin");
        goblin.transform.position = transform.position;// Center goblin inside the ball
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
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
        }
        // Keep the goblin's position centered inside the ball
        goblin.transform.position = transform.position; // - goblinOffset;
    }

    // Repeated collision detection to check if the ball is on the ground
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(track)) // Ball is on the track
        {
            isOnGround = true;
        }
    }

    // Detect when the ball leaves the track
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(track)) // Ball is off the track
        {
            isOnGround = false;
        }
    }
}