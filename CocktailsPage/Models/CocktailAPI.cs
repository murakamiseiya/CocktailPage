using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using CocktailsPage.Models.Json;
using log4net;

namespace CocktailsPage.Models
{
    /// <summary>
    /// カクテルAPIに接続するクラス
    /// </summary>
    public class CocktailAPI
    {

        /// <summary>
        /// 名前でカクテルを検索する
        /// </summary>
        /// <param name="i_searchName">検索に使用する名前</param>
        /// <param name="i_logger">ロガー</param>
        /// <returns></returns>
        public static CocktailNameModel NameSearch(String i_searchName,ILog i_logger)
        {
            i_logger.Debug("Start");
            //接続URL
            String baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/search.php?";
            //GETパラメータの作成
            Dictionary<string, string> sendGetParams = new Dictionary<string, string>();
            //名前でカクテルを検索する場合
            sendGetParams.Add("s", i_searchName);
            WebResponse webRes = HttpAccess(baseUrl, sendGetParams, i_logger);
            CocktailNameModel cnm = JsonPurse(webRes, i_logger);
            i_logger.Debug("End");
            return cnm;
        }

        /// <summary>
        /// IDでカクテルを検索する
        /// </summary>
        /// <param name="i_searchId">検索に使用するID</param>
        /// <param name="i_logger">ロガー</param>
        /// <returns></returns>
        public static Drink IdSearch(String i_searchId, ILog i_logger)
        {
            i_logger.Debug("Start");
            //接続URL
            String baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?";
            //GETパラメータの作成
            Dictionary<string, string> sendGetParams = new Dictionary<string, string>();
            //名前でカクテルを検索する場合
            sendGetParams.Add("i", i_searchId);

            WebResponse webRes = HttpAccess(baseUrl, sendGetParams, i_logger);
            CocktailNameModel cnm = JsonPurse(webRes, i_logger);
            Drink drink = cnm.drinks[0];
            i_logger.Debug("End");
            return drink;
        }

        /// <summary>
        /// Jsonデータの解析を行う
        /// </summary>
        /// <param name="i_res">Jsonデータ</param>
        /// <param name="i_logger">ロガー</param>
        /// <returns>解析後のJsonデータ</returns>
        private static CocktailNameModel JsonPurse(WebResponse i_res,ILog i_logger )
        {
            i_logger.Debug("Start");
            CocktailNameModel cnm = null;

            //デシリアライズ
            using (i_res)
            {
                using (Stream resStream = i_res.GetResponseStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CocktailNameModel));
                    cnm = (CocktailNameModel)serializer.ReadObject(resStream);
                }
            }
            i_logger.Debug("End");
            return cnm;

        }

        /// <summary>
        /// HTTPリクエストを行うメソッド
        /// </summary>
        /// <param name="i_baseUrl">接続先のURL</param>
        /// <param name="i_sendGetParams">getパラメータを設定</param>
        /// <returns>レスポンスを返す</returns>
        private static WebResponse HttpAccess(string i_baseUrl, Dictionary<string, string> i_sendGetParams, ILog i_logger )
        {

            i_logger.Debug("Start");

            //GETパラメータの作成
            NameValueCollection getParams = HttpUtility.ParseQueryString("");
            foreach (KeyValuePair<string, string> getParam in i_sendGetParams)
            {
                getParams.Add(getParam.Key, HttpUtility.UrlEncode(getParam.Value));
            }
            //HTTPアクセス
            WebRequest req = WebRequest.Create(i_baseUrl + getParams.ToString());
            WebResponse res = req.GetResponse();


            i_logger.Debug("End");
            return res;
        }
    }
}