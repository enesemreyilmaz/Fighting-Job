using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Input = UnityEngine.Windows.Input;


public class Merge : MonoBehaviour
{
  private MouseControl _mouseControl;
  private SpawnManager _spawnManager;
  private GameManager _gameManager;
  
  public bool sameObject = false;
  public ParticleSystem greenExplosion;
  
  
  
  
  

    private void Start()
  {
      _mouseControl = GetComponent<MouseControl>();
      _spawnManager = GetComponent<SpawnManager>();
      _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



  }

    

    private void OnTriggerStay(Collider other)
     {
      string thisGameObjectName;
      string collisionGameObjectName;
      
       
      
       if (other.CompareTag("Prefab")) 
       {
        Transform collidedObjectTransform = other.transform;
        thisGameObjectName = gameObject.name.Substring(0, gameObject.name.IndexOf("_"));
        collisionGameObjectName = other.gameObject.name.Substring(0, other.gameObject.name.IndexOf("_"));
        Debug.Log("colliderlar değiyor");
        if ( thisGameObjectName == collisionGameObjectName )
        {
         
         sameObject = true;
          
         if (_mouseControl.mouseRealesed && !_gameManager.gameOver && sameObject )
         {
          
          char lastCharacter = thisGameObjectName[thisGameObjectName.Length -1];
          int currentLevel = int.Parse(lastCharacter.ToString());
          int nextLevel = currentLevel + 1;
          string prefabName = thisGameObjectName.Replace("lvl" + currentLevel, "lvl" + nextLevel +"_");
          Instantiate(Resources.Load(prefabName),collidedObjectTransform.transform.position , collidedObjectTransform.transform.rotation);
          Instantiate(greenExplosion, collidedObjectTransform.transform.position + new Vector3(0, 0.15f, 0),
           Quaternion.identity);
          greenExplosion.Play();
          
          
          
          
          
          Destroy(other.gameObject);
          Destroy(gameObject);
          
          _mouseControl.mouseRealesed = false;
          

         }
         
         
        }
        else if (thisGameObjectName != collisionGameObjectName && _mouseControl.mouseRealesed && !_gameManager.gameOver )
        {
         transform.position = _mouseControl.firstPosition;
         sameObject = false;
        }

        
        
       }
       
       

      
     }
    
     
}

