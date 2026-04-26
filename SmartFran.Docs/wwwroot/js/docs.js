window.sfDocs = {
    copyToClipboard: async (text) => {
        try {
            await navigator.clipboard.writeText(text);
        } catch {
            // fallback para navegadores sin Clipboard API
            const ta = document.createElement('textarea');
            ta.value = text;
            ta.style.position = 'fixed';
            ta.style.opacity = '0';
            document.body.appendChild(ta);
            ta.focus();
            ta.select();
            document.execCommand('copy');
            document.body.removeChild(ta);
        }
    },
    highlightAll: () => {
        if (window.Prism) {
            Prism.highlightAll();
        }
    }
};
