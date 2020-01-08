///
/// ファイル名	: CocktailItemsController.cs
/// 作成者		: murakami
/// 制作日		: 2019/12/27
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2019/12/27	新規作成
///
///

using CocktailsPage.Models;
using CocktailsPage.Models.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace CocktailsPage.Controllers
{
    /// <summary>
    /// 検索結果一覧を表示するクラス
    /// </summary>
    public class CocktailItemsController : BaseController
    {

        /// <summary>
        /// CocktailItems画面を表示する処理
        /// theCocktailDBのAPIより検索に指定された項目のデータを取得し表示する
        /// </summary>
        /// <returns>CocktailItems</returns>
        public ActionResult CocktailItems()
        {

            logger.Debug("Start");

            //GETパラメータをログに出力
            LogHelper.InfoLog_HttpGetParameter(logger, Request);

            CocktailNameModel cnm = null;

            //レスポンスをデシリアライズしたデータを入れる変数
            if (Request.QueryString["CocktailName"] != null) {
                cnm = CocktailAPI.NameSearch(Request.QueryString["CocktailName"], logger);

            }
            else
            {
                //すべてを表示する
                cnm = CocktailAPI.NameSearch("", logger);
            }

            //htmlに表示するデータの格納
            ViewBag.drinks = cnm.drinks;

            logger.Debug("End");
            //自分自身を表示
            return View();

        }

       
    }
}