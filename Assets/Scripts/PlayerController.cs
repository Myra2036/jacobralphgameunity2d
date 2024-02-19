using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access outside scripts
    // Access PlayerStats.cs
    public PlayerStats playerStats;

    // Make these vars accessible to other scripts
    public int MyLevel()
    {
        return myLevel;
    }


    // general vars
    public float speed = 4;
    public Rigidbody2D rb;
    public bool canDash;
    public int playerHealth;
    public int playerMana;
    public int myLevel;

    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        // connect to PlayerStats.cs
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats == null)
        {
            Debug.LogError("Can't connect to PlayerStats.cs");
        }
    }


    // Update is called once per frame
    void Update()
    {
        //*******CALLING METHODS************
        // Call the CalculateLevel() method
        CalculateLevel();
        // Call the PlayerHealth() method
        PlayerHealth();
        // Call the PlayerMana() method
        PlayerMana();


        // ****************Debug, show current player level (myLevel) in console each frame
        Debug.Log("Level: " + myLevel);
    }


    // Player Movement
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;

        // Set WASD keys for movement
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }

        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(new Vector2(newPosition.x, newPosition.y));

        // Check if any movement key is released, and stop the player immediately
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.zero;
        }
    }


    void CalculateLevel()
    {
        if (playerStats != null)
        {
            myLevel = playerStats.GetVitality() + playerStats.GetStrength() + playerStats.GetDexterity() + playerStats.GetIntellect(); 
        }

    }


    void PlayerXP()
    {

    }


    // Player health = Vitatlity stat * 50
    void PlayerHealth()
    {
        playerHealth = playerStats.GetVitality() * 50;

        // TAKING DAMAGE
        //*********DEBUG, ON Q PRESS, APPLY DAMAGE**********
        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerHealth--;
        }

        if (playerHealth > 1)
        {
            isDead = true;
        }
    }


    void PlayerMana()
    {
        playerMana = playerStats.GetIntellect() * 50;
    }
}
