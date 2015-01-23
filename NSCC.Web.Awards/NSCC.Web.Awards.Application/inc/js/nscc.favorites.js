var favorites = {

    config:
	{
	    trackActions: true,
	    gaEventCategory: "Favorites",
        addButton: "#btnAddFav",
        removeButtonSel: "#tblFavoriteList td.favRemove input",
	    domain: "http://webstaging.nscc.ca/",
	    titletext: "Nova Scotia Community College - ",
	    cookieNameTitle: "QuickListTitle",
	    cookieNameURL: "QuickListURL",
	    cookieNameUpdated: "QuickListUpdated",
	    timeToKeep: 31536000000, // 1 year
	    maxListItems: 25,
	    cookieDomain: "nscc.ca",
	    fullMessage: "Your Favorites are full! Please delete an entry before adding another!",
	    emptyMessage: "Are you sure you want to empty your Favorites?",
	    removeButtonText: "Remove Me",
	    container: $("#QuickList"),
        link1: $("#QuickListref"),
        link1Text: "{0}", // {0} is replaced with 'number of items in favorites'
        link2: $("#QuickListref2"),
        link2Text: "{0}", // {0} is replaced with 'number of items in favorites'
        useOldGA: true       
	},

    init: function (config)
    {
        if (config && typeof (config) == "object")
        {
            $.extend(favorites.config, config);
        }

        // create and/or cache some DOM elements we'll want to use throughout the code
        favorites.$container = favorites.config.container;
        favorites.$link1 = favorites.config.link1;
        favorites.$link2 = favorites.config.link2;

        // make a note that the initialization is complete; we don't strictly need this, but it can come in handy
        favorites.initialized = true;

        $(favorites.config.addButton).bind("click", function(e)
        {
            favorites.addToWishList();
            e.preventDefault();
        });


        $(favorites.config.removeButtonSel).each(function(idx)
        {
            $(this).bind("click", function(e)
            {
                favorites.removeMe(idx);
                e.preventDefault();
            });
        });

    },

    addToWishList: function ()
    {
        
        var expires = new Date();
        expires.setTime(expires.getTime() + favorites.config.timeToKeep);
        // Record the updated time stamp

        // Get the arrays
        var myarraytitle = new Array();
        var myarrayurl = new Array();

        favorites.getArray(favorites.config.cookieNameTitle, myarraytitle);
        favorites.getArray(favorites.config.cookieNameURL, myarrayurl);


        var num = favorites.nextEntry(myarraytitle);
        if (num > favorites.config.maxListItems)
        {
            alert(favorites.config.fullMessage);
        }
        else
        {
            if (!(favorites.checkLinkExists(myarrayurl, favorites.getRelativeUrl(document.URL))))
            {
                myarraytitle[num - 1] = document.title.substring(favorites.config.titletext.length);
                myarrayurl[num - 1] = favorites.getRelativeUrl(document.URL);
                favorites.setArray(favorites.config.cookieNameTitle, myarraytitle, expires);
                favorites.setArray(favorites.config.cookieNameURL, myarrayurl, expires);
                favorites.favoritesButtonText();

                if (favorites.config.trackActions) { favorites.trackAction("Add Favorite"); }
            }
        }
        
    },

    favoritesButtonText: function ()
    {
        var myarraytitle = new Array();
        favorites.getArray(favorites.config.cookieNameTitle, myarraytitle);

        favorites.$link1.html(favorites.config.link1Text.replace("{0}", myarraytitle.length));
        favorites.$link2.html(favorites.config.link2Text.replace("{0}", myarraytitle.length));
    },

    readQuickList: function ()
    {
        var myarraytitle = new Array();
        var myarrayurl = new Array();

        favorites.getArray(favorites.config.cookieNameTitle, myarraytitle);
        favorites.getArray(favorites.config.cookieNameURL, myarrayurl);

        var div_value = 'No Links';
        if (myarraytitle.length > 0)
        {
            div_value = '<table cellspacing="0" cellpadding="0" width="100%" style="border:none">'
            for (var i = 0; i < myarraytitle.length; i++)
            {
                div_value += '<tr><td width="80%"><a href=' + favorites.getRootUrl() + myarrayurl[i] + '>' + myarraytitle[i]
					+ '<\/a><\/td><td><input id="btn' + i + '" type="button" value="' + favorites.config.removeButtonText + '" onclick="favorites.removeMe(' + i + ');" /><\/td><\/tr>';
            }
            div_value += '<\/table>';
        }

        favorites.$container.html(div_value);
    },

    checkLinkExists: function (myarrayurl, value)
    {
        for (var i = 0; i < myarrayurl.length; i++)
        {
            if (value == myarrayurl[i])
            {
                return true;
            }
        }
        return false;
    },

    emptyQuickList: function ()
    {
        if (confirm(favorites.config.emptyMessage))
        {
            $.cookies.del(favorites.config.cookieNameTitle, { domain: favorites.config.cookieDomain });
            $.cookies.del(favorites.config.cookieNameURL, { domain: favorites.config.cookieDomain });

            location.reload(true);
        }
    },

    removeMe: function (value)
    {
        var expires = new Date();
        expires.setTime(expires.getTime() + favorites.config.timeToKeep);

        var myarraytitle = new Array();
        var myarrayurl = new Array();

        favorites.delEntry(favorites.config.cookieNameTitle, myarraytitle, value, expires);
        favorites.delEntry(favorites.config.cookieNameURL, myarrayurl, value, expires);

        if (favorites.config.trackActions) { favorites.trackAction("Remove Favorite"); }

        setTimeout(function() { location.reload(true) }, 500);
    },

    getArray: function (name, ary)
    {
        var ent = $.cookies.get(name);
        if (ent)
        {
            var i = 0;
            while (ent.indexOf('^') != '-1')
            {
                ary[i] = ent.substring(0, ent.indexOf('^'));
                i++;
                ent = ent.substring(ent.indexOf('^') + 1, ent.length);
            }
        }
    },

    setArray: function (name, ary, expires)
    {
        var value = '';
        for (var i = 0; i < ary.length; i++)
        {
            value += ary[i] + '^';
        }
        $.cookies.set(name, value, { expiresAt: expires, domain: favorites.config.cookieDomain });

        var currentdate = new Date();
        $.cookies.set(favorites.config.cookieNameUpdated, currentdate.toDateString(), { expiresAt: expires, domain: favorites.config.cookieDomain });
    },

    delEntry: function (name, ary, pos, expires)
    {
        favorites.getArray(name, ary);
        ary.splice(pos, 1);
        favorites.setArray(name, ary, expires);
    },

    nextEntry: function (ary)
    {
        return ary.length + 1;
    },

    getRelativeUrl: function (url)
    {
        var re = new RegExp("(http://[\\w.-]+(\/))(.+)");
        var m = re.exec(url);
        if (m != null)
        {
            return url.substring(m[1].length);
        }

        return url;
    },

    getRootUrl: function ()
    {
        var re = new RegExp("(http://[\\w.-]+(\/))(.+)");
        var m = re.exec(document.URL);
        if (m != null)
        {
            return m[1];
        }

        return "";
    },

    trackAction: function(action)
    {

        if(favorites.config.useOldGA)
        {
            pageTracker._trackEvent(favorites.config.gaEventCategory, action);
        }
        else
        {
            var failedCommands = _gaq.push(['_trackEvent', favorites.config.gaEventCategory, action]);
            //console.log(failedCommands);
        }
    }
};

$(document).ready(function () 
{ 
    favorites.init(); favorites.favoritesButtonText(); 

    // Also setup email this page link bind (this is temporary)
    $("#hlEmailThisPage").bind("click", function (e)
    {
        $.cookies.set("EmailThisPageTitle", document.title);
        $.cookies.set("EmailThisPageUrl", document.URL);
    });
});
