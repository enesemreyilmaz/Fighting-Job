using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosControl : MonoBehaviour
{
    public int gridIndex;

    private SpawnManager spawnManager;
    
    private void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        
    }
     
   private void OnTriggerStay(Collider other)
    {
       if (other.CompareTag("Prefab"))
       {
           spawnManager.occupiedGrids[gridIndex] = true;
       }
    }
   private void OnTriggerExit(Collider other)
   {
       if (other.CompareTag("Prefab"))
       {
           spawnManager.occupiedGrids[gridIndex] = false;
           
       }
   }
   
}
