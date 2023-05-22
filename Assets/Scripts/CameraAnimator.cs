using System;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// manages the camera animations
/// </summary>
public class CameraAnimator : Singleton<CameraAnimator>
{
    Vector3 _startPos = new Vector3(0, 0.8f, -1.5f);
    Guid    uid;
    float   _duration = 1;
    void Start()
    {
        transform.position = _startPos;
        transform.eulerAngles = Vector3.zero;
    }
    /// <summary>
    /// move camera
    /// </summary>
    /// <param name="rotation"></param>
    /// <param name="pos"></param>
    public void AnimateCamera(Vector3 rotation, Vector3 pos)
    {
        if(DOTween.IsTweening(gameObject))
        {
            DOTween.Kill(uid);
        }
        
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOMove(pos, _duration));
        s.Join(transform.DORotate(rotation, _duration));
        s.SetEase(Ease.OutCubic);

        uid = Guid.NewGuid();
        s.id = uid;

        s.Play();
    }

    /// <summary>
    /// move camera to starting pos
    /// </summary>
    public void MoveToStart()
    {
        AnimateCamera(Vector3.zero, _startPos);
    }
}
