using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access outside scripts
    public PlayerStats playerStats;
    
    public PlayerInventory playerInventory;

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

    public int PlayerMana()
    {
        return playerMana;
    }

    public int MaxMana()
    {
        return maxMana;
    }

    public bool CanDash()
    {
        return canDash;
    }


    // general vars
    // base info
    public int speed = 4;
    public Rigidbody2D rb;
    public int playerHealth = 100;

    // base stats
    public int myLevel;
    public int maxHealth;
    public int playerMana = 100;
    public int maxMana;
    
    // dashing
    public bool canDash = true;
    public int dashMult = 2;
    public float dashCooldown = 3f;
    public bool isDashing = false;

    // on death
    private bool isDead;



    // Start is called before the first frame update
    void Start()
    {
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats reference is not assigned in the editor!");
        }

        if (playerInventory == null)
        {
            Debug.LogError("PlayerInventory reference is not assigned in the editor!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        //*******CALLING METHODS************
        // Call the CalculateLevel() method
        CalculateLevel();

        // Dash on Left Shift input
        PlayerDash();

        // Declaring and updating maxHealth
        maxHealth = playerStats.GetVitality() * 50;

        // Declaring ans updating maxMana
        maxMana = playerStats.GetIntellect() * 50;

        //***********DEBUG*************
        //ON Q PRESS, APPLY DAMAGE
        if (Input.GetKey(KeyCode.Q))
        {
            TakeDamage();
        }

        //show current player level (myLevel) in console each frame
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

    // add the 4 stats and adjust the player level accordingly
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
            //isDead = true;

            print("Player is dead.");
        }
    }


    // call the dash coroutine
    void PlayerDash()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDash == true)
            {
                StartCoroutine(DashCoroutine());
            }
        }
    }

    //  dashing
    IEnumerator DashCoroutine()
    {
        isDashing = true;
        speed = 12;
        IFrames();

        yield return new WaitForSeconds(0.3f);

        speed = 4;
        isDashing = false;
        IFrames();

        StartCoroutine(DashCooldownCoruotine());
    }

    // dash cooldown
    IEnumerator DashCooldownCoruotine()
    {
        canDash = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    // IFrames for the player when dashing
    void IFrames()
    {
        if (isDashing == true)
        {

        }

        else
        {

        }
    }
}
