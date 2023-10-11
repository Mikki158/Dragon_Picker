using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;

    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    public TextMeshProUGUI scoreGT;

    public List<GameObject> shieldList;

    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoadSave();
        }

        shieldList = new List<GameObject>();

        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            shieldList.Add(tShieldGo);
        }
    }

    void Update()
    {
        
    }

    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");

        foreach(GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }

        int shieldIndex = shieldList.Count - 1;
        GameObject tshieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tshieldGo);

        if(shieldList.Count == 0)
        {
            GameObject scoreGo = GameObject.Find("Score");
            scoreGT = scoreGo.GetComponent<TextMeshProUGUI>();
            UserSave(int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
        }
    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
    }

    public void UserSave(int currentScore)
    {
        YandexGame.savesData.score = currentScore;
        YandexGame.SaveProgress();
    }
}
