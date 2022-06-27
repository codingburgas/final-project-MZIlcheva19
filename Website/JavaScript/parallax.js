
let forest = document.getElementById("image");
window.addEventListener('scroll', function() {
    var value = window.scrollY;
    forest.style.top = value * 0.5 + 'px';
    heading.style.top = value * 0.6 + 'px';

}) 