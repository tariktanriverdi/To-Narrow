using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{


    [SerializeField] float rotateSpeed = 40f;
    [SerializeField] float healthValue = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Color collectableColor, unCollectableColor;
    public bool isCollectable=false;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        bool touchToPlayer = Physics.CheckSphere(transform.position, transform.localScale.x / 2, playerLayer);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            bool playerCanCollect = player.GetComponent<PlayerController>().canCollect;
            if (playerCanCollect&&isCollectable)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = collectableColor;
                if (touchToPlayer)
                {  
                    player.GetComponent<PlayerController>().IncreseHealth(healthValue);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = unCollectableColor;

            }
        }

    }
}
