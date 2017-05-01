using UnityEngine;
using UnityEngine.UI;

//Script class added to dropdown for selecting mafia count
[RequireComponent(typeof(Dropdown))]
public class SetRoleAmount : MonoBehaviour {

    private Dropdown dropDown;
    public enum Role
    {
        mafia,
        nurse,
        cop
    };
    public Role role;
	void Start ()
    {
        dropDown = GetComponent<Dropdown>();
	}

    public void createOptions()
    {
        dropDown.value = 0;
        if(GameManager.numPlayers >= 5)
        {
            int maxPlayers = GameManager.numPlayers / 2 - 1;
            for (int i = dropDown.options.Count; dropDown.options.Count > maxPlayers; i--)
            {
                dropDown.options.RemoveAt(i - 1);
            }
            for (int i = dropDown.options.Count; i <= maxPlayers; i++)
            {
                if(i != 0)
                {
                    dropDown.options.Add(new Dropdown.OptionData(i.ToString()));
                }
            }
        }
        
    }

    public void setOption()
    {
        switch (role)
        {
            case Role.mafia:
                GameManager.numMafia = int.Parse(dropDown.captionText.text);
                break;
            case Role.nurse:
                GameManager.numNurses = int.Parse(dropDown.captionText.text);
                break;
            case Role.cop:
                GameManager.numCops = int.Parse(dropDown.captionText.text);
                break;
            default:
                break;
        }
    }
}
