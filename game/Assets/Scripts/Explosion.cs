using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem explosionParticles; // Ссылка на префаб частиц взрыва

    public void Explode(Vector3 position)
    {
        // Создаем экземпляр частиц взрыва в указанной позиции
        Instantiate(explosionParticles, position, Quaternion.identity);
        //explosionParticles.
        //Destroy(explosionParticles.gameObject);і
        explosionParticles.gameObject.active = true;
    }
}