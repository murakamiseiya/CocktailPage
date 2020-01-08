///
/// ファイル名	: DivOnclick.js
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

$(function () {

    let targets = document.getElementsByClassName("cocktailData");
    for (let i = 0; i < targets.length; i++) {
        targets[i].addEventListener("click", () => {
            var vURL = "https://localhost:44392/CocktailDetail/CocktailDetailPage?seletID=" + targets[i].id;
            location.href = vURL;
            //divの子オブジェクトと親オブジェクトが一緒に実行されないようにする
            return false;
        }, false);
    }

    /*
    $("div").click(function () {

        var vURL = "https://localhost:44392/CocktailDetail/CocktailDetailPage?seletID=" + this.id;
        location.href = vURL;
        //divの子オブジェクトと親オブジェクトが一緒に実行されないようにする
        return false;

    });
    */
    
});