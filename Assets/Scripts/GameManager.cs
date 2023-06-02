using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ScoreManager������ϐ�
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //�ʍs�l��؂������ǂ������肷��ϐ�
    private bool isCut = false;

    //�ʍs�l�����邽�߂̔z��
    public GameObject[] enemies;

    //�ʍs�l�̃N���X���Q�Ƃ��邽�߂̕ϐ�
    Pedestrian pedestrian;
    Cycle cycle;

    //�j�󂷂�ʍs�l������ϐ�
    public static GameObject destroyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();

        pedestrian = enemies[0].GetComponent<Pedestrian>();
        cycle = enemies[1].GetComponent<Cycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit && !isCut)
            {
                isCut = !isCut;

                if (hit.collider.tag == "Pedestrian")
                {
                    destroyEnemy = hit.collider.gameObject;

                    pedestrian.PedstrianCut();
                    scoreManager.ScoreIncresePedestrian();
                    //UltlaManager.���s�ҕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    destroyEnemy = hit.collider.gameObject;

                    cycle.CycleCut();
                    scoreManager.ScoreIncreseCycle();
                    //UltlaManager.���]�ԕ��̕K�؋Z�Q�[�W���Z�̂��߂̊֐�();
                }
                
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            isCut = !isCut;
        }

    }
}
