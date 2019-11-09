using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float enemysToCreate;
    public int enemyId;
    public float creationCooldown;
    public float id;

    private float cooldown = 0f;
    private GameObject enemyType;
    private string enemyName;
    private Controller controller;

    void Start()
    {
      controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
      enemyType = controller.enemys[enemyId];
      enemyName = controller.enemyNames[enemyId];
    }

    void Update()
    {
      if(cooldown <= 0f && enemysToCreate > 0f){
        GameObject createdEnemy = Instantiate(enemyType, transform.position + new Vector3(0f,1.1f,0f), transform.rotation);
        createdEnemy.name = enemyName;

        enemysToCreate--;
        cooldown = creationCooldown/Time.deltaTime;
      }else if(cooldown > 0f){
        cooldown--;
      }
    }

    public void CollisionDetected(Collider other){

    }
}
