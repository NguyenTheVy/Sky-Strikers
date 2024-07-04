using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIVictory : UICanvas
{
    public void Home()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.click);
        SceneManager.LoadScene("Lobby");
    }

    public void Replay()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.click);
        SceneManager.LoadScene("SampleScene");
    }
}
