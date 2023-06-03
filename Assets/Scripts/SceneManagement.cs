using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }


    //�ȉ�InGame�V�[�������[�h���郁�\�b�h
    public void LoadRuralInGame()
    {
        //�X�R�A�Ȃǂ�����������
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("RuralInGame");
    }


    //�ȉ�Result�V�[�������[�h���郁�\�b�h
    public void LoadRuralResult()
    {
        SceneManager.LoadScene("RuralResult");
    }
}
