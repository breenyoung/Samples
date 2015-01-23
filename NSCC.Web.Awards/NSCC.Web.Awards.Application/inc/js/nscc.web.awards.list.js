var NsccAwardList = NsccAwardList || {};

NsccAwardList = (function ($, document) {

    "use strict";

    var elemAwardsContainer = "#tblAwards",
        elemBasketSubmit = "[id$=lbSubmit]",
        $basketSubmit,
        elemBasketNoAwards = "#basketempty",
        $basketNoAwards,
        elemBasketAwards = "#basketawards",
        $basketAwards,
        elemSelectedAwards = "[id$=hdnSelectedAwards]",
        $hSelectedAwards,
        elemExistingState = "[id$=hdnSessionState]",
        $hExistingState,
        elemBasketContainer = "#basketContainer",
        $basketContainer,
        elemAgreedToTerms = "#cbAgreedToTerms",
        $agreedToTerms,


        elemBasketCount = "#basketCount",
        $dBasketCount,
        basketCount = 0,
        arrSelectedAwards = new Array()
            
    ;

    var setAwardString = function () {

        var delimtedValue = "";

        var len = arrSelectedAwards.length;
        for (var i = 0; i < len; i++) {
            delimtedValue += arrSelectedAwards[i] + ":::";
        }

        $hSelectedAwards.val(delimtedValue);
    };

    var getIndexOfAward = function(code) {

        var len = arrSelectedAwards.length;
        for (var i = 0; i < len; i++) {
            if (arrSelectedAwards[i] === code) {
                return i;
            }
        }
    };

    var loadExistingState = function () {
        
        if ($hExistingState.val() !== "") {
            
            var awards = $hExistingState.val().split(":::");
            $(elemAwardsContainer).find("a").each(function (index) {                
                if (jQuery.inArray($(this).attr("href"), awards) !== -1) {
                    var code = $(this).attr("href");
                    var title = $(this).siblings(".awardTitle").text();
                    addItem(code, title);
                }
            });
        }
    };


    var setBasketCount = function (e) {
        
        $dBasketCount.text(basketCount);
    };

    var removeItem = function (e) {
        
        var code = $(this).data("ID");
        
        $(this).parent().remove();
        
        basketCount -= 1;

        arrSelectedAwards.splice(getIndexOfAward(code), 1);

        if (basketCount == 0) { $basketNoAwards.show(); $basketSubmit.hide(); }

        setAwardString();

        setBasketCount();

        e.preventDefault();
    };

    var addItem = function (code, title) {

        if (jQuery.inArray(code, arrSelectedAwards) === -1) {

            var container = $(document.createElement("li"));
            container.addClass("btest");

            var textNode = $(document.createTextNode(title));
            
            var removeLink = $(document.createElement("a"));
            removeLink.data("ID", code);
            removeLink.attr("href", "#");
            removeLink.attr("class", "btn-remove2");
            //removeLink.text("Remove");
            removeLink.bind("click", removeItem);

            

            container.append(removeLink);
            container.append(textNode);
            
            $basketAwards.append(container);

            

            $basketNoAwards.hide();
            $basketSubmit.show();

            basketCount += 1;

            arrSelectedAwards.push(code);

            setAwardString();

            setBasketCount();
        }
    };

    var init = function () {        
        
        // Cache freq. used selectors
        $hSelectedAwards = $(elemSelectedAwards);
        $basketAwards = $(elemBasketAwards);
        $basketNoAwards = $(elemBasketNoAwards);
        $basketSubmit = $(elemBasketSubmit);
        $hExistingState = $(elemExistingState);
        $dBasketCount = $(elemBasketCount);
        $basketContainer = $(elemBasketContainer);
        $agreedToTerms = $(elemAgreedToTerms);

        //$(elemAwardsContainer).find("a").bind("click", function (e) {
        $(elemAwardsContainer).find("li").bind("click", function (e) {            
            e.preventDefault();
            //addItem($(this).attr("href"), $(this).siblings(".awardTitle").text());
            addItem($(this).children("a").attr("href"), $(this).children(".awardTitle").text());
        });

        loadExistingState();

        /*
        $basketSubmit.click(function (e) {
            //console.log($agreedToTerms.is(":checked"));
            if (!$agreedToTerms.is(":checked")) {
                e.preventDefault();
            }            
        });
        */

    };

    var pub =
	{
	    init: init
	};

    return pub;

}(jQuery, document));

$(document).ready(function () { NsccAwardList.init(); });