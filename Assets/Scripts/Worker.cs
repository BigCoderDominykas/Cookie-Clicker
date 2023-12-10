using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Worker : MonoBehaviour
{
    public string name;
    public int count;
    public int price;
    public int cps;
    public TMP_Text countText;
    public TMP_Text priceText;
    public Button button;

    private void Start()
    {
        Load();
        countText.text = count.ToString();
        priceText.text = "Price:" + price;
        InvokeRepeating("Work", 1f, 1f);
    }

    private void Update()
    {
        var canClick = GameManager.clicks >= price;
        button.interactable = canClick;
    }

    public void Buy()
    {
        if (GameManager.clicks < price)
            return;
        GameManager.clicks -= price;
        count++;
        price = (int)(price * 1.4f);
        countText.text = count.ToString();
        priceText.text = "Price:" + price;
        Save();
    }

    void Work()
    {
        GameManager.clicks += count * cps;
    }

    void Save()
    {
        PlayerPrefs.SetInt(name, count);
        PlayerPrefs.SetInt(name + "price", price);
    }

    void Load()
    {
        count = PlayerPrefs.GetInt(name);
        price = PlayerPrefs.GetInt(name + "price", price);
    }
}