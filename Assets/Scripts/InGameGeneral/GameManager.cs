using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //ScoreManager������ϐ�
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //AudioManager������ϐ�
    [SerializeField] private GameObject audioManagerObj;
    AudioManager audioManager;
    //�ʍs�l��؂������ǂ����Ō��ʉ��𕪂��邽�߂̕ϐ�
    private bool hasPlayed = false;

    //�ʍs�l��؂������ǂ������肷��ϐ�
    private bool isCut = false;
    //�}�E�X�N���b�N�̎��_�ƏI�_������ϐ�
    private Vector2 startPos;
    private Vector2 endPos;
    //�}�E�X�N���b�N�̎n�_�ƏI�_�̍��W�Ԃ̋���������ϐ�
    private float posDistance;

    //�j�󂷂�ʍs�l������ϐ�
    public static GameObject destroyEnemy;
    private Rigidbody2D destroyRigidbody;
    private BoxCollider2D destroyCollider;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
        audioManager = audioManagerObj.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit && !isCut)
            {
                isCut = !isCut;

                if (hit.collider.tag == "Pedestrian")
                {
                    //�ؒf�����I�u�W�F�N�g��destroyEnemy�ɕۑ�
                    destroyEnemy = hit.collider.gameObject;

                    //destroyEnemy�̃R���|�[�l���g���擾
                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();
                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();                    
                }
                                
                else if (hit.collider.tag == "Cycle")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
                }

                else if (hit.collider.tag == "PedestrianLeather")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
                }

                else if (hit.collider.tag == "CycleLeather")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posDistance = Vector2.Distance(startPos, endPos);

            if (posDistance > 1.0f)
            {
                if (destroyEnemy != null)
                {
                    if (destroyEnemy.tag == "Pedestrian")
                    {                        
                        //�؂����ʍs�l���~�߂鏈��
                        destroyRigidbody.velocity = Vector2.zero;

                        scoreManager.ScoreIncresePedestrian();
                        //UltlaManager.���s�ҕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();

                        //�j��A�j���[�V�����Đ����ɓ����蔻�����������
                        destroyCollider.enabled = false;

                        //���ʉ���炷����
                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        //�j����destroyEnemy�̒��g���폜����
                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "Cycle")
                    {
                        destroyRigidbody.velocity = Vector2.zero;
                                                
                        scoreManager.ScoreIncreseCycle();
                        //UltlaManager.���s�ҕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();

                        destroyCollider.enabled = false;

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "PedestrianLeather")
                    {
                        scoreManager.ScoreIncresePedestrianLeather();

                        //�_���[�W���󂯂���Ԃ̖��O�Ȃ�΁A�j�󂷂鏈�����s��
                        if (destroyEnemy.name == "PedLeather_Damaged")
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.�{�v���s�ҕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();

                            destroyCollider.enabled = false;
                        }

                        //���ڂ̐ؒf�Ȃ�΁A�_���[�W���󂯂���Ԃ̖��O�ɕύX
                        if (destroyEnemy.name == "PedestrianLeather(Clone)")
                        {
                            destroyEnemy.name = "PedLeather_Damaged";
                        }

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "CycleLeather")
                    {
                        scoreManager.ScoreIncreseCycleLeather();

                        if (destroyEnemy.name == "CycleLeather_Damaged")
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.�{�v���]�ԕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();

                            destroyCollider.enabled = false;
                        }

                        if (destroyEnemy.name == "CycleLeather(Clone)")
                        {
                            destroyEnemy.name = "CycleLeather_Damaged";
                        }

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }
                }                               
            }

            if (!hasPlayed)
            {
                audioManager.PlayCutSound();
            }

            hasPlayed = false;

            //�ĂуJ�b�g�ł���悤�ɂ���
            isCut = !isCut;
        }
    }
}
