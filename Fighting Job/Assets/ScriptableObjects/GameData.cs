using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/GameData")]
public class GameData :  ScriptableObject


{
     
     public GameData gameData;
     public int money;
     private int incomeMultiplier;
     public int equipmentCost;
     public int incomeCost;
     public int level;
     public bool allgridsOccupied;





}
