using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
 #region  Serialize Varibles
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text scoreText;
 #endregion

 public void OpenGameOverPanel(){
     gameOverPanel.SetActive(true);
 }
 public void UpdateScore(float score){
     scoreText.text=score.ToString();
 }
}
