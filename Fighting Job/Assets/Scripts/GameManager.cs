using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private SpawnManager _spawnManager;
   private Merge _merge;
   public int money = 0;
   //public int level = 1;
   private int incomeCost;
   private int equipmentCost;
   private int incomeAdd = 1;
   private float punchWaitTime = 0.4f;
   private bool isScreenMoneyButtonClicked = false;
   private bool isPunching = false;
   public bool gameOver = false;
   public bool startGame = false;
   public bool savePrefab;

   public GameData gameData;
   public Button moneyScreenButton;
   


   public TextMeshProUGUI moneyText;
   public TextMeshProUGUI incomeText;
   public TextMeshProUGUI addEquipmentText;
   public TextMeshProUGUI levelText;
   public TextMeshProUGUI tapToStartText;
   public Animator _anim;
   public Animator _screenMoneyAnim;
  
   public GameObject helmet1;
   public GameObject punch1;
   
    public List<GameObject> clonedObjects = new List<GameObject>();

   private void Awake()
   {
      DontDestroyOnLoad(helmet1);
      DontDestroyOnLoad(punch1);
   }

   private void Start()
   {
      startGame = false;
      gameOver = false;
      _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
      
      _merge = GetComponent<Merge>();
      incomeCost = gameData.incomeCost;
      equipmentCost = gameData.equipmentCost;
      money = gameData.money;
      moneyText.text = money + "$"; 
      incomeText.text = incomeCost  + "$";  
      addEquipmentText.text = equipmentCost.ToString() + "$"; ;
      levelText.text = "Level: " + gameData.level;
      savePrefab = false;



   }

   private void Update()
   {
      if (isScreenMoneyButtonClicked && !gameOver && startGame == true)
      {
         isScreenMoneyButtonClicked = false;
         StartCoroutine(PlayPunchAnimation());
         punchWaitTime += 0.2f; // Her çağırımda bekleme süresini arttır
         gameData.money = money;

      }

      if (gameOver)
      {
         StopCoroutine(PlayPunchAnimation());
         if (!savePrefab)
         {
            FindPrefabObjects();
            savePrefab = true;
         }
         

      }
     
   }

   public void StartGame()
   {
      startGame = true;
      tapToStartText.gameObject.SetActive(false);
      moneyScreenButton.gameObject.SetActive(true);
      

   }


   public void ScreenMoneyButton()
   {
      if (!gameOver && startGame)
      {
         money += incomeAdd;
         moneyText.text =  money + "$"; 

         isScreenMoneyButtonClicked = true;
         //_screenMoneyAnim.SetTrigger("Money");
         
      }
     
   }


    private IEnumerator PlayPunchAnimation()
   {
      if (!isPunching && !gameOver && startGame)
      {
         _anim.SetTrigger("PunchTrigger");
         isPunching = true;
         
         float timeElapsed = 0f;
         while (timeElapsed < punchWaitTime)
         {
            timeElapsed += Time.deltaTime;
            yield return null;
         }
         
         _anim.Play("Character_Idle", 0, 0f);
          punchWaitTime = 0.4f;
         isPunching = false;
      }
     
      
   }

  

   public void ButtonClickSpawn()
   {
      if (!gameOver && startGame)
      {
         _spawnManager.GridPositionControl();
         if (!_spawnManager.allGridsOccupied && money>=gameData.equipmentCost)
         {
            _spawnManager.RandomSpawnPrefab();
            money = money - gameData.equipmentCost;
            gameData.equipmentCost = gameData.equipmentCost + 25 ;
            addEquipmentText.text=gameData.equipmentCost.ToString() + "$"; 
         }
      }

      
   }

   public void Income()
   {
      if (!gameOver && startGame)
      {
         if (money >= incomeCost)
         {
            incomeAdd++;
           
            money = money - gameData.incomeCost;
            gameData.incomeCost = gameData.incomeCost + 50;
            incomeText.text = "Income" + "(" + gameData.incomeCost + ")";
         }
      }
    
    
   }

   void FindPrefabObjects()
   {
      GameObject[] allObjects = FindObjectsOfType<GameObject>();

      foreach (GameObject obj in allObjects)
      {
         if (obj.CompareTag("Prefab") )
         {
            clonedObjects.Add(obj);
            DontDestroyOnLoad(obj);
            
         }
      }
   }
     


     
   
   
   

   
   
   
}
