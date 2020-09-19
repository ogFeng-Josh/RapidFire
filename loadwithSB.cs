using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class loadwithSB : MonoBehaviour 
{
	//public GameObject dataRetrieval;
	//private playerData loadData;

	public string LevelToLoadName;
    public GameObject introShot;

    bool playing;
	
	void Start () {
        //loadData = dataRetrieval.GetComponent<playerData>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			LoadScene();
			//loadData.LoadPlayer();
        	//SceneManager.LoadScene(LevelToLoadName);
		}
	}

	void LoadScene()
	{
		StartCoroutine(delayTransition());
	}

    IEnumerator delayTransition()
    {
        introShot.SetActive(false);
        gameObject.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(1.25f);
        //loadData.LoadPlayer();
        SceneManager.LoadScene(LevelToLoadName);
    }
}
