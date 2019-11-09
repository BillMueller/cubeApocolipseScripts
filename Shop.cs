using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public float playerSpeed;
    public float playerHealth;
    public float playerHealthRegenration;
    public float playerShots;
    public float playerShotRegeneration;
    public float shotType;
    public float shotReload;
    //--
    public float[] playerHealthPerLevel;
    public float[] playerShotsPerLevel;
    //public float[] playerHealthPerLevel = [100,160,260,410,660,1100,1700,2700,4300,7000,11000];
    //public float[] playerShotsPerLevel = [10,16,26,41,66,110,170,270,430,700,1100];
    //--
    private bool opened = false;
    private Controller controller;
    private Player player;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {

    }
}
