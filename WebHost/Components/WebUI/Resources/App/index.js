requirejs.config({
    baseUrl: "/Components/WebUI/Resources",
    paths:
    {
        jquery: "/Components/WebUI/Resources/vendor/js/jquery-3.2.1.js"
        //bootstrap: "/Components/WebUI/Resources/vendor/js/bootstrap.min"
        }
    //shim:
    //    {
    //        bootstrap: ["jquery"]
    //    }
});

require(["/Components/WebUI/Resources/App/testModule.js"],
    function(module, $) {
        $("body").append(module.foo);
        alert("Loaded!");
    }
);