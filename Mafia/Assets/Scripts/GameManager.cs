using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int numPlayers, numMafia, numNurses, numCops, numTown;
    public static List<Player> players;

    void Awake()
    {
        //makes sure that only one gameMangager object is present in a scene
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }
 
    void Start()
    {

    }
    

	void Update ()
    {
		
	}

    void nightTurn()
    {
        foreach (Player player in players)
        {
            player.nightTurn();
        }
    }

    void dayTurn()
    {
        foreach (Player player in players)
        {
            player.dayTurn();
        }
    }
}

public abstract class Player
{
    public string name;
    public bool isAlive;

    public abstract void nightTurn();
    public abstract void dayTurn();
}

public class Townsperson : Player
    {
    public override void nightTurn()
    {
    }

    public override void dayTurn()
    {
    }

}

public class Mafia : Player
{
    public override void nightTurn()
    {
    }

    public override void dayTurn()
    {
    }

}

public class MafiaTeam : Player
{
    public List<Player> mafiaPlayers;

    public override void nightTurn()
    {
    }
    public override void dayTurn()
    {
    }
    void Add(Player player)
    {
        mafiaPlayers.Add(player);
    }

    void Remove(string playerName)
    {
        for(int i = 0; i < mafiaPlayers.Count; i++)
        {
            if (mafiaPlayers[i].name == playerName)
                mafiaPlayers.RemoveAt(i);
        }
    }
}

public class Nurse : Player
{
    public override void nightTurn()
    {
    }

    public override void dayTurn()
    {
    }

}

public class Cop : Player
{
    public override void nightTurn()
    {
    }

    public override void dayTurn()
    {
    }

}
