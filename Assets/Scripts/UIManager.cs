using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scores;
    [SerializeField] private Slider _slider;

    public void UpdateScores(float score)
    {
        _scores.text = score.ToString();
    }

    public void UpdateCharge(float charge)
    {
        _slider.value = charge;
    }
}
