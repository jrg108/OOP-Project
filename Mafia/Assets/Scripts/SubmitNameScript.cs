using UnityEngine;
using UnityEngine.UI;

public class SubmitNameScript : MonoBehaviour
{

    public InputField nameInputField;
    public Text enterNameText;
    private int playerNumber = 0;

    public void submitName()
    {
        if (playerNumber < GameManager.players.Count)
        {
            GameManager.players[playerNumber].playerName = nameInputField.text;
            nameInputField.text = "";
            playerNumber++;
            if(playerNumber != GameManager.players.Count)
                enterNameText.text = "Enter Name for Player " + (playerNumber + 1).ToString();
        }
        if (playerNumber == GameManager.players.Count)
        {
            ChangeScene.loadScene("Game");
            GameManager.gameRunning = true;
        }
        
    }
}
