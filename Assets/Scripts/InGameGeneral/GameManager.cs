using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //ScoreManagerを入れる変数
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //通行人を切ったかどうか判定する変数
    private bool isCut = false;
    //マウスクリックの視点と終点を入れる変数
    private Vector2 startPos;
    private Vector2 endPos;
    //マウスクリックの始点と終点の座標間の距離を入れる変数
    private float posDistance;

    //破壊する通行人を入れる変数
    public static GameObject destroyEnemy;
    private Rigidbody2D destroyRigidbody;
    private BoxCollider2D destroyCollider;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
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
                    destroyEnemy = hit.collider.gameObject;

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
                        destroyRigidbody.velocity = Vector2.zero;

                        scoreManager.ScoreIncresePedestrian();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        destroyCollider.enabled = false;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "Cycle")
                    {
                        destroyRigidbody.velocity = Vector2.zero;
                                                
                        scoreManager.ScoreIncreseCycle();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        destroyCollider.enabled = false;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "PedestrianLeather")
                    {
                        destroyEnemy.pedLeatherHP--;

                        //scoreManager.ScoreIncresePedestrianLeather();

                        if (PedestrianLeather.pedLeatherHP == 0)
                        {

                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                            destroyCollider.enabled = false;

                            PedestrianLeather.pedLeatherHP = 2;
                        }
                        
                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "CycleLeather")
                    {
                        CycleLeather.cycleLeatherHP--;
                        Debug.Log(CycleLeather.cycleLeatherHP--);

                        scoreManager.ScoreIncreseCycleLeather();

                        if (CycleLeather.cycleLeatherHP == 0)
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                            destroyCollider.enabled = false;

                            CycleLeather.cycleLeatherHP = 2;
                        }
                        
                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }
                }                               
            }

            //再びカットできるようにする
            isCut = !isCut;
        }
    }
}
