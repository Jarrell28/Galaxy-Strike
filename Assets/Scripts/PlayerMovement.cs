using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 8f;
    [SerializeField] float yClampRange = 8f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTransform();
        ProcessRotation();
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void ProcessRotation()
    {
        float roll = -controlRollFactor * movement.x;
        float pitch = -controlPitchFactor * movement.y;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        // transform.localRotation = targetRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    Vector2 movement;
    void ProcessTransform()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);


        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
