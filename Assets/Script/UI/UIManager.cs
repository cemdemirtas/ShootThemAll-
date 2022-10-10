using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonPersistant<UIManager>
{
    //public static UIManager instance;
    public static UnityAction UpgradePanelEvent;
    public static UnityAction KillEvent;

    [SerializeField] GameObject _upgradePanel;
    [SerializeField] Image _killSlider;
    [SerializeField] Image _moneyImage;
    [SerializeField] TextMeshProUGUI _LevelIndexText;
    [SerializeField] public Transform _gameUI;


    [SerializeField] public float _panelCount;
    [SerializeField] public float _killCount;


    [SerializeField] LevelSO _levelSO;

    private void OnEnable()
    {
        _LevelIndexText.text = "Level: " + _levelSO.LevelIndex;
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
        if (_killSlider.fillAmount == 1)
        {
            GameManager.Instance.gamestate = GameManager.GameState.Next;
            _levelSO.LevelIndex++;
            _LevelIndexText.text = "Level: "+_levelSO.LevelIndex;
            _killCount = 0;
        }
    }
}
