using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider){
      GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

      foreach (GameObject obj in enemys) {
        if(obj.GetComponent<Collider>() == collider){
          Enemy enemy = obj.GetComponent<Enemy>();
          enemy.hp -= damage;
          Destroy(gameObject);
        }
      }
    }
}
