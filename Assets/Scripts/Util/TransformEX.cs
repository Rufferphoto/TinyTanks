using UnityEngine;

/// <summary>
/// Class for Transform global extensions.
/// </summary>
public static class TransformEX
{
    public static Transform Clear(this Transform _t)
    {
        foreach (Transform child in _t)
        {
            GameObject.Destroy(child.gameObject);
        }
        return _t;
    }

    public static void SetGlobalScale(this Transform _t, Vector3 _globalScale)
    {
        _t.localScale = Vector3.one;
        _t.localScale = new Vector3(_globalScale.x / _t.lossyScale.x, _globalScale.y / _t.lossyScale.y, _globalScale.z / _t.lossyScale.z);
    }
}
