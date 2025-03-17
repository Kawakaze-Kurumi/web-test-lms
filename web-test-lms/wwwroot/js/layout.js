const toggleDropdown = (dropdown, menu, isOpen) => {
    dropdown.classList.toggle("open", isOpen);
    menu.style.height = isOpen ? `${menu.scrollHeight}px` : 0;
}

const closeAllDropdowns = () => {
    document.querySelectorAll(".dropdown-container.open").forEach(openDropdown => {
        toggleDropdown(openDropdown, openDropdown.querySelector(".dropdown-menu"), false);
    });
}

document.querySelectorAll(".dropdown-toggle").forEach(dropdownToggle => {
    dropdownToggle.addEventListener("click", e => {
        e.preventDefault();

        const dropdown = e.target.closest(".dropdown-container");
        const menu = dropdown.querySelector(".dropdown-menu");
        const isOpen = dropdown.classList.contains("open");

        closeAllDropdowns();

        toggleDropdown(dropdown, menu, !isOpen);
    });
});


document.querySelector(".sidebar-toggler").addEventListener("click", () => {

    closeAllDropdowns();

    document.querySelector(".sidebar").classList.toggle("collapsed");
    document.querySelector(".main").classList.toggle("expanded");
});

