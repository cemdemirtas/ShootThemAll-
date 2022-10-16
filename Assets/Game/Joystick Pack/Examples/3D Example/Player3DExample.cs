using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections;

public class Player3DExample : MonoBehaviour
{

    public float moveSpeed = 8f;
    public Joystick joystick;
    public static UnityAction JoystickEvent;

    [SerializeField] ParticleSystem _dustEffect;
    private void OnEnable()
    {
        JoystickEvent += shotJoystick;
    }
    void FixedUpdate()
    {
  
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        if (moveVector != Vector3.zero && joystick != null)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.Self);
            

        }
    }
    void shotJoystick()
    {
        if (GameManager.Instance.gamestate == GameManager.GameState.InGame && joystick != null) joystick.gameObject.SetActive(true);
        if (GameManager.Instance.gamestate == GameManager.GameState.Start && joystick != null) joystick.gameObject.SetActive(false);
        if (GameManager.Instance.gamestate == GameManager.GameState.Next && joystick != null) joystick.gameObject.SetActive(false);
        if (GameManager.Instance.gamestate == GameManager.GameState.GameOver && joystick != null) joystick.gameObject.SetActive(false);
    }
    IEnumerator dust()
    {
        yield return new WaitForSeconds(1f);
        _dustEffect.Play();
    }

}