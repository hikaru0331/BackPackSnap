using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    [System.NonSerialized] public float defaultTimeCounter = 30.0f ;
    private float timeCounter;

    //EnemyGenerator�̃I�u�W�F�N�g�ƃN���X���擾
    public GameObject enemyGeneratorObj;
    EnemyGenerator enemyGenerator;

    public GameObject playingCanvas;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = defaultTimeCounter;
        enemyGenerator = enemyGeneratorObj.GetComponent<EnemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;

        timerText.text = "Time: " + timeCounter.ToString("f2");

        if (timeCounter <= defaultTimeCounter / 2)
        {
            enemyGenerator.SetInterval();
        }

        if (timeCounter <= 0.0f)
        {
            timeCounter = 0.0f;

            //�^�O�̕t�����I�u�W�F�N�g�����ꂼ��z��ɑ��
            GameObject[] pedestrians = GameObject.FindGameObjectsWithTag("Pedestrian");
            GameObject[] cycles = GameObject.FindGameObjectsWithTag("Cycle");

            //�z��enemy�ɓ������I�u�W�F�N�g�����ׂĔj�󂷂�܂ŌJ��Ԃ�����
            foreach (GameObject enemies in pedestrians)
            {
                Destroy(enemies);
            }
            foreach(GameObject enemies in cycles)
            {
                Destroy(enemies);
            }

            //UI�̐؂�ւ�����
            playingCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);

        }
    }
}
