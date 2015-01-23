var NsccAwardSearch = NsccAwardSearch || {};

NsccAwardSearch = (function ($, document) {
    
    "use strict";

    var arrAllPrograms = new Array(),
        arrAllCampuses = new Array(),
        elemHCampus = "[id$=hdnCampus]",
        $hCampus,
        elemHCampusName = "[id$=hdnCampusName]",
        $hCampusName,
        elemHProgram = "[id$=hdnProgram]",
        $hProgram,
        elemHProgramName = "[id$=hdnProgramName]",
        $hProgramName,
        elemCampusDdlb = "#ddlbCampus",
        $campusDdlb,
        elemDialogAllPrograms = "#divAllPrograms",
        $dialogAllPrograms,
        elemDialogCampusPrograms = "#divCampusPrograms",
        $dialogCampusPrograms,
        oAllProgramsTable,
        oCampusProgramsTable,
        elemShowAllProgramsLink = "#hlShowAllPrograms",
        $hlShowAllPrograms,
        elemShowCampusProgramsLink = "#hlShowCampusPrograms",
        $hlShowCampusPrograms,
        elemSpanDivider = "#spnLinkDivide",
        $spanDivide,
        campusLightBoxLink = "{0} Programs",
        programsForCampusCount = 0

    ;

    var getCampusesForProgram = function (pCode)
    {        
        var len = arrAllPrograms.length;
        for (var i = 0; i < len; i++)
        {
            if (arrAllPrograms[i].ProgramCode === pCode) { return arrAllPrograms[i].Campuses;}
        }
    };

    var getProgramByCode = function (pCode)
    {
        var len = arrAllPrograms.length;
        for (var i = 0; i < len; i++)
        {
            if (arrAllPrograms[i].ProgramCode === pCode) { return arrAllPrograms[i]; }
        }
    };

    var loadProgramsForCampus = function () {
        
        var name = $campusDdlb.find("option:selected").text();
        var val = $campusDdlb.val();
        $hCampus.val(val);
        $hCampusName.val(name);

        //$("#tbProgram").val("");

        var arrToLoad = new Array();
        if (val !== "")
        {
            arrToLoad = new Array();
            var arrLen = arrAllPrograms.length; // Cache for speed
            for (var i = 0; i < arrLen; i++)
            {
                for (var y = 0; y < arrAllPrograms[i].Campuses.length; y++)
                {
                    if (val == arrAllPrograms[i].Campuses[y].CampusCode)
                    {
                        arrToLoad.push({ ProgramCode: arrAllPrograms[i].ProgramCode, ProgramDescr: arrAllPrograms[i].ProgramDescr, Campuses: arrAllPrograms[i].Campuses });
                        continue;
                    }
                }
            }

            programsForCampusCount = arrToLoad.length;

            // Fill datatable
            oCampusProgramsTable.fnClearTable();
            for (var x = 0; x < arrToLoad.length; x++)
            {
                var href = "<a href=\"" + arrToLoad[x].ProgramCode + "\">" + arrToLoad[x].ProgramDescr + "</a>";
                oCampusProgramsTable.fnAddData([href]);
            }
            var oSettings = oCampusProgramsTable.fnSettings();
            oSettings.iDisplayStart = 0;
            oCampusProgramsTable.fnDraw();

            $spanDivide.css("display", "inline");
            $hlShowCampusPrograms.html(campusLightBoxLink.replace("{0}", name));
            //$("#hlShowCampusPrograms").data("campusId", $("#ddlbCampus").val());
            $hlShowCampusPrograms.css("display", "inline");
            $dialogCampusPrograms.dialog("option", "title", name + " Programs");

            //console.log("Programs for campus: " + arrToLoad.length);
        }
        else
        {
            $spanDivide.hide();
            $hlShowCampusPrograms.hide();
            arrToLoad = arrAllPrograms;
        }

        //console.log(arrToLoad);

        // Reload autocomplete options
        initAutocomplete(arrToLoad);
    };

    var loadCampuses = function (dataSet)
    {      
        var prevVal = $campusDdlb.val();
        var options = "<option value=''>Select Campus...</option>";
        for (var i = 0; i < dataSet.length; i++)
        {
            var campus = dataSet[i];
            if (prevVal !== "" && prevVal === campus.CampusCode) {
                options += "<option value='" + campus.CampusCode + "' selected='true'>" + campus.CampusDescr + "</option>";
            } else {
                options += "<option value='" + campus.CampusCode + "'>" + campus.CampusDescr + "</option>";    
            }
            
            //arrAllCampuses.push(campus);
        }
        $campusDdlb.html(options);
        
    };

    var loadPrograms = function ()
    {        
        var arrLen = jsonPrograms.length; // Cache for speed
        for (var i = 0; i < arrLen; i++)
        {
            //console.log(jsonPrograms[i]);
            arrAllPrograms.push(jsonPrograms[i]);
        }
    };

    var initDataTables = function ()
    {
        // Load all programs into table
        var len = arrAllPrograms.length;
        for (var i = 0; i < len; i++) {
            var tr = document.createElement("tr");
            var td = document.createElement("td");

            var link = document.createElement("a");
            link.innerHTML = arrAllPrograms[i].ProgramDescr;
            link.href = arrAllPrograms[i].ProgramCode;

            var br = document.createElement("br");

            td.appendChild(link);
            tr.appendChild(td);
            $("#tbodyAllPrograms").append(tr);
        }
        
        //$("#tblAllPrograms  tr:nth-child(12n) td").css("border-bottom", "none");
        //$("#tblAllPrograms td:last").css("border-bottom", "none");
        //$dialogAllPrograms.find("a").bind("click", function (e)
        $("#divAllPrograms a").bind("click", function (e)
        {
            $dialogAllPrograms.dialog("close");
            if (this.id !== "btnAllProgramsCancel")
            {
                $("#tbProgram").val(this.innerHTML);

                $("#tbProgram").val(htmlDecode(this.innerHTML));

                var pieces = $(this).attr("href").split("/");
                var pId;
                if (pieces.length == 1) { pId = pieces[0]; }
                else { pId = pieces[pieces.length - 1]; }

                $hProgram.val(pId);
                loadCampuses(getCampusesForProgram(pId));
            }
            
            e.preventDefault();
        });

        oAllProgramsTable = $("#tblAllPrograms").dataTable({
            bAutoWidth: false,
            bInfo: false,
            bFilter: false,
            bSort: false,
            bLengthChange: false,
            iDisplayLength: 12,
            sPaginationType: "two_button"
        });
        
        oCampusProgramsTable = $("#tblCampusPrograms").dataTable({
            bAutoWidth: false,
            bInfo: false,
            bFilter: false,
            bSort: false,
            bLengthChange: false,
            iDisplayLength: 12,
            sPaginationType: "two_button",
            //fnDrawCallback: function() { console.log("redrawn"); },
            fnRowCallback: function(nRow, aData, iDisplayIndex, iFullIndex) {
                if (iDisplayIndex == 11 || iFullIndex == (programsForCampusCount - 1)) {
                    $("td", nRow).css("border-bottom", "none");
                }
                //console.log($("td", nRow).html() + "*********" + iFullIndex); 
                return nRow;
            }
        });        
    };

    var initDialogs = function ()
    {
        $("#divAllPrograms").dialog(
        {
            autoOpen: false,
            bgiframe: true,
            height: 460,
            width: 600,
            resizable: false,
            draggable: false,
            modal: true
        });

        $("#divCampusPrograms").dialog(
        {
            autoOpen: false,
            bgiframe: true,
            height: 460,
            width: 600,
            resizable: false,
            draggable: false,
            modal: true
        });

        // Set actions for dialogs        
        $hlShowAllPrograms.bind("click", function (e)
        {
            e.preventDefault();
            // Reset table display to first page
            var oSettings = oAllProgramsTable.fnSettings();
            oSettings.iDisplayStart = 0;
            oAllProgramsTable.fnDraw();
            $dialogAllPrograms.dialog("open");
        });

        $hlShowCampusPrograms.bind("click", function (e) { $dialogCampusPrograms.dialog("open"); e.preventDefault(); });
    };

    var initAutocomplete = function (dataSet)
    {        
        $("#tbProgram").flushCache();
        $("#tbProgram").autocomplete(dataSet,
        {
            minChars: 1,
            formatItem: autocompleteFormatItem,
            formatResult: autocompleteFormatResult
        }).result(autocompleteResult);
    };

    var autocompleteResult = function (event, item)
    {       
        //console.log(item);
        $hProgram.val(item.ProgramCode);
        $hProgramName.val(item.ProgramDescr);
        
        // Filter campus list to just ones for this program
        loadCampuses(item.Campuses);

    };

    var autocompleteFormatItem = function (row, pos, totalItems, searchTerm)
    {
        //console.log(row);
        if (jQuery.isArray(row)) {
            return row[0]; // 'No Records'
        } else
        {
            return row.ProgramDescr;
        }
    };

    var autocompleteFormatResult = function (row, pos, totalItems) {
        
        return row.ProgramDescr;
    };

    var autoSelectCampus = function(campusCode) {
        //console.log("Auto select campus:" + campusCode);
        $campusDdlb.val(campusCode);
        $campusDdlb.trigger("change");
    };

    var autoFillProgram = function(programCode) {
        
        //console.log("auto fill program: " + programCode);

        var prog = getProgramByCode(programCode);
        if (prog !== undefined && prog !== null)
        {
            $hProgram.val(prog.ProgramCode);
            $hProgramName.val(prog.ProgramDescr);

            // Filter campus list to just ones for this program
            loadCampuses(prog.Campuses);
            $("#tbProgram").val(prog.ProgramDescr);
        }

    };

    var autoFillDelivery = function(v)
    {
        $("[id$=ddlbProgramDelivery]").val(v);
    };

    var autoFillYear = function(v)
    {
        $("[id$=ddlbProgramYear]").val(v);
    };

    var resetSearchCriteria = function()
    {
        $hCampus.val("");
        $hCampusName.val("");
        $hProgram.val("");
        $hProgramName.val("");        
        $("[id$=ddlbProgramDelivery]").val("");
        $("[id$=ddlbProgramYear]").val("");
    };

    var init = function ()
    {
        // Cache some freq. used selectors
        $hCampus = $(elemHCampus);
        $hCampusName = $(elemHCampusName);
        $hProgram = $(elemHProgram);
        $hProgramName = $(elemHProgramName);
        $campusDdlb = $(elemCampusDdlb);

        $dialogAllPrograms = $(elemDialogAllPrograms);
        $dialogCampusPrograms = $(elemDialogCampusPrograms);
        $hlShowAllPrograms = $(elemShowAllProgramsLink);
        $hlShowCampusPrograms = $(elemShowCampusProgramsLink);
        $spanDivide = $(elemSpanDivider);

        // Make sure all fields are initialized to original values in case of back button
        resetSearchCriteria();
        


        if (jsonCampuses !== null) {
            //console.log("All Campuses array found with [" + jsonCampuses.length + "] entries");
            loadCampuses(jsonCampuses);
            
            for (var i = 0; i < jsonCampuses.length; i++) {
                var campus = jsonCampuses[i];
                arrAllCampuses.push(campus);
            }
        }

        if (jsonPrograms !== null)
        {
            //console.log("All Programs array found with [" + jsonPrograms.length + "] entries");
            loadPrograms();
        }

        $campusDdlb.bind("change", loadProgramsForCampus);

        initAutocomplete(arrAllPrograms);
        initDialogs();
        initDataTables();     

        $dialogCampusPrograms.find("a").live("click", function (e)
        //$("#divCampusPrograms a").live("click", function (e)
        {
            $dialogCampusPrograms.dialog("close");

            if (this.id != "btnCampusProgramsCancel")
            {
                var desc = htmlDecode(this.innerHTML);

                $("#tbProgram").val(desc);
                //$("#tbProgram").val(this.innerHTML);
                //console.log($(this).attr("href"));

                var pieces = $(this).attr("href").split("/");
                var pId;
                if (pieces.length == 1) { pId = pieces[0]; }
                else { pId = pieces[pieces.length - 1]; }

                //console.log(pId);
                $hProgram.val(pId);
                $hProgramName.val(desc);
                loadCampuses(getCampusesForProgram(pId));
            }

            e.preventDefault();
        });

        // Clear hidden field if program texbox is cleared
        $("#tbProgram").bind("blur", function (e)
        {
            if ($(this).val() === "") { $hProgram.val(""); $hProgramName.val(""); loadCampuses(arrAllCampuses); }
        });

        //console.log("NsccAwardSearch Inited");
    };

    var pub =
	{
	    init: init,
	    autoSelectCampus: autoSelectCampus,
	    autoFillProgram: autoFillProgram,
        autoFillDelivery: autoFillDelivery,
        autoFillYear: autoFillYear
	};

    return pub;

}(jQuery, document));

$(document).ready(function () { NsccAwardSearch.init(); });