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
        private Dictionary<Type, List<Func_Name_Pair>> MenuItems { get; } = new();

        /// <summary>
        /// メニューに表示される項目の追加
        /// </summary>
        /// <typeparam name="T">どの型に対するメニューであるか</typeparam>
        /// <param name="name">メニューの名前</param>
        /// <param name="function">ボタンがクリックされた際に実行する機能</param>
        public void AddMenuItem<T>(string name, Action<ItemBase> function)
        {
            // 型引数からType型を生成
            var type = typeof(T);

            // 辞書のキーに type が存在しない場合、新規に作成
            if (!MenuItems.ContainsKey(type)) MenuItems.Add(type, new());

            // 辞書に追加
            MenuItems[type].Add(new(name, function));
        }

        /// <summary>
        /// あるアイテムに対応するメニューを取得する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal List<Func_Name_Pair> GetMenus(ItemBase item)
        {
            // アイテムの型を取得
            var itemType = item.GetType();

            // 結果を格納する変数
            var menus = new List<Func_Name_Pair>();

            // 辞書の要素でループ
            foreach (var type_func in MenuItems)
            {
                // アイテムの型が、Keyにキャスト不可能である場合はcontinue
                if (!type_func.Key.IsAssignableFrom(itemType)) continue;

                // メニューを追加
                menus.AddRange(type_func.Value);
            }

            return menus;
        }
    }


    /// <summary>
    /// メニュー名と機能のペアを保持したクラス
    /// </summary>
    internal class Func_Name_Pair
    {
        public Func_Name_Pair(string menuName, Action<ItemBase> function)
        {
            this.menuName = menuName;
            this.function = function;
        }

        public string menuName { get; }
        public Action<ItemBase> function { get; }
    }
}