﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject player;
    
    //gameObject is invicible during a certain time after taking damages
    public float timeBetweenDamageInit = 1.0f; //time in sec
    private float timeBetweenDamage;
    private bool isLosingHealth = false;
    private bool hpAlreadyRemoved = false;
    private int damageToTake = 0;
    private float timeToChangeColor = 0;
    private bool changeColor = true;
    private int lifeAdd = 2;
    private float timeToHeal = 0.15f;
    public bool gainingLife = false;
    private bool hpAlreadyAdded = false;
    private bool invincible = false;
    private float timeToInvincible = 10.0f;

    public HealthBar healthBar;

    void Start() // init HP
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); //set healthBar cursor to max health
        timeBetweenDamage = timeBetweenDamageInit;
        timeToHeal = timeBetweenDamageInit;
        timeToChangeColor = 0.15f;
    }

    void Update()
    {
        if(isLosingHealth && !invincible)
        {
            timeBetweenDamage -= Time.deltaTime;
            if(!hpAlreadyRemoved)
            {
                currentHealth -= damageToTake;
                healthBar.SetCurrentHealth(currentHealth); //update healthBar display
                hpAlreadyRemoved = true;
                if(currentHealth <= 0)
                {
                    if(gameObject.tag == "Player")
                    {
                        DeadMenu.gameIsPaused = true;
                    }
                    if(gameObject.tag == "Boss")
                    {
                        VictoryMenu.isActivated = true;
                    }
                    Destroy(gameObject);//remove the gameObject from the game
                }
            }
            if (timeBetweenDamage < 0) //gameObject can take damages again
            {
                timeBetweenDamage = timeBetweenDamageInit;
                isLosingHealth = false;
                hpAlreadyRemoved = false;
                damageToTake = 0; //not a must
                timeToChangeColor = 0.15f;
                changeColor = true;
                player.GetComponent<Renderer>().material.color = Color.white;
            }
            timeToChangeColor -= Time.deltaTime;
            if(timeToChangeColor < 0)
            {
                if(changeColor)
                {
                    player.GetComponent<Renderer>().material.color = Color.red;
                    changeColor = false;
                }
                else
                {
                    player.GetComponent<Renderer>().material.color = Color.white;
                    changeColor = true;
                }
                timeToChangeColor = 0.15f;
            }
        }
        if(gainingLife){
            if(!hpAlreadyAdded)
            {
                if(currentHealth+lifeAdd > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                else
                {
                    currentHealth += lifeAdd;
                }
                healthBar.SetCurrentHealth(currentHealth); //update healthBar display
                hpAlreadyAdded = true;
            }
            timeToChangeColor -= Time.deltaTime;
            timeToHeal -= Time.deltaTime;
            if(timeToChangeColor < 0)
            {
                if(changeColor)
                {
                    player.GetComponent<Renderer>().material.color = Color.green;
                    changeColor = false;
                }
                else
                {
                    player.GetComponent<Renderer>().material.color = Color.white;
                    changeColor = true;
                }
                timeToChangeColor = 0.15f;
            }
            if (timeToHeal < 0) //gameObject can take damages again
            {
                timeToHeal = timeBetweenDamageInit;
                gainingLife = false;
                timeToChangeColor = 0.15f;
                hpAlreadyAdded = false;
                changeColor = true;
                player.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        if(invincible)
        {
            timeToChangeColor -= Time.deltaTime;
            timeToInvincible -= Time.deltaTime;
            if(timeToChangeColor < 0)
            {
                if(changeColor)
                {
                    player.GetComponent<Renderer>().material.color = Color.blue;
                    changeColor = false;
                }
                else
                {
                    player.GetComponent<Renderer>().material.color = Color.white;
                    changeColor = true;
                }
                timeToChangeColor = 0.15f;
            }
            if (timeToInvincible < 0) //gameObject can take damages again
            {
                timeToInvincible = 10.0f;
                invincible = false;
                changeColor = true;
                timeToChangeColor = 0.15f;
                player.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isLosingHealth){
            isLosingHealth = true;
            damageToTake = damage;
        }
    }

    public void GainLife(){
        gainingLife = true;
    }

    public void Invincible(){
        invincible = true;
    }
}
