using UnityEngine;

public class FirstPersonCamera : MonoBehaviour //Se script doit être placer sur la camera du Player
{
    public static FirstPersonCamera instance;
    [Tooltip("Ratacher la camera au player")]
    public Transform player;
    private float cameraVerticalRotation = 0f;

    [Header("Cursor Settings")] 
    public bool isVisibleCursor;

    [Header("Sneak Settings")] 
    public Vector3 maxHead = new Vector3(0f, 0.52f, 0f);
    public Vector3 minHead = new Vector3(0f, -0.31f, 0f);
    private float sneackProgress = 0f;
    public AnimationCurve sneackCurve;
    public float multiSneakSpeed = 2f;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one FirstPersonCamera in scene");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Cursor.visible = isVisibleCursor;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (GameManager.instance.isPause) return;

        float mouseSensitivity = GameManager.instance.senssibility;
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        
        player.Rotate(Vector3.up * inputX);

        if (Input.GetKey(KeyCode.C) && sneackProgress < 1f)
        {
            sneackProgress += Time.deltaTime;
        }
        else if (sneackProgress > 0f)
        {
            sneackProgress -= Time.deltaTime;
        }
        
        float smooth = Mathf.SmoothStep(0f, 1f, sneackProgress);
        transform.localPosition = Vector3.Lerp(minHead, maxHead, sneackCurve.Evaluate(smooth * multiSneakSpeed));
    }
}