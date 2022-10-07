using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static UnityAction UpgradePanelEvent;
    public static UnityAction KillEvent;

    [SerializeField] GameObject _upgradePanel;
    [SerializeField] Image _killSlider;


    [SerializeField] public float _killCount;
    private void Awake()
    {

        if (instance==null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        KillEvent += KillCount;
        UpgradePanelEvent += UpgradePanelShow;
    }
    public void UpgradePanelHide()
    {
        _upgradePanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void UpgradePanelShow()
    {
        if (_killCount == 29)
        {
            _upgradePanel.SetActive(true);
            Time.timeScale = 0;
            _killCount = 0;
        }

    }
    //public void KillSlider()
    //{
    //    _upgradePanel.SetActive(true);
    //}
    private void KillCount()
    {
        UpgradePanelShow();
        _killCount++;
    }
}
