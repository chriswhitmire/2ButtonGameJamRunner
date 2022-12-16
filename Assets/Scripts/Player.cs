using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    CinemachineVirtualCamera cinemachineVC;
    bool shouldShake = false;

    [SerializeField] float horSpeed = 1;
    [SerializeField] float vertSpeed = 1;
    [SerializeField] float size = 1;

    [SerializeField] float maxHorSpeed = 10;
    [SerializeField] float minHorSpeed = 0.5f;
    [SerializeField] float maxVertSpeed = 10;
    [SerializeField] float minVertSpeed = 0.5f;
    [SerializeField] float maxSize = 4;
    [SerializeField] float minSize = 0.5f;
    [SerializeField] float shakeIntensity = 2f;
    
    // for later
    Animator animator;
    
    private void Awake() 
    {
        cinemachineVC = GetComponentInChildren<CinemachineVirtualCamera>();    
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // for later
        // animator.SetFloat("VerticalSpeed", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);
        ShakeCamera();
    }

    // HORIZONTAL
    public float getHorSpeed()
    {
        return horSpeed;
    }
    public float getMaxHorSpeed()
    {
        return maxHorSpeed;
    }
    public float getMinHorSpeed()
    {
        return minHorSpeed;
    }
    public void setHorSpeed(float newSpeed)
    {
        horSpeed = newSpeed;
    }

    // VERTICAL
    public float getVertSpeed()
    {
        return vertSpeed;
    }
    public float getMaxVertSpeed()
    {
        return maxVertSpeed;
    }
    public float getMinVertSpeed()
    {
        return minVertSpeed;
    }
    public void setVertSpeed(float newSpeed)
    {
        vertSpeed = newSpeed;
    }

    // SIZE
    public float getSize()
    {
        return size;
    }
    public float getMinSize()
    {
        return minSize;
    }
    public float getMaxSize()
    {
        return maxSize;
    }
    public void setSize(float newSize)
    {
        size = newSize;
    }

    public void setShouldShake(bool newShouldShake)
    {
        shouldShake = newShouldShake;
    }

    public bool getShouldShake()
    {
        return shouldShake;
    }

    void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (shouldShake)
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        }
        else
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0.0f;
        }
    }
}
