document.getElementById('mode-selector').addEventListener('click', toggle);
var isDarkModeOn = false;
const elements = [
    document.getElementsByTagName('h1')[0],
    document.getElementsByTagName('button')[0],
    document.getElementsByTagName('footer')[0],
    document.getElementsByTagName('body')[0]
];

function toggle(){

    changeText();
    isDarkModeOn = !isDarkModeOn

    elements.forEach(element => {
        element.classList.toggle('dark-mode');
    });
}

function changeText(){
    if(isDarkModeOn){
        elements[0].innerText = 'Dark Mode On';
        elements[1].innerText = 'Light Mode';
        return;
    }

    elements[0].innerText = 'Light Mode On';
    elements[1].innerText = 'Dark Mode';
}