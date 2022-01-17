using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region  Constants
    private const float sizeScale = 0.285f;
    private const float checkerRadius = 0.0001f;
    #endregion
    #region  Private Variables
    private Vector3 default_size = Vector3.one;
    #endregion
    #region  SerializeFields
    [SerializeField] private LayerMask gameObjectsLayer;
    [SerializeField] private float scaleLerpTime = 0.07f;
    #endregion
    #region  Public variables
    public float health = 10.0f;
    #endregion
    public bool canCollect = false;
    #region  Unity
    private void Update()
    {
        //define game object which inside of ring
        Transform gObj = Physics.OverlapSphere(transform.position, checkerRadius, gameObjectsLayer).Length > 0 ? GetTransform() : null;

        float scaleVal = gObj != null ? gObj.localScale.z * sizeScale : default_size.z;
        if (scaleVal > transform.localScale.z)
        {
            Death();
        }
        //change radius of ring
        ChangeRingRadius(gObj, scaleVal);
        
        HealthCounter();
    }
    #endregion
    #region  Functions
    private void ChangeRingRadius(Transform gObj, float scaleVal)
    {
        if (Input.touchCount > 0 && gObj != null)
        {
            //   bool solid=Physics.CheckSphere(transform.position,1f,gameObjectsLayer);
            Vector3 targetVector = new Vector3(default_size.x, scaleVal, scaleVal);
            transform.localScale = Vector3.Slerp(transform.localScale, targetVector, scaleLerpTime);
            
            if (gObj.CompareTag("Obstacle")) Death();
            else{
            Point[] childOfGo=   gObj.GetComponentsInChildren<Point>();
            foreach(var child in childOfGo){
                child.isCollectable=true;
            }
                canCollect = true;
            }
            
            //Debug.Log(gObj.localScale);
        }
        //change radius of ring to defauld value
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, default_size, scaleLerpTime);
            canCollect = false;
        }
    }
    private Transform GetTransform()
    {
        return Physics.OverlapSphere(transform.position, checkerRadius, gameObjectsLayer)[0].transform;
    }
    public void Death()
    {
        Camera.main.GetComponent<CameraController>().enabled = false;

        Debug.Log("Game Over");
        this.gameObject.SetActive(false);

    }
    private void HealthCounter()
    {   
        health=Mathf.Clamp(health,-1,10f);
        if (health > 0) health -= Time.deltaTime;
        else Death();
    }
    public void IncreseHealth(float value)
    {
        health += value;

    }
    #endregion 
}
