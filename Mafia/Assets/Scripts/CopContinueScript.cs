using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopContinueScript : MonoBehaviour {
	public void CopContinue ()
    {
        GameManager.players[GameManager.currentPlayerNumber].finishedTurn = true;
    }
}
