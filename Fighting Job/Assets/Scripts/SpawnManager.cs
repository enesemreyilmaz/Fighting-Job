using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameData gameData;
    public GameObject[] prefabs;
    private int randomPrefab;
    public Transform[] spawnPos; 
    public bool[] occupiedGrids;
    public bool allGridsOccupied;
    public Transform cellRotation;
    
    
    void Start()
    {
        occupiedGrids = new bool[spawnPos.Length];
        allGridsOccupied = gameData.allgridsOccupied; }


    public void GridPositionControl()
    {
        allGridsOccupied = true;

        // İlk 7 bool için kontrol et
        for (int i = 0; i < 8; i++)
        {
            if (!occupiedGrids[i])
            {
                allGridsOccupied = false;
                return; // Eğer bir boş grid bulursanız döngüden çıkın
            }
        }
    }
    public void RandomSpawnPrefab()
    {
        int randomIndex = Random.Range(0, 8);

        if (occupiedGrids[randomIndex])
        {
            while (occupiedGrids[randomIndex])
            {
                randomIndex = Random.Range(0, 8);
            }
            
        }

        randomPrefab = Random.Range(0, 2);
        GameObject spawnObject = Instantiate(prefabs[randomPrefab], spawnPos[randomIndex].position + prefabs[randomPrefab].transform.position, prefabs[randomPrefab].transform.rotation);
        
    }

}
