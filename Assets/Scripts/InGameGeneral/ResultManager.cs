using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    public Text scoreResultText;
    public Text enemyResultText;

    // Start is called before the first frame update
    void Start()
    {
        scoreResultText.text = "�X�R�A: " + ScoreManager.score.ToString();
        enemyResultText.text = "�؂��������b�N: " + ScoreManager.destroyCount.ToString() + "��";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
