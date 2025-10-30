using UnityEngine;

public class FollowHead : MonoBehaviour
{
    [SerializeField] private Camera CameraToFollow;
    [SerializeField] private Transform FollowCameraTransform;
    [SerializeField] private Transform FollowCameraRotate;
    [SerializeField] private Vector3 TranslateOffset;
    private Quaternion currentPlayerBodyRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowCameraTransform.position = CameraToFollow.transform.position + TranslateOffset;

        Vector3 fwd = CameraToFollow.transform.forward + CameraToFollow.transform.up;
        fwd.y = 0.0f;
        currentPlayerBodyRotation = Quaternion.LookRotation(fwd);
        FollowCameraRotate.rotation = currentPlayerBodyRotation;
    }
}
