using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float gravity;
    public float speed;
    public float rotationSpeed;
    public float maxHp;
    public float hp;
    public float hpRegenerationSpeed;
    public bool inCenter;
    public float shots;
    public float maxShots;
    public float shotRegenerationSpeed;
    public int shotLevel;
    public float cooldown;
    public float shotAmmount;
    public float accuracy;
    //---
    private CharacterController charController;
    private float currentGravity = 0f;
    private float hpRegenerationCooldown = 0f;
    private float shotRegenerationCooldown = 0f;
    private Center center;
    private Text hpBar;
    private Text shotBar;
    private Controller controller;
    private Vector3 extraMove;
    private bool reset = false;
    private float currentCooldown = 0f;
    private CreateShots shotCreator;
    // Start is called before the first frame update
    void Start()
    {
        charController = gameObject.GetComponent<CharacterController>();
        hp = maxHp;
        shots = maxShots;
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
        hpBar = GameObject.FindGameObjectWithTag("Hp_bar").GetComponent<Text>();
        shotBar = GameObject.FindGameObjectWithTag("Shot_bar").GetComponent<Text>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        shotCreator = GameObject.FindGameObjectWithTag("ShotCreator").GetComponent<CreateShots>();
    }

    // Update is called once per frame
    void Update()
    {
      if(reset){
        charController.Move(extraMove);
        reset = false;
      }else{
        charController.Move((GetMovement() + GetGravity())*Time.deltaTime);
      }

      Regenerate();
      UpdateHpBar();
      UpdateShotBar();

      if(currentCooldown <= 0f){
        if(Input.GetButtonDown("Fire") && shots >= shotAmmount){
          shots -= shotAmmount;
          currentCooldown = cooldown;
          shotCreator.Fire(shotAmmount, accuracy);
        }
      }else{
        currentCooldown-=Time.deltaTime;
      }
    }

    private void UpdateHpBar(){
      hpBar.text = "HP: " + hp;
    }

    private void UpdateShotBar(){
      shotBar.text = "Shots: " + shots;
    }

    private void Die(string deathReason){
      controller.sendChatMessage("Player died to " + deathReason);
      ResetPlayerToCenter();
    }

    public void ResetPlayerToCenter(){
      if(center.alive){
        Vector3 distance = Vector3.zero - transform.position;
        distance.y += 1;

        extraMove = distance;
        reset = true;
      }else{
        controller.GameOver();
      }
    }

    private void Regenerate(){
      if(hpRegenerationCooldown <= 0){
        if(hp < maxHp){
          hp ++;
          if(inCenter){
            hp += 3;
          }
          hpRegenerationCooldown = 1/hpRegenerationSpeed;
        }
      }else{
        hpRegenerationCooldown -= Time.deltaTime;
        if(inCenter){
          hpRegenerationCooldown -= Time.deltaTime*9;
        }
      }

      if(shotRegenerationCooldown <= 0){
        if(shots < maxShots){
          shots ++;
          shotRegenerationCooldown = 10/shotRegenerationSpeed;
        }
      }else{
        shotRegenerationCooldown -= Time.deltaTime;
        if(inCenter){
          shotRegenerationCooldown -= Time.deltaTime*99;
        }
      }

      if(hp > maxHp){
        hp = maxHp;
      }

      if(shots > maxShots){
        shots = maxShots;
      }

      inCenter = false;
    }

    private void OnTriggerEnter(Collider collider){
      Debug.Log("collision");
      //Collider collider = collision.collider;
      GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

      foreach (GameObject obj in enemys) {
        if(obj.GetComponent<Collider>() == collider){
          Enemy enemy = obj.GetComponent<Enemy>();
          if(enemy.hp >= hp){
            enemy.hp -= hp;
            hp = 0f;
            Die(obj.name);
          }else{
            hp -= enemy.hp;
            enemy.hp = 0f;
          }
        }
      }
    }

    private Vector3 GetGravity(){

      currentGravity += gravity;

      if(charController.isGrounded && currentGravity > 1f){
        currentGravity = 1f;
      }

      return new Vector3(0,-currentGravity, 0);
    }

    private Vector3 GetMovement(){
      Vector3 movement = Vector3.zero;

      movement += transform.right * Input.GetAxis("Strave");

      if(Input.GetAxis("Move")<0){
        movement += transform.forward * Input.GetAxis("Move");
        movement *= .6f;
      }else{
        movement *= .6f;
        movement += transform.forward * Input.GetAxis("Move");
      }
      transform.Rotate(0,rotationSpeed * Input.GetAxis("Rotate")*Time.deltaTime*10,0);

      movement *= speed;

      return movement;
    }
}
