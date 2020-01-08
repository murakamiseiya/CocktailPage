///
/// ファイル名	: LogHelper.cs
/// 作成者		: murakami
/// 制作日		: 2020/1/4
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2020/1/4	新規作成
///
///
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CocktailsPage.Models
{
    /// <summary>
    /// ログ出力の補助をするクラス
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// httpリクエストをログ出力する
        /// </summary>
        /// <param name="i_logger">使用するロガー</param>
        /// <param name="i_request">リクエストパラメータ</param>
        public static void InfoLog_HttpGetParameter( ILog i_logger , HttpRequestBase i_request )
        {
            foreach (string key in i_request.QueryString.Keys)
            {
                i_logger.Info("遷移パラメータ:" + i_request.QueryString[key]);
            }
        }
    }
}