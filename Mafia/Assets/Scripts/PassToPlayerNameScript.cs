using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassToPlayerNameScript : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Text>().text = "Pass to " + GameManager.players[GameManager.currentPlayerNumber].playerName;
    }
}
