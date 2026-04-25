using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeModifer=10f;
   CinemachineImpulseSource cinemachineImpulseSource;

    void Awake()
    {
        cinemachineImpulseSource=GetComponent<CinemachineImpulseSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float distance=Vector3.Distance(transform.position,Camera.main.transform.position);
        float shake=(1f/distance)*shakeModifer;
        shake=Mathf.Min(shake,1f);
        cinemachineImpulseSource.GenerateImpulse(shake);
    }
}
