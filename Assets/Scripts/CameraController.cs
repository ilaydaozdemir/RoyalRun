using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float min=20f;
    [SerializeField] float max=120f;
    [SerializeField] float zoomDuration=1f;
    [SerializeField] float zoomSpeedModifer=5f;
    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera=GetComponent<CinemachineCamera>();
    }
    public void ChangeCamera(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeRoutine(speedAmount));
    }
    IEnumerator ChangeRoutine(float speedAmount)
    {
        float start=cinemachineCamera.Lens.FieldOfView;
        float target=Mathf.Clamp(start+speedAmount*zoomSpeedModifer,min,max);

        float elapsedTime=0f;
        while(elapsedTime<zoomDuration)
        {
            elapsedTime+=Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView=Mathf.Lerp(start,target,elapsedTime/zoomDuration);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView=target;
    }
}
