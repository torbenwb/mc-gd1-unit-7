
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace TowerDefense{

    public class ValueDisplay : MonoBehaviour
    {
        public static UnityEvent<string, object> OnValueChanged = new UnityEvent<string, object>();
    
        [SerializeField] private string valueName = "";
        private TextMeshProUGUI displayText;

        private void Awake()
        {
            displayText = GetComponent<TextMeshProUGUI>();
            OnValueChanged.AddListener(ValueChanged);
        }

        void ValueChanged(string valueName, object value)
        {
            if (this.valueName == valueName)
            {
                displayText.text = value.ToString();
            }
        }
    }


    
}

