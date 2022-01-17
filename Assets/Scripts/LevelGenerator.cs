using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region  SerializeFields
    [Header("LevelComponent Attributes")]
    [Tooltip("Defauld Level Component Prefab")]
    [SerializeField] GameObject lvlComponent;

    [Tooltip("All Components min radius")]
    [SerializeField] float minRadius;
    [Tooltip("All Components max radius")]
    [SerializeField] float maxRadius;

    [Tooltip("All Components min length")]
    [SerializeField] float minLength;
    [Tooltip("All Components max length")]
    [SerializeField] float maxLength;

    [Header("Obstacle Attributes")]
    [SerializeField] GameObject obstacleComponent;
    [SerializeField] float obstacleValue = 0.1f;
    #endregion
    #region PrivateValues
    private GameObject _previousLvlComponent;
    #endregion
    #region  Unity
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            float radius = FindRandomRadius();
            float length = FindRandomLength();
            while (_previousLvlComponent && Mathf.Abs(_previousLvlComponent.transform.localScale.x - radius) < 0.5f)
                radius = FindRandomRadius();
            lvlComponent.transform.localScale = new Vector3(radius, length, radius);
            obstacleComponent.transform.localScale = new Vector3(radius, length, radius);
            if (i == 0) _previousLvlComponent = LvlComponentInstance(Vector3.zero);
            else
            {
                float swapnPoint = _previousLvlComponent.transform.position.z +
                 _previousLvlComponent.transform.localScale.y + lvlComponent.transform.localScale.y;
                //obstacle instantiate
                if (Random.value < obstacleValue)
                {
                    swapnPoint = _previousLvlComponent.transform.position.z +
                   _previousLvlComponent.transform.localScale.y + obstacleComponent.transform.localScale.y;
                    _previousLvlComponent = ObstacleComponentInstance(new Vector3(0, 0, swapnPoint));
                }
                else
                {

                    _previousLvlComponent = LvlComponentInstance(new Vector3(0, 0, swapnPoint));
                }

            }

        }
    }
    #endregion
    #region  Functions
    private GameObject ObstacleComponentInstance(Vector3 position)
    {
        return Instantiate(obstacleComponent, position, obstacleComponent.transform.rotation);
    }

    GameObject LvlComponentInstance(Vector3 position)
    {
        GameObject obj= Instantiate(lvlComponent, position, lvlComponent.transform.rotation);
        //assign count of point randomly
        obj.GetComponent<SpawnPoint>().countOfPoints=Random.RandomRange(1,3);
        return obj;
    }
    float FindRandomRadius()
    {
        return Random.Range(minRadius, maxRadius);
    }
    float FindRandomLength()
    {
        return Random.Range(minLength, maxLength);
    }
    #endregion
}
