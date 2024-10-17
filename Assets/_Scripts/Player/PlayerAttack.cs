using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Slash _slash;
    [SerializeField] Transform _attackPoint;
    [SerializeField] LayerMask _targetLayer;
    [SerializeField] float _attackRange = 0.5f;
    [SerializeField] float _attackRate = 2f;

    private InputReader _input;

    float _nextAttackTime;

    private void Awake()
    {
        _input = GetComponent<PlayerController>().Input;
        _nextAttackTime = 0f;
    }

    private void OnEnable()
    {
        _input.AttackEvent += DoAttack;
    }

    private void OnDisable()
    {
        _input.AttackEvent -= DoAttack;
    }

    private void DoAttack()
    {
        if (_nextAttackTime > Time.time)
        {
            return;
        }

        Instantiate(_slash, _attackPoint.position, Quaternion.identity);
        Collider2D[] targetCols = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _targetLayer);
        foreach (Collider2D target in targetCols)
        {
            Debug.Log(target.name);
        }
        _nextAttackTime = Time.time + 1f / _attackRate;

    }

    private void Attack()
    {
        // spawn slash here

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
