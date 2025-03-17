using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Car : MonoBehaviour
{
    [System.Serializable] // Inspector â���� ���� ���� �߰�
    public struct Wheel
    {
        public WheelCollider wheelCollider;
        public Transform wheelTransform; // ���� �� Transform
        public float rotationSpeedMultiplier; // ���� ȸ�� �ӵ� ����
    }

    public Wheel frontLeftWheel;
    public Wheel frontRightWheel;
    public Wheel rearLeftWheel;
    public Wheel rearRightWheel;

    public float motorTorque = 200f; // ���� ��ũ
    public float brakeTorque = 500f; // �극��ũ ��
    public float maxSteerAngle = 30f; // �ִ� ��Ƽ� ����

    public float currentSpeed { get; private set; } // ���� �ӵ� (�б� ����)

    private Rigidbody rigidBody; // Rigidbody ������Ʈ

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (rigidBody == null)
        {
            Debug.LogError("Rigidbody ������Ʈ�� �����ϴ�!");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        }
    }

    void FixedUpdate()
    {
        // �Է� �ޱ�
        float verticalInput = Input.GetAxis("Vertical"); // ����/���� (W/S �Ǵ� ��/�Ʒ� ȭ��ǥ)
        float horizontalInput = Input.GetAxis("Horizontal"); // ��/�� (A/D �Ǵ� ��/�� ȭ��ǥ)
        bool isBraking = Input.GetKey(KeyCode.Space); // �����̽��� ������ �극��ũ

        // ���� ��ũ ����
        frontLeftWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        frontRightWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        rearLeftWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        rearRightWheel.wheelCollider.motorTorque = verticalInput * motorTorque;

        // ��Ƽ� ����
        frontLeftWheel.wheelCollider.steerAngle = horizontalInput * maxSteerAngle;
        frontRightWheel.wheelCollider.steerAngle = horizontalInput * maxSteerAngle;

        // �극��ũ ����
        SetBrakeTorque(isBraking ? brakeTorque : 0f);

        // ���� �ӵ� ��� (km/h)
        currentSpeed = rigidBody.velocity.magnitude * 3.6f; // m/s -> km/h
    }

    void Update()
    {
        // ���� ȸ��
        RotateWheel(frontLeftWheel);
        RotateWheel(frontRightWheel);
        RotateWheel(rearLeftWheel);
        RotateWheel(rearRightWheel);
    }

    // �극��ũ ��ũ ���� �Լ�
    void SetBrakeTorque(float torque)
    {
        frontLeftWheel.wheelCollider.brakeTorque = torque;
        frontRightWheel.wheelCollider.brakeTorque = torque;
        rearLeftWheel.wheelCollider.brakeTorque = torque;
        rearRightWheel.wheelCollider.brakeTorque = torque;
    }

    // ���� ȸ�� �Լ�
    void RotateWheel(Wheel wheel)
    {
        if (wheel.wheelCollider != null && wheel.wheelTransform != null)
        {
            float rotationAngle = wheel.wheelCollider.rpm * 6 * Time.deltaTime * wheel.rotationSpeedMultiplier;
            wheel.wheelTransform.Rotate(rotationAngle, 0, 0);
        }
    }
}
