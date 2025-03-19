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

    public float motorTorque = 300f; // ���� ��ũ
    public float brakeTorque = 500f; // �극��ũ ��
    public float maxSteerAngle = 20f; // �ִ� ��Ƽ� ����
    public float decelerationRate = 100f; // ���� �ӵ� (km/h/s)
    public float maxSpeed;


    private Quaternion initialRotation; //�⺻ ȸ����
    private Vector3 initialPosition;    //�⺻ ��ġ��

    //public float downforceAtSpeed = 100f; // �ִ� �ӵ����� �ٿ����� (N)

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

        initialRotation = transform.rotation;
        initialPosition = transform.position;

    }

    void FixedUpdate()
    {
        // �Է� �ޱ�
        float verticalInput = Input.GetAxis("Vertical"); // ����/���� (W/S �Ǵ� ��/�Ʒ� ȭ��ǥ)
        float horizontalInput = Input.GetAxis("Horizontal"); // ��/�� (A/D �Ǵ� ��/�� ȭ��ǥ)
        bool isBraking = Input.GetKey(KeyCode.Space); // �����̽��� ������ �극��ũ

        //float speedFactor = Mathf.Clamp01(rigidBody.velocity.magnitude / maxSpeed);
        //Vector3 downforce = Vector3.down * downforceAtSpeed * speedFactor;
        //rigidBody.AddForce(downforce);


        // ���� ��ũ ����
        frontLeftWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        frontRightWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        rearLeftWheel.wheelCollider.motorTorque = verticalInput * motorTorque;
        rearRightWheel.wheelCollider.motorTorque = verticalInput * motorTorque;

        // ��Ƽ� ����
        frontLeftWheel.wheelCollider.steerAngle = horizontalInput * maxSteerAngle;
        frontRightWheel.wheelCollider.steerAngle = horizontalInput * maxSteerAngle;

        // �극��ũ ����
        SetBrakeTorque(isBraking ? brakeTorque : 0f); // �극��ũ �� brakeTorque, �ƴϸ� 0

        // ���� �ӵ� ��� (km/h)
        currentSpeed = rigidBody.velocity.magnitude * 3.6f; // m/s -> km/h
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed); // �ִ� �ӵ� ����

        // ���� ���� (�극��ũ �� ��Ȱ��ȭ)
        if (verticalInput == 0 && !isBraking)
        {
            // ���� �ӵ��� ���� ���ӷ� ����
            float decelerationAmount = decelerationRate * Time.fixedDeltaTime * (currentSpeed / maxSpeed);
            currentSpeed -= decelerationAmount;
            currentSpeed = Mathf.Max(currentSpeed, 0f); // �ּ� �ӵ� 0
        }

        //Debug.Log((int)currentSpeed);
    }

    void Update()
    {
        // ���� ȸ��
        RotateWheel(frontLeftWheel);
        RotateWheel(frontRightWheel);
        RotateWheel(rearLeftWheel);
        RotateWheel(rearRightWheel);

        // R Ű�� ������ ���� �ʱ�ȭ
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetVehicle();
        }
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
            float maxRotationSpeed = 1000f;
            float rotationAngle = Mathf.Clamp(wheel.wheelCollider.rpm * 6 * Time.deltaTime * wheel.rotationSpeedMultiplier, -maxRotationSpeed * Time.deltaTime, maxRotationSpeed * Time.deltaTime);
            wheel.wheelTransform.Rotate(rotationAngle, 0, 0);
        }
    }

    void ResetVehicle()
    {
        // ��ġ�� ȸ�� �ʱ�ȭ
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        //Rigidbody �ӵ� �ʱ�ȭ
        if (rigidBody != null)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}
