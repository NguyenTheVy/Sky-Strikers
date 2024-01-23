using System.Collections;
using System.Collections.Generic;
using Unicorn;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Game_Fly;
using TigerForge;

public class UIHomeLobby : MonoBehaviour
{
    [SerializeField]
    private GameObject settingPopup, infoPopup, quitPopup, levelPopup, shopPopup;

    public Slider musicSlider, sfxSlider;
    private void Start()
    {
        Application.targetFrameRate = 60;
        AudioController.Instance.PlayBackgroundMusic();
    }

    public void OpenSetting()
    {
        settingPopup.SetActive(true);
        AudioController.Instance.PlaySound(AudioController.Instance.click);

    }

    public void CloseSetting()
    {
        
        settingPopup.SetActive(false);
        AudioController.Instance.PlaySound(AudioController.Instance.click);

    }

    public void OpenInfoPopup()
    {
        infoPopup.SetActive(true);
        AudioController.Instance.PlaySound(AudioController.Instance.click);

    }

    public void CloseInfoPopup()
    {
        infoPopup.SetActive(false);
        AudioController.Instance.PlaySound(AudioController.Instance.click);

    }
    public void OpenQuitPopup()
    {
        quitPopup.SetActive(true);
        AudioController.Instance.PlaySound(AudioController.Instance.click);

    }
    public void CloseQuitPopup()
    {
        quitPopup.SetActive(false);
        AudioController.Instance.PlaySound(AudioController.Instance.click);
    }

    public void MusicVolume()
    {
        AudioController.Instance.SetMusicVolume(musicSlider.value);
        PlayerDataManager.Instance.SetMusicSetting(musicSlider.value);
        EventManager.EmitEvent(EventConstants.UPDATE_VOLUME_MUSIC);
    }



    public void SfxVolume()
    {
        AudioController.Instance.SetSoundVolume(sfxSlider.value);
        PlayerDataManager.Instance.SetSoundSetting(sfxSlider.value);
        EventManager.EmitEvent(EventConstants.UPDATE_VOLUME_SOUND);
    }

    public void ExitGame()
    {
        
        Application.Quit();
    }

    public void OpenLevelPopup()
    {
        levelPopup.SetActive(true);
        AudioController.Instance.PlaySound(AudioController.Instance.click);
    }

    public void CloseLevelPopup()
    {
        levelPopup.SetActive(false);
        AudioController.Instance.PlaySound(AudioController.Instance.click);
    }

    public void OpenShopPopup()
    {
        shopPopup.SetActive(true);
        AudioController.Instance.PlaySound(AudioController.Instance.click);
    }

    public void CloseShopPopup()
    {
        shopPopup.SetActive(false);
        AudioController.Instance.PlaySound(AudioController.Instance.click);
    }

}
