using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text clicksText;
    public static int clicks;

    void Start()
    {
        Load();
        InvokeRepeating("Save", 3f, 3f);
    }

    void Update()
    {
        clicksText.text = clicks.ToString();
    }

    void Save()
    {
        PlayerPrefs.SetInt("clicks", clicks);
    }

    void Load()
    {
        clicks = PlayerPrefs.GetInt("clicks");
    }

    void OnApplicationQuit()
    {
        Save();
    }
}