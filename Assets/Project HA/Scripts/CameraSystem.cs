using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public static CameraSystem Instance { get; private set; } = null;

    public float TargetFOV { get; set; } = 60.0f;


    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Cinemachine.CinemachineImpulseSource impulseSource;

    public float zoomSpeed = 5.0f;

    public void ShakeCamera(Vector3 velocity, float duration, float force)
    {
        impulseSource.m_DefaultVelocity = velocity;
        impulseSource.m_ImpulseDefinition.m_ImpulseDuration = duration;
        impulseSource.GenerateImpulseWithForce(force);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void LateUpdate()
    {
        playerCamera.m_Lens.FieldOfView = Mathf.Lerp(playerCamera.m_Lens.FieldOfView, TargetFOV, zoomSpeed * Time.deltaTime);
    }
}
