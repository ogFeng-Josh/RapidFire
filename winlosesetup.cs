using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winlosesetup : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public string restartScene;
    public string mainMenuName;

    public playerData pAlive;

    // Start is called before the first frame update
    void Start()
    {
        pAlive = GameObject.Find("_player(ver. 2)").GetComponent<playerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        pAlive.changeTime();
        SceneManager.LoadScene(restartScene);
    }

    public void loadMenu()
    {
        pAlive.changeTime();
        SceneManager.LoadScene(mainMenuName);
    }
}
