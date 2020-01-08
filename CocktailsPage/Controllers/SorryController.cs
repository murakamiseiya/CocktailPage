///
/// ファイル名	: SorryController.cs
/// 作成者		: murakami
/// 制作日		: 2019/12/30
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2019/12/30	新規作成
///
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CocktailsPage.Controllers
{
    /// <summary>
    /// エラーページを表示するクラス
    /// </summary>
    public class SorryController : Controller
    {
        /// <summary>
        /// エラーページの表示を行うc
        /// </summary>
        /// <returns>エラーページ</returns>
        public ActionResult SorryPage()
        {
            return View();
        }

    }
}