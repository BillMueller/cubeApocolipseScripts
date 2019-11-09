using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShots : MonoBehaviour
{
    public GameObject[] bullets;

    private Player player;

    void Start(){
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Fire(float shotAmmount, float accuracy)
    {
      for (float f = 0f; f<shotAmmount; f++) {
        Vector3 currentDispersion = new Vector3(0,0,0); //TODO: change to new Vector3(randdm(-accuracy, accuracy), 0 , random(-accuracy, accuracy))!!
        Instantiate(bullets[player.shotLevel], transform.position, Quaternion.Euler(currentDispersion+transform.rotation.eulerAngles));
      }
    }
}
