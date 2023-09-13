using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Input = UnityEngine.Windows.Input;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public GameObject[] punchs;
    private Enemy _enemy;
    public Animator _playerAnim;
    public Animator _enemyAnim;
    private EnemyController _enemyController;
    public GameObject nextLevelButton;
    public float playerDamage;
    private float helmetAbsorb;
    private int helmetsLevel;

    public HealthBar healthbar;
    private GameManager gameManager;
    private SlotManagement _slotManagement;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        _enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _slotManagement = GameObject.Find("Head").GetComponent<SlotManagement>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameManager.gameOver = true;
            gameManager.gameOver = true;
            WinAnim();
            LoseAnim();
            NextLevelButton();
            
            
        }
            
    }

    public void Hit()
    {
       
        switch (_enemyController.helmetsLevel)
        {
            case -1:
                helmetAbsorb = 0f;
                break;
            case 0 :
                helmetAbsorb = 0.3f;
                break;
            case 1:
                helmetAbsorb = 0.4f;
                break;
            case 2:
                helmetAbsorb = 0.5f;
                break;
            case 4:
                helmetAbsorb = 0.6f;
                break;
        }
        
        
        if (gameManager.startGame && !gameManager.gameOver)
        {
            Debug.Log("helmetsLevel" + _enemyController.helmetsLevel);
        
            if (punchs[0].activeSelf)
            {
                TakeDamage(playerDamage + 1-(playerDamage*helmetAbsorb)); 
            }
            else if (punchs[1].activeSelf)
            {
                TakeDamage(playerDamage + 2-(playerDamage*helmetAbsorb) ); 
            }
            else if (punchs[2].activeSelf)
            {
                TakeDamage(playerDamage + 3-(playerDamage*helmetAbsorb)); 
            }
            else
            {
                TakeDamage(playerDamage - (playerDamage * helmetAbsorb));
               
            }
        }
      
        
    }
   

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
       
    }

    private void WinAnim()
    {
        _playerAnim.SetTrigger("win");
        
    }

    private void LoseAnim()
    {
        _enemyAnim.SetTrigger("lose");
    }
    private void NextLevelButton()
    {
       nextLevelButton.SetActive(true);
       
    }

   
}
