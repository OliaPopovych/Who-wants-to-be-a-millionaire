function preventBack() { window.history.forward(); }
window.onloadstart = preventBack();