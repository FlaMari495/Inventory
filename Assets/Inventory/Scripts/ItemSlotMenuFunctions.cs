using System;
using System.Collections.Generic;

namespace FlMr_Inventory
{
    /// <summary>
    /// 各アイテムに対してどのようなメニューを表示するかを定めるクラス
    /// </summary>
    public class ItemSlotMenuFunctions
    {
        /// <summary>
        /// メニューに表示される全項目
        /// (この項目全てが表示されるわけではなく、アイテムに合った項目が選択的に表示される)
        /// </summary>
        internal List<(string menuName, Action<ItemBase> function)> MenuItems { get; } = new();

        /// <summary>
        /// メニューに表示される項目の追加
        /// </summary>
        /// <param name="function"></param>
        public void AddMenuItem(string name, Action<ItemBase> function)
        {
            MenuItems.Add((name, function));
        }
    }
}