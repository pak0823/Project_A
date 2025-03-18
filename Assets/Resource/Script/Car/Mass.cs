using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fMass : MonoBehaviour
{
    public Color gizmoColor = Color.yellow; // Gizmo ����
    public float gizmoSize = 0.5f; // Gizmo ũ��

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody ������Ʈ�� �����ϴ�!");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        }
    }

    void OnDrawGizmos()
    {
        if (rb == null) return;

        // ���� �߽� ��ġ ���
        Vector3 worldCenterOfMass = transform.TransformPoint(rb.centerOfMass);

        // Gizmo �׸���
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(worldCenterOfMass, gizmoSize);
    }
}

