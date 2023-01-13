using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Button BackButton;
    public Button Level1;
    public Button Level2;
    public Button Level3;
    void Start() 
    {
        Button BackButton1 =BackButton.GetComponent<Button>();
		BackButton1.onClick.AddListener(BackGame);

        Button Level1b =Level1.GetComponent<Button>();
		Level1b.onClick.AddListener(Gotolevel1);

        Button Level2b =Level2.GetComponent<Button>();
		Level2b.onClick.AddListener(Gotolevel2);

        Button Level3b =Level3.GetComponent<Button>();
		Level3b.onClick.AddListener(Gotolevel3);
	}
    public void Gotolevel1()
    {
        SceneManager.LoadScene("Map fire");
    }
    public void Gotolevel2()
    {
        SceneManager.LoadScene("Map 02");
    }
    public void Gotolevel3()
    {
        SceneManager.LoadScene("Map 03");
    }
    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
