///
/// ファイル名	: BaseController.cs
/// 作成者		: murakami
/// 制作日		: 2020/1/2
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2020/1/2	新規作成
///
///

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CocktailsPage.Controllers
{
    /// <summary>
    /// すべてのコントローラの基底クラス
    /// </summary>
    public class BaseController : Controller
    {

        #region フィールド

        public ILog logger; //ロガー

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseController()
        {
            //デバッグログの初期化
            logger = LogManager.GetLogger(Assembly.GetExecutingAssembly().FullName);
        }

        /// <summary>
        /// アクションでハンドルされない例外が発生したときに呼び出されます。
        /// </summary>
        /// <param name="filterContext">現在の要求およびアクションに関する情報。</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            logger.Error("Start");
            logger.Error("エラー内容:"+filterContext.Exception.ToString());

            if (typeof(HttpRequestValidationException) == filterContext.Exception.GetType())
            {
                //ここにバリデーションエラー時の処理を書く
            }

            filterContext.Result = RedirectToAction("SorryPage", "Sorry");
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            logger.Error("End");
        }
    }
}