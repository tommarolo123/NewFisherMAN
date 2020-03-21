using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScenesUI : MonoBehaviour
{
  public void NewGame()
    {
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("exp");
        PlayerPrefs.DeleteKey("scd");
        PlayerPrefs.DeleteKey("bcd");//以前のデータを消す
         
        SceneManager.LoadScene(1);
    }
    public void Oldgame()
    {
        SceneManager.LoadScene(1);
    }

    public void  OnCloseButton()
    {
        Application.Quit(); 
    }

}

