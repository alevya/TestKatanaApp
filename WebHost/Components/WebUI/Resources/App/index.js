requirejs.config({
    baseUrl: '/',
    paths:
    {
        jquery: 'vendor/js/jquery-3.2.1',
        bootstrap: 'vendor/js/bootstrap.min'
        },
    shim:
        {
       
        }
});

require(['testModule'],
    function(module, $) {
        $('body').append(module.foo);
    }
);