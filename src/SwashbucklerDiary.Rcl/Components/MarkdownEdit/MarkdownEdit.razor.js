import { fixMobileOutlientClick } from '../../js/markdown/fixMarkdownOutline.js'

function after(dotNetCallbackRef, element, outlineElement, copyCutPatch) {
    handleToolbar(dotNetCallbackRef, element);
    fixMobileOutlientClick(dotNetCallbackRef, outlineElement, element);
    if (copyCutPatch) {
        fixCopyCut(dotNetCallbackRef, element);
    }
}

function focus(domRef) {
    if (!domRef || !domRef.Vditor) return;
    try {
        const vditor = domRef.Vditor.vditor;
        const currentMode = vditor ? vditor.currentMode : null;
        let range = currentMode && vditor[currentMode] ? vditor[currentMode].range : null;
        const selection = window.getSelection();

        if (range) {
            selection.removeAllRanges();
            selection.addRange(range);
        } else {
            // 当 range 为空时，尝试寻找编辑区末尾建立安全选区，避免 Vditor.insertValue 中 getRangeAt(0) 越界
            const editArea = domRef.querySelector('.vditor-reset') || domRef.querySelector('[contenteditable="true"]') || domRef;
            if (editArea) {
                const newRange = document.createRange();
                newRange.selectNodeContents(editArea);
                newRange.collapse(false);
                selection.removeAllRanges();
                selection.addRange(newRange);
                if (vditor && currentMode && vditor[currentMode]) {
                    vditor[currentMode].range = newRange;
                }
            }
        }
        domRef.Vditor.focus();
    } catch (e) {
        console.error("MarkdownEdit focus error:", e);
    }
}

function focusToEnd(domRef) {
    domRef.Vditor.focus();
    const focusElement = document.activeElement;
    let range = document.createRange();
    range.selectNodeContents(focusElement);
    range.collapse(false);
    let sel = window.getSelection();
    sel.removeAllRanges();
    sel.addRange(range);
}

function upload(element, inputFileElement) {
    if (!element || !inputFileElement) return;
    const uploadElement = element.querySelector('input[type=file]');
    inputFileElement.files = uploadElement.files;
    inputFileElement.dispatchEvent(new CustomEvent('change'));
}

function getTooltipInfos(domRef) {
    const infos = [];
    const isHoverSupported = window.matchMedia('(hover: hover)').matches;
    if (isHoverSupported) {
        const toolbar = domRef.querySelector(".vditor-toolbar");
        const tooltippedItems = toolbar.querySelectorAll('.vditor-tooltipped');
        tooltippedItems.forEach(el => {
            if (el.offsetParent === null) return; // Skip hidden elements
            const activator = getSelectorWithDynamicId(el);
            const text = el.getAttribute('aria-label');
            infos.push({ activator, text });
        })
    }

    return infos;

    function getSelectorWithDynamicId(el) {
        if (el.id) return `#${el.id}`;

        const newId = `id-${Date.now()}-${Math.random().toString(36).slice(2, 7)}`;
        el.id = newId;
        return `#${newId}`;
    }
}

function handleToolbar(dotNetCallbackRef, domRef) {
    if (!domRef) {
        return;
    }
    //点击Vditor工具栏，输入框不失去焦点
    const toolbar = domRef.querySelector(".vditor-toolbar");
    if (!toolbar) {
        console.log("Vditor toolbar does not exist");
        return;
    }
    //prevent Input Lose Focus
    toolbar.onmousedown = (e) => {
        if (e.target.closest(".vditor-toolbar__item.keep-focus")) return;
        e.preventDefault();
    };

    const toolbarContent = document.createElement("div");
    toolbarContent.classList.add('vditor-toolbar-content');
    insertMiddleElement(toolbar, toolbarContent);
    const items = toolbarContent.querySelectorAll('.vditor-toolbar__item');
    const visibleItems = Array.from(items).filter(item => getComputedStyle(item).display !== 'none');
    if (visibleItems.length > 0) {
        const itemWidth = parseInt(getComputedStyle(visibleItems[0]).width);
        const vditorToolbarWidth = itemWidth * Math.round(visibleItems.length / 2) + 'px';
        toolbarContent.style.setProperty('--vditor-toolbar-width', vditorToolbarWidth);
    }

    const btnTable = toolbar.querySelector('button[data-type=table]');
    if (btnTable) {
        btnTable.addEventListener("click", () => {
            dotNetCallbackRef.invokeMethodAsync("OpenAddTableDialog");
        })
    }
}

function insertMiddleElement(parent, destination) {
    while (parent.firstChild) {
        destination.appendChild(parent.firstChild);
    }
    parent.appendChild(destination);
}

function setMoblieOutline(element, outlineElement) {
    if (!element || !outlineElement) {
        return;
    }

    var outline = element.querySelector(".vditor-outline__content");
    if (!outline) {
        console.log("Vditor outline does not exist");
        return;
    }

    outlineElement.innerHTML = outline.innerHTML;
}

function fixCopyCut(dotNetCallbackRef, element) {
    const items = element.querySelectorAll('.vditor-reset');
    const copy = (event) => {
        event.preventDefault();

        const textData = event.clipboardData.getData('text/plain');
        if (textData) {
            setTimeout(() => {
                dotNetCallbackRef.invokeMethodAsync("SetClipboard", textData);
            }, 200);
        }
    };
    items.forEach(item => {
        item.addEventListener('copy', copy);
        item.addEventListener('cut', copy);
    });
}

export { after, focus, focusToEnd, upload, setMoblieOutline, getTooltipInfos }
