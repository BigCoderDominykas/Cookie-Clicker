using UnityEngine;
using TMPro;

public class Worker : MonoBehaviour
{
    public string name;
    public int count;
    public int price;
    public int cps;
    public TMP_Text countText;

    private void Start()
    {
        Load();
        countText.text = count.ToString();
    }

    public void Buy()
    {
        if (GameManager.clicks < price)
            return;
        GameManager.clicks -= price;
        count++;
        countText.text = count.ToString();
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt(name, count);
    }

    void Load()
    {
        count = PlayerPrefs.GetInt(name);
    }
}