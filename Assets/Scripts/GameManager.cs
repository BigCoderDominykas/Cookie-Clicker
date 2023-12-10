using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public TMP_Text clicksText;
    public TMP_Text cpsText;

    public static int clicks;

    int cps;

    void Start()
    {
        Load();
        InvokeRepeating("Save", 3f, 3f);
        cps = clicks;
        InvokeRepeating("ClicksPerSecond", 0f, 1f);
    }

    void Update()
    {
        if(clicks > 999999)
            clicksText.text = ((decimal)(clicks) / 1000000).ToString("0.0") + "M";
        else if(clicks > 999)
            clicksText.text = ((decimal)(clicks) / 1000).ToString("0.0") + "K";
        else
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

    void ClicksPerSecond()
    {
        cpsText.text = "Per second: " + (clicks - cps).ToString();
        cps = clicks;
    }
}