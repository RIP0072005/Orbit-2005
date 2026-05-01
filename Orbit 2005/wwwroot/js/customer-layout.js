document.addEventListener("DOMContentLoaded", function () {
    // Logic to highlight the active link in the customer navbar
    const currentPath = window.location.pathname.split('/').pop() || 'index.html';
    const navLinks = document.querySelectorAll(".navbar-nav .nav-link");

    navLinks.forEach(link => {
        // Remove active class from all links first
        link.classList.remove("active");

        // Add active class if the href matches the current file name
        const href = link.getAttribute("href");
        if (href === currentPath) {
            link.classList.add("active");
        }
    });

    // Simple scroll effect for navbar
    window.addEventListener('scroll', function () {
        const navbar = document.querySelector('.cosmic-navbar');
        if (window.scrollY > 50) {
            navbar.style.boxShadow = '0 4px 20px rgba(0, 0, 0, 0.5)';
        } else {
            navbar.style.boxShadow = 'none';
        }
    });

    console.log("Orbit 2005 Customer Layout loaded successfully.");
});