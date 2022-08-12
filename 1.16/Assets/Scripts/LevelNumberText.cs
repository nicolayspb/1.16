using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text Text;
    public Game Game;

    private void Start()
    {
        Text.text = "Уровень " + (Game.levelIndex + 1).ToString();
    }
}
