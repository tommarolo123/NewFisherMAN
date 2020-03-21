using UnityEngine.UI;
using UnityEngine;

public class MainSenceUI : MonoBehaviour
{
    public Toggle muteToogle;
    public GameObject settingPanel;

     void Start()
    {
        muteToogle.isOn = !AudiManager.Instance.IsMute;
        
    }


    public  void SwitchMute(bool isOn)
    {
        AudiManager.Instance.SwitchMuteState(isOn);
    }





    public void OnBackButtonDown()
    {
        //保存する
        PlayerPrefs.SetInt("gold", GameController.Instance.gold);
        PlayerPrefs.SetInt("lv", GameController.Instance.lv);
        PlayerPrefs.SetFloat("scd", GameController.Instance.smallTimer);
        PlayerPrefs.SetFloat("bcd", GameController.Instance.bigTimer);
        PlayerPrefs.SetInt("exp", GameController.Instance.exp);
        int temp = (AudiManager.Instance.IsMute == false)? 0:1;
        PlayerPrefs.SetInt("mute", temp);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); //start画面へ飛ぶ
    }
    public void OnSettingButtondown()
    {
        settingPanel.SetActive(true);
    }

    public void OnCloseButtonDown()
    {
        settingPanel.SetActive(false); 
    }


}
