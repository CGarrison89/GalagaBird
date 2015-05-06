using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BirdButton : MonoBehaviour
{
    public Image UIImage;
    public Text UIText;
    public string Description;
    public Sprite Image;
    public GameObject BirdPrefab;

    public void OnHover()
    {
        UIImage.sprite = Image;
        UIText.text = Description + "\n\nFlappy Bird has garnered some rivals since the last time you saw him. Use space bar to take them down.";
    }

    public void OnClick()
    {
        GameState.Bird = BirdPrefab;
        GameState.State = GameStates.GameWaiting;
        Application.LoadLevel("scene_0");
    }
}