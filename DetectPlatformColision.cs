using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlatformColision : MonoBehaviour
{
    public float id;

    private Platform platform;

    void Start()
    {
      GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

      foreach (GameObject obj in platforms) {
        if(obj.GetComponent<Platform>().id == id){
          platform = obj.GetComponent<Platform>();
        }
      }
    }

    private void onTriggerStay(Collider other){
      platform.CollisionDetected(other);
    }
}
