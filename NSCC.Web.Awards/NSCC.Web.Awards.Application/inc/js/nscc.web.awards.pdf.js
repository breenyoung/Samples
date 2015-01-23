var NsccAwardApplicationPdf = NsccAwardApplicationPdf || {};


NsccAwardApplicationPdf = (function ($, document) {
    
    "use strict";

    var financialIndexStart = 14,
        financialIndexEnd = 53;

    var hideFinancialInfo = function () {
        
        // Hide Income / Expenses / Financial Needs areas
        $("#tblMain tr").slice(financialIndexStart, financialIndexEnd).hide();
    };

    var showQuestions = function (elemArray) {

        if (elemArray.length > 0) {
            for (var i = 0; i < elemArray.length; i++) { $(elemArray[i]).show(); }
        }
    };

    var init = function ()
    {

    };

    var pub =
	{
	    init: init,
	    hideFinancialInfo: hideFinancialInfo,
	    showQuestions: showQuestions
	};

    return pub;

}(jQuery, document));

$(document).ready(function () { NsccAwardApplicationPdf.init(); });