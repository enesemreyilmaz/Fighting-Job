using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator _anim;
    public Animator _playerAnim;
   
    public float punchInterval = 5f;
    public float punchDelay;
    private float helmetAbsorb;
    public float enemyDamage;
    
    
    
    
    public GameObject[] punchs;
    public GameObject[] helmets;
    public int helmetsLevel;
    private GameManager gameManager;
    private SlotManagement _slotManagement;
    private Enemy _enemy;

    
    private bool punch;
    void Start()
    {

        _enemy = GameObject.Find("PlayerHealth").GetComponent<Enemy>();
         punch = _anim.GetBool("EnemyPunch");
         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
         _slotManagement = GameObject.Find("Head").GetComponent<SlotManagement>();
         
         if (helmets[0].activeSelf)
         {
             helmetsLevel = 0;
         }
         else if (helmets[1].activeSelf)
         {
             helmetsLevel = 1;
         }
         else  if (helmets[2].activeSelf)
         {
             helmetsLevel = 2;
         }
         
         else
         {
             helmetsLevel = -1;
         }
    }

    private void Update()
    {
        if (gameManager.startGame)
        {
            StartCoroutine(EnemyPunchCoroutine());
        }

        
        if (gameManager.gameOver)
        {
            StopCoroutine(EnemyPunchCoroutine());
        }
    }

    private IEnumerator EnemyPunchCoroutine()
    {
            while (true)
            {
                _anim.SetTrigger("EnemyPunch");
                yield return new WaitForSeconds(punchDelay);
                _anim.SetTrigger("IdleTrigger");
                yield return new WaitForSeconds(punchInterval - _anim.GetCurrentAnimatorStateInfo(0).length);

                if (_enemy.winAnimIsActive)
                {
                    yield break;
                }
            }
        
    }

    private void EnemyHit()
    {
        if (!gameManager.gameOver)
        {
            switch (_slotManagement.helmetsLevel)
            {
                case -1 :
                    helmetAbsorb = 0f;
                    break;
                case 0 :
                    helmetAbsorb = 0.2f;
                    break;
                case 1:
                    helmetAbsorb = 0.3f;
                    break;
                case 2:
                    helmetAbsorb = 0.4f;
                    break;
                case 4:
                    helmetAbsorb = 0.5f;
                    break;
            }
            
            if (punchs[0].activeSelf)
            {
                _enemy.TakeDamage( enemyDamage+4 -(enemyDamage*helmetAbsorb)); 
            }
            else if (punchs[1].activeSelf)
            {
                _enemy.TakeDamage( enemyDamage+8 -(enemyDamage*helmetAbsorb));
            }
            else if (punchs[2].activeSelf)
            {
                _enemy.TakeDamage( enemyDamage+12-(enemyDamage*helmetAbsorb));
            }
            else
            {
                _enemy.TakeDamage(enemyDamage -(enemyDamage*helmetAbsorb) );
            }
            _playerAnim.SetTrigger("Hit");
            if (_playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Character_Idle"))
            {
                _playerAnim.SetTrigger("IdleTrigger");
            } 
            
            
        }
       
      
    }
    
}
