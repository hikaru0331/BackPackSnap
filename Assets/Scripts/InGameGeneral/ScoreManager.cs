using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public static int score = 0;
    public static int destroyCount = 0;

    //AnimationController�̎Q��
    [SerializeField] private GameObject animationControllerObj;
    AnimationController animationController;

    // Start is called before the first frame update
    void Start()
    {
        animationController = animationControllerObj.GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    //�ʏ���s�҂Ɋւ���X�R�A
    public void ScoreIncresePedestrian()
    {
        animationController.PedestrianCut();

        score += 1000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecresePedestrian()
    {
        score -= 1000;
        
        Destroy(GameManager.destroyEnemy);
    }

    //�ʏ펩�]�ԂɊւ���X�R�A
    public void ScoreIncreseCycle()
    {
        animationController.CycleCut();

        score += 5000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecreseCycle()
    {
        score -= 5000;

        Destroy(GameManager.destroyEnemy);
    }

    //�{�v���s�҂Ɋւ���X�R�A
    public void ScoreIncresePedestrianLeather()
    {
        animationController.PedestrianCut();

        score += 1000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecresePedestrianLeather()
    {
        score -= 1000;

        Destroy(GameManager.destroyEnemy);
    }

    //�{�v���]�ԂɊւ���X�R�A
    public void ScoreIncreseCycleLeather()
    {
        animationController.CycleCut();

        score += 5000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecreseCycleLeather()
    {
        score -= 5000;

        Destroy(GameManager.destroyEnemy);
    }
}
