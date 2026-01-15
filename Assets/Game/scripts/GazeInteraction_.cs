using UnityEngine;

public class GazeInteraction_ : MonoBehaviour
{
    [Header("Настройки взгляда")]
    public float gazeTime = 2f; // Время в секундах для взаимодействия
    public float maxDistance = 10f; // Максимальная дистанция для взаимодействия
    public LayerMask interactableLayer; // Слой для взаимодействия

    private float gazeTimer = 0f;
    private GazeTarget_ currentTarget;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; // Информация о попадании луча

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
        {
            GazeTarget_ target = hit.collider.GetComponent<GazeTarget_>(); // Получаем компонент цели взгляда

            if (target != currentTarget) // Если цель изменилась
            {
                currentTarget?.OnGazeExit();
                currentTarget = target;
                currentTarget?.OnGazeEnter();
                gazeTimer = 0f;
            }

            gazeTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(gazeTimer / gazeTime);
            currentTarget?.UpdateGazeProgress(progress);

            if (gazeTimer >= gazeTime)
            {
                currentTarget?.OnGazeInteract();
                gazeTimer = 0f;
            }
        }
        else
        {
            currentTarget?.OnGazeExit();
            currentTarget = null;
            gazeTimer = 0f;
        }
    }
}
