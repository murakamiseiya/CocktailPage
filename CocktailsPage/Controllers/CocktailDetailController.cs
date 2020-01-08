using CocktailsPage.Models;
using CocktailsPage.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CocktailsPage.Controllers
{
    public class CocktailDetailController : BaseController
    {
        // GET: CocktailDetail
        public ActionResult CocktailDetailPage()
        {
            logger.Debug("Start");

            //GETパラメータをログに出力
            LogHelper.InfoLog_HttpGetParameter(logger, Request);
            if(Request.QueryString["selcetID"] != null) {
                throw new Exception("selectIDがありません");
            }
            //表示するデータを取得
            Drink drink = CocktailAPI.IdSearch(Request.QueryString["seletID"],logger);
            //成分・分量のデータを入れる
            ViewBag.cocktailIngredients = drink.CocktailIngredients();

            logger.Debug("End");
            return View(drink);
        }
    }
}