using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script class added to dropdown for selecting mafia count
public class MafiaAmount : MonoBehaviour {

    private Dropdown dropDown;
    
	void Start ()
    {
        dropDown = GetComponent<Dropdown>();
	}

    public void createOptions()
    {
        dropDown.ClearOptions();
        int maxMafia = GameManager.numPlayers / 2 - 1;
        for(int i = 1; i <= maxMafia; i++)
        {
            dropDown.options.Add(new Dropdown.OptionData(i.ToString()));
        }
    }
}
