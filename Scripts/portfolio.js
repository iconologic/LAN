var vm = {
    projectRow: ko.observableArray([]),
    projects: ko.observableArray([]),
    marketSelected: ko.observable(false),
    subMarkets: ko.observableArray([])
}

$(function () {
    ko.applyBindings(vm);
    $('.filter').change(function () {
        filterProjects();
    });

    $('#projectMarket').change(function () {
        fillSubMarkets();
    });

    if (selectedMarket) {
        $('#projectMarket').val(selectedMarket);
        fillSubMarkets(selectedSubMarket == '');
    }
    if (selectedSubMarket) {
        $('#projectSubMarket').val(selectedSubMarket);
    }
    if (selectedService) {
        $('#relatedServices').val(selectedService);
    }
    filterProjects();
});

function fillSubMarkets(async) {
    if (typeof async == 'undefined')
        async = true;
    var market = $('#projectMarket').val();
    var isMarketSelected = market != '';
    vm.marketSelected(isMarketSelected);
    if (isMarketSelected) {
        $.ajax({
            dataType: "json",
            url: '/umbraco/api/submarket/Get',
            data: {
                marketId: market
            },
            success: function (data) {
                vm.subMarkets(data);
            },
            async: async
        });
    } else {
        vm.subMarkets([]);
    }
}

function filterProjects() {
    
    $.ajax({
        dataType: "json",
        url: '/umbraco/api/portfolio/Get',
        data: {
            type: $('#projectType').val(),
            market: $('#projectMarket').val(),
            subMarket: $('#projectSubMarket').val(),
            service: $('#relatedServices').val()
        },
        success: function (data) {
            $.each(data, function(i, item) {
                item.isSecond = ((i+1) % 2 == 0);
                item.isThird = ((i+1) % 3 == 0);
            });
            vm.projects(data);
        }
    });
}
