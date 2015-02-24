
$(function () {
    var vm = {
        storiesByDate: ko.observableArray([]),
        featuredStories: ko.observableArray([]),
        filteredVisible: ko.observable(false)
    };
    vm.emptyResults =
    ko.pureComputed(function () {
        return vm.storiesByDate().length == 0 && vm.featuredStories().length == 0;
    });
    ko.applyBindings(vm);

    $('#filter-form select').change(function () {
        var $location = $('#location-select');
        var location = $location.val();
        var $market = $('#market-select');
        var market = $market.val();
        var $leader = $('#leader-select');
        var leader = $leader.val();
        if (location == '0' && market == '0' && leader == '0') {
            vm.filteredVisible(false);
            return;
        }
        vm.filteredVisible(true);
        var title = $('#filtered-title');
        var titleText = 'Filtered by ';
        var filters = new Array();
        if (location != '0')
            filters.push('<em>' + $location.find('option:selected').text() + '</em>');
        if (market != '0')
            filters.push('<em>' + $market.find('option:selected').text() + '</em>');
        if (leader != '0')
            filters.push('<em>' + $leader.find('option:selected').text() + '</em>');

        titleText += filters[0];
        if (filters.length == 2)
            titleText += " and " + filters[1];
        else if (filters.length > 2)
            titleText += ", " + filters[1] + ", and " + filters[2];


        title.html(titleText);
        $.ajax({
            dataType: "json",
            url: '/umbraco/api/story/Get',
            data: {
                location: location,
                market: market,
                leader: leader
            },
            success: function (data) {
                vm.featuredStories(data.featuredStories);
                vm.storiesByDate(data.storiesByDate);

            }
        });

    });
});