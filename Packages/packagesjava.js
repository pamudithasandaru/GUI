

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
// const words = [
//   '5%',
//   '10%',
//   '15%',
//   '20%',
//   '25%',
// ];

// let counter = 1;

// let interal1 = setInterval
// (
//   () => {
//   if (counter >= words.length) {
//     counter = 0;
//   }
  
//   const nextWord = words[counter];
  
//   document.startViewTransition(() => {
//     document.querySelector('.word').innerText = nextWord;
//   });

//   counter ++;
// }, 1500
// )

// Get elements
// Get all buttons with the class 'bookNowButton'
const bookNowButtons = document.querySelectorAll('.bookNowButton');
const bookingModal = document.getElementById('bookingModal');
const closeModal = document.getElementsByClassName('close')[0];
const bookingForm = document.getElementById('bookingForm');

// Add event listeners to each 'Book Now' button
bookNowButtons.forEach((button) => {
  button.addEventListener('click', function () {
    bookingModal.style.display = 'block';
  });
});

// Close the modal
closeModal.onclick = function () {
  bookingModal.style.display = 'none';
};

// Close the modal when clicking outside the modal content
window.onclick = function (event) {
  if (event.target == bookingModal) {
    bookingModal.style.display = 'none';
  }
};

// Handle form submission
bookingForm.onsubmit = function (e) {
  e.preventDefault();
  const name = document.getElementById('customerName').value;
  const nicNumber = document.getElementById('nicNumber').value;
  const time = document.getElementById('selectTime').value;
  const beautician = document.getElementById('selectBeautician').value;
  const date = document.getElementById('datePicker').value;
  const package = document.getElementById('selectPackage').value;

  console.log(`Booking Details:\nName: ${name}\nNIC: ${nicNumber}\nTime: ${time}\nBeautician: ${beautician}\nDate: ${date}\nPackage: ${package}`);
  bookingModal.style.display = 'none'; // Close modal after submission
};
