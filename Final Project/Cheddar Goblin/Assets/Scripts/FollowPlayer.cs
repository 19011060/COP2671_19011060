using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject goblin; // Reference to the goblin
    private GameManager gameManager;
    public Vector3 offset = new Vector3(0, 4, -6); // Camera offset from the goblin
    public float rotationSpeed = 150.0f; // Speed of camera's rotation
    private Transform goblinTransform;

    // Start is called before the first frame update
    void Start()
    {
        goblin = GameObject.Find("Goblin"); // Find the goblin GameObject
        goblinTransform = goblin.transform; // Cache the goblin's transform
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            float rotationInput = 0f;

            // Get input for rotation
            if (Input.GetKey(KeyCode.A))
            {
                rotationInput = -rotationSpeed * Time.deltaTime; // Rotate left
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotationInput = rotationSpeed * Time.deltaTime; // Rotate right
            }

            // Apply the rotation to the goblin
            goblinTransform.Rotate(0, rotationInput, 0);
        }
    }

    // Called once per frame after Update()
    void LateUpdate()
    {
        if (gameManager.isGameActive)
        {
            // Calculate the camera's new position based on the goblin's rotation
            Vector3 newPosition = goblinTransform.position + goblinTransform.rotation * offset;

            // Set the camera's position and make it look at the goblin
            transform.position = newPosition;
            transform.LookAt(goblinTransform.position + new Vector3(0, 1.5f, 0));
        }
        else if (!gameManager.isGameActive && !gameManager.isLevelComplete)
        {
            // Only adjust the camera's rotation to look at the goblin's position without changing its position
            transform.LookAt(goblinTransform.position + new Vector3(0, 1.5f, 0));
        }
    }
}