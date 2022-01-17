using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] public int countOfPoints;
    
    private void Start()
    {
        CreatePoint(countOfPoints);
    }

    private void CreatePoint(int countOfPoints)
    {
        float perPointComponentWith = (transform.localScale.y * 2) / (countOfPoints + 1);

        float height = point.transform.localScale.x / 2 + transform.localScale.x / 2;

        for (int i = 1; i < countOfPoints + 1; i++)
        {   
        float posStart = transform.position.y - transform.localScale.y +(( perPointComponentWith)*i);
            
            Vector3 position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z + posStart);
           GameObject pointGo= Instantiate(point, position, Quaternion.identity);
           GameObject emty=new GameObject("emty");
           emty.transform.SetParent(transform);
           pointGo.transform.SetParent(emty.transform);
           //pointGo.transform.localScale=Vector3.one;
        }
        //Vector3 position=new Vector3(transform.position.x,transform.position.y+height,transform.position.z+posStart);
        // Debug.Log(position);

    }
}
