using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Access outside scripts
    // Access PlayerController.cs
    public PlayerController playerController;


    // claim vars (default)
    public int Vitality = 2;
    public int Strength = 2;
    public int Dexterity = 2;
    public int Intellect = 2;
    public int mySkillPoints; 


    // make vars accessible to other scripts
    public int GetVitality()
    {
        return Vitality;
    }
    public int GetStrength()
    {
        return Strength;
    }
    public int GetDexterity()
    {
        return Dexterity;
    }
    public int GetIntellect()
    {
        return Intellect;
    }
    public int GetMySkillPoints()
    {
        return mySkillPoints;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {






        // ***********CALLING THE DEBUGANDTEST METHOD ******************
        DebugAndTest();
    }


    // *********DEBUGGING AND TESTING***************
    void DebugAndTest()
    {
        if (mySkillPoints > 1)
        {
            // testing adding 1 to the stated stat on Z press
            if (Input.GetKeyUp(KeyCode.Z))
            {
                Vitality++;
                mySkillPoints--;
            }

            // testing adding 1 to the stated stat on X press
            if (Input.GetKeyUp(KeyCode.X))
            {
                Strength++;
                mySkillPoints--;
            }

            // testing adding 1 to the stated stat on C press
            if (Input.GetKeyUp(KeyCode.C))
            {
                Dexterity++;
                mySkillPoints--;
            }

            // testing adding 1 to the stated stat on V press
            if (Input.GetKeyUp(KeyCode.V))
            {
                Intellect++;
                mySkillPoints--;
            }

            // add 1 skill point on B press
            if (Input.GetKeyUp(KeyCode.B))
            {
                mySkillPoints++;
            }
        }

        else
        {
            //Debug.Log("Not enough skill points to level up.");
        }
    }
}
