/// 
/// ファイル名	: CocktailSerchItem.cs
/// 作成者		: 村上聖矢
/// 制作日		: 2019/12/27
/// 最終更新者	: なし
/// 最終更新日	: なし
/// 
/// 更新履歴
/// 名前			日付		内容
/// 村上聖矢		2019/12/27	新規作成
/// 
/// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

//System.Web.Mvcの名前空間で使用することによりオーバーポスティング攻撃の対策になる。
namespace System.Web.Mvc.CocktailsPage.Models
{
    /// <summary>
    /// カクテルを検索する際に必要なデータのモデル
    /// </summary>
    public class CocktailSerchItem
    {
        #region フィールド

        private string  cocktailName; //カクテル名

        #endregion

        #region  アクセッサ

        //カクテル名
        [DisplayName("カクテル名")]
        public string CocktailName
        {
            get { return cocktailName;  } 
            set { cocktailName = value; }
        }

        

        #endregion


    }
}