using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    [SerializeField] private List<Heart> _hearts;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        OnHealthChanged(_player.Health);
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if (_hearts.Count < health)
        {
            int count = health - _hearts.Count;
            for (int i = 0; i < count; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > health && _hearts.Count != 0)
        {
            for (int i = 0; i < _hearts.Count - health; i++)
            {
                DestroyHeart(_hearts[^1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart);
        newHeart.ToFill();
    }
}