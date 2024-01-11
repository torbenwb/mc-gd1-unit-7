using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TowerDefense;

public class DisplayTowerInfo : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private void OnEnable()
    {
        var textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        title = textComponents[0];
        description = textComponents[1];
    }

    public void Show(Tower_SO towerType)
    {
        gameObject.SetActive(true);
        title.text = towerType.title.ToString();
        description.text = $"- Costs {towerType.cost.ToString()} gold.\n- Deals {towerType.damage.ToString()} damage every {towerType.fireRate} seconds" +
            $"\n- Click a tile to place.\n- Cannot be placed on path.";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
