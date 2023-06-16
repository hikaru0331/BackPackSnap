using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    [System.NonSerialized] public static float defaultTimeCounter;
    private float timeCounter;

    //EnemyGenerator�̃I�u�W�F�N�g�ƃN���X���擾
    public GameObject enemyGeneratorObj;
    EnemyGenerator enemyGenerator;

    public GameObject playingCanvas;
    public GameObject gameOverCanvas;

    public GameObject mouseEffectManager;
    public GameObject road;

    private bool isHalfTime = false;

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
            if (!isHalfTime)
            {
                enemyGenerator.SetInterval();
                isHalfTime = true;
            }

        }

        if (timeCounter <= 0.0f)
        {
            timeCounter = 0.0f;

            //�^�O�̕t�����I�u�W�F�N�g�����ꂼ��z��ɑ��
            GameObject[] pedestrians = GameObject.FindGameObjectsWithTag("Pedestrian");
            GameObject[] cycles = GameObject.FindGameObjectsWithTag("Cycle");
            GameObject[] pedestrianLeathers = GameObject.FindGameObjectsWithTag("PedestrianLeather");
            GameObject[] cycleLeathers = GameObject.FindGameObjectsWithTag("CycleLeather");

            //�z��enemy�ɓ������I�u�W�F�N�g�����ׂĔj�󂷂�܂ŌJ��Ԃ�����
            foreach (GameObject enemies in pedestrians)
            {
                Destroy(enemies);
            }
            foreach(GameObject enemies in cycles)
            {
                Destroy(enemies);
            }
            foreach (GameObject enemies in pedestrianLeathers)
            {
                Destroy(enemies);
            }
            foreach (GameObject enemies in cycleLeathers)
            {
                Destroy(enemies);
            }

            //UI�ƃ}�E�X�G�t�F�N�g�؂�ւ�����
            enemyGeneratorObj.SetActive(false);
            playingCanvas.SetActive(false);
            mouseEffectManager.SetActive(false);
            road.SetActive(false);

            gameOverCanvas.SetActive(true);

        }
    }
}
