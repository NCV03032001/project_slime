using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    void Start() 
    {
		Button PlayButton1 =PlayButton.GetComponent<Button>();
		PlayButton1.onClick.AddListener(PlayGame);
        Button QuitButton1 =QuitButton.GetComponent<Button>();
		QuitButton1.onClick.AddListener(QuitGame);
	}
    public void PlayGame()
    {
        SceneManager.LoadScene("StageMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
