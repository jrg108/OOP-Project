using UnityEngine;
using UnityEngine.UI;

public class ConfirmPlayerNumberScript : MonoBehaviour {

    public Text numPlayerText;
    public GameObject message;

	public void changeNumPlayers()
    {
        GameManager.numPlayers = int.Parse(numPlayerText.text);
        if (GameManager.numPlayers < 5)
            message.SetActive(true);
        else
            message.SetActive(false);

    }
}
