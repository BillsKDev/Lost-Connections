using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField] Slider _familySlider;
    [SerializeField] Slider _socialSlider;
    [SerializeField] float _minValue = 0f;
    [SerializeField] float _maxValue = 100f;
    [SerializeField] bool _clampValues = true;
    [SerializeField] float _smoothSpeed = 5f; 

    private float _targetFamilyValue;
    private float _targetSocialValue;

    private void Start()
    {
        if (_familySlider != null)
        {
            _familySlider.minValue = _minValue;
            _familySlider.maxValue = _maxValue;
            _targetFamilyValue = _familySlider.value;
        }

        if (_socialSlider != null)
        {
            _socialSlider.minValue = _minValue;
            _socialSlider.maxValue = _maxValue;
            _targetSocialValue = _socialSlider.value;
        }
    }

    private void Update()
    {
        if (_familySlider != null)
            _familySlider.value = Mathf.Lerp(_familySlider.value, _targetFamilyValue, Time.deltaTime * _smoothSpeed);

        if (_socialSlider != null)
            _socialSlider.value = Mathf.Lerp(_socialSlider.value, _targetSocialValue, Time.deltaTime * _smoothSpeed);
    }

    public void AdjustFamilySlider(float amount)
    {
        _targetFamilyValue += amount;

        if (_clampValues)
            _targetFamilyValue = Mathf.Clamp(_targetFamilyValue, _minValue, _maxValue);

    }

    public void AdjustSocialSlider(float amount)
    {
        _targetSocialValue += amount;

        if (_clampValues)
            _targetSocialValue = Mathf.Clamp(_targetSocialValue, _minValue, _maxValue);

    }

    public void SetFamilySlider(float value)
    {
        _targetFamilyValue = value;

        if (_clampValues)
            _targetFamilyValue = Mathf.Clamp(_targetFamilyValue, _minValue, _maxValue);

    }

    public void SetSocialSlider(float value)
    {
        _targetSocialValue = value;

        if (_clampValues)
            _targetSocialValue = Mathf.Clamp(_targetSocialValue, _minValue, _maxValue);

    }

    public void AdjustBothSliders(float familyAmount, float socialAmount)
    {
        AdjustFamilySlider(familyAmount);
        AdjustSocialSlider(socialAmount);
    }
}