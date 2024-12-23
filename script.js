let items = document.querySelectorAll('.slider .list .item');
let next = document.getElementById('next');
let prev = document.getElementById('prev');
let thumbnails = document .querySelectorAll('.thumbnail .item');

let countItem = items.length;
let itemActive = 0;
next.onclick = function(){
    itemActive = itemActive + 1;
    if(itemActive >= countItem){
        itemActive = 0;
    }
    showSlider();
}
prev.onclick = function(){
    itemActive = itemActive -1;
    if(itemActive < 0){
        itemActive = countItem -1;
    }
    showSlider();
}

let refreshInterval = setInterval(() => {
    next.click();
}, 10000)

function showSlider(){
    let itemActiveOld = document.querySelector('.slider .list .item.active');
    let thumbnailActiveOld = document.querySelector('.thumbnail .item.active');
    itemActiveOld.classList.remove('active');
    thumbnailActiveOld.classList.remove('active');
    items[itemActive].classList.add('active');
    thumbnails[itemActive].classList.add('active');

    clearInterval(refreshInterval);
    refreshInterval = setInterval(()=>{
        next.click();
    }, 20000)
}
document.addEventListener("scroll", () => {
    const sections = document.querySelectorAll(".section");
    const triggerBottom = window.innerHeight * 0.8; // Trigger when 80% of the element is visible

    sections.forEach((section) => {
        const sectionTop = section.getBoundingClientRect().top;
        if (sectionTop < triggerBottom) {
            section.classList.add("active");
        } else {
            section.classList.remove("active");
        }
    });
});