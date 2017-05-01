using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitVoteScript : MonoBehaviour
{
    public enum Role
    {
        mafia,
        nurse,
        cop,
        townsperson,
        daytimeVote
    };
    public Role role;

    public Dropdown dropdown;
    public Text copMessage;
    public Button copButton;

    public void SubmitVote()
    {
        switch (role)
        {
            case Role.mafia:
                foreach (Player player in GameManager.players)
                {
                    if (player.playerName == dropdown.captionText.text)
                        player.deathVoteCount++;
                }
                GameManager.players[GameManager.currentPlayerNumber].finishedTurn = true;
                break;

            case Role.nurse:
                foreach (Player player in GameManager.players)
                {
                    if (player.playerName == dropdown.captionText.text)
                        player.saveVoteCount++;
                }
                GameManager.players[GameManager.currentPlayerNumber].finishedTurn = true;
                break;

            case Role.cop:
                copButton.interactable = true;
                GetComponent<Button>().interactable = false;
                foreach (Player player in GameManager.players)
                {
                    if (player.playerName == dropdown.captionText.text)
                    {
                        if (player.GetType() == typeof(Mafia))
                            copMessage.text = player.playerName + " is in the Mafia";
                        else
                            copMessage.text = player.playerName + " is not in the Mafia";
                    }
                }
                break;
            case Role.daytimeVote:
                foreach (Player player in GameManager.players)
                {
                    if (player.playerName == dropdown.captionText.text)
                    {
                        GameManager.players.Remove(player);
                        break;
                    } 
                }
                GameManager.isNightTime = true;
                GameManager.DeleteCanvas();
                break;
            default:
                GameManager.players[GameManager.currentPlayerNumber].finishedTurn = true;
                break;
        }
    }
}
