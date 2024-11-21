using UnityEngine;
using UnityEngine.UI;

namespace Enemys
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;


        public void UpdateHealthBar(float currentValue, float maxValue)
        {
            slider.value = currentValue / maxValue;
        }


        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
