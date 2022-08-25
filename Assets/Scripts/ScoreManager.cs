using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public ScoreManager instance;
    public TextMeshPro textMesh;
    int score;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void ChangeStore(int coinValue)
    {
        score += coinValue;
        textMesh.text = score.ToString(); 
    } 
}
