using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private GameManager gameManager;

    [SerializeField]
    private GameObject healthUI;
    public Image[] fruitDisplay;
    [SerializeField]
    private GameObject manaUI;
    public Image[] manaDisplay;

    //Images we will use for the HealthUI in our scene
    [SerializeField]
    private Sprite fullFruit;
    [SerializeField]
    private Sprite eatenFruit;
    [SerializeField]
    private Sprite emptyMana;
    [SerializeField]
    private Sprite fullMana;

    //The maximum amount of health and mana our player should ever have
    private const int HEALTHCAP = 5;
    private const int MANACAP = 6;

    //The most health the player can currently have
    private int maxHealth;
    private int maxMana;

    //The number of full fruits and mana we should display currently
    private int currHealth;
    private int currMana;

    // Use this for initialization
    void Start () {

        //Grab the gameObjects containing our UI elements
        healthUI = GameObject.Find("HealthUI");
        manaUI = GameObject.Find("ManaUI");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Set players health and mana for the scene
        currHealth = gameManager.PlayerScript.Health;
        currMana = gameManager.PlayerScript.Mana;

        fruitDisplay = new Image[currHealth];
        manaDisplay = new Image[currMana];

        for(int i = 0; i < currHealth; i++){
            fruitDisplay[i] = healthUI.GetComponentInChildren<Image>();
        }
        for(int i = 0; i < currMana; i++){
            manaDisplay[i] = manaUI.GetComponentInChildren<Image>();
        }
        

        for(int i = 0; i < HEALTHCAP; i++)
        {
            if(i < maxHealth)//Display the proper amount of fruit
            {
                fruitDisplay[i].enabled = true;
            }
            else//Don't display the rest
            {
                fruitDisplay[i].enabled = false;
            }
        }

        for (int i = 0; i < MANACAP; i++)
        {
            if (i < maxMana)//Display the proper amount of mana
            {
                manaDisplay[i].enabled = true;
            }
            else//Don't display the rest
            {
                manaDisplay[i].enabled = false;
            }
        }

        //Finally update the UI so that we can see our stats
        updateHealthDisplay(0);
        updateManaDisplay(0);
	}

    //We pass in a positive number to this function to represent healing,
    //and pass in a negative number to represent being damaged
    public void updateHealthDisplay(int healthChange)
    {
        int i, j;

        currHealth += healthChange;

        if(currHealth <= 0)//If our player runs out of health, he loses a life and restarts the level at the last checkpoint.
        {
            //gameManager.MovePlayerToLastCheckpoint();
        }
        if(currHealth > maxHealth) //Our player shouldn't have more health than their intended max health
        {
            currHealth = maxHealth;
            return;
        }

        //Display a number of fruits equal to our current health
        for(i = 0; i < currHealth; i++)
        {
            fruitDisplay[i].sprite = fullFruit;
        }

        //Display eaten fruit for the remaining amount of health
        for(j = i; j < maxHealth; j++)
        {
            fruitDisplay[j].sprite = eatenFruit;
        }
    }

    //We pass in a positive number to this function to represent mana recovery,
    //and pass in a negative number to represent mana usage
    public void updateManaDisplay(int manaChange)
    {
        int i, j;

        currMana += manaChange;

        if(currMana < 0)
        {
            currMana = 0;
            return;
        }
        if(currMana > maxMana) //Our player shouldn't have more mana than their intended max mana
        {
            currMana = maxMana;
            return;
        }

        //Display a number of mana charges equal to the current mana
        for(i = 0; i < currMana; i++)
        {
            manaDisplay[i].sprite = fullMana;
        }

        //Display used mana charges for the remaining amount of mana
        for(j = i; j < maxMana; j++)
        {
            manaDisplay[j].sprite = emptyMana;
        }
    }

    public void upgradeMaxHealth()
    {
        //We should never reach this condition, but on the off chance we do return
        if(maxHealth+1 > HEALTHCAP)//We should never have more health than our intended health cap
        {
            return;
        }
        else
        {
            fruitDisplay[maxHealth].enabled = true;
            maxHealth++;
            currHealth = maxHealth;
            updateHealthDisplay(0);
        }
    }

    public void upgradeMaxMana()
    {
        //We should never reach this condition, but on the off chance we do return
        if (maxMana+1 > MANACAP)//We should never have more mana than our intended mana cap
        {
            return;
        }
        else
        {
            manaDisplay[maxMana].enabled = true;
            maxMana++;
            currMana = maxMana;
            updateManaDisplay(0);
        }
    }

    public bool attemptManaConsumption()
    {
        if(currMana <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void setMaxHealth(int newHealth)
    {
        maxHealth = newHealth;
    }

    public void setMaxMana(int newMana)
    {
        maxMana = newMana;
    }
    
}
