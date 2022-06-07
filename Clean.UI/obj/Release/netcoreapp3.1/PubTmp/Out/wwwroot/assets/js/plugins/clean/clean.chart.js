var clean = window.clean = window.clean || {};
(function () {
    clean.chart = function (opt) {
        this.opt = opt = opt || {};
        this.el = opt.el;
        this.data = opt.data;
        this.legend = opt.legend;
        this.date = opt.date;

        this.init();
    };
    clean.chart.prototype = {
        init: function () {
            var self = this;
            self.construct();


        },
        construct: function () {
            var self = this;
            self.configure();
            self.el.find('.chart-container').each(function (i, item) {
                var chartitem = $(item).find('.chart');
                require([
                    'echarts',
                    'echarts/theme/limitless',
                    'echarts/chart/bar',
                    'echarts/chart/line',
                    'echarts/chart/pie',
                    'echarts/chart/funnel'],
                    function (ec, config) {
                        var chart = self.buildChart(chartitem, ec, config)
                    });
            });
        },
        buildChart: function (el, ec, config) {
            var self = this;
            var elm = $(el);
            var type = elm.attr('chart-type');

            var options = {};
            switch (type) {
                case 'Chart_PIE':
                    options = self.Chart_PIE(self);
                    break;
                case 'Chart_ROSE':
                    options = self.Chart_ROSE(self);
                    break;
                case 'Chart_COLUMNS':
                    options = self.Chart_COLUMNS(self);
                    break;
                case 'Chart_ASC':
                    options = self.Chart_ASC(self);
                    break;
                case 'Chart_DESC':
                    options = self.Chart_DESC(self);
                    break;
                case 'Chart_BAR':
                    options = self.Chart_BAR(self);
                    break;
                case 'Chart_COLUMNS_Plus':
                    options = self.Chart_COLUMNS_Plus(self);
                    break;
                case 'Chart_BAR_Plus':
                    options = self.Chart_BAR_Plus(self);
                    break;
            }
            var chart = ec.init(document.getElementById(elm.attr('id')), config);
            chart.setOption(options);
        },

        Chart_ROSE: function (self) {
            return {
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                // Enable drag recalculate
                calculable: true,
                // Add series
                series: [
                    {
                        name: 'Increase (brutto)',
                        type: 'pie',
                        radius: ['15%', '73%'],
                        center: ['50%', '57%'],
                        roseType: 'area',

                        // Funnel
                        width: '40%',
                        height: '78%',
                        x: '30%',
                        y: '17.5%',
                        max: 450,
                        sort: 'ascending',

                        data: self.data
                    }
                ]
            };
        },
        Chart_PIE: function (self) {
            return {
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                // Enable drag recalculate
                calculable: true,
                // Add series
                series: [{
                    name: 'Browsers',
                    type: 'pie',
                    radius: '70%',
                    center: ['50%', '57.5%'],
                    data: self.data
                }]
            };
        },
        Chart_COLUMNS: function (self) {
            return {
                // Setup grid
                grid: self.Chart_grid(),
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                // Enable drag recalculate
                calculable: true,
                // Horizontal axis
                xAxis: [{
                    type: 'category',
                    data: [""]
                }],
                // Vertical axis
                yAxis: [{
                    type: 'value',
                }],
                // Add series
                series: getSeries()
            };
            function getSeries() {
                var getSeries = [];
                for (var i = 0; i < self.data.length; i++) {
                    getSeries.push({
                        name: self.legend[i],
                        type: 'bar',
                        data: [self.data[i].value],
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    textStyle: {
                                        fontWeight: 500
                                    }
                                }
                            }
                        },
                        markLine: {
                            data: [{ type: 'average', name: 'Average' }]
                        }

                    });
                }
                return getSeries;
            };
        },
        Chart_DESC: function (self) {
            return {
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                // Enable drag recalculate
                calculable: true,
                // Add series
                series: [
                    {
                        name: 'Statistics',
                        type: 'funnel',
                        x: '25%',
                        x2: '25%',
                        y: '17.5%',
                        height: '80%',
                        itemStyle: {
                            normal: {
                                label: {
                                    position: 'left'
                                }
                            }
                        },
                        data: self.data
                    }
                ]
            };
        },
        Chart_ASC: function (self) {
            return {
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                // Enable drag recalculate
                calculable: true,
                // Add series
                series: [
                    {
                        name: 'Statistics',
                        type: 'funnel',
                        x: '25%',
                        x2: '25%',
                        y: '17.5%',
                        height: '80%',
                        sort: 'ascending',
                        itemStyle: {
                            normal: {
                                label: {
                                    position: 'left'
                                }
                            }
                        },
                        data: self.data
                    }
                ]
            };
        },
        Chart_BAR: function (self) {
            return {
                // Setup grid
                grid: self.Chart_grid(),
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                calculable: true,
                // Horizontal axis
                xAxis: [{
                    type: 'value',
                    boundaryGap: [0, 0.01]
                }],
                // Vertical axis
                yAxis: [{
                    type: 'category',
                    data: [""]
                }],
                // Add series
                series: getSeries()
            };
            function getSeries() {
                var getSeries = [];
                for (var i = 0; i < self.data.length; i++) {
                    getSeries.push({
                        name: self.legend[i],
                        type: 'bar',
                        data: [self.data[i].value],
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    textStyle: {
                                        fontWeight: 500
                                    }
                                }
                            }
                        },
                        markLine: {
                            data: [{ type: 'average', name: 'Average' }]
                        }

                    });
                }
                return getSeries;
            };
        },
        Chart_BAR_Plus: function (self) {
            return {
                // Setup grid
                grid: self.Chart_grid(),
                // Add Title 
                title: self.Chart_title(),
                // Add legend 
                legend: self.Chart_legend(self),
                // Display toolbox
                toolbox: self.Chart_toolbox(),
                // Add tooltip
                tooltip: self.Chart_tooltip(),
                calculable: true,
                // Horizontal axis
                xAxis: [{
                    type: 'value',
                    boundaryGap: [0, 0.01]
                }],
                // Vertical axis
                yAxis: [{
                    type: 'category',
                    data: [""]
                }],
                // Add series
                series: getSeries()
            };
            function getSeries() {
                var getSeries = [];
                for (var i = 0; i < self.data.length; i++) {
                    getSeries.push({
                        name: self.legend[i],
                        type: 'bar',
                        data: [self.data[i].value]
                    });
                }
                return getSeries;
            };
        },
        Chart_COLUMNS_Plus: function (self) {
            return {

                // Setup grid
                grid: {
                    x: 40,
                    x2: 40,
                    y: 35,
                    y2: 25
                },

                // Add tooltip
                tooltip: {
                    trigger: 'axis'
                },

                // Add legend
                legend: {
                    data: ['Evaporation', 'Precipitation']
                },

                // Enable drag recalculate
                calculable: true,

                // Horizontal axis
                xAxis: [{
                    type: 'category',
                    data: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                }],

                // Vertical axis
                yAxis: [{
                    type: 'value'
                }],

                // Add series
                series: [
                    {
                        name: 'Evaporation',
                        type: 'bar',
                        data: [2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3],
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    textStyle: {
                                        fontWeight: 500
                                    }
                                }
                            }
                        },
                        markLine: {
                            data: [{ type: 'average', name: 'Average' }]
                        }
                    },
                    {
                        name: 'Precipitation',
                        type: 'bar',
                        data: [2.6, 5.9, 58.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0],
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    textStyle: {
                                        fontWeight: 500
                                    }
                                }
                            }
                        },
                        markLine: {
                            data: [{ type: 'average', name: 'Average' }]
                        }
                    }
                ]
            };
            function getSeries() {
                var getSeries = [];
                for (var i = 0; i < self.data.length; i++) {
                    getSeries.push({
                        name: self.legend[i],
                        type: 'bar',
                        data: [self.data[i].value],
                        itemStyle: {
                            normal: {
                                label: {
                                    show: true,
                                    textStyle: {
                                        fontWeight: 500
                                    }
                                }
                            }
                        },
                        markLine: {
                            data: [{ type: 'average', name: 'Average' }]
                        }
                    });
                }
                return getSeries;
            };

        },

        Chart_title: function () {
            return {
                text: 'گراف احصائیوی',
                subtext: '',
                x: 'center'
            };
        },
        Chart_legend: function (self) {
            return {
                x: 'left',
                y: 75,
                orient: 'vertical',
                data: self.legend
            };
        },
        Chart_toolbox: function () {
            return {
                show: true,
                feature: {
                    saveAsImage: {
                        show: true,
                        title: 'Same as image',
                        lang: ['Save']
                    }
                }
            };
        },
        Chart_tooltip: function () {
            return {
                trigger: 'item',
                formatter: "{b}: {c} "
            };
        },
        Chart_grid: function () {
            return {
                x: 100,
                x2: 100,
                y: 45,
                y2: 45,
                containLabel: true
            };
        },

        configure: function (opt) {
            var self = this;
            require.config({
                paths: {
                    echarts: '/assets/js/plugins/visualization/echarts'
                }
            });
            window.onresize = function () {
                setTimeout(function () {
                    $.each(self.charts, function (i, item) {
                        item.resize();
                    });
                }, 200);
            };

        },

    };
}
)();