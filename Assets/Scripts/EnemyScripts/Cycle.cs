using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    //���]�Ԃ̃X�s�[�h
    public float cycleSpeed;

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
        Debug.Log("���]�Ԑؒf");
        //ScoreManager.���s�ҕ��̃X�R�A���Z�̂��߂̊֐�();
    }
}
