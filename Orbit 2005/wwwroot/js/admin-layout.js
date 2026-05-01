document.addEventListener("DOMContentLoaded", function () {
    // Highlight the active link in the sidebar based on the current URL
    const currentPath = window.location.pathname;
    const sidebarLinks = document.querySelectorAll(".aside-sidebar a");

    sidebarLinks.forEach(link => {
        if (link.getAttribute("href") === currentPath) {
            link.style.backgroundColor = "var(--cosmic-accent)";
            link.style.color = "white";
        }
    });

    console.log("Cosmic Admin Layout loaded successfully.");
});

//aside actions
document.addEventListener("DOMContentLoaded", function () {
    // 1. Generalized Dropdown Logic
    const dropdownToggles = document.querySelectorAll(".dropdown-toggle");

    dropdownToggles.forEach(toggle => {
        toggle.addEventListener("click", function () {
            // this.nextElementSibling بيجيب الـ div اللي تحت اللينك على طول اللي هو الـ sub-menu
            const subMenu = this.nextElementSibling;
            const arrow = this.querySelector(".arrow");

            // بنبدل الكلاسات عشان نظهر القائمة ونلف السهم
            subMenu.classList.toggle("show-menu");
            arrow.classList.toggle("rotate-arrow");
        });
    });

    // 2. Active Link Logic (عشان يفضل منور على الصفحة اللي إنت فيها)
    const currentPath = window.location.pathname.split('/').pop() || 'dashboard.html';
    const sidebarLinks = document.querySelectorAll(".aside-sidebar a");

    sidebarLinks.forEach(link => {
        link.classList.remove("active");

        if (link.getAttribute("href") === currentPath) {
            link.classList.add("active");

            // لو اللينك ده جوة قائمة منسدلة، افتح القائمة دي تلقائي
            if (link.closest(".sub-menu")) {
                link.closest(".sub-menu").classList.add("show-menu");

                // ولف السهم بتاع القائمة دي
                const toggleArrow = link.closest(".menu-item").querySelector(".arrow");
                if (toggleArrow) {
                    toggleArrow.classList.add("rotate-arrow");
                }
            }
        }
    });

    console.log("Orbit 2005 Admin Layout loaded successfully with Dynamic Dropdowns.");
});