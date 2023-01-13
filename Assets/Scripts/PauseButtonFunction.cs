using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonFunction : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    public Button ResumeButton;
    public Button PauseButton;
    public Button VolumeButton;
    public bool muted=false;
    public Button HomeButton;
    void Start() 
    {
    Button PauseButton1 =PauseButton.GetComponent<Button>();
	PauseButton1.onClick.AddListener(PauseGame);

    Button ResumeButton1 =ResumeButton.GetComponent<Button>();
	ResumeButton1.onClick.AddListener(ResumeGame);

    Button VolumeButton1 =VolumeButton.GetComponent<Button>();
	VolumeButton1.onClick.AddListener(MuteVolume);

    Button HomeButton1 =HomeButton.GetComponent<Button>();
	HomeButton1.onClick.AddListener(ReturnHome);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
    }
    public void MuteVolume()
    {
        if (muted)
        {
            AudioListener.volume=0;
        }
        else
        {
            AudioListener.volume=1;
        }
    }
    public void ReturnHome()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
}
