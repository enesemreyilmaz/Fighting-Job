using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SlotManagement : MonoBehaviour
{

    private Merge _merge;
    public MouseControl _mouseControl;
    private GameManager _gameManager;
    public string gameObjectLevel;
    public int gameObjectLevelint;
    public int helmetsLevel;
    public int punchsLevel;
    private string gameObjectName;
    public string slotName;
    public bool sameName;
    private SpawnManager spawnManager;
   
    public GameObject[] helmets;
    public GameObject[] punchs;
    public GameObject gameObj;
    
    
    private int slotLevel;
    public TextMeshProUGUI slotLevelText;
        
    private void Start()
    {
        _merge = GetComponent<Merge>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        slotLevelText.text = 0.ToString();
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        helmetsLevel = -1;


    }

    

    public void OnTriggerEnter(Collider other)
    {

      

        
         gameObj = other.gameObject;
       
        
        
        gameObjectName = other.gameObject.name.Substring(0,1);
        slotName = gameObject.name.Substring(0, 1); 
        
        
            
            if ( slotName==gameObjectName )
            {
                
                sameName = true;
                
                
                if (slotName == "H" )
                {
                    gameObjectLevel = other.gameObject.name[other.gameObject.name.Length - 9].ToString();
                    helmetsLevel = int.Parse(gameObjectLevel) - 1;
                    helmets[helmetsLevel].SetActive(true);
                    slotLevelText.text = gameObjectLevel;
                    if (helmets[1].activeSelf)
                    {
                       helmets[0].SetActive(false);
                    }
                    if (helmets[2].activeSelf)
                    {
                        helmets[0].SetActive(false);
                        helmets[1].SetActive(false);
                    }
                    if (helmets[3].activeSelf)
                    {
                        helmets[0].SetActive(false);
                        helmets[1].SetActive(false);
                        helmets[2].SetActive(false);
                    }
                }
                else if (slotName == "P")
                {
                    gameObjectLevel = other.gameObject.name[other.gameObject.name.Length - 9].ToString();
                    punchsLevel = int.Parse(gameObjectLevel) - 1;
                    punchs[punchsLevel].SetActive(true);
                    if (punchs[1].activeSelf)
                    {
                        
                        punchs[0].SetActive(false);
                        
                    }
                    if (punchs[2].activeSelf)
                    {
                        
                        punchs[0].SetActive(false);
                        punchs[1].SetActive(false);
                        
                    }
                    slotLevelText.text = gameObjectLevel;
                }
                
                




            }
           else if(slotName!=gameObjectName)
            {
              slotLevelText.text = 0.ToString();
              sameName = false;
              
              
             
                
                
            }
          
            
    }

    private void OnTriggerExit(Collider other)
    {


        if (slotName == "H")
            {
                helmets[helmetsLevel].SetActive(false);
                helmetsLevel = -1;
                slotLevelText.text = 0.ToString();
           
            }


        if (slotName == "P")
            {
                punchs[punchsLevel].SetActive(false);
                slotLevelText.text = 0.ToString();
            
            }
        
        
      
    }

}
