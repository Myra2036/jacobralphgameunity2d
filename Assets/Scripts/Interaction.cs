using UnityEngine;

public class Interaction : MonoBehaviour
{
    public LayerMask interactableLayer; // Set this in the Unity editor to the layer where your interactable objects are placed
    public float interactRange = 1f; // Set this to the range at which the player can interact with the object

    public PlayerInventory playerInventory;
    public PlayerController playerController;

    void Update()
    {
        // Get the last movement input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Create a Vector2 representing the direction based on the last movement input
            Vector2 raycastDirection = new Vector2(horizontalInput, verticalInput).normalized;

            // Perform raycast to detect the interactable object
            RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, interactRange, interactableLayer);

            // Log the raycast hit information
            if (hit.collider != null)
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name + " with tag: " + hit.collider.tag + " on layer: " + LayerMask.LayerToName(hit.collider.gameObject.layer));
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }

            // Check if the ray hit an object
            if (hit.collider != null)
            {
                // Check if the hit object has a specific tag to identify it
                if (hit.collider.CompareTag("Interactable"))
                {
                    // Replace "YourInteractableTag" with the tag you assigned to your interactable objects

                    // Perform interaction (you can replace this with your actual interaction logic)
                    Debug.Log("Interacting with: " + hit.collider.gameObject.name);

                    WhatIsIt(hit.collider.gameObject.name);
                }
            }
        }
    }


    void WhatIsIt(string objectName)
    {
        // interacting with glint (bonfire)
        if (objectName == "glint")
        {
            playerController.playerHealth = playerController.maxHealth;

            playerInventory.solarFlaskCount = playerInventory.maxSolarFlaskCount;

        }

        if (objectName == "testmaxflask")
        {
            playerInventory.maxSolarFlaskCount++;
        }
    }
}