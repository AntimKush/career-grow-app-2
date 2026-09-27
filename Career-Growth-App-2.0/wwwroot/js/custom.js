// custom.js - support for multi-level Bootstrap 5 dropdowns
document.addEventListener('DOMContentLoaded', function () {
    // Handle clicks on nested dropdown toggles
    document.querySelectorAll('.dropdown-submenu .dropdown-toggle').forEach(function (toggle) {
        toggle.addEventListener('click', function (e) {
            e.preventDefault();
            e.stopPropagation();
            var submenu = toggle.nextElementSibling;
            if (!submenu) return;

            var isShown = submenu.classList.contains('show');
            // close other open submenus at the same level
            var parentMenu = toggle.closest('.dropdown-menu');
            if (parentMenu) {
                parentMenu.querySelectorAll('.dropdown-menu.show').forEach(function (sm) {
                    if (sm !== submenu) sm.classList.remove('show');
                });
            }

            if (!isShown) {
                submenu.classList.add('show');
                toggle.setAttribute('aria-expanded', 'true');
            } else {
                submenu.classList.remove('show');
                toggle.setAttribute('aria-expanded', 'false');
            }
        });
    });

    // When a top-level dropdown hides, ensure nested menus are closed
    document.querySelectorAll('.dropdown').forEach(function (dd) {
        dd.addEventListener('hidden.bs.dropdown', function () {
            dd.querySelectorAll('.dropdown-menu.show').forEach(function (sm) { sm.classList.remove('show'); });
            dd.querySelectorAll('.dropdown-toggle[aria-expanded="true"]').forEach(function (t) { t.setAttribute('aria-expanded', 'false'); });
        });
    });

    // Animated counters for dashboard
    function animateCounter(el, target) {
        var duration = 1200;
        var start = 0;
        var startTime = null;

        function step(timestamp) {
            if (!startTime) startTime = timestamp;
            var progress = Math.min((timestamp - startTime) / duration, 1);
            var value = Math.floor(progress * (target - start) + start);
            el.textContent = value.toLocaleString();
            if (progress < 1) {
                window.requestAnimationFrame(step);
            }
        }
        window.requestAnimationFrame(step);
    }

    document.querySelectorAll('.counter').forEach(function (el) {
        var target = parseInt(el.getAttribute('data-target')) || parseInt(el.textContent) || 0;
        el.textContent = '0';
        // delay a bit to allow layout
        setTimeout(function () { animateCounter(el, target); }, 300);
    });

    // Dropdown fade animation for navbar menus
    document.querySelectorAll('.dropdown-fade .dropdown').forEach(function (dd) {
        dd.addEventListener('show.bs.dropdown', function (e) {
            var menu = dd.querySelector('.dropdown-menu');
            if (menu) {
                menu.classList.add('fade-in');
            }
        });
        dd.addEventListener('hide.bs.dropdown', function (e) {
            var menu = dd.querySelector('.dropdown-menu');
            if (menu) {
                menu.classList.remove('fade-in');
            }
        });
    });

    // Sidebar toggle: remember state in localStorage
    var sidebarToggle = document.getElementById('sidebarToggle');
    if (sidebarToggle) {
        var body = document.body;
        var collapsed = localStorage.getItem('sidebar-collapsed') === '1';
        if (collapsed) body.classList.add('sidebar-collapsed');

        sidebarToggle.addEventListener('click', function () {
            body.classList.toggle('sidebar-collapsed');
            localStorage.setItem('sidebar-collapsed', body.classList.contains('sidebar-collapsed') ? '1' : '0');
        });
    }
});
