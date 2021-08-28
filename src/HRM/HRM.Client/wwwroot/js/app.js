
function showHideMenu() {
    if (getWidth() >= 768) {
        if ($('body').hasClass('sidebar-collapse')) {
            $('body').attr('class', 'sidebar-mini pace-done sidebar-open');
        } else {
            $('body').attr('class', 'sidebar-mini pace-done sidebar-open sidebar-collapse');
        }
    } else {
        if ($('body').hasClass('sidebar-open')) {
            $('body').attr('class', 'sidebar-mini pace-done');
        } else {
            $('body').attr('class', 'sidebar-mini pace-done sidebar-open');
        }
    }
}

function initilizeInactivityTimer(dotNetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 30*60*1000);
    }

    function logout() {
        dotNetHelper.invokeMethodAsync('Logout');
    }

}

function getWidth() {
    return Math.max(
        document.body.scrollWidth,
        document.documentElement.scrollWidth,
        document.body.offsetWidth,
        document.documentElement.offsetWidth,
        document.documentElement.clientWidth
    );
}

function expandSidebar(id, level) {

    

    switch (level) {
        case 1:
            resetExpandSidebar();
            $(`#${id}`).addClass('active');
            break;
        case 2:
            $(`#${id}`).addClass('active');
            break;
        case 3:
            break;
        case 4:
            break;
    }

}

function resetExpandSidebar() {
    $('ul.sidebar-menu > li.active').each(function (idx, item) {
        $(item).removeClass('active');
    });

    $('ul.sidebar-menu ul.treeview-menu > li.active').each(function (idx, item) {
        $(item).removeClass('active');
    });
}

