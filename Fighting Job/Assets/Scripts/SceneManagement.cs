using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    private GameManager _gameManager;
    public GameData gameData;
    private int currentSceneIndex;
    private ObjectCollector objectCollector;
    public SpawnManager _SpawnManager;
    
   
    


    private void Awake()
    {
       
        
        
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
       
        
        
        if (currentSceneIndex == 0)
        {
            gameData.level = 1;
            gameData.money = 10000;
            gameData.incomeCost = 50;
            gameData.equipmentCost = 10;
        }
    }

    private void Start()
    {

        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _gameManager.gameOver = false;


    }

    public void NextScene()
    {
         
        
        
        int nextSceneIndex = currentSceneIndex + 1; 

        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            gameData.level++;
            
            
            

        }
        
    }



    public void TryAgainScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
}

