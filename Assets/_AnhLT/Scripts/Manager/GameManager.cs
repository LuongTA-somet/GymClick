using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Bot bot;
    public BotFinish botFinish;
    public bool isBotFinish=false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
    }

}
