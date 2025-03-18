using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarInitSetting", menuName = "ScriptableObjects/CarInitSetting", order = 1)]
public class CarInitSetting : ScriptableObject
{
    [System.Serializable]
    public struct WheelPrefabSettings
    {
        public GameObject wheelPrefab; // Wheel ������
        public float rotationSpeedMultiplier; // ���� ȸ�� �ӵ� ����
    }

    [System.Serializable]
    public struct WheelSettings
    {
        public WheelCollider wheelCollider; // WheelCollider ������Ʈ
        public Transform wheelTransform; // ���� �� Transform
        public float rotationSpeedMultiplier; // ���� ȸ�� �ӵ� ����
    }

    public WheelSettings frontLeftWheelSettings;
    public WheelSettings frontRightWheelSettings;
    public WheelSettings rearLeftWheelSettings;
    public WheelSettings rearRightWheelSettings;

    public float motorTorque = 300f; // ���� ��ũ
    public float brakeTorque = 500f; // �극��ũ ��
    public float maxSteerAngle = 20f; // �ִ� ��Ƽ� ����
    public float decelerationRate = 100f; // ���� �ӵ� (km/h/s)
    public float maxSpeed = 200f; // �ִ� �ӵ�
}
