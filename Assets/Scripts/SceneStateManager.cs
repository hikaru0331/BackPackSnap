using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //�ȉ�OutGame�Ɋւ���V�[�������[�h���郁�\�b�h
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadStageSelect()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false; //�Q�[���v���C�I��
    #else
         Application.Quit(); //�Q�[���v���C�I��
    #endif
    }


    //�ȉ�InGame�V�[�������[�h���郁�\�b�h
    public void LoadRuralInGame()
    {
        //�X�R�A�Ȃǂ�����������
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("RuralInGame");
    }

    public void LoadArbanInGame()
    {
        //�X�R�A�Ȃǂ�����������
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("ArbanInGame");
    }


    //�ȉ�Result�V�[�������[�h���郁�\�b�h
    public void LoadRuralResult()
    {
        SceneManager.LoadScene("RuralResult");
    }

    public void LoadArbanResult()
    {
        SceneManager.LoadScene("ArbanResult");
    }
}
