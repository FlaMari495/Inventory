using UnityEngine;

namespace FlMr_Inventory.Demo
{
    [CreateAssetMenu(menuName = "Item/Weapon", fileName = "Weapon")]
    public class Weapon : ItemBase, IUsable
    {
        /// <summary>
        /// 攻撃力
        /// </summary>
        [SerializeField] private int atk;

        /// <summary>
        /// 防御力
        /// </summary>
        [SerializeField] private int df;

        #region IUsableの要請

        public bool Check()
        {
            // プレイヤーが装備できる武器の数に制限がある場合
            // if(player.Instance.Weapons.Count >= 2) return false;

            return true;
        }

        public void Use()
        {
            // player.Instance.Weapons.Add(this);

            Debug.Log($"{ItemName}を装備しました!");
        }

        #endregion
    }
}