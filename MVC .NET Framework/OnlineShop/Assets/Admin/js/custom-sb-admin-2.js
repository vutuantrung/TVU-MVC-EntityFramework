function getRandomLoginImage(from, to) {
    // Get image by random number
    const randomNumber = Math.floor(Math.random() * (to - from) + from);
    const imgSource = `../assets/admin/img/logImages/loginImg_${randomNumber}.jpg`;

    // Set image background
    var div = document.getElementById("loginImage");
    div.style.backgroundImage = `url(${imgSource})`;
};