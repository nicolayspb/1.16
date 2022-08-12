using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class Game : MonoBehaviour
{
    public Controls Controls;

    public ParticleSystem dieParticle;
    public ParticleSystem winParticle;

    public enum State
    {
        Playing,
        Win,
        Lose,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Lose;
        Controls.enabled = false;
        dieParticle.Play();
        Debug.Log("over");

        Invoke("ReloadLevel",2);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Win;
        Controls.enabled = false;
        winParticle.Play();
        Debug.Log("win");
        levelIndex++;
        Invoke("ReloadLevel", 2);
    }

    public int levelIndex
    {
        get => PlayerPrefs.GetInt(levelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(levelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string levelIndexKey = "levelIndex";

    private void ReloadLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
