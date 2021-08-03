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

function getWidth() {
	return Math.max(
		document.body.scrollWidth,
		document.documentElement.scrollWidth,
		document.body.offsetWidth,
		document.documentElement.offsetWidth,
		document.documentElement.clientWidth
	);
}
