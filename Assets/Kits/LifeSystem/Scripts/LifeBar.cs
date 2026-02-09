using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] Life life;
    [SerializeField] Image imageFill;

    private void OnEnable()
    {
        life.onLifeChange.AddListener(OnLifeChange);
        life.onDeath.AddListener(OnDeath);
    }

    private void OnDisable()
    {
        life.onLifeChange.RemoveListener(OnLifeChange);
        life.onDeath.RemoveListener(OnDeath);
    }

    void OnLifeChange(float newLife)
    {
        imageFill.fillAmount = newLife;
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }
}
