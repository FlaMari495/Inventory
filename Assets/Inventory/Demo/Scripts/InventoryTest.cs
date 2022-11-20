using UnityEngine;

namespace FlMr_Inventory.Demo
{
    public class InventoryTest : MonoBehaviour
    {
        /// <summary>
        /// “®ìŠm”F‚Ì‘ÎÛ‚Å‚ ‚éItemBag
        /// </summary>
        [SerializeField] private ItemBag bag;

        void Start()
        {
            bag.AddItem(1, 2);
            bag.AddItem(2, 2);
            bag.AddItem(3, 2);
        }

    }
}