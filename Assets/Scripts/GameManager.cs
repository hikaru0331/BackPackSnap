using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�ʍs�l��؂������ǂ������肷��ϐ�
    private bool isCut = false;

    //�ʍs�l�����邽�߂̔z��
    public GameObject[] enemies;

    //�ʍs�l�̃N���X���Q�Ƃ��邽�߂̕ϐ�
    Pedestrian pedestrian;
    Cycle cycle;

    // Start is called before the first frame update
    void Start()
    {
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
                    pedestrian.PedstrianCut();
                    Destroy(hit.collider.gameObject);
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    cycle.CycleCut();
                    Destroy(hit.collider.gameObject);
                }
                
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            isCut = !isCut;
        }

    }
}
