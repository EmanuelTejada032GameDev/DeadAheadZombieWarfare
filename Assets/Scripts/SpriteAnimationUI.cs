using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimationUI : MonoBehaviour
{
    public float _speed = 1f;
    public int frameRate = 30;
    public bool loop = false;

    private Image _image = null;
    public Sprite[] animationSprites = null;

    private float _timePerFrame = 0f;
    private float _elapsedTime = 0f;
    private int _currentFrame = 0;


    void Start()
    {
        _image = GetComponent<Image>();
        enabled = false;
        spritesAnimationConfig();
    }

    private void spritesAnimationConfig()
    {
        _timePerFrame = 1f / frameRate;
        Play();
    }

    private void Play()
    {
        enabled = true;
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime * _speed;
        if(_elapsedTime >= _timePerFrame)
        {
            _elapsedTime = 0;
            _currentFrame++;
            SetSprite();
            if(_currentFrame >= animationSprites.Length)
            {
                if (loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    enabled = false;
                }


            }
        }
    }

    private void SetSprite()
    {
        if (_currentFrame >= 0 && _currentFrame < animationSprites.Length)
            _image.sprite = animationSprites[_currentFrame];
    }
}
