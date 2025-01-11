using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBacground : MonoBehaviour
{
    public Camera cam;                // Tham chiếu đến camera để tính toán hiệu ứng parallax
    public Transform followTarget;    // Tham chiếu đến đối tượng mục tiêu mà parallax sẽ di chuyển theo (player)

    // Vị trí ban đầu của hiệu ứng parallax
    private Vector2 startPositon;     // Vị trí bắt đầu của lớp parallax (background layer) khi bắt đầu game

    // Tính khoảng cách mà camera đã di chuyển kể từ khi bắt đầu
    private Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startPositon;

    // Tính khoảng cách Z giữa lớp parallax và đối tượng mục tiêu (followTarget)
    private float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // Xác định mặt clipping của camera để tính toán độ sâu cho hiệu ứng parallax
    private float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Tính hệ số parallax (parallax factor) dựa trên khoảng cách Z từ đối tượng mục tiêu và mặt clipping của camera
    private float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Lưu trữ vị trí ban đầu của vật thể (theo trục Z) để không thay đổi theo hiệu ứng parallax
    private float startZ;

    void Start()
    {
        // Gán vị trí ban đầu của lớp parallax khi khởi động
        startPositon = transform.position;

        // Gán vị trí Z ban đầu để giữ cố định trục Z
        startZ = transform.position.z;
    }

    void Update()
    {
        // Tính vị trí mới dựa trên vị trí bắt đầu và khoảng cách camera đã di chuyển, có xét đến parallaxFactor
        Vector2 newPosition = startPositon + camMoveSinceStart * parallaxFactor;

        // Cập nhật vị trí của lớp parallax trên trục X và Y, giữ nguyên trục Z để không thay đổi độ sâu
        transform.position = new Vector3(newPosition.x, newPosition.y, startZ);
    }
}
