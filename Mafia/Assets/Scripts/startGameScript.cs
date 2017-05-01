using UnityEngine;
using UnityEngine.UI;

public class startGameScript : MonoBehaviour
{
    private Button startButton;

    void Start()
    {
        startButton = GetComponent<Button>();
    }

    void Update()
    {
        if (GameManager.numPlayers >= 5 && GameManager.numMafia + GameManager.numNurses + GameManager.numCops <= GameManager.numPlayers && GameManager.numMafia > 0)
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }

    public void startGame()
    {
        GameManager.numTown = GameManager.numPlayers - GameManager.numCops - GameManager.numMafia - GameManager.numNurses;
        for(int i = 0; i < GameManager.numMafia; i++)
        {
            GameManager.AddMafiaPlayer();
        }

        for (int i = 0; i < GameManager.numCops; i++)
        {
            GameManager.AddCopPlayer();
        }

        for (int i = 0; i < GameManager.numNurses; i++)
        {
            GameManager.AddNursePlayer();
        }

        for (int i = 0; i < GameManager.numTown; i++)
        {
            GameManager.AddTownPlayer();
        }

        GameManager.players.Shuffle();

        ChangeScene.loadScene("Name Setup");
    }
	
}
