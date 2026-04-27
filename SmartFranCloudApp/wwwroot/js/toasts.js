(function () {
    // Create the fixed stack container
    const stack = document.createElement('div');
    stack.id = 'sf-toast-stack';
    Object.assign(stack.style, {
        position: 'fixed', bottom: '2rem', right: '2rem',
        zIndex: '9999', display: 'flex', flexDirection: 'column-reverse',
        gap: '0.75rem', pointerEvents: 'none', width: '340px',
    });
    document.body.appendChild(stack);

    const style = document.createElement('style');
    style.textContent = `
        @keyframes sf-toast-in {
            from { opacity:0; transform:translateX(24px) scale(0.97); }
            to   { opacity:1; transform:translateX(0) scale(1); }
        }
        @keyframes sf-toast-out {
            from { opacity:1; transform:translateX(0) scale(1); max-height:120px; }
            to   { opacity:0; transform:translateX(24px) scale(0.96); max-height:0; }
        }
        .sf-toast {
            pointer-events: all;
            animation: sf-toast-in 0.28s cubic-bezier(0.34,1.4,0.64,1) both;
            border-radius: 1.25rem;
            overflow: hidden;
        }
        .sf-toast.leaving {
            animation: sf-toast-out 0.32s ease forwards;
        }
    `;
    document.head.appendChild(style);

    const TYPES = {
        venta: {
            icon: 'point_of_sale',
            title: 'Venta procesada',
            body: 'La venta fue registrada correctamente en el sistema.',
            accent: 'linear-gradient(135deg,#6e59ee 0%,#9080f5 100%)',
            duration: 4000,
        },
        ticket: {
            icon: 'receipt',
            title: 'Ticket impreso',
            body: 'El ticket de venta fue enviado a la impresora.',
            accent: 'linear-gradient(135deg,#006267 0%,#009da4 100%)',
            duration: 4500,
        },
        comprobante: {
            icon: 'mark_email_read',
            title: 'Comprobante electrónico',
            body: 'El comprobante fue generado y enviado al cliente.',
            accent: 'linear-gradient(135deg,#4b3e73 0%,#63568c 100%)',
            duration: 5000,
        },
    };

    function show(type) {
        const cfg = TYPES[type];
        if (!cfg) return;
        const D = cfg.duration;

        const el = document.createElement('div');
        el.className = 'sf-toast';
        el.style.cssText = [
            'background:rgba(253,247,255,0.96)',
            'backdrop-filter:blur(20px)',
            '-webkit-backdrop-filter:blur(20px)',
            'box-shadow:0 8px 40px rgba(11,9,53,0.13),0 2px 8px rgba(110,89,238,0.06)',
        ].join(';');

        el.innerHTML = `
            <div style="display:flex;align-items:stretch;overflow:hidden;border-radius:1.25rem;">
                <div style="width:12px;background:${cfg.accent};flex-shrink:0;border-radius:1.25rem 0 0 1.25rem;"></div>
                <div style="flex:1;display:flex;align-items:flex-start;gap:0.875rem;padding:1rem 1rem 1rem 0.875rem;">
                    <div style="width:2.5rem;height:2.5rem;border-radius:9999px;background:${cfg.accent};display:flex;align-items:center;justify-content:center;flex-shrink:0;margin-top:0.05rem;">
                        <span class="material-symbols-outlined" style="font-size:1.2rem;color:#ffffff;font-variation-settings:'FILL' 1;">${cfg.icon}</span>
                    </div>
                    <div style="flex:1;min-width:0;">
                        <p style="font-family:'Plus Jakarta Sans',sans-serif;font-weight:800;font-size:0.825rem;color:#19124a;margin:0 0 0.2rem;line-height:1.2;">${cfg.title}</p>
                        <p style="font-family:'Manrope',sans-serif;font-size:0.72rem;color:#4f4255;margin:0;line-height:1.5;font-weight:500;">${cfg.body}</p>
                    </div>
                    <button class="sf-toast-x" style="background:none;border:none;cursor:pointer;color:#817287;padding:0.1rem;margin-top:-0.1rem;flex-shrink:0;line-height:1;opacity:0.5;transition:opacity 0.15s;" onmouseenter="this.style.opacity=1" onmouseleave="this.style.opacity=0.5">
                        <span class="material-symbols-outlined" style="font-size:1rem;">close</span>
                    </button>
                </div>
            </div>
            <div style="height:2px;background:rgba(11,9,53,0.06);overflow:hidden;border-radius:0 0 1.25rem 1.25rem;">
                <div class="sf-toast-bar" style="height:100%;background:${cfg.accent};width:100%;transition:width ${D}ms linear;border-radius:inherit;"></div>
            </div>
        `;

        let timer;

        function dismiss() {
            clearTimeout(timer);
            el.classList.add('leaving');
            el.addEventListener('animationend', () => el.remove(), { once: true });
        }

        el.querySelector('.sf-toast-x').addEventListener('click', dismiss);
        stack.appendChild(el);

        requestAnimationFrame(() => requestAnimationFrame(() => {
            const bar = el.querySelector('.sf-toast-bar');
            if (bar) bar.style.width = '0%';
        }));

        timer = setTimeout(dismiss, D);

        el.addEventListener('mouseenter', () => {
            clearTimeout(timer);
            const bar = el.querySelector('.sf-toast-bar');
            if (bar) bar.style.transitionDuration = '0ms';
        });
        el.addEventListener('mouseleave', () => {
            const bar = el.querySelector('.sf-toast-bar');
            if (!bar) return;
            const remaining = (parseFloat(bar.style.width || '0') / 100) * D;
            bar.style.transitionDuration = remaining + 'ms';
            bar.style.width = '0%';
            timer = setTimeout(dismiss, remaining);
        });
    }

    window.sfToasts = { show };
})();
