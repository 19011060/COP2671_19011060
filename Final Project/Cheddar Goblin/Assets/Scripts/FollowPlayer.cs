using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject goblin; // Reference to the goblin
    public Vector3 offset = new Vector3(0, 4, -6); // Camera offset from the goblin
    public float rotationSpeed = 100.0f; // Speed of camera's rotation
    private float currentRoatation = 0f;  // Current horizontal rotation

    // Start is called before the first frame update
    void Start()
    {
        goblin = GameObject.Find("Goblin"); // Find the goblin GameObject
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera around the goblin using 'A' and 'D' input
        if (Input.GetKey(KeyCode.A))
        {
            currentRoatation -= rotationSpeed * Time.deltaTime; // Rotate left
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentRoatation += rotationSpeed * Time.deltaTime; // Rotate right
        }
    }

    // Called once per frame after Update()
    void LateUpdate()
    {
        // Calculate the camera's rotation and position for orbiting around the player
        Quaternion rotation = Quaternion.Euler(0, currentRoatation, 0); // Quaternion rotation around the y-axis using currentRoatation as the degrees
        Vector3 newPosition = goblin.transform.position + rotation * offset; // Add the new rotation to the new position of the camera

        // Set the camera's new position and focus it on the goblin
        transform.position = newPosition;
        transform.LookAt(goblin.transform.position + new Vector3(0, (float)1.5, 0));
    }
}