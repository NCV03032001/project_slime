using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button BackButton;
    void Start() 
    {

        Button BackButton1 =BackButton.GetComponent<Button>();
		BackButton1.onClick.AddListener(BackGame);
	}
    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
