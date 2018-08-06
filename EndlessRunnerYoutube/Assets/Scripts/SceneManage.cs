using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject CreditPanel;
    private bool isIntro = true;
    private bool isMainMenu = true;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

        if (isIntro)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
            {
                isIntro = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if ((Input.GetKey(KeyCode.C)) && isMainMenu)
            {
                MainMenuPanel.SetActive(false);
                CreditPanel.SetActive(true);
                isMainMenu = false;
            }
            else if ((Input.GetKey(KeyCode.Escape)) && !isMainMenu)
            {
                MainMenuPanel.SetActive(true);
                CreditPanel.SetActive(false);
                isMainMenu = true;
            }
        }
	}


}
