using UnityEngine;

namespace PixelGameAssets.Scripts.Actor.ControllerSys
{
    /// <summary>
    /// Controller 基类
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseController : MonoBehaviour
    {
        /// <summary>
        /// 可推动物体所在层 (参考 推箱子)
        /// </summary>
        //public LayerMask pushblock_layer;
        [SerializeField] [Header("Collider")] protected Collider2D myCollider; // 缓存对撞机（仅使用Collider2D）

        // 检查给定图层中actor的顶部是否存在碰撞
        public bool CollisionSelf(LayerMask layer)
        {
            var leftcorner = new Vector2(myCollider.bounds.center.x - myCollider.bounds.extents.x + .1f,
                myCollider.bounds.center.y + myCollider.bounds.extents.y - .1f);
            var rightcorner = new Vector2(myCollider.bounds.center.x + myCollider.bounds.extents.x - .1f,
                myCollider.bounds.center.y - myCollider.bounds.extents.y + .1f);
            return Physics2D.OverlapArea(leftcorner, rightcorner, layer);
        }

        // 辅助函数，用于检查给定图层中是否存在任何具有额外设置位置的碰撞
        public bool CheckColAtPlace(Vector2 extraPos, LayerMask layer)
        {
            var leftcorner = Vector2.zero;
            var rightcorner = Vector2.zero;

            leftcorner = new Vector2(myCollider.bounds.center.x - myCollider.bounds.extents.x + .1f,
                             myCollider.bounds.center.y + myCollider.bounds.extents.y - .1f) + extraPos;
            rightcorner = new Vector2(myCollider.bounds.center.x + myCollider.bounds.extents.x - .1f,
                              myCollider.bounds.center.y - myCollider.bounds.extents.y + .1f) + extraPos;

            return Physics2D.OverlapArea(leftcorner, rightcorner, layer);
        }
    }
}