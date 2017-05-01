using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinner : MonoBehaviour {

	
	void Start ()
    {
        if (GameManager.mafiaWin)
            GetComponent<Text>().text = "Mafia Win";
        else
            GetComponent<Text>().text = "Townspeople Win";
	}
}
