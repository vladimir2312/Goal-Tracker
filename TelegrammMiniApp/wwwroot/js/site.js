document.addEventListener("DOMContentLoaded", () => {
    // === ИНИЦИАЛИЗАЦИЯ TELEGRAM WEBAPP ===
    if (window.Telegram && window.Telegram.WebApp) {
        const tg = window.Telegram.WebApp;

        // 1. Сообщаем Телеграму, что приложение готово
        tg.ready();

        // 2. Раскрываем приложение на весь экран
        tg.expand();

        // 3. Подхватываем цветовую схему Телеграма
        const isDark = tg.colorScheme === 'dark';
        if (isDark) {
            document.body.classList.add('tg-dark');
        } else {
            document.body.classList.add('tg-light');
        }

        // 4. Настройка нативной кнопки "Назад"
        const currentPath = window.location.pathname;
        if (currentPath !== '/Goals' && currentPath !== '/') {
            tg.BackButton.show();
            tg.BackButton.onClick(() => {
                window.location.href = '/Goals';
            });
        } else {
            tg.BackButton.hide();
        }

        // 5. Цвета шапки Телеграма
        tg.setHeaderColor('#0f0f11');
        tg.setBackgroundColor('#0f0f11');
    }

    // === ТВОЙ СУЩЕСТВУЮЩИЙ КОД ДЛЯ МЕНЮ ===
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