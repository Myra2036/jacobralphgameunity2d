using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Access player controller script
    public PlayerController playerController;

    // claim vars
    // health flask
    public int solarFlaskCount = 3;
    // mana flask
    public int lunarFlaskCount = 3;
    // return to bonfire thing
    public bool useReturnItem;


    // Make these vars accessible to outside scripts
    public int SolarFlaskCount()
    {
        return solarFlaskCount;
    }

    public int LunarFlaskCount()
    {
        return lunarFlaskCount;
    }

    public bool UseReturnIten()
    {
        return useReturnItem;
    }


    void SolarFlask()
    {
        if (solarFlaskCount > 0)
        {
            playerController.playerHealth += 50;
            solarFlaskCount--;

            if (playerController.playerHealth > playerController.maxHealth)
            {
                playerController.playerHealth = playerController.maxHealth;
            }
        }

        else
        {
            Debug.Log("No available Solar Flasks.");
        }
    }


    void LunarFlask()
    {
        if (lunarFlaskCount > 0)
        {
            playerController.playerMana += 50;
            lunarFlaskCount--;

            if (playerController.playerMana > playerController.maxMana)
            {
                playerController.playerMana = playerController.maxMana;
            }
        }

        else
        {
            Debug.Log("No available Lunar Flasks.");
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SolarFlask();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LunarFlask();
        }
    }
}
