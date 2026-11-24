document.addEventListener("DOMContentLoaded", () => {
    const openBtn = document.getElementById("openMenuBtn");
    const closeBtn = document.getElementById("closeMenuBtn");
    const sideMenu = document.getElementById("sideMenu");
    const overlay = document.getElementById("menuOverlay");

    const toggleMenu = (show) => {
        if (show) {
            sideMenu.classList.add("active");
            overlay.classList.add("active");
        } else {
            sideMenu.classList.remove("active");
            overlay.classList.remove("active");
        }
    };

    if (openBtn) openBtn.addEventListener("click", () => toggleMenu(true));
    if (closeBtn) closeBtn.addEventListener("click", () => toggleMenu(false));
    if (overlay) overlay.addEventListener("click", () => toggleMenu(false));

    // Закрытие по Esc
    document.addEventListener("keydown", (e) => {
        if (e.key === "Escape") toggleMenu(false);
    });
});