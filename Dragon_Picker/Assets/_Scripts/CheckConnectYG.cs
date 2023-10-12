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
    }
}
