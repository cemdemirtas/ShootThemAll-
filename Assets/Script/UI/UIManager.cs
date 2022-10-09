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
    [SerializeField] Image _moneyImage;


    [SerializeField] public float _panelCount;
    [SerializeField] public float _killCount;


    [SerializeField] LevelSO _levelSO;
    private void Awake()
    {

        if (instance==null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        KillEvent += PanelCount;
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
        if (_panelCount == 29)
        {
            _upgradePanel.SetActive(true);
            Time.timeScale = 0;
            _panelCount = 0;
        }

    }
    //public void KillSlider()
    //{
    //    _upgradePanel.SetActive(true);
    //}
    private void PanelCount()
    {
        _moneyImage.transform.GetComponent<Animator>().SetTrigger("Shake");
        UpgradePanelShow();
        _panelCount++;
    }
    private void KillCount()
    {
        _killCount++;
        _killSlider.fillAmount = (_killCount / _levelSO.LevelIndex * 10)/100;
        Debug.Log(_killSlider.fillAmount);
    }
}
