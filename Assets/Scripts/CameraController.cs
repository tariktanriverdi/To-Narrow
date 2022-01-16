using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("value of camera speed")]
    float cameraSpeed=0.5f;
   private void FixedUpdate() {
       transform.Translate(Vector3.forward*cameraSpeed,Space.World);
   }
 
}
