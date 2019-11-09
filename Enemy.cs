using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float gravity;
  public float speed;
  public float hp;
  public float reward;
  //---
  private CharacterController charController;
  private float currentGravity = 0f;
  private GameObject player;
  private Controller controller;
  // Start is called before the first frame update
  void Start()
  {
      charController = gameObject.GetComponent<CharacterController>();
      player = GameObject.FindGameObjectWithTag("Player");
      controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
  }

  void Update()
  {
    RotateTowardsTarget();
    charController.Move((transform.forward*speed + GetGravity())*Time.deltaTime);
    if(hp <= 0f){
      Die();
    }
  }

  private void Die(){
    controller.money += reward;
    Destroy(gameObject);
  }

  Vector3 GetGravity(){

    currentGravity += gravity;

    if(charController.isGrounded && currentGravity > 1f){
      currentGravity = 1f;
    }

    return new Vector3(0,-currentGravity, 0);
  }

  void RotateTowardsTarget(){
    Vector3 direction = player.transform.position - transform.position;
    direction.y = 0;
    Quaternion ld = Quaternion.LookRotation(direction);
    transform.rotation = ld;
  }
}
