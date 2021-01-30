using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindsManager : MonoBehaviour
{

    public KeyCode jumpKey;
    public KeyCode punchKey;
    public KeyCode kickKey;

    private List<string> keys;
    public List<Dropdown> dropdowns = new List<Dropdown>();


    // Start is called before the first frame update
    void Start()
    {
        keys = new List<string> { "Space", "A", "B", "C", "D", "E", "F", "G", "Q", "R", "T", "V", "X", "Z", };
        for (int i = 0; i < dropdowns.Count; i++)
        {
            dropdowns[i].AddOptions(keys);
        }
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpPrefs"));
        Select_Key(dropdowns[0], jumpKey.ToString());

        punchKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("punchPrefs"));
        Select_Key(dropdowns[1], punchKey.ToString());

        kickKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("kickPrefs"));
        Select_Key(dropdowns[1], kickKey.ToString());
    }
    
    private void Select_Key(Dropdown _dropdown, string _s)
    {
        for(int i = 0; i < keys.Count; i++)
        {
            if(_s == keys[i])
            {
                _dropdown.value = i;
            }
        }
    }
   public void ChangeJumpKey(int id)
    {
        jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
        PlayerPrefs.SetString("jumpPrefs", keys[id]);
    }

    public void ChangePunchKey(int id)
    {
        punchKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
        PlayerPrefs.SetString("punchPrefs", keys[id]);
    }

    public void ChangeKickKey(int id)
    {
        kickKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
        PlayerPrefs.SetString("kickPrefs", keys[id]);
    }
}
