using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    //���]�Ԃ̃X�s�[�h
    public static float cycleSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
