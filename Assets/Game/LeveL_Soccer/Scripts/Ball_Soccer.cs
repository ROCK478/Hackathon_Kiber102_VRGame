using UnityEngine;

public class Ball_Soccer : MonoBehaviour
{
    private Rigidbody rb;
    private float baseBounceForce;
    private float maxSpeed;

    [Header("General Settings")]
    public Transform player;           // Ссылка на игрока (камера)
    public float radiusFromPlayer = 0.5f;

    private float targetRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null) player = Camera.main.transform;

        SetDifficulty(GameSettings.difficultyLevel);
        targetRadius = radiusFromPlayer;
    }

    public void SetDifficulty(int level)
    {
        switch (level)
        {
            case 1: // Easy
                baseBounceForce = 3f;
                maxSpeed = 4f;
                break;
            case 2: // Medium
                baseBounceForce = 9f;
                maxSpeed = 6f;
                break;
            case 3: // Hard
                baseBounceForce = 11f;
                maxSpeed = 8f;
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        // Разная логика для тренировочного и обычного режимов
        if (GameSettings.trainingMode)
        {
            // Всегда одинаковый отскок
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, baseBounceForce, rb.linearVelocity.z);
        }
        else
        {
            // Реалистичный отскок, зависит от силы и угла
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.8f + baseBounceForce, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        // Ограничиваем горизонтальную скорость
        Vector3 vel = rb.linearVelocity;
        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        vel.z = Mathf.Clamp(vel.z, -maxSpeed, maxSpeed);
        rb.linearVelocity = vel;

        // === Основная логика ограничения движения по окружности ===

        // Вектор от игрока до мяча
        Vector3 fromPlayer = transform.position - player.position;

        // Сохраняем только горизонтальную составляющую
        fromPlayer.y = 0;

        // Если мяч не на нужном расстоянии — корректируем радиус
        fromPlayer = fromPlayer.normalized * targetRadius;

        // Применяем корректировку позиции (по горизонтали)
        Vector3 desiredPosition = player.position + fromPlayer;
        desiredPosition.y = transform.position.y; // по вертикали оставляем физику

        // Перемещаем мяч плавно (не резко)
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * 8f);
    }
}

