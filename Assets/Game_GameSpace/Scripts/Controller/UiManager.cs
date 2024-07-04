using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public UiMainLobby UiMainLobby;
    public UiWinWave UiWinWave;
    public UiLose UiLose;
    public UIGamePlay UiGamePlay;
    public UIVictory UiVictory;

    public void Init()
    {
        OpenUiMainLobby();
    }

    public void OpenUiMainLobby()
    {
        UiMainLobby.Show(true);
    }
    public void OpenUiGamePlay()
    {
        UiGamePlay.Show(true);
    }

    public void OpenUiWinWave()
    {
        UiWinWave.Show(true);
    }

    public void OpenUiLose()
    {
        UiLose.Show(true);
    }

    public void OpenUiVictory()
    {
        UiVictory.Show(true);
    }
}
