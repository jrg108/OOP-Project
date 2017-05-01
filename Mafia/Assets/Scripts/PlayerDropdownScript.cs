using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class PlayerDropdownScript : MonoBehaviour
{

    private Dropdown dropDown;

	// Use this for initialization
	void Start ()
    {
        dropDown = GetComponent<Dropdown>();
        foreach (Player player in GameManager.players)
        {
            dropDown.options.Add(new Dropdown.OptionData(player.playerName));
        }
    }
}
