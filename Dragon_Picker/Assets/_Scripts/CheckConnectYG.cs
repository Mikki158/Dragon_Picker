using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += ChekSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= ChekSDK;

    private TextMeshProUGUI scoreBest;

    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            ChekSDK();
        }
    }

    public void ChekSDK()
    {
        if (YandexGame.auth == true)
        {
            Debug.Log("User authorization ok");
        }
        else
        {
            Debug.Log("User not autorization");
            YandexGame.AuthDialog();
        }

        GameObject scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best score: " + YandexGame.savesData.bestScore.ToString();

        if ((YandexGame.savesData.achivMent)[0] == null & !GameObject.Find("ListAchiv"))
        {

        }
        else
        {
            foreach (string item in YandexGame.savesData.achivMent)
            {
                GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text + item + "\n";
            }
        }
    }
}
