using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    //���]�Ԃ̃X�s�[�h
    public static float cycleSpeed = 3.5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, cycleSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * cycleSpeed * Time.deltaTime;
    }

    public void CycleCut()
    {
        //�����ŃA�j���[�V�����𐧌䂷�郁�\�b�h���Ăяo��
    }
}
