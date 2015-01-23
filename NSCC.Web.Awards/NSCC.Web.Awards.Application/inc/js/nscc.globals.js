var testvar = "breen";
var strWaterfrontCode = "WATER";
//var INFOSESSION_CAMPUSES = new Array("WATER", "MARCO", "KINGS");
var INFOSESSION_CAMPUSES = new Array();

var WS_URL = "/WebService/NsccService.asmx";


Array.prototype.contains = function (element)
{
    for (var i = 0; i < this.length; i++)
    {
        if (this[i] == element)
        {
            return true;
        }
    }
}

String.prototype.trim = function()
{
    return this.replace(/^\s+|\s+$/g, "");
}
String.prototype.ltrim = function()
{
    return this.replace(/^\s+/, "");
}
String.prototype.rtrim = function()
{
    return this.replace(/\s+$/, "");
}

String.prototype.endsWith = function(suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
};


function htmlEncode(value)
{
    return $('<div/>').text(value).html();
}

function htmlDecode(value)
{
    return $('<div/>').html(value).text();
}

function parseMicrosoftDate(value)
{
    var a;
    if (typeof value === "string")
    {
        if (value.indexOf("Date") >= 0)
        {
            a = /^\/Date\((-?[0-9]+)\)\/$/.exec(value);
            if (a)
            {
                return new Date(parseInt(a[1], 10));
            }
        }
    }
}


var HashSearch = new function ()
{
    var params;

    this.set = function (key, value)
    {
        params[key] = value;
        this.push();
    };

    this.remove = function (key, value)
    {
        delete params[key];
        this.push();
    };


    this.get = function (key, value)
    {
        return params[key];
    };

    this.keyExists = function (key)
    {
        return params.hasOwnProperty(key);
    };

    this.push = function ()
    {
        var hashBuilder = [], key, value;

        for (key in params) if (params.hasOwnProperty(key))
        {
            key = escape(key), value = escape(params[key]); // escape(undefined) == "undefined"
            hashBuilder.push(key + ((value !== "undefined") ? '=' + value : ""));
        }

        window.location.hash = hashBuilder.join("&");
    };

    (this.load = function ()
    {
        params = {}
        var hashStr = window.location.hash, hashArray, keyVal
        hashStr = hashStr.substring(1, hashStr.length);
        hashArray = hashStr.split('&');

        for (var i = 0; i < hashArray.length; i++)
        {
            keyVal = hashArray[i].split('=');
            params[unescape(keyVal[0])] = (typeof keyVal[1] != "undefined") ? unescape(keyVal[1]) : keyVal[1];
        }
    })();
}
