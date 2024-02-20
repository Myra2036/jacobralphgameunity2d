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

    public int PlayerHealth()
    {
        return playerHealth;
    }

    public int MaxHealth()
    {
        return maxHealth;
    }

    // general vars
    public float speed = 4;
    public Rigidbody2D rb;
    public bool canDash = true;
    public int playerHealth = 100;
    public int playerMana;
    public int myLevel;
    public int flaskAmount = 3;
    public int maxHealth;


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

        // Call the PlayerMana() method
        PlayerMana();

        // Dash on Left Shift input
        PlayerDash();

        // Declaring and updating maxHealth
        maxHealth = playerStats.GetVitality() * 50;



        if (Input.GetKeyDown(KeyCode.E))
        {
            Flask();
        }


        //***********DEBUG*************
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth = maxHealth + 50;
        }

        // TAKING DAMAGE
        //*********DEBUG, ON Q PRESS, APPLY DAMAGE**********
        if (Input.GetKey(KeyCode.Q))
        {
            TakeDamage();
        }

        // ****************Debug, show current player level (myLevel) in console each frame
        //Debug.Log("Level: " + myLevel);
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


    void TakeDamage()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            isDead = true;

            print("Player is dead.");
        }
    }


    void PlayerMana()
    {
        playerMana = playerStats.GetIntellect() * 50;
    }


    void PlayerDash()
    {
        if (canDash == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            
        }
    }

    void Flask()
    {
        if (flaskAmount > 0)
        {
            playerHealth = playerHealth + 50;
            flaskAmount--;

            if (playerHealth > maxHealth)
            {
                playerHealth = maxHealth;
            }
        }

        else
        {
            Debug.Log("No flasks available.");
        }
    }
}
