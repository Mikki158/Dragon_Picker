using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += ChekSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= ChekSDK;

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
        if (YandexGame.SDKEnabled == true)
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
        }
    }
}
