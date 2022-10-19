using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class Player3DExample : MonoBehaviour
{

    public float moveSpeed = 8f;
    public float _totalHp;
    public Joystick joystick;
    public static UnityAction JoystickEvent;
    [SerializeField] Image hpBarIcon;
    [SerializeField] UpgradeSO _upgradeSO;
    [SerializeField] ParticleSystem _dustEffect;
    private void OnEnable()
    {
        JoystickEvent += shotJoystick;
        UIManager.Instance.GetHealthEvent += hpUpdater;

    }
    void FixedUpdate()
    {


        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        if (moveVector != Vector3.zero && joystick != null && _totalHp > 0)
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
    //void Damage(int damage)
    //{
    //    hpBarIcon.fillAmount = _totalHp / 100;
    //    _totalHp = _totalHp - damage;
    //    if (_totalHp <= 0) 
    //    {
    //        UIManager.Instance.PlayerDieEvent?.Invoke();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IDamageable>(out var damageable)) HpBooster(5);
    }
    void HpBooster(int damage)
    {
        hpBarIcon.fillAmount = _totalHp / 100;
        _totalHp = _totalHp - damage;
        if (_totalHp <= 0)
        {
            UIManager.Instance.PlayerDieEvent?.Invoke();
        }
    }
    void hpUpdater()
    {
        _totalHp = _upgradeSO.Health;
        hpBarIcon.fillAmount = _totalHp / 100;
        if(_upgradeSO.Health>100) _upgradeSO.Health = 100;
    }
}