using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static UnityAction UpgradePanelEvent;

    [SerializeField] GameObject UpgradePanel;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        UpgradePanelEvent += UpgradePanelShow;
    }
    public void UpgradePanelHide()
    {
        UpgradePanel.SetActive(false);
    }
    public void UpgradePanelShow()
    {
        UpgradePanel.SetActive(true);
    }
}
