using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{    public bool isAlive=true;
     #region Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {

            Destroy(gameObject);

        }
        else
        {
            _instance = this;
        }
    }
    #endregion
     private void Update() {
         if(!isAlive&&Input.touchCount>0&& Input.GetTouch(0).phase==TouchPhase.Began){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
     }
}
