using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject[] punchs;
    public Animator _playerAnim;
    public Animator _enemyAnim;
    private EnemyController enemyController;
    public bool winAnimIsActive;
    public GameObject tryAgainButton;
    private GameManager gameManager;
    
    

    public HealthBar healthbar;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameManager.gameOver = true;
            WinAnim();
            LoseAnim();
            TryAgain();
            


        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    public void WinAnim()
    {
        _enemyAnim.SetTrigger("win");
        winAnimIsActive = true;
        gameManager.gameOver = true;

    }

    private void LoseAnim()
    {
        _playerAnim.SetTrigger("lose");
        gameManager.gameOver = true;
        
    }

    private void TryAgain()
    {
        tryAgainButton.SetActive(true);
    }
    
   

   
}
