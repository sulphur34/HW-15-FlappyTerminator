using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour
{
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        _weapon.Shoot();
    }

    private void OnDisable()
    {
        _weapon?.ResetPool();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBullet bullet) == false)
        {
            GameObject ammunition = transform.Find("Ammunition").gameObject;
            gameObject.GetComponent<Weapon>().ResetPool();
            gameObject.SetActive(false);            
            ammunition.SetActive(true);
        }
    }
}