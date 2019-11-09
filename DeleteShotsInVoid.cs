using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShotsInVoid : MonoBehaviour
{
  private GameObject playerObject;
  private Player player;

  void Start(){
    playerObject = GameObject.FindGameObjectWithTag("Player");
    player = playerObject.GetComponent<Player>();
  }

  private void OnTriggerExit(Collider collider){
    foreach (GameObject obj in FindObjectsOfType<GameObject>()) {
      if(obj.GetComponent<Collider>() == collider){
        if(obj == playerObject){
          player.ResetPlayerToCenter();
        }else{
          Destroy(obj);
        }
      }
    }
  }
}
