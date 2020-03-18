
using UnityEngine;

public class MainSenceUI : MonoBehaviour
{
    public GameObject settingPanel;
    public  void SwitchMute()
    {
        AudiManager.Instance.SwitchMuteState();
    }

    public void OnBackButtonDown()
    {
        //保存する
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
