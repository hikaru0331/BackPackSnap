using System.Collections.Generic;
using UnityEngine;

public class MouseEffectManager : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;

    //�p�[�e�B�N���̃v���n�u������ϐ�
    [SerializeField] private GameObject mouseBurstPrefab;
    //�C���X�^���X���ꂽ�p�[�e�B�N��������ϐ�
    private GameObject mouseBurst;

    private int posCount = 0;
    private float interval = 0.1f;

    private void Start()
    {
        //lineRenderer�̐F���C���X�y�N�^�[��̂��̂ɂ���
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineRenderer.startColor;
    }

    private void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            SetPosition(mousePos);
        }                
        else if (Input.GetMouseButtonUp(0))
        {
            posCount = 0;
            lineRenderer.enabled = false;

            //�v���n�u�𐶐����A�ϐ��ɑ����������ꂽ�p�[�e�B�N����0.5�b��ɔj��
            mouseBurst = Instantiate(mouseBurstPrefab, mousePos, Quaternion.identity);
            Destroy(mouseBurst, 0.5f);
        }
            
    }

    private void SetPosition(Vector2 pos)
    {
        if (!PosCheck(pos)) return;

        posCount++;
        lineRenderer.positionCount = posCount;
        lineRenderer.SetPosition(posCount - 1, pos);
    }

    private bool PosCheck(Vector2 pos)
    {
        if (posCount == 0) return true;

        float distance = Vector2.Distance(lineRenderer.GetPosition(posCount - 1), pos);
        if (distance > interval)
            return true;
        else
            return false;

    }
}