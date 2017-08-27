var sortingAndPagination;

function createTable(options) {

    //VARIABLES
    var tableId = "#Table";
    var controller = "";
    var action = "GridFilter";
    var cardView = { ApplyCardView: false, IsCardView: false, WidthPerApply: 800 };
    sortingAndPagination = { StartPage: "1", EndPage: "10", SortBy: "Id", Sort: "ASC" };
    var filters = [];
    var clickToSelect = false;
    var columns = [];
    var buttons = { OperateEvents: {} };

    //OPTIONS
    if (options.TableId) tableId = options.TableId;
    if (options.Controller) controller = options.Controller;
    if (options.Action) action = options.Action;
    if (options.Filters) filters = options.Filters;

    //CHECKBOX
    if (options.ClickToSelect) {
        clickToSelect = options.ClickToSelect;
    }

    //COLUMNS
    if (options.Columns) {
        $(options.Columns).each(function (index, column) {
            addColumnByObject(column[0], column[1], column[2]);
        });
    }

    //BUTTONS
    if (options.Buttons) {
        var widthButtons = 45;

        $(options.Buttons).each(function (index, buttton) {
            widthButtons = SumValues(widthButtons, 30);
        });

        columns.push({
            field: 'Buttons',
            title: 'Operaciones',
            align: 'center',
            valign: 'middle',
            width: widthButtons,
            clickToSelect: false,
            formatter: function (value, row) {
                var formatter = "<div class='buttonsColumn' style='min-width:" + widthButtons + "px'>";
                $(options.Buttons).each(function (index, buttton) {
                    var newButton = buttton(buttons, row);
                    formatter += newButton;
                });
                formatter += "</div>";
                return formatter;
            },
            events: window.operateEvents = buttons.OperateEvents
        });
    }

    //CARDVIEW
    if (options.CardView) {
        if (options.CardView.ApplyCardView) cardView.ApplyCardView = options.CardView.ApplyCardView;
        if (options.CardView.WidthPerApply) cardView.WidthPerApply = options.CardView.WidthPerApply;
    }

    //QUERY
    if (options.SortingAndPagination) {
        if (options.SortingAndPagination.StartPage) sortingAndPagination.StartPage = options.SortingAndPagination.StartPage;
        if (options.SortingAndPagination.EndPage) sortingAndPagination.EndPage = options.SortingAndPagination.EndPage;
        if (options.SortingAndPagination.SortBy) sortingAndPagination.SortBy = options.SortingAndPagination.SortBy;
        if (options.SortingAndPagination.Sort) sortingAndPagination.Sort = options.SortingAndPagination.Sort;
    }

    //INSTANCE
    $("#" + controller).find(tableId).bootstrapTable({
        method: 'Get',
        url: root + controller + "/" + action,
        classes: "withoutBorder table table-hover",
        showColumns: false,
        showExport: false,
        cardView: cardView.ApplyCardView && $(window).width() < cardView.WidthPerApply,
        checkboxEnable: true,
        checkboxHeader: true,
        showToggle: false,
        cache: false,
        striped: true,
        exportTypes: ['excel'],
        clickToSelect: clickToSelect,
        pagination: true,
        pageSize: 10,
        pageList: [10, 25, 50, 100, 200],
        iconSize: "sm",
        sidePagination: "server",
        minimumCountColumns: 2,
        //rowStyle: function (row) {
        //    if (clickToSelect) {
        //        if (row.IsReference) {
        //            return { classes: 'inactive' };
        //        } else {
        //            return { classes: 'active' };
        //        }
        //    }
        //    return { classes: '' };
        //},
        queryParams: function (params) {

            $(options.ChangeColumnSortBy).each(function (index, changeColumnSortBy) {
                if (changeColumnSortBy[0] == params.sort) {
                    params.sort = changeColumnSortBy[1];
                }
            });

            var realParams = {
                ItemsToShow: params.limit,
                Page: dividerValues(params.limit + params.offset, params.limit),
                Sort: sortingAndPagination.Sort != "" ? sortingAndPagination.Sort : params.order != undefined ? params.order.toUpperCase() : "ASC",
                SortBy: params.sort != undefined ? params.sort : sortingAndPagination.SortBy != "" ? sortingAndPagination.SortBy : "Id"
            };

            sortingAndPagination.Sort = realParams.Sort;
            sortingAndPagination.SortBy = realParams.SortBy;

            $(filters).each(function (index, filter) {
                realParams[filter] = $("#" + controller).find("#" + filter).val();
            });

            return realParams;
        },
        responseHandler: function (response) {
            checkResponseToAjax(response);
            if (response.Result == resultType.Ok) {
                $("#" + controller).find(tableId).parent().parent().show();
                //actionToResizaWindow();
                //clearOpacity();
                return { rows: response.Records, total: response.Count };
            }
            $("#" + controller).find(tableId + "Loading").html("<i class='fa fa-warning'></i> " + response.Message + "...</span> ");
            checkResponseToAjax(response);
            //clearOpacity();
            return null;
        },
        columns: columns
    }).on('load-success.bs.table', function () {
        eventToLoadSuccessTable();
    }).on('check.bs.table uncheck.bs.table uncheck-all.bs.table load-error.bs.table', function () {

    }).on('check-all.bs.table', function () {

    }).on('sort.bs.table', function (input, name, order) {
        sortingAndPagination.Sort = order;
    });

    eventToClickFilter();

    //FILTER
    function eventToClickFilter() {
        $("#" + controller).find(".btnFilter").click(function () {
            $("#" + controller).find("#Table").bootstrapTable('refresh');
        });

        $(filters).each(function (index, filter) {
            $("#" + controller).find("#" + filter).keyup(function (e) {
                if (e.keyCode == 13)
                    $("#" + controller).find(".btnFilter").trigger("click");
                if (isInValidFilter($(this).val())) {
                    var str = $(this).val();
                    var newstr = str.replace(regExprToFilter, '');
                    $(this).val(newstr);
                    return false;
                }
                return true;
            });
        });
    }

    function addColumnByObject(field, title, isSortable) {
        columns.push({
            field: field,
            title: title,
            align: 'left',
            sortable: isSortable,
            valign: 'middle',
            formatter: function (value, row) {
                
                $(options.ChangeColumnValues).each(function (index, changeColumnValue) {
                    if (changeColumnValue[0] == field) {
                        value = changeColumnValue[1](value, row);
                    }
                });

                return value;
            }
        });
    }

    function eventToLoadSuccessTable() {
        $("#" + controller).find(tableId + "Loading").hide();
        //if (cardView.ApplyCardView && $(window).width() < cardView.WidthPerApply)
        //    aplyStyleToCardView();
        //eventToClickToPageList();
        //addToolTips();
        //addTouchSpin();
        //pageListHover();
    }
}