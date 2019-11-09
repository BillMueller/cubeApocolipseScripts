using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCenterPositions : MonoBehaviour
{
    private Center center;
    private GameObject playerObject;
    private Collider playerCollider;
    private Player player;

    void Start(){
      center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
      playerObject = GameObject.FindGameObjectWithTag("Player");
      playerCollider = playerObject.GetComponent<Collider>();
      player = playerObject.GetComponent<Player>();
    }

    private void OnTriggerStay(Collider collider){
      GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

      foreach (GameObject obj in enemys) {
        if(obj.GetComponent<Collider>() == collider){
          center.hp--;
        }
      }

      if(playerCollider == collider && center.alive){
        player.inCenter = true;
      }
    }
}
