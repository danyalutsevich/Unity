using UnityEngine;

public class Fire : MonoBehaviour
{
    // Префаб снаряда
    public GameObject projectilePrefab;
    // Позиция, откуда будет выпущен снаряд
    public Transform firePoint;
    // Скорость полета снаряда
    public float projectileSpeed = 1000f;

    void Update()
    {
        // Проверяем, если нажата кнопка для выстрела (например, пробел)
        if (Input.GetKeyDown(KeyCode.F))
        {
           Shoot();
        }
    }

    void Shoot()
    {
        // Создаем луч, направленный вперед от башни танка
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Пускаем луч
        if (Physics.Raycast(ray, out hit))
        {
            // Если луч столкнулся с чем-то, то получаем точку столкновения и направление к ней
            Vector3 targetPoint = hit.point;

            // Поворачиваем башню танка в сторону точки столкновения
            transform.LookAt(targetPoint);

            // Создаем снаряд и запускаем его в сторону точки столкновения
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.velocity = transform.forward * projectileSpeed;
            //projectileRb.AddForce(targetPoint*projectileSpeed, ForceMode.Impulse);
        }
        else
        {
            // Если луч не столкнулся с чем-то, то просто создаем снаряд и пускаем его вперед
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.velocity = transform.forward * projectileSpeed;
        }
    }
}