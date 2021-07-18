using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    private void Start()
    {
        SetScore(0);
    }

    public void SetScore(int score)
    {
        textBox.text = "" + score;
    }
}
