using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;


public class MouseControl : MonoBehaviour
{


    public bool isDragging = false;
    private Vector3 offset;
    public Vector3 mouseWorldPos;
    public Vector3 firstPosition;
    private Transform planeTransformm;
    
    private int boolPlanee;
    
    private float mouseElevaiton;
    private float mouseElevaitonZ;
        
    
    private SpawnManager _spawnManager;
    private Merge _merge;
    private SlotManagement _slotManagement;
    private SlotManagement _slotManagement2;

    private Transform draggedObject;
    public bool mouseRealesed;
    
    
    public float tiltAngle;

    private float mZCoord;
    private float elevation;
    
    private int levelFarkı;


    


    private void Start()
    {
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        SpawnPosControl _spawnPosControl = GetComponent<SpawnPosControl>();
        _merge = GetComponent<Merge>();
        _slotManagement = GameObject.Find("Head").GetComponent<SlotManagement>();
        _slotManagement2 = GameObject.Find("Punch").GetComponent<SlotManagement>();
        mouseElevaiton = 0.35f;
        mouseRealesed = false;





    }

    

    private void OnMouseDown()
    {

        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        
        offset = transform.position - GetMouseWorldPosition();
        firstPosition = transform.position;
       
        isDragging = true;
        mouseRealesed = false;
      
        
        


    }
    private void OnMouseDrag()
    {
        if (isDragging)

        {
            (Transform planeTransform, int boolPlane) = PlaneCheckAndBoolCheck();
            
           
            planeTransformm = planeTransform;
            boolPlanee = boolPlane;
            mouseWorldPos = GetMouseWorldPosition() + offset;
            elevation = (transform.position.z-firstPosition.z)* Mathf.Tan(tiltAngle * Mathf.Deg2Rad);
            mouseWorldPos.y = elevation+ firstPosition.y +mouseElevaiton ;
            
            transform.position = mouseWorldPos;
            
            
            
            
        }

        
    }
    private void OnMouseUp()
    {
        isDragging = false;
        
        
        mouseRealesed = true;
       
       
       
       
        
        if (planeTransformm != null && boolPlanee != -1 )
        {
            if (!_spawnManager.occupiedGrids[boolPlanee] && boolPlanee !=8 && boolPlanee !=9)
            {
                transform.position = planeTransformm.position +  new Vector3(0, 0.15f, 0);
                mouseRealesed = false;
                mouseElevaiton = 0.35f;
                



            }
            if (boolPlanee == 9 && gameObject.name.Substring(0, 1) == "P"  )
            {
                
                if (!_spawnManager.occupiedGrids[9])
                {
                    
                    transform.position = planeTransformm.position;
                    transform.rotation = Quaternion.Euler(50,-180f,0.092f);
                    mouseRealesed = false;
                    mouseElevaiton = 0.8f;
                }
                
                

            }
            else if ((boolPlanee == 9 && gameObject.name.Substring(0, 1) == "H"))
            {
                transform.position = firstPosition;
                mouseRealesed = false;
                mouseElevaiton = 0.35f;
            }
            else if (boolPlanee == 8 && gameObject.name.Substring(0, 1) == "H" )
            {
                if ( !_spawnManager.occupiedGrids[8])
                {
                    transform.position = planeTransformm.position;
                    transform.rotation = Quaternion.Euler(-53.996f,-180f,0f);
                    mouseRealesed = false;
                    mouseElevaiton = 0.8f;
                }
              

            }
            else if ((boolPlanee == 8 && gameObject.name.Substring(0, 1) == "P"))
            {
                transform.position = firstPosition;
                mouseRealesed = false;
                mouseElevaiton = 0.35f;
            }
        }
       
        else if (planeTransformm == null && boolPlanee == -1 && !_merge.sameObject )
        {
           transform.position = firstPosition;
           mouseRealesed = false;
            mouseElevaiton = 0.35f;
        }
            
        
        }
      
    
    public Vector3 GetMouseWorldPosition()
    {
        
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public (Transform, int) PlaneCheckAndBoolCheck()
    {
        Vector3 rayDirection = new Vector3(0, -1, 1); 
        Ray ray = new Ray(transform.position, rayDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("plane"))
            {
                
                SpawnPosControl _spawnPosControl = hit.collider.GetComponent<SpawnPosControl>();
                Transform planeTransform = hit.collider.transform;
                int boolPlane = _spawnPosControl.gridIndex;
                

                return (planeTransform, boolPlane);
            }

            
        }

        return (null, -1);
    }

   


    
}