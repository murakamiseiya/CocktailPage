///
/// ファイル名	: MainPageController.cs
/// 作成者		: murakami
/// 制作日		: 2019/12/26
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2019/12/26	新規作成
///
///

using CocktailsPage.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.CocktailsPage.Models;
using System.Web.Routing;

namespace CocktailsPage.Controllers
{
    /// <summary>
    /// 検索するページ
    /// </summary>
    public class MainController : BaseController
    {

        /// <summary>
        /// MainPageを表示する処理
        /// </summary>
        /// <returns>MainPage</returns>
        public ActionResult MainPage()
        {
            logger.Debug("Start");

            logger.Debug("End");
            return View();
        }

        /// <summary>
        /// 検索結果一覧画面に遷移を行う
        /// その際入力された項目を次のページにGetパラメータとして送る
        /// </summary>
        /// <param name="cocktailSerchItem">入力された項目</param>
        /// <returns>検索結果一覧画面</returns>
        [HttpPost]
        public ActionResult MainPage(CocktailSerchItem cocktailSerchItem)
        {
            logger.Debug("Start");
            //遷移するコントローラー
            string controllerName = "CocktailItems";
            //遷移先のメソッド名
            string actionName = "CocktailItems";

            logger.Debug("End");
            //別コントローラに画面を遷移させる（GETパラメータ送信)
            return RedirectToAction(actionName, controllerName, new { CocktailName = cocktailSerchItem.CocktailName });

        }

    }
}