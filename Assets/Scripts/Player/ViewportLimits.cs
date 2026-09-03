using UnityEngine;

[CreateAssetMenu(fileName = "ViewportLimits", menuName = "Scriptable Objects/ViewportLimits")]
public class ViewportLimits : ScriptableObject
{
    [Range(0, 1)][SerializeField] private float _minY;
   
    [Range(0, 1)] [SerializeField] private float _maxY;

    public float MinY => _minY;
    public float MaxY => _maxY;
}
