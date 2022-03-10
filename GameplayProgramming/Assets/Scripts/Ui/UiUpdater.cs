using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiUpdater : MonoBehaviour
{
    private TextMeshProUGUI TextMP;
    private PlayerScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<PlayerScoreManager>();
        TextMP = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        TextMP.SetText(scoreManager.score.ToString());
    }
}
