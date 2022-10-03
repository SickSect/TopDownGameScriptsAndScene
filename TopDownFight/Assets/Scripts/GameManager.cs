using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FloatingTextManager textManager;

    private void Awake()
    {
       if (GameManager.instance != null)
       {
            Destroy(gameObject);
            return;
       }
       instance = this;
       SceneManager.sceneLoaded += LoadState;
       DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List <int> xpTable;
    public Enemy player;
    public int coins;
    public int exp;
    public GameObject[] enemies;

    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += exp.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // SKIN
        coins = int.Parse(data[1]);
        exp = int.Parse(data[2]);
        //WEAPON
    }

    public void ShowText(string msg, int fonstSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        //Debug.Log("HERE MSG IS " + msg);
        textManager.Show(msg, fonstSize, color, position, motion, duration);
    }

}
