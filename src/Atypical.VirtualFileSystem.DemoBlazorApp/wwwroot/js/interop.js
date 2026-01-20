// CloudDrive JavaScript Interop

window.cloudDrive = {
    // Context menu
    contextMenu: {
        show: function (x, y, menuId) {
            const menu = document.getElementById(menuId);
            if (menu) {
                menu.style.left = x + 'px';
                menu.style.top = y + 'px';
                menu.classList.remove('hidden');
            }
        },
        hide: function (menuId) {
            const menu = document.getElementById(menuId);
            if (menu) {
                menu.classList.add('hidden');
            }
        },
        hideAll: function () {
            document.querySelectorAll('.context-menu').forEach(menu => {
                menu.classList.add('hidden');
            });
        }
    },

    // Modal/Dialog
    modal: {
        trapFocus: function (modalId) {
            const modal = document.getElementById(modalId);
            if (!modal) return;

            const focusableElements = modal.querySelectorAll(
                'button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])'
            );
            const firstElement = focusableElements[0];
            const lastElement = focusableElements[focusableElements.length - 1];

            modal.addEventListener('keydown', function (e) {
                if (e.key === 'Tab') {
                    if (e.shiftKey) {
                        if (document.activeElement === firstElement) {
                            lastElement.focus();
                            e.preventDefault();
                        }
                    } else {
                        if (document.activeElement === lastElement) {
                            firstElement.focus();
                            e.preventDefault();
                        }
                    }
                }
            });

            // Focus the first element
            if (firstElement) {
                firstElement.focus();
            }
        }
    },

    // Clipboard
    clipboard: {
        writeText: async function (text) {
            try {
                await navigator.clipboard.writeText(text);
                return true;
            } catch {
                return false;
            }
        },
        readText: async function () {
            try {
                return await navigator.clipboard.readText();
            } catch {
                return null;
            }
        }
    },

    // File download (simulated)
    download: {
        text: function (filename, content) {
            const blob = new Blob([content], { type: 'text/plain' });
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = filename;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
            document.body.removeChild(a);
        }
    },

    // Focus management
    focus: {
        setFocus: function (elementId) {
            const element = document.getElementById(elementId);
            if (element) {
                element.focus();
            }
        },
        selectAll: function (elementId) {
            const element = document.getElementById(elementId);
            if (element && element.select) {
                element.select();
            }
        }
    },

    // Keyboard navigation helper
    keyboard: {
        handleGridNavigation: function (containerId, dotNetRef) {
            const container = document.getElementById(containerId);
            if (!container) return;

            container.addEventListener('keydown', function (e) {
                const items = container.querySelectorAll('[data-file-item]');
                const currentIndex = Array.from(items).findIndex(item => item === document.activeElement);

                let newIndex = currentIndex;
                const columns = Math.floor(container.offsetWidth / 180); // Approximate item width

                switch (e.key) {
                    case 'ArrowRight':
                        newIndex = Math.min(currentIndex + 1, items.length - 1);
                        e.preventDefault();
                        break;
                    case 'ArrowLeft':
                        newIndex = Math.max(currentIndex - 1, 0);
                        e.preventDefault();
                        break;
                    case 'ArrowDown':
                        newIndex = Math.min(currentIndex + columns, items.length - 1);
                        e.preventDefault();
                        break;
                    case 'ArrowUp':
                        newIndex = Math.max(currentIndex - columns, 0);
                        e.preventDefault();
                        break;
                    case 'Enter':
                        if (currentIndex >= 0) {
                            const path = items[currentIndex].getAttribute('data-path');
                            if (path) {
                                dotNetRef.invokeMethodAsync('OnItemActivated', path);
                            }
                        }
                        e.preventDefault();
                        break;
                    case 'Escape':
                        dotNetRef.invokeMethodAsync('OnEscapePressed');
                        e.preventDefault();
                        break;
                }

                if (newIndex !== currentIndex && items[newIndex]) {
                    items[newIndex].focus();
                    const path = items[newIndex].getAttribute('data-path');
                    if (path) {
                        dotNetRef.invokeMethodAsync('OnItemFocused', path);
                    }
                }
            });
        }
    }
};

// Global click handler to close context menus
document.addEventListener('click', function (e) {
    if (!e.target.closest('.context-menu')) {
        window.cloudDrive.contextMenu.hideAll();
    }
});

// Global keydown handler for Escape
document.addEventListener('keydown', function (e) {
    if (e.key === 'Escape') {
        window.cloudDrive.contextMenu.hideAll();
    }
});
