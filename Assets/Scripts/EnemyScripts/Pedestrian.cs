using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{   
    //���s�҂̃X�s�[�h
    public static float pedSpeed = 3.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, pedSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void PedestrianCut()
    {
        //�����ŃA�j���[�V�����𐧌䂷�郁�\�b�h���Ăяo��
    }
}
