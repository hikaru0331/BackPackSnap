using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    //���s�҂̃X�s�[�h
    public float pedSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * pedSpeed * Time.deltaTime;
    }

    public void PedstrianCut()
    {
        Debug.Log("�ʍs�l�ؒf");
        //ScoreManager.���s�ҕ��̃X�R�A���Z�̂��߂̊֐�();
    }
}
