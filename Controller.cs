using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float money;
    public float chatVisibilityTime;
    public bool chatVisibility;
    public string[] enemyNames;
    public GameObject[] enemys;
    //--
    private Player player;
    private Text moneyBar;
    private Text chat;
    private string chatText;
    private float currentChatVisibility;

    void Start()
    {
      money = 0;
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      moneyBar = GameObject.FindGameObjectWithTag("Money_bar").GetComponent<Text>();
      chat = GameObject.FindGameObjectWithTag("Chat").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      UpdateMoneyBar();
      if(chatVisibility){
        UpdateChat();
      }
    }

    public void GameOver(){
      sendChatMessage("Game Over!");
    }

    private void UpdateChat(){
      if(currentChatVisibility <= 0f){
        chatText = "";
      }else{
        currentChatVisibility -= Time.deltaTime;
      }

      chat.text = chatText;
    }

    private void UpdateMoneyBar(){
      moneyBar.text = "Money: " + money + "$";
    }

    public void sendChatMessage(string text){
      chatText = chatText + text + "\n";
      currentChatVisibility = chatVisibilityTime;
    }
}
