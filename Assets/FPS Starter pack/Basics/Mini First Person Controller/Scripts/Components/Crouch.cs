using System.Collections;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Slow Movement")]
    [Tooltip("Movement to slow down when crouched.")]
    public FirstPersonMovement movement;
    [Tooltip("Movement speed when crouched.")]
    public float movementSpeed = 2;

    [Header("Low Head")]
    [Tooltip("Head to lower when crouched.")]
    public Transform headToLower;
    [HideInInspector] public float defaultHeadYLocalPosition;
    public float crouchYHeadPosition = 1;
    
    [Tooltip("Collider to lower when crouched.")]
    public CapsuleCollider colliderToLower;
    [HideInInspector] public float defaultColliderHeight;

    private float loweringAmount;
    private const float crouchSpeed = 0.2f;
    public LayerMask layerMask;

    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;

    private void Start()
    {
        defaultColliderHeight = colliderToLower.height;
        defaultHeadYLocalPosition = headToLower.localPosition.y;
        loweringAmount = defaultHeadYLocalPosition - crouchYHeadPosition;
        layerMask = ~layerMask;
    }

    private void Reset()
    {
        // Try to get components.
        movement = GetComponentInParent<FirstPersonMovement>();
        headToLower = movement.GetComponentInChildren<Camera>().transform;
        colliderToLower = movement.GetComponentInChildren<CapsuleCollider>();
    }

    private void LateUpdate()
    {
        if (Input.GetKey(crouchKey))
        {
            if (headToLower) // Lower the head (camera).
            {
                //headToLower.localPosition = new Vector3(headToLower.localPosition.x, crouchYHeadPosition, headToLower.localPosition.z);
            }

            if (colliderToLower) // Lower the colliderToLower.
            {
                colliderToLower.height = Mathf.Max(defaultColliderHeight - loweringAmount, 0);
                colliderToLower.center = Vector3.up * colliderToLower.height * .5f;
            }

            if (!IsCrouched) // Set IsCrouched state.
            {
                IsCrouched = true;
                SetSpeedOverrideActive(true);
                CrouchStart?.Invoke();

                StartCoroutine(MoveCamera(defaultHeadYLocalPosition, crouchYHeadPosition, crouchSpeed));
            }
        }
        else
        {
            if (IsCrouched)
            {
                RaycastHit hit;
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, defaultColliderHeight, layerMask))
                {
                    if (headToLower) // Rise the head back up.
                    {
                        headToLower.localPosition = new Vector3(headToLower.localPosition.x, defaultHeadYLocalPosition, headToLower.localPosition.z);
                    }

                    if (colliderToLower) // Reset the colliderToLower's height.
                    {
                        colliderToLower.height = defaultColliderHeight;
                        colliderToLower.center = Vector3.up * colliderToLower.height * .5f;
                    }

                    // Reset IsCrouched.
                    IsCrouched = false;
                    SetSpeedOverrideActive(false);
                    CrouchEnd?.Invoke();

                    StartCoroutine(MoveCamera(crouchYHeadPosition, defaultHeadYLocalPosition, crouchSpeed));
                }
                else
                {
                    //print("Tak ovanför!");
                }
            }
        }
    }

    private IEnumerator MoveCamera(float start, float end, float duration)
    {
        float percent = 0;
        float timeFactor = 1 / duration;
        float yPos;
        while (percent < 1)
        {
            percent += Time.deltaTime * timeFactor;
            yPos = Mathf.Lerp(start, end, Mathf.SmoothStep(0, 1, percent));
            headToLower.localPosition = new Vector3(headToLower.localPosition.x, yPos, headToLower.localPosition.z);
            yield return null;
        }
        
    }

    #region Speed override.
    void SetSpeedOverrideActive(bool state)
    {
        // Stop if there is no movement component.
        if(!movement)
        {
            return;
        }

        // Update SpeedOverride.
        if (state)
        {
            // Try to add the SpeedOverride to the movement component.
            if (!movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Add(SpeedOverride);
            }
        }
        else
        {
            // Try to remove the SpeedOverride from the movement component.
            if (movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Remove(SpeedOverride);
            }
        }
    }

    float SpeedOverride() => movementSpeed;
    #endregion
}