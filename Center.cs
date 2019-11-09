using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public bool alive;
    public Material destroyed;
    //---
    private float cooldown = 0f;
    private MeshRenderer centerRenderer;
    private MeshRenderer stairRenderer;
    private Controller controller;

    void Start()
    {
      hp = maxHp;
      centerRenderer = gameObject.GetComponent<MeshRenderer>();
      stairRenderer = GameObject.Find("CenterStair").GetComponent<MeshRenderer>();
      controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }

    void Update()
    {
      if(hp <= 0 && alive){
        alive = false;
        centerRenderer.material = destroyed;
        stairRenderer.material = destroyed;
        controller.sendChatMessage("Center Destroyed");
      }
      Regenerate();
    }

    private void Regenerate(){
      if(cooldown <= 0){
        if(hp < maxHp && alive){
          hp++;
          cooldown = 1f;
        }
      }else{
        cooldown -= Time.deltaTime;
      }
    }
}
