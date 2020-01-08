///
/// ファイル名	: MainPageController.cs
/// 作成者		: murakami
/// 制作日		: 2019/12/29
/// 最終更新者	: なし
/// 最終更新日	: なし
///
/// 更新履歴
/// 名前			日付		内容
/// murakami		2019/12/29	新規作成
///
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CocktailsPage.Models.Json
{
    /// <summary>
    /// カクテル名で検索した場合のJsonデータ
    /// </summary>
    [DataContract]
    public class CocktailNameModel
    {
        //取得したカクテルのデータすべて
        [DataMember]
        public List<Drink> drinks { get; set; }

    }

    /// <summary>
    /// カクテル一杯のデータ
    /// </summary>
    [DataContract]
    public class Drink
    {
        [DataMember] public string idDrink { get; set; }
        [DisplayName("カクテル名")]
        [DataMember] public string strDrink { get; set; }
        [DataMember] public string strDrinkAlternate { get; set; }
        [DataMember] public string strDrinkES { get; set; }
        [DataMember] public string strDrinkDE { get; set; }
        [DataMember] public string strDrinkFR { get; set; }
        [DataMember] public string strDrinkZH_HANS { get; set; }
        [DataMember] public string strDrinkZH_HANT { get; set; }
        [DataMember] public string strTags { get; set; }
        [DataMember] public string strVideo { get; set; }
        [DataMember] public string strCategory { get; set; }
        [DataMember] public string strIBA { get; set; }
        [DataMember] public string strAlcoholic { get; set; }
        [DisplayName("グラス")]
        [DataMember] public string strGlass { get; set; }
        [DisplayName("説明")]
        [DataMember] public string strInstructions { get; set; }
        [DataMember] public string strInstructionsES { get; set; }
        [DataMember] public string strInstructionsDE { get; set; }
        [DataMember] public string strInstructionsFR { get; set; }
        [DataMember] public string strInstructionsZH_HANS { get; set; }
        [DataMember] public string strInstructionsZH_HANT { get; set; }
        [DataMember] public string strDrinkThumb { get; set; }
        [DisplayName("成分")]
        [DataMember] public string strIngredient1 { get; set; }
        [DataMember] public string strIngredient2 { get; set; }
        [DataMember] public string strIngredient3 { get; set; }
        [DataMember] public string strIngredient4 { get; set; }
        [DataMember] public string strIngredient5 { get; set; }
        [DataMember] public string strIngredient6 { get; set; }
        [DataMember] public string strIngredient7 { get; set; }
        [DataMember] public string strIngredient8 { get; set; }
        [DataMember] public string strIngredient9 { get; set; }
        [DataMember] public string strIngredient10 { get; set; }
        [DataMember] public string strIngredient11 { get; set; }
        [DataMember] public string strIngredient12 { get; set; }
        [DataMember] public string strIngredient13 { get; set; }
        [DataMember] public string strIngredient14 { get; set; }
        [DataMember] public string strIngredient15 { get; set; }
        [DisplayName("分量")]
        [DataMember] public string strMeasure1 { get; set; }
        [DataMember] public string strMeasure2 { get; set; }
        [DataMember] public string strMeasure3 { get; set; }
        [DataMember] public string strMeasure4 { get; set; }
        [DataMember] public string strMeasure5 { get; set; }
        [DataMember] public string strMeasure6 { get; set; }
        [DataMember] public string strMeasure7 { get; set; }
        [DataMember] public string strMeasure8 { get; set; }
        [DataMember] public string strMeasure9 { get; set; }
        [DataMember] public string strMeasure10 { get; set; }
        [DataMember] public string strMeasure11 { get; set; }
        [DataMember] public string strMeasure12 { get; set; }
        [DataMember] public string strMeasure13 { get; set; }
        [DataMember] public string strMeasure14 { get; set; }
        [DataMember] public string strMeasure15 { get; set; }
        [DataMember] public string strCreativeCommonsConfirmed { get; set; }
        [DataMember] public string dateModified { get; set; }
        private int count ;
        public int Count { get { return count; } }


        /// <summary>
        /// カクテルの成分と分量を返す
        /// </summary>
        /// <returns>カクテルの成分と分量</returns>
        public CocktailIngredient[] CocktailIngredients()
        {
            //カクテルの成分、分量を保持する変数
            CocktailIngredient[] cocktailIngredients;
            try
            {
                //カクテルの成分配列
                string[] ingredients = { strIngredient1  , strIngredient2  , strIngredient3  , strIngredient4  , strIngredient5  , strIngredient6  ,
                                     strIngredient7  , strIngredient8  , strIngredient9  , strIngredient10 , strIngredient11 , strIngredient12 ,
                                     strIngredient13 , strIngredient14 , strIngredient15   };
                //カクテルの分量配列
                string[] measures = { strMeasure1  , strMeasure2  , strMeasure3  , strMeasure4  , strMeasure5  , strMeasure6  ,
                                  strMeasure7  , strMeasure8  , strMeasure9  , strMeasure10 , strMeasure11 , strMeasure12 ,
                                  strMeasure13 , strMeasure14 , strMeasure15   };

                //カクテルの成分の数をカウントする
                count = 0;
                while (ingredients[count] != null)
                {
                    count++;
                }

                //カクテルの成分、分量を代入する
                cocktailIngredients = new CocktailIngredient[count];
                for (int i = 0; i < count; i++)
                {

                    cocktailIngredients[i] = new CocktailIngredient(ingredients[i], measures[i]);

                }
            }
            catch(Exception e)
            {
                //データ０の配列を返す。
                count = 0;
                cocktailIngredients = new CocktailIngredient[0];
            }

            return cocktailIngredients;
        }
    }

    /// <summary>
    /// カクテル作成に必要な成分と分量のデータ
    /// </summary>
    public class CocktailIngredient
    {

        #region フィールド
        private string ingredient;  //成分
        private string measure;     //分量
        #endregion

        #region アクセッサ
        public string Ingredient { 
            get { return ingredient; } 
            set { ingredient = value; }
        } 
        public string Measure
        {
            get { return measure; }
            set { measure = value; }
        }
        #endregion

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="i_ingredient">カクテルの成分</param>
        /// <param name="i_measure">カクテルの分量</param>
        public CocktailIngredient(string i_ingredient, string i_measure)
        {
            ingredient = i_ingredient;
            measure = i_measure;
        }
    }
}