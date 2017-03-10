using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPlayerNumberScript : MonoBehaviour {

    public Text numPlayerText;

	public void changeNumPlayers()
    {
        GameManager.numPlayers = System.Int32.Parse(numPlayerText.text);
    }
}
