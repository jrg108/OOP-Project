using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int numPlayers = 0, numMafia = 0, numNurses = 0, numCops = 0, numTown = 0;
    public static List<Player> players = new List<Player>();
    public static bool gameRunning = false;
    public static int currentPlayerNumber = 0;
    public static bool isNightTime = true;
    public static bool mafiaWin;

    void Awake()
    {
        //makes sure that only one gameMangager object is present in a scene
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        if (gameRunning == true)
        {
            RunGame();
        }
    }

	public static void AddMafiaPlayer()
    {
        players.Add(new Mafia());
    }

    public static void AddCopPlayer()
    {
        players.Add(new Cop());
    }

    public static void AddNursePlayer()
    {
        players.Add(new Nurse());
    }

    public static void AddTownPlayer()
    {
        players.Add(new Townsperson());
    }

    void RunGame()
    {
        if(currentPlayerNumber == players.Count)
        {
            if(CheckWinConditions())
            {
                SceneManager.LoadScene("WinnerScene");
            }

            if (isNightTime == true)
                isNightTime = false;
            currentPlayerNumber = 0;
            overNightDeath();
            DayTime();
        }

        if (isNightTime == true)
        {
            NightTime();
        }
    }

    void NightTime()
    {
        
        if (players[currentPlayerNumber].takingTurn == false)
        {
            players[currentPlayerNumber].nightTurn();
        }
            
        if (players[currentPlayerNumber].finishedTurn == true)
        {
            players[currentPlayerNumber].takingTurn = false;
            players[currentPlayerNumber].finishedTurn = false;
            currentPlayerNumber++;
            DeleteCanvas();
        }
    }

    void DayTime()
    {
        //Debug.Log("implement telling which player died overnight");
        SceneManager.LoadScene("DaytimeVote", LoadSceneMode.Additive);
    }

    public static void DeleteCanvas()
    {
        GameObject[] deletable = GameObject.FindGameObjectsWithTag("deleteAfterTurn");
        foreach (GameObject gameObject in deletable)
        {
            Destroy(gameObject);
        }
    }

    void overNightDeath()
    {
        int highestKillVote = 0;
        int highestSaveVote = 0;

        List<string> highestKillVotePlayers = new List<string>();
        List<string> highestSaveVotePlayers = new List<string>();

        foreach (Player player in players)
        {
            if (player.deathVoteCount > highestKillVote)
                highestKillVote = player.deathVoteCount;
            if (player.saveVoteCount > highestSaveVote)
                highestSaveVote = player.saveVoteCount;
        }

        foreach (Player player in players)
        {
            if (player.deathVoteCount == highestKillVote)
                highestKillVotePlayers.Add(player.playerName);
            if (player.saveVoteCount == highestSaveVote)
                highestSaveVotePlayers.Add(player.playerName);
            player.deathVoteCount = 0;
            player.saveVoteCount = 0;
        }

        string nameOfKilled = highestKillVotePlayers[Random.Range(0, highestKillVotePlayers.Count)];
        string nameOfSaved = highestSaveVotePlayers[Random.Range(0, highestKillVotePlayers.Count)];
        Debug.Log("killed: " + nameOfKilled);
        Debug.Log("saved: " + nameOfSaved);

        //highest save vote equal to zero here makes sure that there was actually a nurse that tried to save someone and they were not all 0
        if (nameOfKilled != nameOfSaved || highestSaveVote == 0)
        {
            foreach (Player player in players)
            {
                if (player.playerName == nameOfKilled)
                {
                    players.Remove(player);
                    break;
                }
            }
        }
    }

    bool CheckWinConditions()
    {
        int numMafia = 0;

        foreach (Player player in players)
        {
            if (player.GetType() == typeof(Mafia))
                numMafia++;
        }

        if(numMafia == 0)
        {
            mafiaWin = false;
            return true;
        }
        else if(numMafia >= players.Count/2)
        {
            mafiaWin = true;
            return true;
        }
        else
            return false;
    }
}

public abstract class Player
{
    public string playerName;
    public bool isAlive = true;
    public int deathVoteCount = 0;
    public int saveVoteCount = 0;
    public bool takingTurn = false;
    public bool finishedTurn = false;

    public abstract void nightTurn();
}

public class Townsperson : Player
    {
    public override void nightTurn()
    {
        takingTurn = true;
        SceneManager.LoadScene("Townsperson Turn", LoadSceneMode.Additive);
    }

}

public class Mafia : Player
{
    public string killVote;
    public override void nightTurn()
    {
        takingTurn = true;
        SceneManager.LoadScene("Mafia Turn", LoadSceneMode.Additive);
    }

}

public class MafiaTeam : Player
{
    public List<Player> mafiaPlayers;

    public override void nightTurn()
    {
        takingTurn = true;
    }

    void Add(Player player)
    {
        mafiaPlayers.Add(player);
    }

    void Remove(string playerName)
    {
        for(int i = 0; i < mafiaPlayers.Count; i++)
        {
            if (mafiaPlayers[i].playerName == playerName)
                mafiaPlayers.RemoveAt(i);
        }
    }
}

public class Nurse : Player
{
    public override void nightTurn()
    {
        takingTurn = true;
        SceneManager.LoadScene("Nurse Turn", LoadSceneMode.Additive);
    }
}

public class Cop : Player
{
    public override void nightTurn()
    {
        takingTurn = true;
        SceneManager.LoadScene("Cop Turn", LoadSceneMode.Additive);
    }
}

public static class ExtensionMethod
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
